using System;
using System.Data;
using System.Data.SqlClient;

public class DatabaseConnection
{
    private SqlConnection connection;
    private string connectionString = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True";

    public DatabaseConnection()
    {
        connection = new SqlConnection(connectionString);
    }

    public void OpenConnection()
    {
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
    }

    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public DataTable ExecuteQuery(string query)
    {
        OpenConnection();
        DataTable dataTable = new DataTable();

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
        }

        CloseConnection();
        return dataTable;
    }
}
