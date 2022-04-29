namespace Application.Users.EventHandlers
{
	public sealed class UserPasswordChangedEventHandler :
MediatR.INotificationHandler<Domain.Aggregates.Users.Events.UserPasswordChangedEvent>
	{
		public UserPasswordChangedEventHandler
			(Dtat.Logging.ILogger<UserPasswordChangedEventHandler> logger) : base()
		{
			Logger = logger;
		}

		private Dtat.Logging.ILogger<UserPasswordChangedEventHandler> Logger { get; }

		public System.Threading.Tasks.Task Handle
			(Domain.Aggregates.Users.Events.UserPasswordChangedEvent notification,
			System.Threading.CancellationToken cancellationToken)
		{
			Logger.LogInformation($"{nameof(UserPasswordChangedEventHandler)} Done!");

			return System.Threading.Tasks.Task.CompletedTask;
		}
	}
}
