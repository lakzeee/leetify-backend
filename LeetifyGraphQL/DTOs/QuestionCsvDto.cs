using CsvHelper.Configuration.Attributes;

namespace LeetifyGraphQL.DTOs;

public class QuestionCsvDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    [Name("is_premium")]
    public required string IsPremium { get; set; }
    [Name("difficulty")]
    public required string DifficultyString { get; set; }
    public required string SolutionLink { get; set; }
    public double AcceptanceRate { get; set; }
    public double Frequency { get; set; }
    public required string Url { get; set; }
    public int DiscussCount { get; set; }
    public required string Accepted { get; set; }
    public required string Submissions { get; set; }
    public required string Companies { get; set; }
    [Name("related_topics")]
    public string? RelatedTopics { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
    public double Rating { get; set; }
    public bool AskedByFaang { get; set; }
    [Name("similar_questions")]
    public string? SimilarQuestions { get; set; }
}