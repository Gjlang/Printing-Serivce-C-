using System;
using System.Data;
using System.Data.SqlClient;

namespace OOP_GROUP_29
{
    internal class Inputdata
    {
        private readonly string connectionString = "Data Source=LAPTOP-13KUA0E2\\SQLEXPRESS;Initial Catalog=OOP_DATABASE_G29;Integrated Security=True;TrustServerCertificate=True";

        public void AddRequest(string bookingID, string name, int quantity, string serviceType, double fees, string status, DateTime date, string confirmation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Requests] (BookingID, Name, Quantity, ServiceType, Fees, Status, Date, Confirmation) VALUES (@BookingID, @Name, @Quantity, @ServiceType, @Fees, @Status, @Date, @Confirmation)", con))
                    {
                        cmd.Parameters.Add("@BookingID", SqlDbType.NVarChar).Value = bookingID;
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@ServiceType", serviceType);
                        cmd.Parameters.AddWithValue("@Fees", fees);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = date;
                        cmd.Parameters.Add("@Confirmation", confirmation);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }


    }
}
