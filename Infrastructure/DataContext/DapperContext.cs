using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly IConfiguration? _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration=configuration;
    }

    public NpgsqlConnection Connection()
    {
       return new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection"));
    }

}
