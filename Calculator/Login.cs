using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Login : Form
    {
        private Calculator.Business.Interface.IUserBL _user = new Calculator.Business.Abstract.UserBL();
      /// <summary>
      /// Login form
      /// </summary>
        public Login()
        {
            InitializeComponent();
        }

      /// <summary>
      /// Register click
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register frmReg = new Register();
            frmReg.Show();
        }

/// <summary>
/// Login Click
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            /// <summary>This checks is username is null</summary>
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            var rst = _user.LoginUser(txtUsername.Text, txtPassword.Text);
            if (rst != null)
            {
                if (rst.Valid)
                {
                    Calculator.Model.Cookie.Name = rst.Value;
                    this.Hide();
                    MainMenu frmMainMenu = new MainMenu();
                    frmMainMenu.Show();
                }
                else
                    MessageBox.Show(rst.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("User details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
