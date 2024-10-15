using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.myexceptions
{
    public class AppointmentNotFoundException:ApplicationException
    {
        public AppointmentNotFoundException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
