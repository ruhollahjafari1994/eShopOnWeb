namespace Domain.Test.SharedKernel
{
	public class EmailAddressUnitTest : object
	{
		public EmailAddressUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.EmailAddress);

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
				Domain.SharedKernel.EmailAddress.Create(value: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.EmailAddress);

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
				Domain.SharedKernel.EmailAddress.Create(value: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.EmailAddress);

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
			// **************************************************
			string value = string.Empty;

			for (int index = 1; index <= Domain.SharedKernel.EmailAddress.MaxLength + 1; index++)
			{
				value += "a";
			}
			// **************************************************

			var result =
				Domain.SharedKernel.EmailAddress.Create(value: value);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.MaxLength,
				Resources.DataDictionary.EmailAddress,
				Domain.SharedKernel.EmailAddress.MaxLength);

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
				Domain.SharedKernel.EmailAddress.Create(value: "abcde");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.RegularExpression,
				Resources.DataDictionary.EmailAddress);

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
				Domain.SharedKernel.EmailAddress.Create(value: "DariushT@GMail.com");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "DariushT@GMail.com", actual: result.Value.Value);
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
				Domain.SharedKernel.EmailAddress.Create(value: "   DariushT@GMail.com   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "DariushT@GMail.com", actual: result.Value.Value);
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
				Domain.SharedKernel.EmailAddress.Create(value: "DariushT@LocalHost");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "DariushT@LocalHost", actual: result.Value.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0090()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.False(condition: result.Value.IsVerified);
			Xunit.Assert.NotNull(@object: result.Value.VerificationKey);
			Xunit.Assert.Equal(expected: "DariushT@GMail.com", actual: result.Value.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(result.Errors);
			Xunit.Assert.Empty(result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0100()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result.Value;

			var emailAddress = emailAddressObject.Value;
			var verificationKey = emailAddressObject.VerificationKey;

			var newEmailAddressObject =
				emailAddressObject.Verify();

			// **************************************************
			Xunit.Assert.False(condition: newEmailAddressObject.IsFailed);
			Xunit.Assert.True(condition: newEmailAddressObject.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.True(condition: newEmailAddressObject.Value.IsVerified);
			Xunit.Assert.Equal(expected: emailAddress, actual: newEmailAddressObject.Value.Value);
			Xunit.Assert.Equal(expected: verificationKey, actual: newEmailAddressObject.Value.VerificationKey);
			// **************************************************

			// **************************************************
			string successMessage =
				Resources.Messages.Successes.EmailAddressVerified;

			Xunit.Assert.Equal(expected: successMessage, actual: newEmailAddressObject.Successes[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(newEmailAddressObject.Errors);
			Xunit.Assert.Single(newEmailAddressObject.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0110()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result.Value;

			var newResult =
				emailAddressObject.Verify();

			var newNewResult =
				newResult.Value.Verify();

			// **************************************************
			Xunit.Assert.True(condition: newNewResult.IsFailed);
			Xunit.Assert.False(condition: newNewResult.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage =
				Resources.Messages.Errors.EmailAddressAlreadyVerified;

			Xunit.Assert.Equal(expected: errorMessage, actual: newNewResult.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(newNewResult.Errors);
			Xunit.Assert.Empty(newNewResult.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0120()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result.Value;

			var emailAddress = emailAddressObject.Value;
			var verificationKey = emailAddressObject.VerificationKey;

			var newEmailAddressObject =
				emailAddressObject.VerifyByKey(verificationKey: verificationKey);

			// **************************************************
			Xunit.Assert.False(condition: newEmailAddressObject.IsFailed);
			Xunit.Assert.True(condition: newEmailAddressObject.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.True(condition: newEmailAddressObject.Value.IsVerified);
			Xunit.Assert.Equal(expected: emailAddress, actual: newEmailAddressObject.Value.Value);
			Xunit.Assert.Equal(expected: verificationKey, actual: newEmailAddressObject.Value.VerificationKey);
			// **************************************************

			// **************************************************
			string successMessage =
				Resources.Messages.Successes.EmailAddressVerified;

			Xunit.Assert.Equal(expected: successMessage, actual: newEmailAddressObject.Successes[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(newEmailAddressObject.Errors);
			Xunit.Assert.Single(newEmailAddressObject.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0130()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result.Value;

			var newEmailAddressObject =
				emailAddressObject.VerifyByKey(verificationKey: "abcde");

			// **************************************************
			Xunit.Assert.True(condition: newEmailAddressObject.IsFailed);
			Xunit.Assert.False(condition: newEmailAddressObject.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage =
				Resources.Messages.Errors.EmailAddressAlreadyVerified;

			Xunit.Assert.Equal(expected: errorMessage, actual: newEmailAddressObject.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(newEmailAddressObject.Errors);
			Xunit.Assert.Empty(newEmailAddressObject.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0140()
		{
			var result =
				Domain.SharedKernel.EmailAddress.Create(value: "  DariushT@GMail.com  ");

			var emailAddressObject = result.Value;

			var verificationKey =
				emailAddressObject.VerificationKey;

			var newResult =
				emailAddressObject.VerifyByKey(verificationKey: verificationKey);

			var newNewResult =
				newResult.Value.VerifyByKey(verificationKey: verificationKey);

			// **************************************************
			Xunit.Assert.True(condition: newNewResult.IsFailed);
			Xunit.Assert.False(condition: newNewResult.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage =
				Resources.Messages.Errors.EmailAddressAlreadyVerified;

			Xunit.Assert.Equal(expected: errorMessage, actual: newNewResult.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(newNewResult.Errors);
			Xunit.Assert.Empty(newNewResult.Successes);
			// **************************************************
		}
	}
}
