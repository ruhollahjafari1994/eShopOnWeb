namespace Domain.Test.SharedKernel
{
	public class CellPhoneNumberUnitTest : object
	{
		public CellPhoneNumberUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: null);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.CellPhoneNumber);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: string.Empty);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.CellPhoneNumber);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "     ");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.CellPhoneNumber);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "  12345  ");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.FixLengthNumeric,
				Resources.DataDictionary.CellPhoneNumber, Domain.SharedKernel.CellPhoneNumber.FixLength);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0050()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "  123451234512345  ");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.FixLengthNumeric,
				Resources.DataDictionary.CellPhoneNumber, Domain.SharedKernel.CellPhoneNumber.FixLength);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0060()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "09121087461");

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: "09121087461", actual: result.Value.Value);
		}

		[Xunit.Fact]
		public void Test0070()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "  09121087461  ");

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: "09121087461", actual: result.Value.Value);
		}

		[Xunit.Fact]
		public void Test0080()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "09aaaaaaaaa");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.RegularExpression, Resources.DataDictionary.CellPhoneNumber);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0090()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "  09121087461  ");

			Xunit.Assert.True(condition: result.IsSuccess);

			Xunit.Assert.False(condition: result.Value.IsVerified);
			Xunit.Assert.Equal(expected: "09121087461", actual: result.Value.Value);
		}

		[Xunit.Fact]
		public void Test0100()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "  09121087461  ");

			Xunit.Assert.True(condition: result.IsSuccess);

			Xunit.Assert.False(condition: result.Value.IsVerified);
			Xunit.Assert.Equal(expected: "09121087461", actual: result.Value.Value);

			var cellPhoneNumber = result.Value;

			var newResult = cellPhoneNumber.Verify();

			Xunit.Assert.True(condition: newResult.Value.IsVerified);
			Xunit.Assert.Equal(expected: "09121087461", actual: newResult.Value.Value);

			string successMessage =
				Resources.Messages.Successes.CellPhoneNumberVerified;

			Xunit.Assert.Equal(expected: successMessage, actual: newResult.Successes[0].Message);
		}

		[Xunit.Fact]
		public void Test0110()
		{
			var result =
				Domain.SharedKernel.CellPhoneNumber.Create(value: "  09121087461  ");

			Xunit.Assert.True(condition: result.IsSuccess);

			Xunit.Assert.False(condition: result.Value.IsVerified);
			Xunit.Assert.Equal(expected: "09121087461", actual: result.Value.Value);

			var cellPhoneNumber = result.Value;

			var newResult = cellPhoneNumber.Verify();
			newResult = newResult.Value.Verify();

			string errorMessage =
				Resources.Messages.Errors.CellPhoneNumberAlreadyVerified;

			Xunit.Assert.Equal(expected: errorMessage, actual: newResult.Errors[0].Message);
		}
	}
}
