using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.util
{
    public static class DatabaseInitializer
    {
        // Method to init the DB by creating required tables if they don't exist
        public static void Initialize()
        {
            using (var connection = DBConnection.GetConnection()) {
                if (connection == null)
                {
                    Console.WriteLine("DB connection failed. Cannot initialize the DB.");
                    return;
                }
                try
                {
                    // SQL script to create tables if they do not already exist
                    string createTablesSql = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Patients' AND xtype='U')
                        CREATE TABLE Patients (
                            PatientId INT PRIMARY KEY IDENTITY(1,1),
                            FirstName NVARCHAR(50),
                            LastName NVARCHAR(50),
                            DateOfBirth DATE,
                            Gender NVARCHAR(10),
                            ContactNumber NVARCHAR(20),
                            Address NVARCHAR(200)
                        );

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Doctors' AND xtype='U')
                        CREATE TABLE Doctors (
                            DoctorId INT PRIMARY KEY IDENTITY(1,1),
                            FirstName NVARCHAR(50),
                            LastName NVARCHAR(50),
                            Specialization NVARCHAR(100),
                            ContactNumber NVARCHAR(20)
                        );

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Appointments' AND xtype='U')
                        CREATE TABLE Appointments (
                            AppointmentId INT PRIMARY KEY IDENTITY(1,1),
                            PatientId INT FOREIGN KEY REFERENCES Patients(PatientId),
                            DoctorId INT FOREIGN KEY REFERENCES Doctors(DoctorId),
                            AppointmentDate DATE,
                            Description NVARCHAR(500)
                        );
                    ";

                    using (SqlCommand command = new SqlCommand(createTablesSql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    //Console.WriteLine("DB initialized successfully.");
                }
                catch (Exception e) {
                    Console.WriteLine($"Error during Db initialization: {e.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
