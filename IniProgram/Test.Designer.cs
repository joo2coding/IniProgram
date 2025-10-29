namespace IniProgram
{
    partial class Test
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
            this.btn_open = new System.Windows.Forms.Button();
            this.tb_allFile = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tb_section = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_value = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(90, 263);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "열기";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // tb_allFile
            // 
            this.tb_allFile.Location = new System.Drawing.Point(12, 12);
            this.tb_allFile.Name = "tb_allFile";
            this.tb_allFile.Size = new System.Drawing.Size(230, 245);
            this.tb_allFile.TabIndex = 1;
            this.tb_allFile.Text = "";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(329, 181);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "저장";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tb_section
            // 
            this.tb_section.Location = new System.Drawing.Point(355, 44);
            this.tb_section.Name = "tb_section";
            this.tb_section.Size = new System.Drawing.Size(100, 21);
            this.tb_section.TabIndex = 3;
            this.tb_section.TextChanged += new System.EventHandler(this.tb_section_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "섹션";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "키";
            // 
            // tb_key
            // 
            this.tb_key.Location = new System.Drawing.Point(355, 87);
            this.tb_key.Name = "tb_key";
            this.tb_key.Size = new System.Drawing.Size(100, 21);
            this.tb_key.TabIndex = 5;
            this.tb_key.TextChanged += new System.EventHandler(this.tb_key_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "벨류";
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(355, 128);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(100, 21);
            this.tb_value.TabIndex = 7;
            this.tb_value.TextChanged += new System.EventHandler(this.tb_value_TextChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(329, 263);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 9;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 333);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_key);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_section);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_allFile);
            this.Controls.Add(this.btn_open);
            this.Name = "Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.RichTextBox tb_allFile;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox tb_section;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.Button btn_clear;
    }
}