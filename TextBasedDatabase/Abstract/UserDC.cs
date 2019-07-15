using Calculator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedDatabase.Inteface;

namespace TextBasedDatabase.Abstract
{
    public class DataFile
    {
        private string FilePath
        {
            get
            {
                return Path.Combine(Directory
                    .GetParent(System.IO.Directory
                    .GetCurrentDirectory()).Parent.FullName,
                    @"File\Data.txt");
            }
        }

        public string filePath { get; set; }

        public DataFile()
        {
            this.filePath = this.FilePath;

        }
    }
    public sealed class UserDC : Inteface.IUserDC
    {
        Results IUserDC.LoginUser(string Username, string Password)
        {
            try
            {
                var DataFilePath = new DataFile().filePath;
                bool bValid = false;
                string msg = string.Empty,rstValue = string.Empty;
                if (File.Exists(DataFilePath))
                {
                    var lstContent = new List<string>(File.ReadAllLines(DataFilePath, Encoding.UTF8));
                    
                    if (lstContent.Count > 0)
                    {
                        foreach (var itm in lstContent)
                        {
                            var lineEntery = itm.Split('|');
                            var dbName = ($"{lineEntery[0]} {lineEntery[1]}");
                            var dbUsername = lineEntery[2];
                            var dbPassword = Calculator.Security.StringCipher.Decrypt(lineEntery[3]);
                            if ((Password.Equals(dbPassword)) && (Username.Equals(dbUsername)))
                            {
                                bValid = true;
                                rstValue = dbName;
                                msg = "Login success";
                            }
                            else
                            {
                                bValid = false;
                                msg = "User does not exist.";
                            }

                            if (bValid)
                                break;
                        }
                        return new Results
                        {
                            Valid = bValid,
                            Message = msg,
                            Value = rstValue
                        };
                    }
                    else
                        return new Results
                        {
                            Valid = false,
                            Message = "Database has no records."
                        };
                }
                else
                    return new Results
                    {
                        Valid = false,
                        Message = "File not found"
                    };
            }
            catch (Exception e)
            {
                return new Results
                {
                    Valid = false,
                    Message = e.Message 
                };
            }
        }

        bool IUserDC.RegisterUser(Calculator.Model.User user)
        {
            try
            {
                var DataFilePath = new DataFile().filePath;
                List<string> lstContent = new List<string>();

                var userEntry = string.Format("{0}|{1}|{2}|{3}",
                                              user.Firstname,
                                              user.Lastname,
                                              user.Username,
                                             Calculator.Security.StringCipher.Encrypt(user.Password));
                if (File.Exists(DataFilePath))
                {
                    var FileContent = File.ReadAllLines(DataFilePath, Encoding.UTF8);
                    if (FileContent.Length> 1)
                    {
                        lstContent = new List<string>(FileContent);
                        lstContent.Add(userEntry);
                    }
                    else
                        lstContent.Add(userEntry);

                    File.Delete(DataFilePath);

                    using (var tw = new StreamWriter(DataFilePath, true))
                    {
                        foreach (var itm in lstContent)
                            tw.WriteLine(itm);
                    }
                }
                else
                {
                    using (var tw = new StreamWriter(DataFilePath, true))
                    {
                        lstContent.Add(userEntry);
                        foreach (var itm in lstContent)
                            tw.WriteLine(itm);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
