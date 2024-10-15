using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.entity;

namespace Hospital_Management_System.dao.interfaces
{
    public interface IHospitalServiceImpl
    {
        void ViewAppointmentById();
        void ViewAppointmentsForPatient();
        void ViewAppointmentsForDoctor();
        void ScheduleAppointment();
        void UpdateAppointment();
        void CancelAppointment();
    }
}
