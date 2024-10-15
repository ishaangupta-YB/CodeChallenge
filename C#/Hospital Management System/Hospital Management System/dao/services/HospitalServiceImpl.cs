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
    // Service class to implement all operations for user
    public class HospitalServiceImpl:IHospitalServiceImpl
    {
        private readonly IHospitalService hospitalService;
        public HospitalServiceImpl()
        {
            hospitalService=new HospitalService();
        }

        // Method to schedule an appointment
        public void ScheduleAppointment()
        {
            try
            {
                Console.Write("Enter Patient ID: ");
                int patientId = int.Parse(Console.ReadLine());

                Console.Write("Enter Doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine());

                Console.Write("Enter Appointment Date (YYYY-MM-DD): ");
                DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                var appointment = new Appointment
                {
                    PatientId = patientId,
                    DoctorId = doctorId,
                    AppointmentDate = appointmentDate,
                    Description = description
                };

                // Scheduling the appointment using the service
                bool success = hospitalService.ScheduleAppointment(appointment);
                if (success) Console.WriteLine("Appointment scheduled successfully.");
                else Console.WriteLine("Failed to schedule appointment.");
                
            }
            catch (PatientNumberNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);  // Handle invalid patient number
            }
            catch (DoctorNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message); // Handle invalid doctor ID
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter date as YYYY-MM-DD."); // Handle invalid date format entered by usre
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); // Handle any other exceptions
            }
        }

        // Method to update an existing appointment
        public void UpdateAppointment()
        {
            try
            {
                Console.Write("Enter Appointment ID to update: ");
                int appointmentId = int.Parse(Console.ReadLine());

                var existingAppointment = hospitalService.GetAppointmentById(appointmentId);

                Console.Write("Enter New Appointment Date (YYYY-MM-DD): ");
                DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter New Description: ");
                string description = Console.ReadLine();

                // Update the appointment obj with new details
                existingAppointment.AppointmentDate = appointmentDate;
                existingAppointment.Description = description;

                // Update the appointment using the service
                bool success = hospitalService.UpdateAppointment(existingAppointment);
                if (success) Console.WriteLine("Appointment updated successfully.");
                else  Console.WriteLine("Failed to update appointment.");
            }
            catch (AppointmentNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);  // Handle invalid appointment ID
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter date as YYYY-MM-DD.");  // Handle wrong date formats
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); // Catch all other exceptions
            }
        }

        // Method to cancel an existing appointment
        public void CancelAppointment()
        {
            try
            {
                Console.Write("Enter Appointment ID to cancel: ");
                int appointmentId = int.Parse(Console.ReadLine());

                // Cancel the appointment using the service
                bool success = hospitalService.CancelAppointment(appointmentId);
                if (success) Console.WriteLine("Appointment cancelled successfully.");
                else Console.WriteLine("Failed to cancel appointment.");
            }
            catch (AppointmentNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);  // Handle invalid appointment ID
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); // Catch all other exceptions
            }
        }

        // Method to view an appointment by ID
        public void ViewAppointmentById()
        {
            try
            {
                Console.Write("Enter Appointment ID: ");
                int appointmentId = int.Parse(Console.ReadLine());

                // Fetch appointment details using the service
                var appointment = hospitalService.GetAppointmentById(appointmentId);
                Console.WriteLine($"Appointment ID: {appointment.AppointmentId}");
                Console.WriteLine($"Patient ID: {appointment.PatientId}");
                Console.WriteLine($"Doctor ID: {appointment.DoctorId}");
                Console.WriteLine($"Appointment Date: {appointment.AppointmentDate.ToShortDateString()}");
                Console.WriteLine($"Description: {appointment.Description}");
            }
            catch (AppointmentNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);   // Handle invalid appointment ID
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); // Catch all other exceptions
            }
        }

        // Method to view all appointments for a specific patient
        public void ViewAppointmentsForPatient()
        {
            try
            {
                Console.Write("Enter Patient ID: ");
                int patientId = int.Parse(Console.ReadLine());

                // Fetch appointments for the patient using the service
                var appointments = hospitalService.GetAppointmentsForPatient(patientId);
                if (appointments.Count == 0)
                {
                    Console.WriteLine("No appointments found for this patient.");
                    return;
                }

                // Displaying all appointments for the patient
                Console.WriteLine($"Appointments for Patient ID {patientId}:");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, Doctor ID: {appointment.DoctorId}, Date: {appointment.AppointmentDate.ToShortDateString()}, Description: {appointment.Description}");
                }
            }
            catch (PatientNumberNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);  // Handle invalid patient ID
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);  // Catch all other exceptions
            }
        }

        // Method to view all appointments for a specific doctor
        public void ViewAppointmentsForDoctor()
        {
            try
            {
                Console.Write("Enter Doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine());

                // Fetch appointments for the doctor using the service
                var appointments = hospitalService.GetAppointmentsForDoctor(doctorId);
                if (appointments.Count == 0)
                {
                    Console.WriteLine("No appointments found for this doctor.");
                    return;
                }

                // Displayng all appointments for the doctor
                Console.WriteLine($"Appointments for Doctor ID {doctorId}:");
                foreach (var appointment in appointments) Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, Patient ID: {appointment.PatientId}, Date: {appointment.AppointmentDate.ToShortDateString()}, Description: {appointment.Description}");
            }
            catch (DoctorNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message); // Handle invalid doctor ID
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);  // Catch all other exceptions
            }
        }
    }
}
