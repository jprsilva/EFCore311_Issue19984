using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore311_Issue19984Test.EFC
{
    public class LoggingFactory
    {
        public static Microsoft.Extensions.Logging.ILoggerFactory LoggerFactory { get; private set; }

        static LoggingFactory()
        {
            //  https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging
            //  Version 3.0
            LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == Microsoft.EntityFrameworkCore.DbLoggerCategory.Database.Command.Name &&
                        level == LogLevel.Information)
                    .AddDebug();
            });
        }
    }
}
