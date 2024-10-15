using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.dao.interfaces;
using Hospital_Management_System.entity;
using Hospital_Management_System.util;

namespace Hospital_Management_System.dao.repositories
{
    public class PatientRepository:IPatientRepository
    {
        public void Add(Patient patient)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "INSERT INTO Patients (FirstName, LastName, DateOfBirth, Gender, ContactNumber, Address) " +
                            "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactNumber, @Address)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int patientId)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "DELETE FROM Patients WHERE PatientId = @PatientId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Patient> GetAll()
        {
            var patients = new List<Patient>();
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Patients";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var patient = new Patient
                        {
                            PatientId = (int)reader["PatientId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Gender = reader["Gender"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            Address = reader["Address"].ToString()
                        };
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }
        public Patient GetById(int patientId)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "SELECT * FROM Patients WHERE PatientId = @PatientId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Patient
                        {
                            PatientId = (int)reader["PatientId"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            Gender = reader["Gender"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            Address = reader["Address"].ToString()
                        };
                    }
                }
            }
            return null;
        }
        public void Update(Patient patient)
        {
            using (var connection = DBConnection.GetConnection())
            {
                var query = "UPDATE Patients SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, " +
                            "Gender = @Gender, ContactNumber = @ContactNumber, Address = @Address WHERE PatientId = @PatientId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patient.PatientId);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                    command.Parameters.AddWithValue("@Address", patient.Address);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
