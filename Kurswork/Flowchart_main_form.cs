using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Kurswork
{
    [Serializable]
    public partial class Flowchart_main_form : Form
    {

        public Flowchart_main_form()
        {
            InitializeComponent();
        }
        public Flowchart_main_form(string text)
        {
            InitializeComponent();
            richTextBox_text_program.Text = text;
            get_methods();
        }

        public void SetSelectionStyle(int startIndex, int lastindex, FontStyle style, Color color)
        {

            richTextBox_text_program.Select(startIndex, lastindex - startIndex);
            richTextBox_text_program.SelectionFont = new Font(richTextBox_text_program.SelectionFont, richTextBox_text_program.SelectionFont.Style | style);
            richTextBox_text_program.SelectionColor = color;
        }

        private void ToolStripMenuItem_create_new_program_fail_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "cs fails(*.cs)|*.cs";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//Показать диалог
            {
                try
                {

                    panel_picture_flowchart_main.Controls.Clear();
                    string Filename = openFileDialog1.FileName;
                    string filetext = System.IO.File.ReadAllText(Filename);
                    richTextBox_text_program.Text = filetext;
                    //get_higher_level(1);
                    get_code_conversion();
                    get_methods();
                    richTextBox_text_program.Text = filetext;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void get_code_conversion()
        {
            Regex regex; MatchCollection matches;


            //преобразование switch
            regex = new Regex(@"\bswitch\s*\([^{}]*\)");
            matches = regex.Matches(richTextBox_text_program.Text);
            for (int i = matches.Count - 1; i >= 0; i--)
            {

                int first;
                int last = get_index_lvl_s(matches[i].Index, out first);
                //MessageBox.Show(richTextBox_text_program.Text.Substring(matches[i].Index));
                string term = richTextBox_text_program.Text.Substring(first + 1, last - first - 1);// запоминаем переменную

                int f_s;
                int l_s = get_index_lvl(last, out f_s);

                // удаляем cwitch с текста

                //MessageBox.Show(richTextBox_text_program.Text);

                Regex r_arg = new Regex(@"(\b\S*){1}:");
                Regex regex_case = new Regex(@"\bcase\s");

                MatchCollection matchCollection = regex_case.Matches(richTextBox_text_program.Text.Substring(f_s, l_s - f_s));// все case у этого switch


                MatchCollection arg = r_arg.Matches(richTextBox_text_program.Text.Substring(f_s + matchCollection[0].Index + matchCollection[0].Length));
                //MessageBox.Show();

                //MessageBox.Show(richTextBox_text_program.Text.Substring(f_s + match_default.Index));
                for (int j = matchCollection.Count - 1; j > 0; j--)
                {
                    //MessageBox.Show(richTextBox_text_program.Text.Substring(f_s + matchCollection[j].Index, arg[j].Index + matchCollection[0].Index + matchCollection[0].Length + arg[j].Length + 1 - matchCollection[j].Index));
                    richTextBox_text_program.Text = richTextBox_text_program.Text.Replace(richTextBox_text_program.Text.Substring(f_s + matchCollection[j].Index, arg[j].Index + matchCollection[0].Index + matchCollection[0].Length + matchCollection[j].Length + arg[j].Length + 1 - matchCollection[j].Index),
                         "}" + $" else if ({term}=={arg[j].Value.Substring(0, arg[j].Length - 2)}) " + "{");

                }
                //MessageBox.Show(richTextBox_text_program.Text.Substring(matchCollection[0].Index + f_s));
                richTextBox_text_program.Text = richTextBox_text_program.Text.Replace(richTextBox_text_program.Text.Substring(matches[i].Index, f_s + matchCollection[0].Index + 2 * matchCollection[0].Length + arg[0].Index + arg[0].Length - matches[i].Index + 1),
                    $"if ({term}=={arg[0].Value.Substring(0, arg[0].Length - 2)}) " + "{");


            }
            Regex regex_default = new Regex(@"\bdefault");
            Match match_default = regex_default.Match(richTextBox_text_program.Text);
            if (match_default.Success)
                richTextBox_text_program.Text = //richTextBox_text_program.Text.Substring(0, f_s + match_default.Index) + "} else { " + richTextBox_text_program.Text.Substring(f_s + match_default.Index + match_default.Length + 2);
                 richTextBox_text_program.Text.Replace(match_default.Value, "} else { ");//.Substring(first + match_default.Index)

            //MessageBox.Show(richTextBox_text_program.Text);


            //преобразование if где нет {}
            regex = new Regex(@"\bif\s*\([^{}]*\)");
            matches = regex.Matches(richTextBox_text_program.Text);
            for (int i = matches.Count - 1; i >= 0; i--)
            {
                Match match = matches[i];
                Regex regex_h = new Regex(@"\S");
                Match match_h = regex_h.Match(richTextBox_text_program.Text.Substring(match.Index + match.Length));
                if (match_h.Value != "{")
                {
                    richTextBox_text_program.Text = richTextBox_text_program.Text.Insert(match.Index + match.Length + 1, "{");
                    Regex r = new Regex(@";");
                    Match m = r.Match(richTextBox_text_program.Text.Substring(match.Index + match.Length));
                    richTextBox_text_program.Text = richTextBox_text_program.Text.Insert(match.Index + match.Length + m.Index + 1, "}");
                }
            }

            //MessageBox.Show(richTextBox_text_program.Text);
            //преобразование else if

            regex = new Regex(@"\belse\s*if\b");//вхождение else if
                                                //MatchCollection matches = regex.Matches(richTextBox_text_program.Text);

            matches = regex.Matches(richTextBox_text_program.Text);
            //MessageBox.Show(richTextBox_text_program.Text);
            for (int i = matches.Count - 1; i >= 0; i--)// обход с конца
            {
                Match match = matches[i];
                int f;
                int first_if = match.Index + 4;
                //MessageBox.Show(richTextBox_text_program.Text.Substring(first_if));
                int last_if = get_index_lvl(first_if, out f);

                Regex regex_else = new Regex(@"\b\S*\b");//первое вхождение else, если есть

                Match match_else = regex_else.Match(richTextBox_text_program.Text.Substring(last_if));

                if (match_else.Value == "else")
                {

                    last_if = get_index_lvl(last_if + 1, out f) + 1;
                }

                richTextBox_text_program.Text = richTextBox_text_program.Text.Insert(first_if, "{");
                richTextBox_text_program.Text = richTextBox_text_program.Text.Insert(last_if, "}");
                // get_code_conversion();

            }
            //MessageBox.Show(richTextBox_text_program.Text);
        }
        //находит индекс парной фигурной скобки
        public int get_index_lvl(int startindex, out int first)
        {

            int count = 0;
            Regex regex = new Regex(@"{|}");
            // Regex regex = new Regex(@"if\s*\([^{}]*\)\s*{[^{}]*}");
            MatchCollection matches = regex.Matches(richTextBox_text_program.Text.Substring(startindex));
            first = matches[0].Index + startindex;
            int last = startindex;
            foreach (Match match in matches)
            {
                //MessageBox.Show(match.Value);
                if (match.Value == "{") count++;

                else if (match.Value == "}")
                {
                    count--;
                    if (count == 0)
                    {
                        last = match.Index + startindex;
                        break;

                    }
                }
            }
            return last;
        }

        public int get_index_lvl_s(int startindex, out int first)
        {
            int count = 0;
            Regex regex = new Regex(@"\(|\)");
            // Regex regex = new Regex(@"if\s*\([^{}]*\)\s*{[^{}]*}");
            MatchCollection matches = regex.Matches(richTextBox_text_program.Text.Substring(startindex));
            first = matches[0].Index + startindex;

            int last;
            foreach (Match match in matches)
            {

                if (match.Value == "(") count++;

                else if (match.Value == ")")
                {
                    count--;
                    if (count == 0)
                    {
                        last = match.Index + startindex;
                        return last;
                    }
                }
            }
            return 0;
        }

        string block_json;
        public void get_methods()
        {
            int x = 0;
            int count = 0;
            int count_methhods = 0;

            Regex regex = new Regex(@"{|}");
            // Regex regex = new Regex(@"if\s*\([^{}]*\)\s*{[^{}]*}");
            MatchCollection matches = regex.Matches(richTextBox_text_program.Text);
            int first, last;
            if (matches.Count > 3) 
             first = matches[2].Index;
            else first = 0;
          
            foreach (Match match in matches)
            {
                if (match.Value == "{")
                {
                    count++;
                    if (count == 3)
                    {
                        first = match.Index;

                    }
                }
                else if (match.Value == "}")
                {
                    count--;
                    if (count == 2 && count_methhods<30)
                    {
                        last = match.Index;
                        SetSelectionStyle(first + 1, last, FontStyle.Bold, Color.Purple);

                        Panel panel_methode = new Panel();
                        panel_methode.Width = 1000;
                        panel_methode.Location = new Point(x, 0);
                        panel_methode.AutoScroll = false;
                        //MessageBox.Show(richTextBox_text_program.Text.Substring(first + 1, last - first - 1));
                        Block method = new Block(richTextBox_text_program.Text.Substring(first + 1, last - first - 1), this, 1, panel_methode, out panel_methode);

                        panel_picture_flowchart_main.Controls.Add(panel_methode);
                        panel_picture_flowchart_main.Invalidate();


                        x += 1010;
                        count_methhods++;

                    }else if (count == 2 )
                    {
                        
                        Flowchart_main_form newform = new Flowchart_main_form("{{"+richTextBox_text_program.Text.Substring(first));
                        newform.Show();
                        break;
                    }

                }
            }
            if (count_methhods == 0) 
            { 
                MessageBox.Show("Нет методов. \n Откройте файл заного.");
                richTextBox_text_program.Text = "";
                ToolStripMenuItem_save_into_BD.Visible = false; 
            }
            else
            ToolStripMenuItem_save_into_BD.Visible = true;
            //block_json = JsonSerializer.Serialize(panel_picture_flowchart_main.Controls);
            //MessageBox.Show(block_json.ToString());
        }
        public string code_name;
        private void ToolStripMenuItem_save_into_BD_Click(object sender, EventArgs e)
        {
            try
            {
                Form_save_name name = new Form_save_name(this);
                name.ShowDialog();
                using (ApplicationContext db = new ApplicationContext())
                {
                    FlowChart flowChart = new FlowChart
                    {
                        Name = code_name,
                        Jsonstring = richTextBox_text_program.Text
                    };
                    // добавляем их в бд
                    db.FlowChart.Add(flowChart);

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ToolStripMenuItem_open_Click(object sender, EventArgs e)
        {
            try
            {
                Form_open_flowchart form = new Form_open_flowchart(this);
                form.ShowDialog();
                panel_picture_flowchart_main.Controls.Clear();
                get_code_conversion();
                get_methods();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Block Block
        {
            get => default;
            set
            {
            }
        }

        public Form_save_name Form_save_name
        {
            get => default;
            set
            {
            }
        }

        internal Show_details Show_details
        {
            get => default;
            set
            {
            }
        }

        public Form_open_flowchart Form_open_flowchart
        {
            get => default;
            set
            {
            }
        }
    }
}
