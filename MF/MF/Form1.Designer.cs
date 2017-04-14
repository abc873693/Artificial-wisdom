namespace MF
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
            this.richTextBox_out = new System.Windows.Forms.RichTextBox();
            this.button_submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_PB = new System.Windows.Forms.TextBox();
            this.textBox_PM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ZR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_NS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_NM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_NB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox_out
            // 
            this.richTextBox_out.Font = new System.Drawing.Font("新細明體", 16F);
            this.richTextBox_out.Location = new System.Drawing.Point(180, 75);
            this.richTextBox_out.Name = "richTextBox_out";
            this.richTextBox_out.Size = new System.Drawing.Size(298, 193);
            this.richTextBox_out.TabIndex = 0;
            this.richTextBox_out.Text = "";
            // 
            // button_submit
            // 
            this.button_submit.Font = new System.Drawing.Font("新細明體", 9F);
            this.button_submit.Location = new System.Drawing.Point(403, 43);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(75, 23);
            this.button_submit.TabIndex = 1;
            this.button_submit.Text = "計算";
            this.button_submit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "PB";
            // 
            // textBox_PB
            // 
            this.textBox_PB.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_PB.Location = new System.Drawing.Point(74, 22);
            this.textBox_PB.Name = "textBox_PB";
            this.textBox_PB.Size = new System.Drawing.Size(100, 30);
            this.textBox_PB.TabIndex = 3;
            this.textBox_PB.Text = "10";
            this.textBox_PB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PM
            // 
            this.textBox_PM.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_PM.Location = new System.Drawing.Point(74, 58);
            this.textBox_PM.Name = "textBox_PM";
            this.textBox_PM.Size = new System.Drawing.Size(100, 30);
            this.textBox_PM.TabIndex = 5;
            this.textBox_PM.Text = "7";
            this.textBox_PM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "PM";
            // 
            // textBox_PS
            // 
            this.textBox_PS.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_PS.Location = new System.Drawing.Point(74, 94);
            this.textBox_PS.Name = "textBox_PS";
            this.textBox_PS.Size = new System.Drawing.Size(100, 30);
            this.textBox_PS.TabIndex = 7;
            this.textBox_PS.Text = "3.5";
            this.textBox_PS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "PS";
            // 
            // textBox_ZR
            // 
            this.textBox_ZR.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_ZR.Location = new System.Drawing.Point(74, 130);
            this.textBox_ZR.Name = "textBox_ZR";
            this.textBox_ZR.Size = new System.Drawing.Size(100, 30);
            this.textBox_ZR.TabIndex = 9;
            this.textBox_ZR.Text = "0";
            this.textBox_ZR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "ZR";
            // 
            // textBox_NS
            // 
            this.textBox_NS.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_NS.Location = new System.Drawing.Point(74, 166);
            this.textBox_NS.Name = "textBox_NS";
            this.textBox_NS.Size = new System.Drawing.Size(100, 30);
            this.textBox_NS.TabIndex = 11;
            this.textBox_NS.Text = "-4";
            this.textBox_NS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "NS";
            // 
            // textBox_NM
            // 
            this.textBox_NM.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_NM.Location = new System.Drawing.Point(74, 202);
            this.textBox_NM.Name = "textBox_NM";
            this.textBox_NM.Size = new System.Drawing.Size(100, 30);
            this.textBox_NM.TabIndex = 13;
            this.textBox_NM.Text = "-8";
            this.textBox_NM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "NM";
            // 
            // textBox_NB
            // 
            this.textBox_NB.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_NB.Location = new System.Drawing.Point(74, 238);
            this.textBox_NB.Name = "textBox_NB";
            this.textBox_NB.Size = new System.Drawing.Size(100, 30);
            this.textBox_NB.TabIndex = 15;
            this.textBox_NB.Text = "-10";
            this.textBox_NB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "NB";
            // 
            // textBox_X
            // 
            this.textBox_X.Font = new System.Drawing.Font("新細明體", 14F);
            this.textBox_X.Location = new System.Drawing.Point(259, 39);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(100, 30);
            this.textBox_X.TabIndex = 17;
            this.textBox_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Adobe Devanagari", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(230, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "X";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 310);
            this.Controls.Add(this.textBox_X);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_NB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_NM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_NS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_ZR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_PS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_PM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_PB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.richTextBox_out);
            this.Name = "Form1";
            this.Text = "歸屬函數計算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_out;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_PB;
        private System.Windows.Forms.TextBox textBox_PM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ZR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_NS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_NM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_NB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.Label label8;
    }
}

