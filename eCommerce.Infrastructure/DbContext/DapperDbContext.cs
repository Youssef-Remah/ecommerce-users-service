using eCommerce.Infrastructure.AppConfigurations;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IDbConnection _dbConnection;

    public IDbConnection DbConnection => _dbConnection;

    public DapperDbContext(IOptions<ConnectionStrings> options)
    {
        string _connectionString = options.Value
                                          .PostgresConnection
                                          .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
                                          .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

        _dbConnection = new NpgsqlConnection(_connectionString);
    }
}
