namespace Service.WindowsForm
{
    partial class TipsWindow
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
            this.lbl_TipsMessage = new System.Windows.Forms.Label();
            this.Btn_Sure = new System.Windows.Forms.Button();
            this.btn_Refuse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_TipsMessage
            // 
            this.lbl_TipsMessage.AutoSize = true;
            this.lbl_TipsMessage.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_TipsMessage.Location = new System.Drawing.Point(76, 82);
            this.lbl_TipsMessage.Name = "lbl_TipsMessage";
            this.lbl_TipsMessage.Size = new System.Drawing.Size(249, 38);
            this.lbl_TipsMessage.TabIndex = 0;
            this.lbl_TipsMessage.Text = "是否确定安装服务";
            // 
            // Btn_Sure
            // 
            this.Btn_Sure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Sure.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Sure.Location = new System.Drawing.Point(83, 275);
            this.Btn_Sure.Name = "Btn_Sure";
            this.Btn_Sure.Size = new System.Drawing.Size(90, 40);
            this.Btn_Sure.TabIndex = 1;
            this.Btn_Sure.Text = "安装";
            this.Btn_Sure.UseVisualStyleBackColor = false;
            this.Btn_Sure.Click += new System.EventHandler(this.Btn_Sure_Click);
            // 
            // btn_Refuse
            // 
            this.btn_Refuse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Refuse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Refuse.Location = new System.Drawing.Point(236, 275);
            this.btn_Refuse.Name = "btn_Refuse";
            this.btn_Refuse.Size = new System.Drawing.Size(89, 40);
            this.btn_Refuse.TabIndex = 2;
            this.btn_Refuse.Text = "不安装";
            this.btn_Refuse.UseVisualStyleBackColor = false;
            this.btn_Refuse.Click += new System.EventHandler(this.btn_Refuse_Click);
            // 
            // TipsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 350);
            this.Controls.Add(this.btn_Refuse);
            this.Controls.Add(this.Btn_Sure);
            this.Controls.Add(this.lbl_TipsMessage);
            this.MaximumSize = new System.Drawing.Size(418, 388);
            this.MinimumSize = new System.Drawing.Size(418, 388);
            this.Name = "TipsWindow";
            this.Text = "TipsWindow";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_TipsMessage;
        private System.Windows.Forms.Button Btn_Sure;
        private System.Windows.Forms.Button btn_Refuse;
    }
}