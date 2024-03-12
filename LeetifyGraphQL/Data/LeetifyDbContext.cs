using LeetifyGraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeetifyGraphQL.Data;

public class LeetifyDbContext : DbContext
{
    public LeetifyDbContext(DbContextOptions options) : base(options)
    {
    }

    public required DbSet<User> Users { get; set; }
    public required DbSet<Plan> Plans { get; set; }
    public required DbSet<PlanQuestion> PlanQuestions { get; set; }
    public required DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.CreatedPlans)
            .WithOne(p => p.CreatedByUser)
            .HasForeignKey(p => p.CreatedByUserSub);
        modelBuilder.Entity<User>()
            .HasMany(u => u.SavedPlans)
            .WithMany(p => p.SavedByUsers);
        modelBuilder.Entity<PlanQuestion>()
            .HasOne(u => u.Question)
            .WithMany();
        modelBuilder.Entity<Plan>()
            .HasMany(p => p.PlanQuestions)
            .WithOne(pq => pq.Plan)
            .HasForeignKey(pq => pq.PlanId);
    }
}