using Auth.Application.Common.Interfaces;
using System;

namespace Auth.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
