namespace Domain.Test.Aggregates.Users.ValueObjects
{
	public class PasswordUnitTest : object
	{
		public PasswordUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Password);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
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
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Password);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
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
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Password);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: "     ALI   ALI     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.MinLength,
				Resources.DataDictionary.Password,
				Domain.Aggregates.Users.ValueObjects.Password.MinLength);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0050()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Password.Create
				(value: "     SEYED ALI REZA ALAVI   SEYED ALI REZA ALAVI   ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.MaxLength,
				Resources.DataDictionary.Password,
				Domain.Aggregates.Users.ValueObjects.Password.MaxLength);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0060()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: "AliReza Alavi");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.RegularExpression, Resources.DataDictionary.Password);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0070()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: "DariushTasdighi");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "DariushTasdighi", actual: result.Value.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0080()
		{
			var result =
				Domain.Aggregates.Users.ValueObjects.Password.Create(value: "  DariushTasdighi  ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "DariushTasdighi", actual: result.Value.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}
	}
}
