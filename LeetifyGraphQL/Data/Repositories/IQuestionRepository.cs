using LeetifyGraphQL.Entities;

namespace LeetifyGraphQL.Data.Repositories;

public interface IQuestionRepository
{
    public Task<List<Question>> GetQuestionsByIdsAsync(List<int> questionIds);
}