using Microsoft.EntityFrameworkCore;

namespace Persistence.SharedKernel
{
	internal class GenderConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.SharedKernel.Gender>
	{
		public GenderConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.SharedKernel.Gender> builder)
		{
			// **************************************************
			builder
				// using Microsoft.EntityFrameworkCore;
				.ToTable(name: "Genders")
				;
			// **************************************************

			// **************************************************
			builder
				.HasKey(p => p.Value)
				;

			builder
				.Property(p => p.Value)
				.ValueGeneratedNever()
				.IsRequired(required: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(p => p.Name)
				.IsRequired(required: true)
				.HasMaxLength(maxLength: Domain.SharedKernel.Gender.MaxLength)
				;
			// **************************************************

			// **************************************************
			// Data Seeding
			// https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

			builder.HasData(Domain.SharedKernel.Gender.Male);
			builder.HasData(Domain.SharedKernel.Gender.Female);

			//builder.HasData(new Domain.SharedKernel.Gender(0, "Male"));
			//builder.HasData(new Domain.SharedKernel.Gender(1, "Female"));
			// **************************************************
		}
	}
}
