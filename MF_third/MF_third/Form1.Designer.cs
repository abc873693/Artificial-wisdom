namespace MF_third
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_table_out = new System.Windows.Forms.RichTextBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.textBox_X2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_X1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox_MF_out = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_table_out
            // 
            this.richTextBox_table_out.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox_table_out.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_table_out.Name = "richTextBox_table_out";
            this.richTextBox_table_out.Size = new System.Drawing.Size(364, 263);
            this.richTextBox_table_out.TabIndex = 0;
            this.richTextBox_table_out.Text = "";
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(423, 95);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(75, 23);
            this.button_confirm.TabIndex = 27;
            this.button_confirm.Text = "確定";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // textBox_X2
            // 
            this.textBox_X2.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_X2.Location = new System.Drawing.Point(411, 59);
            this.textBox_X2.Name = "textBox_X2";
            this.textBox_X2.Size = new System.Drawing.Size(100, 30);
            this.textBox_X2.TabIndex = 26;
            this.textBox_X2.Text = "0.7";
            this.textBox_X2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "X2";
            // 
            // textBox_X1
            // 
            this.textBox_X1.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_X1.Location = new System.Drawing.Point(411, 13);
            this.textBox_X1.Name = "textBox_X1";
            this.textBox_X1.Size = new System.Drawing.Size(100, 30);
            this.textBox_X1.TabIndex = 24;
            this.textBox_X1.Text = "0.3";
            this.textBox_X1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(382, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 26);
            this.label8.TabIndex = 23;
            this.label8.Text = "X1";
            // 
            // richTextBox_MF_out
            // 
            this.richTextBox_MF_out.Font = new System.Drawing.Font("新細明體", 9F);
            this.richTextBox_MF_out.Location = new System.Drawing.Point(382, 124);
            this.richTextBox_MF_out.Name = "richTextBox_MF_out";
            this.richTextBox_MF_out.Size = new System.Drawing.Size(174, 151);
            this.richTextBox_MF_out.TabIndex = 28;
            this.richTextBox_MF_out.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 290);
            this.Controls.Add(this.richTextBox_MF_out);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.textBox_X2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_X1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBox_table_out);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_table_out;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.TextBox textBox_X2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_X1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox_MF_out;
    }
}

