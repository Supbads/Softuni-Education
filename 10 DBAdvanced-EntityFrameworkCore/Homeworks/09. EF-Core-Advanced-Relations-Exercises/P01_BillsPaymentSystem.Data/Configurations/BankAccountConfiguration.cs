namespace P01_BillsPaymentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(b => b.BankAccountId);

            builder.Property(b => b.Balance).IsRequired();
            builder.Property(b => b.BankName).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(b => b.SwiftCode).HasMaxLength(20).IsUnicode(false).IsRequired();

            builder.Ignore(b => b.PaymentMethodId);
        }
    }
}