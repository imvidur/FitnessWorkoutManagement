using Microsoft.EntityFrameworkCore;
using FitnessWorkoutMgmnt.Models;


namespace FitnessWorkoutMgmnt.Data
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutCategory> WorkoutCategories { get; set; }
        
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProgressTracking> ProgressTrackings { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<FitnessClass> FitnessClass { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<UserChallenge> UserChallenges { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Report> Reports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Workout Relationship (One-to-Many)
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Prevent cascade delete

            // Workout-WorkoutPlan Relationship (One-to-Many)
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Plan)
                .WithMany()
                .HasForeignKey(w => w.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            // User-Message Relationship (One-to-Many for Sender and Receiver)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // User-Report Relationship (One-to-Many)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // User-ProgressTracking Relationship (One-to-Many)
            modelBuilder.Entity<ProgressTracking>()
                .HasOne(pt => pt.User)
                .WithMany(u => u.ProgressTrackings)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User-MealPlans Relationship (One-to-Many)
            modelBuilder.Entity<MealPlan>()
                .HasOne(mp => mp.User)
                .WithMany(u => u.MealPlans)
                .HasForeignKey(mp => mp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // User-FitnessClasses Relationship (One-to-Many)
            modelBuilder.Entity<FitnessClass>()
                     .HasOne(fc => fc.Trainer)
                     .WithMany(u => u.ClassesAsTrainer)
                     .HasForeignKey(fc => fc.TrainerId)
                     .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FitnessClass>()
                .HasOne(fc => fc.User)
                .WithMany(u => u.ClassesAsUser)
                .HasForeignKey(fc => fc.UserId)
                .OnDelete(DeleteBehavior.NoAction);


            // User-Challenges Relationship (One-to-Many)
            modelBuilder.Entity<Challenge>()
                .HasOne(c => c.User)
                .WithMany(u => u.Challenges)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserChallenge>()
                .HasKey(uc => new { uc.UserId, uc.ChallengeId });

            modelBuilder.Entity<UserChallenge>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChallenges)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<Payment>()
                   .Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<UserChallenge>()
                .HasOne(uc => uc.Challenge)
                .WithMany(c => c.UserChallenges)
                .HasForeignKey(uc => uc.ChallengeId);


            // Define Primary Keys
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Workout>().HasKey(w => w.WorkoutId);
            modelBuilder.Entity<WorkoutPlan>().HasKey(wp => wp.PlanId);
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
            modelBuilder.Entity<Report>().HasKey(r => r.ReportId);
            modelBuilder.Entity<ProgressTracking>().HasKey(pt => pt.ProgressId);
            modelBuilder.Entity<MealPlan>().HasKey(mp => mp.MealPlanId);
            modelBuilder.Entity<FitnessClass>().HasKey(fc => fc.ClassId);
            modelBuilder.Entity<Challenge>().HasKey(c => c.ChallengeId);
            modelBuilder.Entity<UserChallenge>()
                .HasKey(uc => new { uc.UserId, uc.ChallengeId });


        }


    }
}
