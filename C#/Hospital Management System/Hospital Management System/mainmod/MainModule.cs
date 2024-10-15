using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.dao.interfaces;
using Hospital_Management_System.dao.services;
using Hospital_Management_System.util;

namespace Hospital_Management_System.mainmod
{
    public class MainModule
    {
        // Main entry point for application
        static void Main(string[] args)
        {
            // Initializes the database by creating necessary tables
            DatabaseInitializer.Initialize();

            // creating instance of HospitalServiceImpl to handle multiple operations
            IHospitalServiceImpl hsi = new HospitalServiceImpl();
            bool exit = false; // Variable to control the app exit

            while (!exit) {

                // Display the menu for user inputs
                Console.WriteLine("\n===== Hospital Management System =====");
                Console.WriteLine("1. Schedule Appointment");
                Console.WriteLine("2. Update Appointment");
                Console.WriteLine("3. Cancel Appointment");
                Console.WriteLine("4. View Appointment by ID");
                Console.WriteLine("5. View Appointments for Patient");
                Console.WriteLine("6. View Appointments for Doctor");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number from the menu.");
                    continue;
                }

                // handling menu choices
                switch (choice)
                {
                    case 1:
                        hsi.ScheduleAppointment();    // Schedules a new appointment
                        break;
                    case 2:
                        hsi.UpdateAppointment();      // Updates an existing appointment
                        break;
                    case 3:
                        hsi.CancelAppointment();      // Cancels an appointment
                        break;
                    case 4:
                        hsi.ViewAppointmentById();    // View an appointment by its ID
                        break;
                    case 5:
                        hsi.ViewAppointmentsForPatient();  // View all appointments for a specific patient (by using patient ID)
                        break;
                    case 6:
                        hsi.ViewAppointmentsForDoctor();   // View all appointments for a specific doctor (by doctor ID)
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            Console.WriteLine("Bye :)");  // final exit message
        }
    }
}
