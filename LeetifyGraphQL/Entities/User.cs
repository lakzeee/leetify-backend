using System.ComponentModel.DataAnnotations;

namespace LeetifyGraphQL.Entities;

public class User
{
    [Key] public string Sub { get; set; }
    public string ProfileName { get; set; }
    public string Email { get; set; }
    public string Image { get; set; }
    public string AuthProvider { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Plan> CreatedPlans { get; set; }
    public List<Plan> SavedPlans { get; set; }
}