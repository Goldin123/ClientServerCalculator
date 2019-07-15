using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Interface
{
    public interface IUserBL
    {
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        bool RegisterUser(Calculator.Model.User user);
        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The password.</param>
        /// <returns></returns>
        Results LoginUser(string Username, string Password);
    }
}
