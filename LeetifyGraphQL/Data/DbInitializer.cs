using System.Globalization;
using AutoMapper;
using CsvHelper;
using LeetifyGraphQL.DTOs;
using LeetifyGraphQL.Entities;
using Microsoft.EntityFrameworkCore;
using Path = System.IO.Path;

namespace LeetifyGraphQL.Data;

public static class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var mapper = app.Services.GetRequiredService<IMapper>();
        SeedData(scope.ServiceProvider.GetService<LeetifyDbContext>() ?? throw new InvalidOperationException(), mapper);
    }

    private static void SeedData(LeetifyDbContext context, IMapper mapper)
    {
        context.Database.Migrate();
        if (!context.Questions.Any())
        {
            var csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data/leetcode_problem.csv");
            if (!File.Exists(csvFilePath)) throw new DirectoryNotFoundException($"Can't find {csvFilePath}");

            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null, // Ignore header validation issues
                MissingFieldFound = null, // Optionally ignore missing fields
                PrepareHeaderForMatch = args => args.Header.Trim().ToLower() // Adjust to match property naming
            };
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, config);


            var records = csv.GetRecords<QuestionCsvDto>().ToList();
            var questions = mapper.Map<List<Question>>(records);
            context.AddRange(questions);
            context.SaveChanges();
        }

        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new()
                {
                    Sub = "user1",
                    ProfileName = "User One",
                    Email = "userone@example.com",
                    Image = "image1.jpg",
                    AuthProvider = "google",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new()
                {
                    Sub = "user2",
                    ProfileName = "User Two",
                    Email = "usertwo@example.com",
                    Image = "image2.jpg",
                    AuthProvider = "github",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        if (!context.Plans.Any())
        {
            var userSubs = context.Users.Select(u => u.Sub).ToList();
            var questions = context.Questions.Take(2).ToList();

            var plans = new List<Plan>
            {
                new()
                {
                    Name = "Plan One",
                    Tags = "Algorithms, Data Structures",
                    Description = "Plan description here",
                    IsPublic = true,
                    CreatedByUserSub = userSubs[0],
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanQuestions = new List<PlanQuestion>
                    {
                        new() { Question = questions[0], GroupName = "Basics", GroupRank = 1, GroupOrder = 1 },
                        new() { Question = questions[1], GroupName = "Intermediate", GroupRank = 2, GroupOrder = 2 }
                    }
                },
                new()
                {
                    Name = "Plan Two",
                    Tags = "System Design",
                    Description = "Another plan description",
                    IsPublic = false,
                    CreatedByUserSub = userSubs[1],
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanQuestions = new List<PlanQuestion>
                    {
                        new() { Question = questions[0], GroupName = "Concepts", GroupRank = 1, GroupOrder = 1 },
                        new() { Question = questions[1], GroupName = "Practical", GroupRank = 2, GroupOrder = 2 }
                    }
                }
            };
            context.Plans.AddRange(plans);
            context.SaveChanges();
        }
    }
}