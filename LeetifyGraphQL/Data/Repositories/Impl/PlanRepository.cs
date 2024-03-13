using LeetifyGraphQL.Entities;

namespace LeetifyGraphQL.Data.Repositories.Impl;

public class PlanRepository : IPlanRepository
{
    private readonly LeetifyDbContext _context;

    public PlanRepository(LeetifyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveAsync(Plan plan)
    {
        _context.Plans.Add(plan);
        return await _context.SaveChangesAsync() > 0;
    }
}