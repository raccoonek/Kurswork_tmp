namespace Kurswork
{
    partial class Flowchart_main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ToolStripMenuItem_fail = new ToolStripMenuItem();
            ToolStripMenuItem_create_new_program_fail = new ToolStripMenuItem();
            ToolStripMenuItem_save_into_BD = new ToolStripMenuItem();
            ToolStripMenuItem_open = new ToolStripMenuItem();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel_picture_flowchart_main = new Panel();
            panel3 = new Panel();
            richTextBox_text_program = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_fail });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(838, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_fail
            // 
            ToolStripMenuItem_fail.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_create_new_program_fail, ToolStripMenuItem_save_into_BD, ToolStripMenuItem_open });
            ToolStripMenuItem_fail.Name = "ToolStripMenuItem_fail";
            ToolStripMenuItem_fail.Size = new Size(59, 24);
            ToolStripMenuItem_fail.Text = "Файл";
            // 
            // ToolStripMenuItem_create_new_program_fail
            // 
            ToolStripMenuItem_create_new_program_fail.Name = "ToolStripMenuItem_create_new_program_fail";
            ToolStripMenuItem_create_new_program_fail.Size = new Size(224, 26);
            ToolStripMenuItem_create_new_program_fail.Text = "Создать";
            ToolStripMenuItem_create_new_program_fail.Click += ToolStripMenuItem_create_new_program_fail_Click;
            // 
            // ToolStripMenuItem_save_into_BD
            // 
            ToolStripMenuItem_save_into_BD.Name = "ToolStripMenuItem_save_into_BD";
            ToolStripMenuItem_save_into_BD.Size = new Size(224, 26);
            ToolStripMenuItem_save_into_BD.Text = "Сохранить в БД";
            ToolStripMenuItem_save_into_BD.Visible = false;
            ToolStripMenuItem_save_into_BD.Click += ToolStripMenuItem_save_into_BD_Click;
            // 
            // ToolStripMenuItem_open
            // 
            ToolStripMenuItem_open.Name = "ToolStripMenuItem_open";
            ToolStripMenuItem_open.Size = new Size(224, 26);
            ToolStripMenuItem_open.Text = "Открыть";
            ToolStripMenuItem_open.Click += ToolStripMenuItem_open_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(838, 53);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 19);
            label2.Name = "label2";
            label2.Size = new Size(158, 20);
            label2.TabIndex = 1;
            label2.Text = "Блок-схемы методов:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 0;
            label1.Text = "Программный код:";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel_picture_flowchart_main);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(838, 452);
            panel2.TabIndex = 2;
            // 
            // panel_picture_flowchart_main
            // 
            panel_picture_flowchart_main.AutoScroll = true;
            panel_picture_flowchart_main.AutoSize = true;
            panel_picture_flowchart_main.Dock = DockStyle.Fill;
            panel_picture_flowchart_main.Location = new Point(311, 0);
            panel_picture_flowchart_main.Name = "panel_picture_flowchart_main";
            panel_picture_flowchart_main.Size = new Size(527, 452);
            panel_picture_flowchart_main.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(richTextBox_text_program);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(311, 452);
            panel3.TabIndex = 0;
            // 
            // richTextBox_text_program
            // 
            richTextBox_text_program.Dock = DockStyle.Fill;
            richTextBox_text_program.Location = new Point(0, 0);
            richTextBox_text_program.Name = "richTextBox_text_program";
            richTextBox_text_program.Size = new Size(311, 452);
            richTextBox_text_program.TabIndex = 0;
            richTextBox_text_program.Text = "";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Flowchart_main_form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 533);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Flowchart_main_form";
            Text = "Flowchart_main_form";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_fail;
        private Panel panel2;
        private Panel panel3;
        public RichTextBox richTextBox_text_program;
        private ToolStripMenuItem ToolStripMenuItem_create_new_program_fail;
        private OpenFileDialog openFileDialog1;
        public Panel panel1;
        public Panel panel_picture_flowchart_main;
        private ToolStripMenuItem ToolStripMenuItem_save_into_BD;
        private ToolStripMenuItem ToolStripMenuItem_open;
        private Label label2;
        private Label label1;
    }
}