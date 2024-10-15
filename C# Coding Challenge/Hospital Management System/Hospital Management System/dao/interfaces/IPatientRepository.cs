using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.entity;

namespace Hospital_Management_System.dao.interfaces
{
    public interface IPatientRepository
    {
        Patient GetById(int patientId);
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(int patientId);
        List<Patient> GetAll();
    }
}
