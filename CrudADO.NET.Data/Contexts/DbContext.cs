using CrudADO.NET.Domain.Customs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GenericCrudADO.NET.Data
{
    internal sealed class DbContext
    {
        private SqlConnection _connection;

        public DbContext()
        {
            _connection = new SqlConnection(Constants.TESTDB_CONNECTION_STRING);
        }

        public async Task<SqlDataReader> ConnectionAsync(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);

            if (_connection.State == ConnectionState.Open)
                _connection.Close();
            else
            {
                _connection.Open();
                if (query.Contains("SELECT"))
                {
                    return await command.ExecuteReaderAsync();
                }
                else
                {
                    await command.ExecuteNonQueryAsync();
                }
                _connection.Close();
            }

            return null;
        }
    }
}
