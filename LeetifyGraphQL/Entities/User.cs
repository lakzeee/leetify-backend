using System.ComponentModel.DataAnnotations;

namespace LeetifyGraphQL.Entities;

public class User
{
    [Key]public required string Sub { get; set; }
    public required string ProfileName { get; set; }
    public required string Email { get; set; }
    public required string Image { get; set; }
    public required string AuthProvider { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Plan>? CreatedPlans { get; set; }
    public List<Plan>? SavedPlans { get; set; }
}