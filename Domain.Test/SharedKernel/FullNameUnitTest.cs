namespace Domain.Test.SharedKernel
{
	public class FullNameUnitTest : object
	{
		public FullNameUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.SharedKernel.FullName.Create
				(gender: null, firstName: null, lastName: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Gender);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.FirstName);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.LastName);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[2].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Successes);
			Xunit.Assert.Equal(expected: 3, result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.SharedKernel.FullName.Create
				(gender: Domain.SharedKernel.Gender.Male.Value, firstName: null, lastName: null);

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
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.LastName);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Successes);
			Xunit.Assert.Equal(expected: 2, result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.SharedKernel.FullName.Create
				(gender: 2,
				firstName: "Ali Reza", lastName: "Alavi Asl");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.InvalidCode, Resources.DataDictionary.Gender);

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
				Domain.SharedKernel.FullName.Create
				(gender: Domain.SharedKernel.Gender.Male.Value,
				firstName: "  Ali     Reza  ", lastName: "  Alavi     Asl  ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Ali Reza", actual: result.Value.FirstName.Value);
			Xunit.Assert.Equal(expected: "Alavi Asl", actual: result.Value.LastName.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}
	}
}
