using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.entity;

namespace Hospital_Management_System.dao.interfaces
{
    public interface IDoctorRepository
    {
        Doctor GetById(int doctorId);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(int doctorId);
        List<Doctor> GetAll();
    }
}
