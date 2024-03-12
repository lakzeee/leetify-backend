namespace LeetifyGraphQL.Entities;

public class Plan
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Tags { get; set; }
    public required string Description { get; set; }
    public required bool IsPublic { get; set; }
    public User? CreatedByUser { get; set; }
    public string? CreatedByUserSub { get; set; }
    public List<User>? SavedByUsers { get; set; } = [];
    public List<PlanQuestion>? PlanQuestions { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}