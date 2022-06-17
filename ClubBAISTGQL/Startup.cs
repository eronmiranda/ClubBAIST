using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClubBAISTGQL
{
  public class Startup
  {
    private readonly IConfiguration Configuration;
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
      (Configuration.GetConnectionString("CommandDBConnectionString")));

      services
          .AddGraphQLServer()
          .AddQueryType<Query>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseWebSockets();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGraphQL();
      });
    }
  }
}
