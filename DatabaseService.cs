using System.Data;
using System.Dynamic;
using Npgsql;

namespace BackForFrontVue2.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<dynamic>> GetUserLanguageSkills(string username)
        {
            var result = new List<dynamic>();

            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Creează comanda pentru a apela procedura stocată
                var command = new NpgsqlCommand("SELECT * FROM public.getUserLanguageSkills(@username);", connection);
                command.Parameters.AddWithValue("username", username);

                // Execută comanda și citește rezultatele
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new ExpandoObject() as IDictionary<string, Object>;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader.GetName(i), reader.GetValue(i));
                        }

                        result.Add(row);
                    }
                }
            }

            return result;
        }
    }
}