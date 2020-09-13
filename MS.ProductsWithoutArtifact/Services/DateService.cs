using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MS.ProductsWithoutArtifact.Services
{
    [ExcludeFromCodeCoverage]
    public class DateService : IDateService
    {
        private IConfiguration _configuration { get; }
        public DateService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DateTime GetDate()
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZone"]);
            DateTime cstTime = TimeZoneInfo.ConvertTime(DateTime.Now, cstZone);
            return cstTime;
        }
    }
}
