namespace NT106.Q12._1_Lab2_24521940
{
    partial class Bai3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_READ = new System.Windows.Forms.Button();
            this.btn_CALC = new System.Windows.Forms.Button();
            this.btn_WRITE = new System.Windows.Forms.Button();
            this.tb_IN = new System.Windows.Forms.TextBox();
            this.tb_OUT = new System.Windows.Forms.TextBox();
            this.tb_Prc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(47, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "input3.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(625, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "output3.txt";
            // 
            // btn_READ
            // 
            this.btn_READ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_READ.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_READ.Location = new System.Drawing.Point(148, 306);
            this.btn_READ.Name = "btn_READ";
            this.btn_READ.Size = new System.Drawing.Size(150, 50);
            this.btn_READ.TabIndex = 2;
            this.btn_READ.Text = "Đọc";
            this.btn_READ.UseVisualStyleBackColor = true;
            this.btn_READ.Click += new System.EventHandler(this.btn_READ_Click);
            // 
            // btn_CALC
            // 
            this.btn_CALC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_CALC.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CALC.Location = new System.Drawing.Point(148, 166);
            this.btn_CALC.Name = "btn_CALC";
            this.btn_CALC.Size = new System.Drawing.Size(150, 50);
            this.btn_CALC.TabIndex = 3;
            this.btn_CALC.Text = "Tính";
            this.btn_CALC.UseVisualStyleBackColor = true;
            this.btn_CALC.Click += new System.EventHandler(this.btn_CALC_Click);
            // 
            // btn_WRITE
            // 
            this.btn_WRITE.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_WRITE.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_WRITE.Location = new System.Drawing.Point(786, 318);
            this.btn_WRITE.Name = "btn_WRITE";
            this.btn_WRITE.Size = new System.Drawing.Size(150, 50);
            this.btn_WRITE.TabIndex = 4;
            this.btn_WRITE.Text = "Ghi";
            this.btn_WRITE.UseVisualStyleBackColor = true;
            this.btn_WRITE.Click += new System.EventHandler(this.btn_WRITE_Click);
            // 
            // tb_IN
            // 
            this.tb_IN.Location = new System.Drawing.Point(53, 424);
            this.tb_IN.Multiline = true;
            this.tb_IN.Name = "tb_IN";
            this.tb_IN.ReadOnly = true;
            this.tb_IN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_IN.Size = new System.Drawing.Size(460, 360);
            this.tb_IN.TabIndex = 5;
            // 
            // tb_OUT
            // 
            this.tb_OUT.Location = new System.Drawing.Point(631, 424);
            this.tb_OUT.Multiline = true;
            this.tb_OUT.Name = "tb_OUT";
            this.tb_OUT.ReadOnly = true;
            this.tb_OUT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_OUT.Size = new System.Drawing.Size(460, 360);
            this.tb_OUT.TabIndex = 6;
            // 
            // tb_Prc
            // 
            this.tb_Prc.Location = new System.Drawing.Point(366, 127);
            this.tb_Prc.Multiline = true;
            this.tb_Prc.Name = "tb_Prc";
            this.tb_Prc.ReadOnly = true;
            this.tb_Prc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Prc.Size = new System.Drawing.Size(407, 150);
            this.tb_Prc.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(344, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(449, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "ĐỌC VÀ GHI FILE (TÍNH TOÁN)";
            // 
            // Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Prc);
            this.Controls.Add(this.tb_OUT);
            this.Controls.Add(this.tb_IN);
            this.Controls.Add(this.btn_WRITE);
            this.Controls.Add(this.btn_CALC);
            this.Controls.Add(this.btn_READ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Bai3";
            this.Text = "Bai3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_READ;
        private System.Windows.Forms.Button btn_CALC;
        private System.Windows.Forms.Button btn_WRITE;
        private System.Windows.Forms.TextBox tb_IN;
        private System.Windows.Forms.TextBox tb_OUT;
        private System.Windows.Forms.TextBox tb_Prc;
        private System.Windows.Forms.Label label3;
    }
}