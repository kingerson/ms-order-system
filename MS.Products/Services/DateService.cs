using Microsoft.Extensions.Configuration;
using System;

namespace MS.Products.Services
{
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
