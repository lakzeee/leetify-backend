using AutoMapper;
using HotChocolate.AspNetCore;
using LeetifyGraphQL.Data.Repositories;
using LeetifyGraphQL.Entities;
using LeetifyGraphQL.GraphQL.Types.Inputs;
using LeetifyGraphQL.Helpers;

namespace LeetifyGraphQL.GraphQL.Mutations;

public class Mutation(
    IMapper mapper,
    IPlanRepository planRepository,
    IQuestionRepository questionRepository)
{
    public async Task<Plan> CreatePlan(CreatePlanInput input)
    {
        var plan = mapper.Map<CreatePlanInput, Plan>(input);
        var questions =
            await questionRepository.GetQuestionsByIdsAsync(input.PlanQuestions.Select(pq => pq.QuestionId).ToList());
        var idToQuestionDic = questions.ToDictionaryById(q => q.Id);

        foreach (var planQuestionInput in input.PlanQuestions)
        {
            var newPlanQuestion = mapper.Map<PlanQuestionInput, PlanQuestion>(planQuestionInput);
            newPlanQuestion.Question = idToQuestionDic[planQuestionInput.QuestionId];
            plan.PlanQuestions.Add(newPlanQuestion);
        }

        var result = await planRepository.SaveAsync(plan);
        return result ? plan : throw new GraphQLRequestException("Failed to create plan");
    }
}