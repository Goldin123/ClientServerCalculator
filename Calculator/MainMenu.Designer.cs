namespace Calculator
{
    partial class MainMenu
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTerminateServices = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnStartClient = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(20, 25);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(301, 46);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTerminateServices);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.btnStartClient);
            this.panel1.Controls.Add(this.btnStartServer);
            this.panel1.Location = new System.Drawing.Point(16, 112);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 298);
            this.panel1.TabIndex = 1;
            // 
            // btnTerminateServices
            // 
            this.btnTerminateServices.Enabled = false;
            this.btnTerminateServices.Location = new System.Drawing.Point(24, 155);
            this.btnTerminateServices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTerminateServices.Name = "btnTerminateServices";
            this.btnTerminateServices.Size = new System.Drawing.Size(301, 46);
            this.btnTerminateServices.TabIndex = 4;
            this.btnTerminateServices.Text = "Terminate Services";
            this.btnTerminateServices.UseVisualStyleBackColor = true;
            this.btnTerminateServices.Click += new System.EventHandler(this.btnTerminateServices_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(20, 224);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(301, 46);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnStartClient
            // 
            this.btnStartClient.Enabled = false;
            this.btnStartClient.Location = new System.Drawing.Point(23, 91);
            this.btnStartClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Size = new System.Drawing.Size(301, 46);
            this.btnStartClient.TabIndex = 1;
            this.btnStartClient.Text = "Initianate Client Handshake";
            this.btnStartClient.UseVisualStyleBackColor = true;
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Location = new System.Drawing.Point(16, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 91);
            this.panel2.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(19, 18);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 428);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartClient;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnTerminateServices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
    }
}