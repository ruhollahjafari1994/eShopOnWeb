using Microsoft.EntityFrameworkCore;

namespace Persistence.Users.Configurations
{
	internal class UserConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Aggregates.Users.User>
	{
		public UserConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder
			<Domain.Aggregates.Users.User> builder)
		{
			// **************************************************
			//builder
			//	// using Microsoft.EntityFrameworkCore;
			//	.ToTable(name: "Users")
			//	;
			// **************************************************

			// **************************************************
			builder
				.Property(p => p.Username)
				.HasMaxLength(maxLength: Domain.Aggregates.Users.ValueObjects.Username.MaxLength)
				.IsRequired(required: true)
				.HasConversion(p => p.Value,
					p => Domain.Aggregates.Users.ValueObjects.Username.Create(p).Value)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(p => p.Password)
				.HasMaxLength(maxLength: Domain.Aggregates.Users.ValueObjects.Password.MaxLength)
				.IsRequired(required: true)
				.HasConversion(p => p.Value,
					p => Domain.Aggregates.Users.ValueObjects.Password.Create(p).Value)
				;
			// **************************************************

			// **************************************************
			builder.HasOne(p => p.Role)
				.WithMany()
				.HasForeignKey(foreignKeyPropertyNames: "RoleId")
				.IsRequired(required: true)
				;

			builder.Property<int>("RoleId")
				.HasColumnName("RoleId")
				.IsRequired(required: true)
				.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
				;

			// دستور ذیل کار نمی‌کند
			//builder.Property(p => p.Role)
			//	.HasColumnName(nameof(Domain.Aggregates.Users.ValueObjects.Role) + "Id");
			// **************************************************

			builder
				.OwnsOne(p => p.FullName, p =>
				{
					// **************************************************
					p.HasOne(pp => pp.Gender)
						.WithMany()
						.HasForeignKey(foreignKeyPropertyNames: "GenderId")
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						;

					// For Fixing Field Name in Database: FullName_GenderId -> GenderId
					p.Property<int>("GenderId")
						.HasColumnName("GenderId")
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						;

					// دستور ذیل کار نمی‌کند
					//p.Property(pp => pp.Gender)
					//	.HasColumnName(nameof(Domain.SharedKernel.Gender) + "Id");
					// **************************************************

					// **************************************************
					p.Property(pp => pp.FirstName)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Domain.SharedKernel.FullName.FirstName))
						.HasMaxLength(maxLength: Domain.SharedKernel.FirstName.MaxLength)
						.HasConversion(p => p.Value, p => Domain.SharedKernel.FirstName.Create(p).Value)
						;
					// **************************************************

					// **************************************************
					p.Property(pp => pp.LastName)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Domain.SharedKernel.FullName.LastName))
						.HasMaxLength(maxLength: Domain.SharedKernel.LastName.MaxLength)
						.HasConversion(p => p.Value, p => Domain.SharedKernel.LastName.Create(p).Value)
						;
					// **************************************************
				});

			builder
				.OwnsOne(p => p.EmailAddress, p =>
				{
					// **************************************************
					p.Property(pp => pp.Value)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Domain.SharedKernel.EmailAddress))
						.HasMaxLength(maxLength: Domain.SharedKernel.EmailAddress.MaxLength)
						;
					// **************************************************

					// **************************************************
					p.Property(pp => pp.IsVerified)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Resources.DataDictionary.IsEmailAddressVerified))
						;
					// **************************************************

					// **************************************************
					p.Property(pp => pp.VerificationKey)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Resources.DataDictionary.EmailAddressVerificationKey))
						.HasMaxLength(maxLength: Domain.SharedKernel.EmailAddress.VerificationKeyFixLength)
						;
					// **************************************************
				});

			builder
				.OwnsOne(p => p.CellPhoneNumber, p =>
				{
					// **************************************************
					p.Property(pp => pp.Value)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Domain.SharedKernel.CellPhoneNumber))
						.HasMaxLength(maxLength: Domain.SharedKernel.CellPhoneNumber.FixLength)
						;
					// **************************************************

					// **************************************************
					p.Property(pp => pp.IsVerified)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(nameof(Resources.DataDictionary.IsCellPhoneNumberVerified))
						;
					// **************************************************

					// **************************************************
					p.Property(pp => pp.VerificationKey)
						.IsRequired(required: true) // فعلا باگ دارد و کار نمی‌کند
						.UsePropertyAccessMode(propertyAccessMode: PropertyAccessMode.Field)
						.HasColumnName(name: nameof(Resources.DataDictionary.CellPhoneNumberVerificationKey))
						.HasMaxLength(maxLength: Domain.SharedKernel.CellPhoneNumber.VerificationKeyFixLength)
						;
					// **************************************************
				})
				;
		}
	}
}
