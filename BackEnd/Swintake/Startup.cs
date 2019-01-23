using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NJsonSchema;
using NSwag.AspNetCore;
using SecuredWebApi.Services;
using SecuredWebApi.Services.Security;
using Swintake.domain.Data;
using Swintake.domain.Users;
using Swintake.infrastructure.Exceptions;
using Swintake.infrastructure.Logging;
using Swintake.services.Users;
using Swintake.services.Users.Security;
using System;
using Swintake.api.Helpers.Campaigns;
using Swintake.domain;
using Swintake.domain.Campaigns;
using Swintake.services.Campaigns;
using Swintake.api.Helpers.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swintake.domain.Candidates;
using Swintake.services.Candidates;
using Swintake.api.Helpers.Candidates;
using Swintake.domain.JobApplications;
using Swintake.services.JobApplications;
using Swintake.api.Helpers.JobApplications;

namespace Swintake.api
{
    public class Startup
    {

        private string _connectionstring = ".\\SQLExpress";

        public Startup(IConfiguration configuration, ILoggerFactory logFactory)
        {
            var foo = Environment.GetEnvironmentVariable("LocalSql", EnvironmentVariableTarget.User);
            if (foo != null && foo.Equals("SqlServer"))
            {
                _connectionstring = "(LocalDb)\\MSSQLLocalDb";
            }

            Configuration = configuration;
            ApplicationLogging.LoggerFactory = logFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSwintakeServices(services);
        }

        protected virtual DbContextOptions<SwintakeContext> ConfigureDbContext()
        {
            return new DbContextOptionsBuilder<SwintakeContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=Swintake;Integrated Security=True;")
                .Options;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            ConfigureSwintake(app, env, builder);

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Swintake API";
                    document.Info.Description = "An API for Swintake";
                };
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }

        protected virtual void ConfigureSwintakeServices(IServiceCollection services)
        {
            services.AddSingleton(ConfigureDbContext());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<Hasher>();
            services.AddSingleton<Salter>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<SwintakeContext>();
            services.Configure<Secrets>(Configuration);
            services.AddScoped<UserMapper>();
            services.AddScoped<IRepository<Campaign>, CampaignRepository>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<CampaignMapper>();
            services.AddScoped<IRepository<Candidate>, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<CandidateMapper>();
            services.AddScoped<IRepository<JobApplication>, JobApplicationRepository>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<JobApplicationMapper>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
            services.AddCors();

            services
                .AddAuthorization()
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(GetSecretKey()),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
        }

        private byte[] GetSecretKey()
        {
            var secretKey = Configuration["SuperStrongPassword"];

            return Encoding.ASCII.GetBytes(secretKey);
        }


        protected virtual void ConfigureSwintake(IApplicationBuilder app, IHostingEnvironment env, ConfigurationBuilder builder)
        {

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            builder
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
