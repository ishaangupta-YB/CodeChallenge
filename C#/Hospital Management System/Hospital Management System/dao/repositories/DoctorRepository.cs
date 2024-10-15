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
    public class DoctorRepository:IDoctorRepository
    {
        public void Add(Doctor doctor)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "INSERT INTO Doctors (FirstName, LastName, Specialization, ContactNumber) " +
                            "VALUES (@FirstName, @LastName, @Specialization, @ContactNumber)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                    command.Parameters.AddWithValue("@LastName", doctor.LastName);
                    command.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    command.Parameters.AddWithValue("@ContactNumber", doctor.ContactNumber);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int doctorId)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "DELETE FROM Doctors WHERE DoctorId = @DoctorId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Doctor> GetAll()
        {
            var doctors = new List<Doctor>();
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Doctors";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var doctor = new Doctor
                        {
                            DoctorId = (int)reader["DoctorId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString()
                        };
                        doctors.Add(doctor);
                    }
                }
            }
            return doctors;
        }

        public Doctor GetById(int doctorId)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Doctors WHERE DoctorId = @DoctorId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Doctor
                        {
                            DoctorId = (int)reader["DoctorId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void Update(Doctor doctor)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "UPDATE Doctors SET FirstName = @FirstName, LastName = @LastName, " +
                            "Specialization = @Specialization, ContactNumber = @ContactNumber WHERE DoctorId = @DoctorId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                    command.Parameters.AddWithValue("@FirstName", doctor.FirstName);
                    command.Parameters.AddWithValue("@LastName", doctor.LastName);
                    command.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    command.Parameters.AddWithValue("@ContactNumber", doctor.ContactNumber);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
