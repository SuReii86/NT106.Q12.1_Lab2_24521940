namespace NT106.Q12._1_Lab2_24521940
{
    partial class Bai1
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
            this.btn_READ = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.tb_IO = new System.Windows.Forms.TextBox();
            this.tb_label = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RESET = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ROUT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_READ
            // 
            this.btn_READ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_READ.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_READ.Location = new System.Drawing.Point(139, 353);
            this.btn_READ.Name = "btn_READ";
            this.btn_READ.Size = new System.Drawing.Size(150, 50);
            this.btn_READ.TabIndex = 0;
            this.btn_READ.Text = "Đọc";
            this.btn_READ.UseVisualStyleBackColor = true;
            this.btn_READ.Click += new System.EventHandler(this.btn_READ_Click);
            // 
            // btn_Write
            // 
            this.btn_Write.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Write.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Write.Location = new System.Drawing.Point(139, 504);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(150, 50);
            this.btn_Write.TabIndex = 1;
            this.btn_Write.Text = "Ghi";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // tb_IO
            // 
            this.tb_IO.Location = new System.Drawing.Point(439, 172);
            this.tb_IO.Multiline = true;
            this.tb_IO.Name = "tb_IO";
            this.tb_IO.Size = new System.Drawing.Size(630, 573);
            this.tb_IO.TabIndex = 2;
            // 
            // tb_label
            // 
            this.tb_label.Font = new System.Drawing.Font("Cascadia Code SemiLight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_label.Location = new System.Drawing.Point(209, 241);
            this.tb_label.Name = "tb_label";
            this.tb_label.ReadOnly = true;
            this.tb_label.Size = new System.Drawing.Size(203, 31);
            this.tb_label.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "File sử dụng: ";
            // 
            // btn_RESET
            // 
            this.btn_RESET.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RESET.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RESET.Location = new System.Drawing.Point(139, 427);
            this.btn_RESET.Name = "btn_RESET";
            this.btn_RESET.Size = new System.Drawing.Size(150, 50);
            this.btn_RESET.TabIndex = 5;
            this.btn_RESET.Text = "Làm mới";
            this.btn_RESET.UseVisualStyleBackColor = true;
            this.btn_RESET.Click += new System.EventHandler(this.btn_RESET_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(416, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "GHI VÀ ĐỌC FILE";
            // 
            // btn_ROUT
            // 
            this.btn_ROUT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_ROUT.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ROUT.Location = new System.Drawing.Point(103, 591);
            this.btn_ROUT.Name = "btn_ROUT";
            this.btn_ROUT.Size = new System.Drawing.Size(213, 64);
            this.btn_ROUT.TabIndex = 7;
            this.btn_ROUT.Text = "Đọc file CAU1_IN.txt";
            this.btn_ROUT.UseVisualStyleBackColor = true;
            this.btn_ROUT.Click += new System.EventHandler(this.btn_ROUT_Click);
            // 
            // Bai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.btn_ROUT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_label);
            this.Controls.Add(this.btn_RESET);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_IO);
            this.Controls.Add(this.btn_Write);
            this.Controls.Add(this.btn_READ);
            this.Name = "Bai1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_READ;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.TextBox tb_IO;
        private System.Windows.Forms.TextBox tb_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RESET;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ROUT;
    }
}

