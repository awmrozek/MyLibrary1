using System;

namespace MyLibrary1;

public class Class1
{
    async public void MyMethod ()
    {
        var connectionString = Environment.GetEnvironmentVariable("PSQL_CONNECTION_STRIN"); ;
        await using var dataSource = Npgsql.NpgsqlDataSource.Create(connectionString);


        // Retrieve all rows
        await using (var cmd = dataSource.CreateCommand("SELECT * FROM public.consolidated_communication_view;"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                Console.WriteLine(reader.GetString(0) + " " + reader.GetDateTime(1) + " " + reader.GetString(2));
            }
        }
    }
}
