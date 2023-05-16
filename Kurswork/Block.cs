using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Kurswork
{
    [Serializable]
    public class Block
    {
        Panel panel;
        string code;
        public int whidth_block, height_block=0, gap_block;
        Flowchart_main_form Main;
        //Pen p;
        //Graphics graphics;
        //SolidBrush brush;
        int x, y;//текущее положение в координатах
        int lvl;
        public Block() { }
        public Block(string Code, Flowchart_main_form main,int lv, Panel pan, out Panel pan_well) {
            
            Main = main;
            code = Code;
            lvl = lv;
            panel = pan;
            whidth_block = panel.Width / 4;
            if(whidth_block<100) whidth_block=100;
            height_block = whidth_block / 2;
            x = pan.Width / 2; y = height_block/2;// начальные значения на любой панели
            gap_block = height_block +30/lvl;
            //ylast = y0;
            //MessageBox.Show(code);
            
            
            if(lvl%4 == 0)
            {
                pan_well = new Panel();
               //pan_well.AutoSize = true;
                pan_well.Width= panel.Width;
                pan_well.Height= panel.Width;
                pan_well.Location = panel.Location;
                pan_well.BackColor = Color.Gray;
                pan_well.BorderStyle = BorderStyle.FixedSingle;
                pan_well.AutoScroll = true;
                Label l = new Label();
                l.Text = code.Replace("    "," ");
                l.AutoSize = true;
                l.ForeColor = Color.White;
                l.Location = new Point(0, 0);
                //l.Dock = DockStyle.Fill;
                //while (l.Width < System.Windows.Forms.TextRenderer.MeasureText(l.Text,
                //    new Font(l.Font.FontFamily, l.Font.Size, l.Font.Style)).Width)
                //{
                //    l.Font = new Font(l.Font.FontFamily, l.Font.Size - 0.5f, l.Font.Style);
                //}
                pan_well.Controls.Add(l);
                
                l.Click += click_panel;
            }
            else
            {
                get_action(0);
                //panel.Height += 50;
                panel.Height = y + height_block / 2 + 30 / lvl;
                pan_well = panel;
                if (lvl % 3 == 0 || lvl % 3 == 2)
                    pan_well.Click += click_panel;
            }
           
        }
        //парсит блок по действиям
        int endindex;
        public void get_action(int startindex)
        {

            Regex regex = new Regex(@"(if)|(else)|(while)|(switch)|([^{};]*;)"); //
            // Regex regex = new Regex(@"if\s*\([^{}]*\)\s*{[^{}]*}");
            MatchCollection matches = regex.Matches(code.Substring(startindex));
            //MessageBox.Show(code.Substring(startindex));
            if (matches.Count != 0)
            {
                int y_if=0,x_if=0,y_for=0,height_if_block_true=0, width_if_block_true = 0, count_if=0;
                bool true_block=false,false_block=false, block_for=false;
                foreach (Match match in matches)
                {
                    if (match.Index >= endindex)
                    {
                        switch (match.Value)
                        {
                            case "if":
                                int first;
                                int last = get_index_lvl_s(match.Index, out first);//first, last индексы в code
                                string term = code.Substring(first+1, last - first-1);
                                //MessageBox.Show(term);
                                draw_if_block(term.Replace("    ", ""));
                                int startaction;
                                int endaction = get_index_lvl(last, out startaction);// индексы в code
                                string text_new_if_block_true = code.Substring(startaction + 1, endaction - startaction );//тк длина

                                Panel pan_if_true=new Panel();
                                pan_if_true.Width = panel.Width/ 2-25;
                                pan_if_true.Height = 0;
                                pan_if_true.AutoScroll = false;
                                pan_if_true.Location= new Point(5,y+ gap_block/2);
                                Block if_block_true = new Block(text_new_if_block_true, Main,lvl+1,pan_if_true, out Panel pan_well_low_if_true) ;
                                
                                panel.Controls.Add(pan_well_low_if_true);
                                panel.Invalidate();
                                get_arrow_horisont(new Point(2 + pan_well_low_if_true.Width / 2, y), new Point(x, y));
                                get_arrow_vert(new Point(2 + pan_well_low_if_true.Width / 2, y),new Point (2 + pan_well_low_if_true.Width / 2, y+ gap_block/2));

                                true_block = true;
                                y_if = y;
                                x_if = x;
                                height_if_block_true = pan_well_low_if_true.Height;
                                width_if_block_true = pan_well_low_if_true.Width;
                                endindex = endaction + startindex;

                                y += pan_well_low_if_true.Height  + gap_block/2;
                                //if (y < 3 * panel.Width)
                                //{
                               //panel.Height += pan_well_low_if_true.Height;
                               // panel.Height = y;
                                //}
                                y += gap_block;
                                break;
                            case "else":
                                int startaction_else;
                                int endaction_else = get_index_lvl(match.Index, out startaction_else);
                                string text_new_if_block_false = code.Substring(startaction_else + 1, endaction_else - startaction_else - 1);

                                Panel pan_if_false = new Panel();
                                pan_if_false.Width = panel.Width / 2-25;
                                pan_if_false.Height = 10;
                                pan_if_false.AutoScroll = false;
                                pan_if_false.Location = new Point(panel.Width/2+5, y_if + gap_block/2);
                                Block if_block_false = new Block(text_new_if_block_false, Main,lvl+1, pan_if_false, out Panel pan_well_low_if_false);
                                panel.Controls.Add(pan_well_low_if_false);
                                panel.Invalidate();


                                get_arrow_horisont(new Point(x_if, y_if), new Point(x_if+ 2 + pan_well_low_if_false.Width / 2, y_if));
                                get_arrow_vert(new Point(x_if+2 + pan_well_low_if_false.Width / 2, y_if), new Point(x_if+2 + pan_well_low_if_false.Width / 2, y_if  + gap_block/2));

                                false_block = true;
                                endindex = endaction_else + startindex;
                                //проверка какая ветвь блока if больше
                                if(height_if_block_true < pan_well_low_if_false.Height)
                                {
                                    
                                    y =y_if+ pan_well_low_if_false.Height+ gap_block/2;
                                    y += gap_block;
                                    //if (y < 3 * panel.Width)
                                    //{
                                    // panel.Height += (pan_well_low_if_false.Height - height_if_block_true);
                                    //}
                                }

                                get_arrow_vert(new Point(2 + width_if_block_true / 2, y_if + height_if_block_true +gap_block/2 ),//+ height_block/2 + gap_block
                                    new Point(2 + width_if_block_true / 2, y-gap_block+10));
                                get_arrow_vert(new Point(x_if + 2 + width_if_block_true / 2, y_if+ pan_well_low_if_false.Height+gap_block/2),
                                    new Point(x_if + 2 + width_if_block_true / 2, y - gap_block + 10));
                                get_arrow_horisont(new Point(2 + width_if_block_true / 2, y - gap_block + 10),
                                    new Point(x_if + 2 + width_if_block_true / 2, y - gap_block + 10));
                                get_arrow_vert(new Point(x - 3, y - gap_block + 10), new Point(x - 3, y - height_block / 2 + 3));
                                true_block = false;count_if = 0;
                                
                               // panel.Height = y;
                                break;

                            case "while":
                            f:
                                int first_for;
                                int last_for = get_index_lvl_s(match.Index, out first_for);//first, last индексы в code
                                string term_for = code.Substring(first_for + 1, last_for - first_for - 1);
                                if (block_for) 
                                {
                                    block_for = false;
                                    draw_for_block(term_for.Replace("    ", "")); 
                                }   
                                else draw_if_block(term_for.Replace("    ", ""));
                                get_arrow_vert(new Point(x - 3, y + height_block / 2 - 1), new Point(x - 3, y + gap_block/2));

                                int startaction_for;
                                int endaction_for = get_index_lvl(last_for, out startaction_for);// индексы в code
                                string text_new_for_block = code.Substring(startaction_for + 1, endaction_for - startaction_for );//тк длина

                                Panel pan_for = new Panel();
                                pan_for.Width = 3* panel.Width / 4;
                                pan_for.Height = 0;
                                pan_for.AutoScroll = false;
                                pan_for.Location = new Point(x-3* panel.Width / 8, y + gap_block / 2);
                                Block for_block = new Block(text_new_for_block, Main, lvl + 1, pan_for, out Panel pan_well_low_for);

                                y_for = y;
                                panel.Controls.Add(pan_well_low_for);
                                panel.Invalidate();
                                endindex = endaction_for + startindex;
                                y += gap_block / 2 + pan_well_low_for.Height;
                                //отрисовка линий
                                get_arrow_vert(new Point(x, y), new Point(x, y + 10));
                                get_arrow_horisont(new Point(x- 3 * panel.Width / 8-whidth_block/4, y+10), new Point(x, y + 10));
                                get_arrow_vert(new Point(x - 3 * panel.Width / 8 - whidth_block / 4, y_for), new Point(x - 3 * panel.Width / 8 - whidth_block / 4, y + 10));
                                get_arrow_horisont(new Point(x - 3 * panel.Width / 8 - whidth_block / 4, y_for), new Point(x-whidth_block/2, y_for));
                                get_arrow_horisont( new Point(x + whidth_block / 2, y_for), new Point(x + 3 * panel.Width / 8 + whidth_block / 4, y_for));
                                get_arrow_vert(new Point(x + 3 * panel.Width / 8 + whidth_block / 4, y_for), new Point(x + 3 * panel.Width / 8 + whidth_block / 4, y + 20));
                                get_arrow_horisont( new Point(x, y + 20), new Point(x + 3 * panel.Width / 8 + whidth_block / 4, y + 20));
                                get_arrow_vert(new Point(x, y+20), new Point(x, y +gap_block-height_block/2));
                                //y += gap_block - height_block / 2;
                                y += gap_block+lvl*2;
                                break;
                            //case "switch"://то же самое как и вовторение else if
                                
                            //    last = get_index_lvl_s(match.Index, out first);//first, last индексы в code
                            //    term = code.Substring(first+1, last - first-1);
                            //    //MessageBox.Show(term);
                            //    draw_Rectangle(term.Replace("    ", ""));

                            //    break;
                            default:
                                // проверка на цикл for
                                Regex r_for = new Regex(@"\bfor");
                                MatchCollection match_for = r_for.Matches(match.Value);
                                if (match_for.Count != 0) {block_for = true; goto f; }

                                endindex += match.Length;
                                draw_Rectangle(match.Value.Replace("    ", ""));
                                get_arrow_vert(new Point(x-3, y + height_block / 2-1), new Point(x-3, y + gap_block-height_block/2+3));
                                y += gap_block;
                                //panel.Height = y;
                                break;

                        }
                        if (true_block && false_block==false)
                        {
                            count_if++;
                            if (count_if == 2)
                            {
                                get_arrow_horisont(new Point(x_if,y_if),new Point(x_if + 2 + width_if_block_true / 2, y_if));
                                get_arrow_vert(new Point( 2 + width_if_block_true / 2, y_if+height_if_block_true + gap_block/2), 
                                    new Point(2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2+10));
                                get_arrow_vert(new Point(x_if + 2 + width_if_block_true / 2, y_if),
                                    new Point(x_if + 2 + width_if_block_true / 2, y_if + height_if_block_true  +gap_block/2+10));
                                get_arrow_horisont(new Point(2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2+10),
                                    new Point(x_if + 2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2+10 ));
                                get_arrow_vert(new Point(x - 3, y_if + height_if_block_true + gap_block / 2 + 10), new Point(x - 3, y_if + height_if_block_true + gap_block+10));
                                true_block = false; 
                                count_if = 0;
                            }
                        }else if (false_block)
                        {
                            false_block = false;
                        }
                    }
                }
                
                if (true_block )
                {
                    get_arrow_horisont(new Point(x_if, y_if), new Point(x_if + 2 + width_if_block_true / 2, y_if));
                    get_arrow_vert(new Point(2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2),
                            new Point(2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2+10 ));
                        get_arrow_vert(new Point(x_if + 2 + width_if_block_true / 2, y_if),
                            new Point(x_if + 2 + width_if_block_true / 2, y_if + height_if_block_true + gap_block/2 +10));
                        get_arrow_horisont(new Point(2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2+10),
                            new Point(x_if + 2 + width_if_block_true / 2, y_if + height_if_block_true  + gap_block/2+10 ));
                    get_arrow_vert(new Point(x - 3, y_if + height_if_block_true + gap_block / 2 + 10), new Point(x - 3, y + gap_block - height_block / 2 + 3));
                    true_block = false;
                        count_if = 0;
                    y = y_if + height_if_block_true + gap_block+gap_block/2+5 ;
                }

                y -= gap_block;
                //MessageBox.Show(matches[0].Value);

                // get_action(endindex);
            }
            
        }
        public void draw_Rectangle(string action)
        {
            //if (y < 2 * panel.Width)
                //panel.Height += height_block+gap_block;
            


            Button btn = new Button();
            btn.Tag = "блок";
            btn.Text = action;
            btn.Location = new Point(x - whidth_block / 2, y - height_block / 2);
            btn.Height = height_block;
            btn.Width = whidth_block;
            //размещаем на панели
            
                btn.Click += click_button;
            panel.Controls.Add(btn);

            panel.Invalidate();
        }
        public void draw_if_block(string action)
        {

            //if (y < 2 * panel.Width)
                //panel.Height += height_block+gap_block;
            
            Button btn = new Button();
            btn.Tag = "блок if";
            btn.Text =  action;
            btn.Location = new Point(x-whidth_block/2, y-height_block/2);
            btn.Height = height_block;
            btn.Width = whidth_block;
            btn.AutoEllipsis = true;

            // Set a new rectangle to the same size as the button's 
            // ClientRectangle property.
            
            
            System.Drawing.Drawing2D.GraphicsPath myPath =new System.Drawing.Drawing2D.GraphicsPath();
            Point[] points = {new Point(0,height_block/2), new Point( whidth_block/2, 0),
                new Point( whidth_block, height_block / 2), new Point( whidth_block/2, height_block) };
            
            myPath.AddPolygon(points);

            Region myRegion = new Region(myPath);
            btn.Region = myRegion;

            btn.Click += click_button;

            
            //размещаем на панели
            panel.Controls.Add(btn);

            panel.Invalidate();
        }

        private void click_button(object sender, EventArgs e)
        {
            //
            Show_details show_Details = new Show_details();
            Button btn = sender as Button;
            show_Details.label_type_block.Text = (string)btn.Tag;
            show_Details.label_context.Text = btn.Text;
            show_Details.Show();
            //throw new NotImplementedException();
        }

        public void draw_for_block(string action)
        {

            //if (y < 2 * panel.Width)
            //panel.Height += height_block+gap_block;

            Button btn = new Button();
            btn.Tag = "блок for";
            btn.Text =  action;
            btn.Location = new Point(x - whidth_block / 2, y - height_block / 2);
            btn.Height = height_block;
            btn.Width = whidth_block;
            btn.AutoEllipsis = true;

            // Set a new rectangle to the same size as the button's 
            // ClientRectangle property.
            

            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            Point[] points = {new Point(0,height_block/2), new Point( whidth_block/4, 0),new Point( whidth_block/2+whidth_block/4, 0),
                new Point( whidth_block, height_block / 2), new Point(  whidth_block/2+whidth_block/4, height_block), new Point( whidth_block/4, height_block) };

            myPath.AddPolygon(points);

            Region myRegion = new Region(myPath);
            btn.Region = myRegion;
            //Event_Args_button e = new Event_Args_button("блок for", action);

            btn.Click += click_button;

            //размещаем на панели
            panel.Controls.Add(btn);

            panel.Invalidate();
        }
        //находит индекс парной фигурной скобки
        public int get_index_lvl(int startindex, out int first)
        {
            int count = 0;
            Regex regex = new Regex(@"{|}");
            // Regex regex = new Regex(@"if\s*\([^{}]*\)\s*{[^{}]*}");
            MatchCollection matches = regex.Matches(code.Substring(startindex));
            first = matches[0].Index + startindex; int last=first;
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
        //находит индекс парной скобки
        public int get_index_lvl_s(int startindex, out int first)
        {
            int count = 0;
            Regex regex = new Regex(@"\(|\)");
            // Regex regex = new Regex(@"if\s*\([^{}]*\)\s*{[^{}]*}");
            MatchCollection matches = regex.Matches(code.Substring(startindex));
            first = matches[0].Index+startindex;
            
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
        
        void click_panel(object sender, EventArgs e)
        {
            Flowchart_main_form flowchart_Main_Form = new Flowchart_main_form();

            flowchart_Main_Form.richTextBox_text_program.Text= code;
            Block block_click_panel = new Block(flowchart_Main_Form.richTextBox_text_program.Text, flowchart_Main_Form, 1, flowchart_Main_Form.panel_picture_flowchart_main, out flowchart_Main_Form.panel_picture_flowchart_main);
            flowchart_Main_Form.Show();
        }
        
        private void get_arrow_vert(Point start,Point end)
        {
            Button btn_arrow = new Button();

            btn_arrow.Location = start;
            btn_arrow.Height = end.Y-start.Y;
            btn_arrow.Width = 3;
            btn_arrow.AutoEllipsis = true;

            panel.Controls.Add(btn_arrow);

            panel.Invalidate();
        }
        private void get_arrow_horisont(Point start,Point end)
        {
            Button btn_arrow = new Button();

            btn_arrow.Location = start;
            btn_arrow.Height = 3;
            btn_arrow.Width = end.X-start.X;
            btn_arrow.AutoEllipsis = true;

            panel.Controls.Add(btn_arrow);

            panel.Invalidate();
        }

        public Block Block1
        {
            get => default;
            set
            {
            }
        }
    }

    public class Event_Args_button : EventArgs
    {
        string type_Block;
        string arg_Block;
        public Event_Args_button(string type, string action)
        {
            type_Block = type;
            arg_Block = action;
        }
    }
}
