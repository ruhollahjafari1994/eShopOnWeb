namespace Persistence.Cities
{
	internal class CityConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Aggregates.Cities.City>
	{
		public CityConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders
			.EntityTypeBuilder<Domain.Aggregates.Cities.City> builder)
		{
			// **************************************************
			//builder
			//	// using Microsoft.EntityFrameworkCore;
			//	.ToTable(name: "Cities")
			//	;
			// **************************************************

			// **************************************************
			builder
				.Property(p => p.Name)
				.IsRequired(required: true)
				.HasMaxLength(maxLength: Domain.SharedKernel.Name.MaxLength)
				.HasConversion(p => p.Value,
					p => Domain.SharedKernel.Name.Create(p).Value)
				;

			// دقت کنید که دستور ذیل کار نمی‌کند
			//builder
			//	.HasAlternateKey(current => new { current.Province.Id, current.Name });

			// دستور ذیل کار می‌کند ولی در زمان اصلاح نام شهر خطا می‌دهد
			//builder
			//	.HasAlternateKey("ProvinceId", "Name");

			//builder
			//	.HasIndex("ProvinceId", "Name")
			//	.IsUnique(unique: true)
			//	;

			builder
				.HasIndex
					(nameof(Domain.Aggregates.Provinces.Province) + nameof(Domain.SeedWork.Entity.Id),
					nameof(Domain.Aggregates.Provinces.Province.Name))
				.IsUnique(unique: true)
				;
			// **************************************************
		}
	}
}
