using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace webapi
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string DBName { get; set; } = null!;
    }
}
