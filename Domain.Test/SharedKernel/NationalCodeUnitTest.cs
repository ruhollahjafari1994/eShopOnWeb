namespace Domain.Test.SharedKernel
{
	public class NationalCodeUnitTest : object
	{
		public NationalCodeUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: null);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.NationalCode);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: string.Empty);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.NationalCode);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: "     ");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.NationalCode);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: "  12345  ");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.FixLengthNumeric,
				Resources.DataDictionary.NationalCode, Domain.SharedKernel.NationalCode.FixLength);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0050()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: "  123451234512345  ");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.FixLengthNumeric,
				Resources.DataDictionary.NationalCode, Domain.SharedKernel.NationalCode.FixLength);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}

		[Xunit.Fact]
		public void Test0060()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: "1234512345");

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: "1234512345", actual: result.Value.Value);
		}

		[Xunit.Fact]
		public void Test0070()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: "  1234512345  ");

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: "1234512345", actual: result.Value.Value);
		}

		[Xunit.Fact]
		public void Test0080()
		{
			var result =
				Domain.SharedKernel.NationalCode.Create(value: "aaaaaaaaaa");

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.RegularExpression, Resources.DataDictionary.NationalCode);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
		}
	}
}
