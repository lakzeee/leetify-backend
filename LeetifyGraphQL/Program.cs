using LeetifyGraphQL.Data;
using LeetifyGraphQL.Data.Repositories;
using LeetifyGraphQL.Data.Repositories.Impl;
using LeetifyGraphQL.GraphQL.Mutations;
using LeetifyGraphQL.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<LeetifyDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection"));
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

DbInitializer.InitDb(app);
app.MapGraphQL();
app.Run();