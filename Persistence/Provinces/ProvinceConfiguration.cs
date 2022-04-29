namespace Persistence.Provinces
{
	internal class ProvinceConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Aggregates.Provinces.Province>
	{
		public ProvinceConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders
			.EntityTypeBuilder<Domain.Aggregates.Provinces.Province> builder)
		{
			// **************************************************
			//builder
			//	// using Microsoft.EntityFrameworkCore;
			//	.ToTable(name: "Provinces")
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

			// دستور ذیل کار می‌کند ولی در زمان اصلاح نام استان خطا می‌دهد
			//builder
			//	.HasAlternateKey(current => new { current.Name });

			// دستور ذیل کار می‌کند ولی در زمان اصلاح نام استان خطا می‌دهد
			//builder
			//	.HasAlternateKey(current => current.Name);

			// دستور ذیل کار می‌کند ولی در زمان اصلاح نام استان خطا می‌دهد
			//builder
			//	.HasAlternateKey(propertyNames: "Name");

			// دستور ذیل کار می‌کند ولی در زمان اصلاح نام استان خطا می‌دهد
			//builder
			//	.HasAlternateKey(propertyNames: nameof(Domain.SharedKernel.Name));

			builder
				.HasIndex(p => p.Name)
				.IsUnique(unique: true)
				;
			// **************************************************

			// **************************************************
			//builder
			//	.HasMany(current => current.Cities)
			//	.WithOne(current => current.Province)
			//	.IsRequired(required: true)
			//	.HasForeignKey("ProvinceId")
			//	.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			//	;
			// **************************************************

			// **************************************************
			//builder
			//	.HasMany(current => current.Cities)
			//	.WithOne(current => current.Province)
			//	.IsRequired(required: true)
			//	.HasForeignKey(nameof(Domain.Aggregates.Provinces.Province) + "Id")
			//	.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			//	;
			// **************************************************

			// **************************************************
			builder
				.HasMany(current => current.Cities)
				.WithOne(current => current.Province)
				.IsRequired(required: true)
				.HasForeignKey
					(nameof(Domain.Aggregates.Provinces.Province) + nameof(Domain.SeedWork.Entity.Id))
				.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			// Seed
			// **************************************************
			var province =
				Domain.Aggregates.Provinces.Province.Create("Tehran");

			builder.HasData(province.Value);

			province =
				Domain.Aggregates.Provinces.Province.Create("Alborz");

			builder.HasData(province.Value);
			// **************************************************
		}
	}
}
