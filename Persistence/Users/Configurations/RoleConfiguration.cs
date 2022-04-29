using Microsoft.EntityFrameworkCore;

namespace Persistence.Users.Configurations
{
	internal class RoleConfiguration : object,
		Microsoft.EntityFrameworkCore
		.IEntityTypeConfiguration<Domain.Aggregates.Users.ValueObjects.Role>
	{
		public RoleConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders
			.EntityTypeBuilder<Domain.Aggregates.Users.ValueObjects.Role> builder)
		{
			builder
				// using Microsoft.EntityFrameworkCore;
				.ToTable(name: "Roles")
				;

			builder
				.HasKey(p => p.Value)
				;

			builder
				.Property(p => p.Value)
				.ValueGeneratedNever()
				.IsRequired(required: true)
				;

			builder
				.Property(p => p.Name)
				.IsRequired(required: true)
				.HasMaxLength(maxLength: Domain.Aggregates.Users.ValueObjects.Role.MaxLength)
				;

			// Data Seeding
			// https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

			builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Programmer);
			builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Administrator);
			builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Supervisor);
			builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Agent);
			builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Customer);
		}
	}
}

//using Microsoft.EntityFrameworkCore;

//namespace Persistence.Users
//{
//	internal class RoleConfiguration : object,
//		Microsoft.EntityFrameworkCore
//		.IEntityTypeConfiguration<Domain.Aggregates.Users.ValueObjects.Role>
//	{
//		public RoleConfiguration() : base()
//		{
//		}

//		public void Configure
//			(Microsoft.EntityFrameworkCore.Metadata.Builders
//			.EntityTypeBuilder<Domain.Aggregates.Users.ValueObjects.Role> builder)
//		{
//			builder
//				// using Microsoft.EntityFrameworkCore;
//				.ToTable(name: "Roles")
//				;

//			builder
//				.HasKey(p => p.Value)
//				;

//			builder
//				.Property(p => p.Value)
//				.ValueGeneratedNever()
//				.IsRequired(required: true)
//				;

//			builder
//				.Property(p => p.Name)
//				.IsRequired(required: true)
//				.HasMaxLength(maxLength: 50)
//				;

//			// Data Seeding
//			// https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

//			//builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Programmer);
//			//builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Administrator);
//			//builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Supervisor);
//			//builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Agent);
//			//builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Customer);
//		}
//	}

//	internal class ProgrammerTypeConfiguration : object,
//		Microsoft.EntityFrameworkCore
//		.IEntityTypeConfiguration<Domain.Aggregates.Users.ValueObjects.Role.ProgrammerType>
//	{
//		public ProgrammerTypeConfiguration() : base()
//		{
//		}

//		public void Configure
//			(Microsoft.EntityFrameworkCore.Metadata.Builders
//			.EntityTypeBuilder<Domain.Aggregates.Users.ValueObjects.Role.ProgrammerType> builder)
//		{
//			builder
//				// using Microsoft.EntityFrameworkCore;
//				.ToTable(name: "Roles")
//				;

//			builder.HasBaseType(typeof(Domain.Aggregates.Users.ValueObjects.Role));

//			// دستور ذیل نباید نوشته شود
//			//builder
//			//	.HasKey(p => p.Value)
//			//	;

//			builder
//				.Property(p => p.Value)
//				.ValueGeneratedNever()
//				.IsRequired(required: true)
//				;

//			builder
//				.Property(p => p.Name)
//				.IsRequired(required: true)
//				.HasMaxLength(maxLength: 50)
//				;

//			// Data Seeding
//			// https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

//			builder.HasData(Domain.Aggregates.Users.ValueObjects.Role.Programmer);
//		}
//	}
//}
