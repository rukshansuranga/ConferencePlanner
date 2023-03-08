using ConferencePlanner.GraphQL;
using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

var app = builder.Build();

app.UseRouting();

app.MapGet("/", () => "Hello World!");

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapGraphQL();
// });

app.MapGraphQL();

app.Run();
