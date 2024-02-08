using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configuration;

public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder
            .ToTable("User_Skills")
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Skills)
            .HasForeignKey(p => p.IdUser);
        
    }
}