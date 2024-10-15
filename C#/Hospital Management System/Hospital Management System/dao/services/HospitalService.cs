using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.dao.interfaces;
using Hospital_Management_System.dao.repositories;
using Hospital_Management_System.entity;
using Hospital_Management_System.myexceptions;

namespace Hospital_Management_System.dao.services
{
    public class HospitalService:IHospitalService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IAppointmentRepository appointmentRepository;

        // Constructor to initialize repositories for accessing data
        public HospitalService()
        {
            patientRepository = new PatientRepository();
            doctorRepository = new DoctorRepository();
            appointmentRepository = new AppointmentRepository();
        }

        // Fetching appointment by its ID, throws custom exception if not found
        public Appointment GetAppointmentById(int appointmentId)
        {
            var appointment = appointmentRepository.GetById(appointmentId);
            if (appointment == null) throw new AppointmentNotFoundException("Appointment not found.");
            return appointment;
        }

        // Fetching all appointments for a specific doctor,  throws custom exception if doctor not found
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var doctor = doctorRepository.GetById(doctorId);
            if (doctor == null) throw new DoctorNotFoundException("Doctor not found.");
            return appointmentRepository.GetByDoctorId(doctorId);
        }

        // Fetches all appointments for a specific patient, throws custom exception if patient not found
        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var patient = doctorRepository.GetById(patientId);
            if (patient == null) throw new PatientNumberNotFoundException("Patient not found.");
            return appointmentRepository.GetByPatientId(patientId);
        }

        // Scheduling a new appointment, throws exception if patient or doctor is not found
        public bool ScheduleAppointment(Appointment appointment)
        {
            var patient = patientRepository.GetById(appointment.PatientId);
            if (patient == null) throw new PatientNumberNotFoundException("Patient not found.");

            var doctor = doctorRepository.GetById(appointment.DoctorId);
            if (doctor == null) throw new DoctorNotFoundException("Doctor not found.");

            appointmentRepository.Add(appointment);
            return true;
        }

        // Updating an existing appointment, throws exception if not found
        public bool UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = appointmentRepository.GetById(appointment.AppointmentId);
            if (existingAppointment == null) throw new AppointmentNotFoundException("Appointment not found.");
            appointmentRepository.Update(appointment);
            return true;
        }

        // Cancelling an appointment by its ID, throws exception if not found
        public bool CancelAppointment(int appointmentId)
        {
            var appointment = appointmentRepository.GetById(appointmentId);
            if (appointment == null) throw new AppointmentNotFoundException("Appointment not found.");
            appointmentRepository.Delete(appointmentId);
            return true;
        }
    }
}
