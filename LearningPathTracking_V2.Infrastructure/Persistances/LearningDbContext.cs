using System;
using System.Collections.Generic;
using LearningPathTracking_V2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LearningPathTracking_V2.Infrastructure.Persistances;

public partial class LearningDbContext : DbContext
{
    public LearningDbContext(DbContextOptions<LearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LearningTopic> LearningTopics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LearningTopic>(entity =>
        {
            entity.ToTable("LearningTopic");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
