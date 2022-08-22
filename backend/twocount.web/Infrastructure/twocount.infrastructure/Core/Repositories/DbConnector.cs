using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace twocount.infrastructure.Core.Repositories;

public abstract class DbConnector
{
    private readonly IConfiguration _configuration;

    protected DbConnector(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("PostgresqlDb");
        return new NpgsqlConnection(connectionString);
    }
}