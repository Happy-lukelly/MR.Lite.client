using Service.ServiceInstaller;
namespace Service.WindowsForm
{
    partial class NowServiceWindow
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
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.btn_UnInstall = new System.Windows.Forms.Button();
            this.lbl_SerivceName = new System.Windows.Forms.Label();
            this.lbl_ServicePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_TipsMessage
            // 
            this.lbl_TipsMessage.AutoSize = true;
            this.lbl_TipsMessage.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_TipsMessage.Location = new System.Drawing.Point(4, 64);
            this.lbl_TipsMessage.Name = "lbl_TipsMessage";
            this.lbl_TipsMessage.Size = new System.Drawing.Size(394, 38);
            this.lbl_TipsMessage.TabIndex = 1;
            this.lbl_TipsMessage.Text = "当前系统中已安装了指定服务";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Cancel.Location = new System.Drawing.Point(246, 264);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(90, 40);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "取消";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // btn_UnInstall
            // 
            this.btn_UnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_UnInstall.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_UnInstall.Location = new System.Drawing.Point(52, 264);
            this.btn_UnInstall.Name = "btn_UnInstall";
            this.btn_UnInstall.Size = new System.Drawing.Size(89, 40);
            this.btn_UnInstall.TabIndex = 3;
            this.btn_UnInstall.Text = "卸载";
            this.btn_UnInstall.UseVisualStyleBackColor = false;
            this.btn_UnInstall.Click += new System.EventHandler(this.btn_UnInstall_Click);
            // 
            // lbl_SerivceName
            // 
            this.lbl_SerivceName.AutoSize = true;
            this.lbl_SerivceName.Location = new System.Drawing.Point(66, 132);
            this.lbl_SerivceName.Name = "lbl_SerivceName";
            this.lbl_SerivceName.Size = new System.Drawing.Size(0, 12);
            this.lbl_SerivceName.TabIndex = 4;
            this.lbl_SerivceName.Text = "服务名称："+existsSerivce.Name;
            // 
            // lbl_ServicePath
            // 
            this.lbl_ServicePath.AutoSize = true;
            this.lbl_ServicePath.Location = new System.Drawing.Point(66, 171);
            this.lbl_ServicePath.Name = "lbl_ServicePath";
            this.lbl_ServicePath.Size = new System.Drawing.Size(0, 12);
            this.lbl_ServicePath.TabIndex = 5;
            this.lbl_ServicePath.Text = "服务程序路径：\r\n" + existsSerivce.ImagePath;
            // 
            // NowServiceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 350);
            this.Controls.Add(this.lbl_ServicePath);
            this.Controls.Add(this.lbl_SerivceName);
            this.Controls.Add(this.btn_UnInstall);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.lbl_TipsMessage);
            this.MaximumSize = new System.Drawing.Size(418, 388);
            this.MinimumSize = new System.Drawing.Size(418, 388);
            this.Name = "NowServiceWindow";
            this.Text = "NowServiceWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TipsMessage;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button btn_UnInstall;
        private System.Windows.Forms.Label lbl_SerivceName;
        private System.Windows.Forms.Label lbl_ServicePath;
    }
}