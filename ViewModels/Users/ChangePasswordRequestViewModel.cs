namespace ViewModels.Users
{
	public class ChangePasswordRequestViewModel : object
	{
		public ChangePasswordRequestViewModel() : base()
		{
		}

		public System.Guid? Id { get; set; }

		public string NewPassword { get; set; }
	}
}
