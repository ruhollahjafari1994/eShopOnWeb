namespace Domain.Test.Aggregates.Users.ValueObjects
{
	public class RoleUnitTest : object
	{
		public RoleUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required,
				Resources.DataDictionary.UserRole);

			Xunit.Assert.Equal
				(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: 10);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode,
				Resources.DataDictionary.UserRole);

			Xunit.Assert.Equal
				(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: 0);

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal
				(expected: Domain.Aggregates.Users.ValueObjects.Role.Customer,
				actual: result.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: 1);

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal
				(expected: Domain.Aggregates.Users.ValueObjects.Role.Agent,
				actual: result.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0050()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: 2);

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal
				(expected: Domain.Aggregates.Users.ValueObjects.Role.Supervisor,
				actual: result.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0060()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: 3);

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal
				(expected: Domain.Aggregates.Users.ValueObjects.Role.Administrator,
				actual: result.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0070()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Role.GetByValue(value: 4);

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal
				(expected: Domain.Aggregates.Users.ValueObjects.Role.Programmer,
				actual: result.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}
	}
}
