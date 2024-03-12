namespace LeetifyGraphQL.GraphQL.Types.Inputs;

public class CreatePlanInput
{
    public required string Name { get; set; }
    public string? Tags { get; set; }
    public string? Description { get; set; }
    public bool IsPublic { get; set; }
    public string? CreatedByUserSub { get; set; }
    public List<PlanQuestionInput>? PlanQuestions { get; set; }
}

public class PlanQuestionInput
{
    public int QuestionId { get; set; }
    public required string GroupName { get; set; }
    public int GroupRank { get; set; }
    public int GroupOrder { get; set; }
}