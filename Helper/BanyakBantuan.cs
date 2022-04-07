using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Helper
{
    public class BanyakBantuan
    {
        public int BuatOTP()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }
    }
}
