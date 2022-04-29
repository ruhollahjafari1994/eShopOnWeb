namespace Domain.Aggregates.Users.Events
{
	public sealed class UserPasswordChangedEvent : object, Dtat.Ddd.IDomainEvent
	{
		public UserPasswordChangedEvent
			(SharedKernel.FullName fullName, SharedKernel.EmailAddress emailAddress) : base()
		{
			FullName = fullName;
			EmailAddress = emailAddress;
		}

		public SharedKernel.FullName FullName { get; }

		public SharedKernel.EmailAddress EmailAddress { get; }
	}
}
