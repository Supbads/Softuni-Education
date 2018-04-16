namespace P01_BillsPaymentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {

            builder.HasKey(pm => pm.Id);

            builder.HasIndex(pm => new { pm.UserId, pm.BankAccountId, pm.CreditCardId }).IsUnique();

            builder.HasOne(pm => pm.BankAccount)
                .WithOne(b => b.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);

            builder.HasOne(pm => pm.CreditCard)
                .WithOne(cc => cc.PaymentMethod)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId);

            builder.HasOne(pm => pm.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(pm => pm.UserId);
        }
    }
}
