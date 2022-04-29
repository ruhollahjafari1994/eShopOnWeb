//using Microsoft.EntityFrameworkCore;

//namespace Persistence.Companies
//{
//	internal class CompanyConfiguration : object,
//		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Aggregates.Companies.Company>
//	{
//		public CompanyConfiguration() : base()
//		{
//		}

//		public void Configure
//			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Aggregates.Companies.Company> builder)
//		{
//			builder
//				// using Microsoft.EntityFrameworkCore;
//				.ToTable(name: "Companies")
//				;

//			builder
//				.Property(current => current.Name)
//				.IsRequired(required: true)
//				.HasMaxLength(maxLength: 50)
//				;
//		}
//	}
//}
