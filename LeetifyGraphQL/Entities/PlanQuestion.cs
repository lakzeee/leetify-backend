namespace LeetifyGraphQL.Entities;

public class PlanQuestion
{
    public Guid Id { get; set; }
    public Question? Question { get; set; }
    public string? GroupName { get; set; }
    public int GroupRank { get; set; }
    public int GroupOrder { get; set; }
    public Plan? Plan { get; set; }
    public Guid? PlanId { get; set; }
}