using LeetifyGraphQL.Entities;

namespace LeetifyGraphQL.Data.Repositories;

public interface IPlanRepository
{
    public Task<bool> SaveAsync(Plan plan);
}