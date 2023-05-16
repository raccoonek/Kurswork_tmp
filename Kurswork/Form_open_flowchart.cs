using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurswork
{
    public partial class Form_open_flowchart : Form
    {
        Flowchart_main_form Form;
        public Form_open_flowchart(Flowchart_main_form form)
        {
            InitializeComponent();
            Form = form;
            using (ApplicationContext db = new ApplicationContext())
            {
                var flowcharts = (from flowchart in db.FlowChart select flowchart).ToList();

                foreach (var flowchart in flowcharts)
                {
                    comboBox_names_code.Items.Add(flowchart.Name);
                }
            }
        }

        public ApplicationContext ApplicationContext
        {
            get => default;
            set
            {
            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            if (comboBox_names_code.Text != "")
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var flowcharts = (from flowchart in db.FlowChart where flowchart.Name == comboBox_names_code.Text select flowchart).ToList();

                    foreach (var flowchart in flowcharts)
                    {
                        Form.richTextBox_text_program.Text = flowchart.Jsonstring;
                    }
                    Close();
                }
            }
            else MessageBox.Show("Выберите название.");
        }
    }
}
