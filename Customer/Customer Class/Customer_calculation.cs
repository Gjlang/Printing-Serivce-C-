using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    public class Customer_calculation
    {
        private readonly string connectionString = "Data Source=LAPTOP-13KUA0E2\\SQLEXPRESS;Initial Catalog=OOP_DATABASE_G29;Integrated Security=True;TrustServerCertificate=True";

        public List<Services> GetServices()
        {
            List<Services> services = new List<Services>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Services";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Services service = new Services
                                {
                                    ServiceID = reader["ServiceID"].ToString(), // Convert the ServiceID to a string
                                    ServiceType = reader["ServiceType"].ToString(), // Convert the ServiceType to a string
                                    Size = reader["Size"].ToString(), // Convert the Size to a string
                                    Fees = reader["Fees"] != DBNull.Value ? Convert.ToDouble(reader["Fees"]) : 0, // Handle DBNull and convert to double
                                    Discount = reader["Discount"] != DBNull.Value ? Convert.ToDouble(reader["Discount"]) : 0, // Handle DBNull and convert to double
                                };

                                services.Add(service);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL-related exceptions
                Console.WriteLine($"Database error: {ex.Message}");
                // Optionally log the error or rethrow the exception
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                // Optionally log the error or rethrow the exception
            }

            return services;
        }

        // Method to calculate the total cost of a service, considering a possible discount and quantity
        public double CalculateTotalCost(Services services, int quantity)
        {
            // Calculate the total fee for the given quantity
            double totalFees = services.Fees * quantity;
            // Calculate the discount amount
            double discount = totalFees * (services.Discount / 100);
            // Subtract the discount amount from the total fee to get the total cost
            double totalCost = totalFees - discount;
            // Return the total cost

            return totalCost;
        }
    }

    // This class represents a Service with various properties
    public class Services
    {
        // Properties of the Service class
        public string ServiceID { get; set; } // The ID of the service
        public string ServiceType { get; set; } // The type of the service
        public string Size { get; set; } // The size of the service
        public double Fees { get; set; } // The fee for the service
        public double Discount { get; set; } // The discount percent for the service
    }
}
