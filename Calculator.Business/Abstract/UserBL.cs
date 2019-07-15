using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Business.Interface;
using Calculator.Model;

namespace Calculator.Business.Abstract
{
    public sealed class UserBL : Interface.IUserBL
    {
        /// <summary>
        /// The user
        /// </summary>
        private TextBasedDatabase.Inteface.IUserDC _user = new TextBasedDatabase.Abstract.UserDC();
        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The password.</param>
        /// <returns></returns>
        Results IUserBL.LoginUser(string Username, string Password) => _user.LoginUser(Username,Password);
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool IUserBL.RegisterUser(Calculator.Model.User user) => _user.RegisterUser(user);
    }
}
