using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.
  AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services
  .AddGraphQLServer()
  .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
  .AddQueryType<Query>()
  .AddFiltering()
  .AddSorting()
  .AddProjections()
  .AddErrorFilter<GraphQLErrorFilter>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.MapGet("/", () => "Welcome to Club BAIST GraphQL project");

app.UseRouting();

app.MapGraphQL();

app.UseGraphQLVoyager(new VoyagerOptions()
{
  GraphQLEndPoint = "/graphql"
});

app.Run();