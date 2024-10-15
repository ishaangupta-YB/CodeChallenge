using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.entity
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; } 
        public int DoctorId { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public string Description { get; set; }
    }
}
