using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Habanero.DB;

namespace labs3
{
    public class Client_rep_DB
    {


        private readonly DatabaseConnection _databaseConnection;

        public Client_rep_DB()
        {
            _databaseConnection = DatabaseConnection.Instance;
        }
        public void Load()
        {
            //
        }

        public void Save()
        {
            //
        }

        public Client GetClientById(int id)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Clients WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8)
                        );
                    }
                }
            }
            return null;
        }

        public List<Client> GetK_N_ShortList(int k, int n)
        {
            var clients = new List<Client>();
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Clients ORDER BY Id OFFSET @n ROWS FETCH NEXT @k ROWS ONLY", connection);
                command.Parameters.AddWithValue("@n", n);
                command.Parameters.AddWithValue("@k", k);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetString(8)
                        ));
                    }
                }
            }
            return clients;
        }

        public void AddClient(Client client)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Clients (LastName, FirstName, MiddleName, Phone, Email, Birthday, Passport, Comment) OUTPUT INSERTED.Id VALUES (@lastName, @firstName, @middleName, @phone, @email, @birthday, @passport, @comment)", connection);
                command.Parameters.AddWithValue("@lastName", client.GetLastName());
                command.Parameters.AddWithValue("@firstName", client.GetFirstName());
                command.Parameters.AddWithValue("@middleName", client.GetMiddleName());
                command.Parameters.AddWithValue("@phone", client.GetPhone());
                command.Parameters.AddWithValue("@email", client.GetEmail());
                command.Parameters.AddWithValue("@birthday", client.GetBirthday());
                command.Parameters.AddWithValue("@passport", client.GetPassport());
                command.Parameters.AddWithValue("@comment", client.GetComment());

                int newId = (int)command.ExecuteScalar();
                // Здесь можно обновить объект клиента с новым ID если нужно
            }
        }

        public void UpdateClient(Client client)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Clients SET LastName=@lastName, FirstName=@firstName, MiddleName=@middleName, Phone=@phone, Email=@email, Birthday=@birthday, Passport=@passport, Comment=@comment WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@id", client.getId());
                command.Parameters.AddWithValue("@lastName", client.GetLastName());
                command.Parameters.AddWithValue("@firstName", client.GetFirstName());
                command.Parameters.AddWithValue("@middleName", client.GetMiddleName());
                command.Parameters.AddWithValue("@phone", client.GetPhone());
                command.Parameters.AddWithValue("@email", client.GetEmail());
                command.Parameters.AddWithValue("@birthday", client.GetBirthday());
                command.Parameters.AddWithValue("@passport", client.GetPassport());
                command.Parameters.AddWithValue("@comment", client.GetComment());

                command.ExecuteNonQuery();
            }
        }

        public void DeleteClient(int id)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Clients WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public int GetCount()
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Clients", connection);
                return (int)command.ExecuteScalar();
            }
        }
    }
}
