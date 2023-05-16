using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class Form_save_name : Form
    {
        Flowchart_main_form flowchart_main_Form;
        public Form_save_name(Flowchart_main_form flowchart_Main_Form)
        {
            InitializeComponent();
            flowchart_main_Form = flowchart_Main_Form;
        }

        public ApplicationContext ApplicationContext
        {
            get => default;
            set
            {
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_name_code.Text != "")
            {
                bool name_ok=true;
                using (ApplicationContext db = new ApplicationContext())
                {
                    var flowcharts =  (from flowchart in db.FlowChart select flowchart).ToList();

                    foreach (var flowchart in flowcharts)
                    {
                        if (textBox_name_code.Text== flowchart.Name)
                        {
                            MessageBox.Show("Такое название уже существует.\nВведите название заново.");
                            textBox_name_code.Text = ""; 
                            name_ok= false;
                            break;
                        }
                    }
                }
                if (name_ok)
                {
                    flowchart_main_Form.code_name = textBox_name_code.Text;
                    Close();
                }
            }
            else MessageBox.Show("Введите название.");
            
        }
    }
}
