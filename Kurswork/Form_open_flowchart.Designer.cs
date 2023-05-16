namespace Kurswork
{
    partial class Form_open_flowchart
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
            label1 = new Label();
            comboBox_names_code = new ComboBox();
            button_open = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 17);
            label1.Name = "label1";
            label1.Size = new Size(187, 20);
            label1.TabIndex = 0;
            label1.Text = "Выберите название кода:";
            // 
            // comboBox_names_code
            // 
            comboBox_names_code.FormattingEnabled = true;
            comboBox_names_code.Location = new Point(18, 53);
            comboBox_names_code.Name = "comboBox_names_code";
            comboBox_names_code.Size = new Size(256, 28);
            comboBox_names_code.TabIndex = 1;
            // 
            // button_open
            // 
            button_open.Location = new Point(18, 106);
            button_open.Name = "button_open";
            button_open.Size = new Size(94, 29);
            button_open.TabIndex = 2;
            button_open.Text = "Открыть";
            button_open.UseVisualStyleBackColor = true;
            button_open.Click += button_open_Click;
            // 
            // Form_open_flowchart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 183);
            Controls.Add(button_open);
            Controls.Add(comboBox_names_code);
            Controls.Add(label1);
            Name = "Form_open_flowchart";
            Text = "Form_open_flowchart";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox_names_code;
        private Button button_open;
    }
}