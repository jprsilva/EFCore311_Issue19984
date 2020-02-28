using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore226.EFC
{
    public class LoggingFactory
    {
        public static Microsoft.Extensions.Logging.ILoggerFactory LoggerFactory { get; private set; }

        static LoggingFactory()
        {
            //  https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging
            //  Version 2.0
            LoggerFactory = new Microsoft.Extensions.Logging.LoggerFactory(new[]
            {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider(
                    (category, level) 
                    => category == Microsoft.EntityFrameworkCore.DbLoggerCategory.Database.Command.Name &&
                    level == LogLevel.Information
                    )
            });
        }
    }
}
