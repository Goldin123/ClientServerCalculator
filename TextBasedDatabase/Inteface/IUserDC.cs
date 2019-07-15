using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedDatabase.Inteface
{
   public interface IUserDC
    {
        bool RegisterUser(Calculator.Model.User user);
        Results LoginUser(string Username,string Password);
    }
}
