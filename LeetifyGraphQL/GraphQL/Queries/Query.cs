using LeetifyGraphQL.Data;
using LeetifyGraphQL.Entities;

namespace LeetifyGraphQL.GraphQL.Queries;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Question> GetQuestions([Service] LeetifyDbContext context)
    {
        return context.Questions;
    }

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Plan> GetPlans([Service] LeetifyDbContext context)
    {
        return context.Plans;
    }
}