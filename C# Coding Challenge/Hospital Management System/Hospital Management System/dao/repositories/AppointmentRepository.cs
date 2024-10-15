using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.dao.interfaces;
using Hospital_Management_System.entity;
using Hospital_Management_System.util;

namespace Hospital_Management_System.dao.repositories
{
    // Repository class to interact with the Appointments table in the db
    public class AppointmentRepository:IAppointmentRepository
    {

        // Adds a new appointment to the DB
        public void Add(Appointment appointment)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Description) " +
                            "VALUES (@PatientId, @DoctorId, @AppointmentDate, @Description)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Deletes an appointment from the DB by its ID
        public void Delete(int appointmentId)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "DELETE FROM Appointments WHERE AppointmentId = @AppointmentId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Retrieves all appointments from the DB
        public List<Appointment> GetAll()
        {
            var appointments = new List<Appointment>();
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Appointments";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var appointment = new Appointment
                        {
                            AppointmentId = (int)reader["AppointmentId"],
                            PatientId = (int)reader["PatientId"],
                            DoctorId = (int)reader["DoctorId"],
                            AppointmentDate = (DateTime)reader["AppointmentDate"],
                            Description = reader["Description"].ToString()
                        };
                        appointments.Add(appointment);
                    }
                }
            }
            return appointments;
        }

        // Retrieves a specific appointment by its ID
        public Appointment GetById(int appointmentId)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Appointments WHERE AppointmentId = @AppointmentId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Appointment
                        {
                            AppointmentId = (int)reader["AppointmentId"],
                            PatientId = (int)reader["PatientId"],
                            DoctorId = (int)reader["DoctorId"],
                            AppointmentDate = (DateTime)reader["AppointmentDate"],
                            Description = reader["Description"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // Retrieves all appointments associated with a specific doctor
        public List<Appointment> GetByDoctorId(int doctorId)
        {
            var appointments = new List<Appointment>();
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Appointments WHERE DoctorId = @DoctorId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var appointment = new Appointment
                        {
                            AppointmentId = (int)reader["AppointmentId"],
                            PatientId = (int)reader["PatientId"],
                            DoctorId = (int)reader["DoctorId"],
                            AppointmentDate = (DateTime)reader["AppointmentDate"],
                            Description = reader["Description"].ToString()
                        };
                        appointments.Add(appointment);
                    }
                }
            }
            return appointments;
        }

        // Retrieves all appointments associated with a specific patient
        public List<Appointment> GetByPatientId(int patientId)
        {
            var appointments = new List<Appointment>();
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Appointments WHERE PatientId = @PatientId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var appointment = new Appointment
                        {
                            AppointmentId = (int)reader["AppointmentId"],
                            PatientId = (int)reader["PatientId"],
                            DoctorId = (int)reader["DoctorId"],
                            AppointmentDate = (DateTime)reader["AppointmentDate"],
                            Description = reader["Description"].ToString()
                        };
                        appointments.Add(appointment);
                    }
                }
            }
            return appointments;
        }

        // Updates an existing appointment in the DB
        public void Update(Appointment appointment)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "UPDATE Appointments SET PatientId = @PatientId, DoctorId = @DoctorId, " +
                            "AppointmentDate = @AppointmentDate, Description = @Description WHERE AppointmentId = @AppointmentId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
