using LeetifyGraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeetifyGraphQL.Data.Repositories.Impl;

public class QuestionRepository : IQuestionRepository
{
    private readonly LeetifyDbContext _context;

    public QuestionRepository(LeetifyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetQuestionsByIdsAsync(List<int> questionIds)
    {
        IQueryable<Question> query = _context.Questions;
        return await query.Where(q => questionIds.Contains(q.Id)).ToListAsync();
    }
}