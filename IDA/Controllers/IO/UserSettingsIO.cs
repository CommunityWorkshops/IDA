using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDA.Models;

namespace IDA.Controllers.IO
{
    public class UserSettingsIo
    {

        public static void LoadUser()
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(Path.Combine("Settings","User.dat"),FileMode.Open,FileAccess.Read,FileShare.Read);
                sr = new StreamReader(fs);

                UserModel.UserName = sr.ReadLine();
                UserModel.UserEmail = sr.ReadLine();


                sr?.Close();
                fs?.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sr?.Close();
                fs?.Close();
            }
        }

    }
}
