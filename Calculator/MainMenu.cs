using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainMenu : Form
    {
        private readonly string ServerApplication = string.Format(@"{0}Server.exe", System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "").Replace(@"\Calculator", @"\Server"));
        private readonly string ClientApplication = string.Format(@"{0}Client.exe", System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "").Replace(@"\Calculator", @"\Client"));
        /// <summary>
        /// Initializes a new  instance of the <see cref="MainMenu"/> class.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnStartServer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Process.Start(@"cmd.exe", @"/C " + ServerApplication);
            btnStartClient.Enabled = true;
            btnTerminateServices.Enabled = true;
            //btnStartServer.Enabled = false;
            this.Location = new Point(800, 10);

        }
        /// <summary>
        /// Handles the Click event of the btnStartClient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStartClient_Click(object sender, EventArgs e)
        {
            Process.Start(@"cmd.exe", @"/C " + ClientApplication);
            this.Location = new Point(800,10);
        }

        /// <summary>
        /// Handles the Click event of the btnTerminateServices control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTerminateServices_Click(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcessesByName("Server"))
            {
                proc.Kill();
            }
            foreach (Process proc in Process.GetProcessesByName("Client"))
            {
                proc.Kill();
            }
            btnStartClient.Enabled = false;
            btnTerminateServices.Enabled = false;
            //btnStartServer.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btnLogOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcessesByName("Server"))
            {
                proc.Kill();
            }
            foreach (Process proc in Process.GetProcessesByName("Client"))
            {
                proc.Kill();
            }

            this.Hide();
            Login frmLogin = new Login();
            frmLogin.Show();
        }

        /// <summary>
        /// Handles the Load event of the MainMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainMenu_Load(object sender, EventArgs e)
        {
            lblStatus.Text = string.Format("Welcome {0} enjoy, \nClick on start server to get things going.\nOnce server is running you can start as many clients as you want.", Calculator.Model.Cookie.Name);
        }
    }
}
