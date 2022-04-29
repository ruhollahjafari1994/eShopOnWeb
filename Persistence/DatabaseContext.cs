using System.Linq;

namespace Persistence
{
	/// <summary>
	/// https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/
	/// </summary>
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		private static readonly System.Type[] EnumerationTypes =
			{ typeof(Domain.Aggregates.Users.ValueObjects.Role), typeof(Domain.SharedKernel.Gender) };

		public DatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions options, MediatR.IMediator mediator) : base(options: options)
		{
			Mediator = mediator;

			Database.EnsureCreated();
		}

		private MediatR.IMediator Mediator { get; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Aggregates.Users.User> Users { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Aggregates.Cities.City> Cities { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Aggregates.Provinces.Province> Provinces { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Aggregates.DiscountCoupons.DiscountCoupon> DiscountCoupons { get; set; }

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly
				(typeof(DiscountCoupons.DiscountCouponConfiguration).Assembly);
		}

		public override
			async
			System.Threading.Tasks.Task<int>
			SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
		{
			// **************************************************
			// دستورات ذیل بینهایت اهمیت دارند
			// **************************************************
			var enumerationEntries =
				ChangeTracker.Entries()
				.Where(current => EnumerationTypes.Contains(current.Entity.GetType()));

			foreach (var enumerationEntry in enumerationEntries)
			{
				enumerationEntry.State =
					Microsoft.EntityFrameworkCore.EntityState.Unchanged;
			}
			// **************************************************

			int affectedRows =
				await base.SaveChangesAsync(cancellationToken: cancellationToken);

			if (affectedRows > 0)
			{
				var aggregateRoots =
					ChangeTracker.Entries()
					.Where(current => current.Entity is Dtat.Ddd.IAggregateRoot)
					.Select(current => current.Entity as Dtat.Ddd.IAggregateRoot)
					.ToList()
					;

				foreach (var aggregateRoot in aggregateRoots)
				{
					// Dispatch Events!
					foreach (var domainEvent in aggregateRoot.DomainEvents)
					{
						await Mediator.Publish(domainEvent, cancellationToken);
					}

					// Clear Events!
					aggregateRoot.ClearDomainEvents();
				}
			}

			return affectedRows;
		}
	}
}
