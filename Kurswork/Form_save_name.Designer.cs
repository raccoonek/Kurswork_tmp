namespace Kurswork
{
    partial class Form_save_name
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
            textBox_name_code = new TextBox();
            button_save = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 0;
            label1.Text = "Введите название кода:";
            // 
            // textBox_name_code
            // 
            textBox_name_code.Location = new Point(12, 51);
            textBox_name_code.Name = "textBox_name_code";
            textBox_name_code.Size = new Size(266, 27);
            textBox_name_code.TabIndex = 1;
            // 
            // button_save
            // 
            button_save.Location = new Point(12, 93);
            button_save.Name = "button_save";
            button_save.Size = new Size(94, 29);
            button_save.TabIndex = 2;
            button_save.Text = "Сохранить";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // Form_save_name
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 134);
            Controls.Add(button_save);
            Controls.Add(textBox_name_code);
            Controls.Add(label1);
            Name = "Form_save_name";
            Text = "Form_save_name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_name_code;
        private Button button_save;
    }
}