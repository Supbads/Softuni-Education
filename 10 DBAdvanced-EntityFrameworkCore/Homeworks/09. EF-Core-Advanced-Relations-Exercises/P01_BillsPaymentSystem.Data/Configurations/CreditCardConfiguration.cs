namespace P01_BillsPaymentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(cc => cc.CreditCardId);

            builder.Property(cc => cc.Limit).IsRequired();
            builder.Property(cc => cc.MoneyOwed).IsRequired();
            builder.Property(cc => cc.ExpirationDate).IsRequired();

            builder.Ignore(cc => cc.PaymentMethodId);
            builder.Ignore(cc => cc.LimitLeft);
        }
    }
}