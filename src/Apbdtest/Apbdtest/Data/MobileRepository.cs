using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ApbdTest.Models;


namespace ApbdTest.Data
{
    public class MobileRepository
    {
        private readonly string _connectionString;

        public MobileRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Client CreateOrUpdateClient(Client client)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "IF EXISTS (SELECT 1 FROM Clients WHERE Email = @Email) " +
                             "UPDATE Clients SET FullName = @FullName, City = @City WHERE Email = @Email " +
                             "ELSE " +
                             "INSERT INTO Clients (FullName, Email, City) VALUES (@FullName, @Email, @City)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", client.FullName);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@City", client.City ?? (object)DBNull.Value); // Handle NULL for City
                    cmd.ExecuteNonQuery();
                }
            }
            return client;
        }

        public Client GetClientByMobileNumber(string mobileNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT FullName, Email, City FROM Clients WHERE MobileNumber = @MobileNumber";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Client
                            {
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                City = reader["City"].ToString(),
                                MobileNumber = mobileNumber
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool DeleteClientByMobileNumber(string mobileNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Clients WHERE MobileNumber = @MobileNumber";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
            }
        }
    }
}
