namespace Domain.Test.SharedKernel
{
	public class FirstNameUnitTest : object
	{
		public FirstNameUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.SharedKernel.FirstName.Create(value: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.FirstName);

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
				Domain.SharedKernel.FirstName.Create(value: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.FirstName);

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
				Domain.SharedKernel.FirstName.Create(value: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.FirstName);

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
				Domain.SharedKernel.FirstName.Create(value: "Ali");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Ali", actual: result.Value.Value);
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
				Domain.SharedKernel.FirstName.Create(value: "  Ali  ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Ali", actual: result.Value.Value);
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
				Domain.SharedKernel.FirstName.Create(value: "  Ali  Reza  ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Ali Reza", actual: result.Value.Value);
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
				Domain.SharedKernel.FirstName.Create(value: "  Ali     Reza  ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Ali Reza", actual: result.Value.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}
	}
}
