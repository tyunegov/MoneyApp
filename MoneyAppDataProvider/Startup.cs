using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;

namespace MoneyAppDataProvider
{
    public class Startup:MoneyApp.Startup
    {
        public Startup(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            string connectionString = @"Server=Data Source=DESCKTOP\SQLEXPRESS;Initial Catalog=MoneyApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddTransient<ITransactionRepository, TransactionRepository>(provider => new TransactionRepository(connectionString));
            services.AddControllersWithViews();
        }
    }
}
