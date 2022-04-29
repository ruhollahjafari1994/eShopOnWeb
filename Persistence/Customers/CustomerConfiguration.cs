//using Microsoft.EntityFrameworkCore;

//namespace Persistence.Customers
//{
//	internal class CustomerConfiguration : object,
//			Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Aggregates.Customers.Customer>
//	{
//		public CustomerConfiguration() : base()
//		{
//		}

//		public void Configure
//			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Aggregates.Customers.Customer> builder)
//		{
//			builder
//				// using Microsoft.EntityFrameworkCore;
//				.ToTable(name: "Customers")
//				;

//			//builder
//			//	.Property(p => p.EmailAddress)
//			//	.HasMaxLength(maxLength: 255)
//			//	.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
//			//	.HasConversion(p => p.Value, p => Domain.SharedKernel.EmailAddress.Create(p).Value)
//			//	;

//			builder
//				.OwnsOne(p => p.FullName, p =>
//				{
//					// **************************************************
//					p.HasOne(pp => pp.Gender)
//						.WithMany()
//						.HasForeignKey(foreignKeyPropertyNames: "GenderId")
//						.IsRequired(required: true)
//						;

//					// For Fixing Field Name in Database: FullName_GenderId -> GenderId
//					p.Property<long>("GenderId").HasColumnName("GenderId");
//					// **************************************************

//					p.Property(pp => pp.FirstName)
//						.HasColumnName(nameof(Domain.SharedKernel.FullName.FirstName))
//						.HasMaxLength(maxLength: 20)
//						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
//						;

//					p.Property(pp => pp.LastName)
//						.HasColumnName(nameof(Domain.SharedKernel.FullName.LastName))
//						.HasMaxLength(maxLength: 30)
//						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
//						;
//				});
//		}
//	}
//}
