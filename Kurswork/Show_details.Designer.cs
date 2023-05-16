namespace Kurswork
{
    partial class Show_details
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
            label_type_block = new Label();
            label2 = new Label();
            label_context = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 29);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Тип:";
            // 
            // label_type_block
            // 
            label_type_block.AutoSize = true;
            label_type_block.Location = new Point(80, 29);
            label_type_block.Name = "label_type_block";
            label_type_block.Size = new Size(0, 20);
            label_type_block.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 72);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Условие:";
            // 
            // label_context
            // 
            label_context.AutoSize = true;
            label_context.Location = new Point(114, 71);
            label_context.Name = "label_context";
            label_context.Size = new Size(0, 20);
            label_context.TabIndex = 3;
            // 
            // Show_details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 173);
            Controls.Add(label_context);
            Controls.Add(label2);
            Controls.Add(label_type_block);
            Controls.Add(label1);
            Name = "Show_details";
            Text = "Show_details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        public Label label_type_block;
        public Label label_context;
    }
}