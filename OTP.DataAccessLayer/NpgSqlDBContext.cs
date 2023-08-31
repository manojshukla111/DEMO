
using OTP.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using Microsoft.Extensions.Configuration;
using OTP.Model.Entity;

namespace DataAccessLayer;
public class NpgSqlDBContext : DbContext
{
    private readonly string connectionString;
    private readonly string ApplicationName;
    private readonly ILogger<NpgSqlDBContext> _logger;

    public NpgSqlDBContext(IConfiguration config, ILogger<NpgSqlDBContext> logger)
    {
        ApplicationName = config["ApplicationName"] ?? "TemplateAPI";
        connectionString = config["ConnectionStrings:" + ApplicationName] ?? "Host=localhost;Port=5432;Database=OTP_Database;Username=postgres;Password=manoj@1607";
        _logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            var connection = new NpgsqlConnection(connectionString);
            _logger.LogInformation("ConnectionStrings key : ConnectionStrings:" + ApplicationName);    
            optionsBuilder.UseNpgsql(connection);
            base.OnConfiguring(optionsBuilder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception in ApplicationDBContext => OnConfiguring");
            throw;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            modelBuilder.HasDefaultSchema(ApplicationName);
            base.OnModelCreating(modelBuilder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception in ApplicationDBContext => OnModelCreating");
            throw;
        }
    }

    public DbSet<OTPMaster> OTPMaster { get; set; }
}
