using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.util
{
    public class PropertyUtil
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HMSDB"].ConnectionString;
        }
    }
}
