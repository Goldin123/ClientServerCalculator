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
    public partial class Register : Form
    {
        private Calculator.Business.Interface.IUserBL _user = new Calculator.Business.Abstract.UserBL();
        public Register()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frmLogin = new Login();
            frmLogin.Show();
        }
        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string sFirstname = txtFirstName.Text.Replace("|", "");
            string sLastname = txtLastName.Text.Replace("|", "");
            string sUsername = txtRegUsername.Text.Replace("|", "");
            string sPassword = txtRegPassword.Text.Replace("|", "");
            string sRePassword = txtRePassword.Text.Replace("|", "");

            if (sPassword.Equals(sRePassword))
            {
                var user = new Calculator.Model.User
                {
                    Firstname = sFirstname,
                    Lastname = sLastname,
                    Username = sUsername,
                    Password = sPassword
                };
                var rst = _user.RegisterUser(user);
                if (rst)
                {
                    ClearForm();
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Something went wrong, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Clears the form.
        /// </summary>
        void ClearForm()
        {
            txtFirstName.Text = "";
            txtFirstName.Focus();
            txtLastName.Text = "";
            txtRegUsername.Text = "";
            txtRegPassword.Text = "";
            txtRePassword.Text = "";
        }
        
    }
}
