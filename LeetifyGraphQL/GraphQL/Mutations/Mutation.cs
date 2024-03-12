using System.Diagnostics;
using AutoMapper;
using LeetifyGraphQL.Data;
using LeetifyGraphQL.Entities;
using LeetifyGraphQL.GraphQL.Types.Inputs;

namespace LeetifyGraphQL.GraphQL.Mutations;

public class Mutation
{
    private readonly IMapperBase _mapper;
    private readonly LeetifyDbContext _context;

    public Mutation(IMapperBase mapper, LeetifyDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Plan> CreatePlan(CreatePlanInput input)
    {
        var plan = _mapper.Map<CreatePlanInput, Plan>(input);
        plan.PlanQuestions = new List<PlanQuestion>();
        Debug.Assert(input.PlanQuestions != null, "input.PlanQuestions != null");
        foreach (var pqInput in input.PlanQuestions)
        {
            var question = await _context.Questions.FindAsync(pqInput.QuestionId);
            if (question == null) continue;

            var planQuestion = _mapper.Map<PlanQuestion>(pqInput);
            planQuestion.Question = question;
            planQuestion.Plan = plan;
            plan.PlanQuestions.Add(planQuestion);
        }

        await _context.SaveChangesAsync();

        return plan;
    }
}