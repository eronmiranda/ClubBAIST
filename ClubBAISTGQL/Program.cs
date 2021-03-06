using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using ClubBAISTGQL.GraphQL.Members;
using ClubBAISTGQL.GraphQL.Memberships;
using ClubBAISTGQL.GraphQL.MemberTeeTimes;
using ClubBAISTGQL.GraphQL.Events;
using ClubBAISTGQL.GraphQL.RestrictedTimes;
using ClubBAISTGQL.GraphQL.StandingTeeTimes;
using ClubBAISTGQL.GraphQL.TeeTimes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.
  AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services
  .AddGraphQLServer()
  .AddQueryType<Query>()
  .AddMutationType<Mutation>()
  .AddSubscriptionType<Subscription>()
  .AddType<EventType>()
  .AddType<MemberType>()
  .AddType<MembershipType>()
  .AddType<MemberTeeTimeType>()
  .AddType<RestrictedTimeType>()
  .AddType<StandingTeeTimeType>()
  .AddType<TeeTimeType>()
  .AddFiltering()
  .AddSorting()
  .AddInMemorySubscriptions()
  .AddErrorFilter<GraphQLErrorFilter>(); // Used for testing purposes only.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.MapGet("/", () => "Welcome to Club BAIST GraphQL project");

app.UseWebSockets();

app.UseRouting();

app.MapGraphQL();

app.UseGraphQLVoyager(new VoyagerOptions()
{
  GraphQLEndPoint = "/graphql"
});

app.Run();