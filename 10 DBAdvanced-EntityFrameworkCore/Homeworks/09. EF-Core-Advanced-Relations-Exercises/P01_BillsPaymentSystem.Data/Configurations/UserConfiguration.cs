﻿namespace P01_BillsPaymentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.FirstName).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(u => u.Email).HasMaxLength(80).IsUnicode(false).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(25).IsUnicode(false).IsRequired();
            
        }
    }
}