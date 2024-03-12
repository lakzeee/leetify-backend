namespace LeetifyGraphQL.Entities;

public class Question
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public bool IsPremium { get; set; }
    public Difficulty Difficulty { get; set; }
    public double Frequency { get; set; }
    public string? Url { get; set; }
    public string? Accepted { get; set; }
    public string? Submissions { get; set; }
    public string? Companies { get; set; }
    public string? RelatedTopics { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public string? SimilarQuestions { get; set; }
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}