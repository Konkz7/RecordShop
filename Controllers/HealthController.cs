using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using RecordShop.Data;
using Microsoft.IdentityModel.Tokens;

namespace RecordShop.Controllers
{
    
    public class HealthCheck : IHealthCheck
    {
        private MyDbContext _dbContext;
        public HealthCheck(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (_dbContext.Albums.IsNullOrEmpty())
            {
                return HealthCheckResult.Unhealthy("Unable to return Albums!");
            }
            else
            {
                return HealthCheckResult.Healthy("Everything should be fine!");
            }
        }
    }
}
