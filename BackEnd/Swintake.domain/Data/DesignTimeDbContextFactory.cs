using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Swintake.domain.Data
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<SwintakeContext>
    {
        private string _connectionstring = ".\\SQLExpress";


        public readonly ILoggerFactory efLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category.Contains("Command") && level == LogLevel.Information, true), });


        public DesignTimeDbContextFactory()
        {
        }

        public DesignTimeDbContextFactory(ILoggerFactory efLoggerFactory)
        {
            this.efLoggerFactory = efLoggerFactory;
        }


        public SwintakeContext CreateDbContext(string[] args)
        {
            var foo = Environment.GetEnvironmentVariable("LocalSql", EnvironmentVariableTarget.User);
            if (foo != null && foo.Equals("SqlServer"))
            {
                _connectionstring = "(LocalDb)\\MSSQLLocalDb";
            }


            var options = new DbContextOptionsBuilder<SwintakeContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=Swintake;Integrated Security=True;")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(efLoggerFactory)
                .Options;

            return new SwintakeContext(options, efLoggerFactory);
        }
    }
}
