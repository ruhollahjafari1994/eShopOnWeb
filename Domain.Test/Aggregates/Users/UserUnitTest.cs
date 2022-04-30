//namespace Domain.Test.Aggregates.Users
//{
//	public class UserUnitTest : object
//	{
//		public UserUnitTest() : base()
//		{
//		}

//		[Xunit.Fact]
//		public void Test0010()
//		{
//			var result =
//				Domain.Aggregates.Users.User.Create
//				(username: null, password: null, emailAddress: null,
//				role: null, gender: null, firstName: null, lastName: null);

//			// **************************************************
//			Xunit.Assert.True(condition: result.IsFailed);
//			Xunit.Assert.False(condition: result.IsSuccess);
//			// **************************************************

//			// **************************************************
//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.Username);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[0].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.Password);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[1].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.EmailAddress);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[2].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.UserRole);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[3].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.Gender);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[4].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.FirstName);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[5].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.LastName);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[6].Message);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Empty(result.Successes);
//			Xunit.Assert.Equal(expected: 7, actual: result.Errors.Count);
//			// **************************************************
//		}

//		[Xunit.Fact]
//		public void Test0020()
//		{
//			var result =
//				Domain.Aggregates.Users.User.Create
//				(username: string.Empty, password: string.Empty, emailAddress: string.Empty,
//				role: 20, gender: 10, firstName: string.Empty, lastName: string.Empty);

//			// **************************************************
//			Xunit.Assert.True(condition: result.IsFailed);
//			Xunit.Assert.False(condition: result.IsSuccess);
//			// **************************************************

//			// **************************************************
//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.Username);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[0].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.Password);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[1].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.EmailAddress);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[2].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.InvalidCode,
//				Resources.DataDictionary.UserRole);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[3].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.InvalidCode,
//				Resources.DataDictionary.Gender);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[4].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.FirstName);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[5].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.LastName);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[6].Message);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Empty(result.Successes);
//			Xunit.Assert.Equal(expected: 7, actual: result.Errors.Count);
//			// **************************************************
//		}

//		[Xunit.Fact]
//		public void Test0030()
//		{
//			var result =
//				Domain.Aggregates.Users.User.Create
//				(username: "  AliReza  ", password: "  12345  ", emailAddress: "  AliReza  ",
//				role: 20, gender: 10, firstName: "     ", lastName: "     ");

//			// **************************************************
//			Xunit.Assert.True(condition: result.IsFailed);
//			Xunit.Assert.False(condition: result.IsSuccess);
//			// **************************************************

//			// **************************************************
//			string errorMessage = string.Format
//				(Resources.Messages.Validations.MinLength,
//				Resources.DataDictionary.Username,
//				Domain.Aggregates.Users.ValueObjects.Username.MinLength);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[0].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.MinLength,
//				Resources.DataDictionary.Password,
//				Domain.Aggregates.Users.ValueObjects.Username.MinLength);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[1].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.RegularExpression,
//				Resources.DataDictionary.EmailAddress);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[2].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.InvalidCode,
//				Resources.DataDictionary.UserRole);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[3].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.InvalidCode,
//				Resources.DataDictionary.Gender);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[4].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.FirstName);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[5].Message);
//			// **************************************************

//			// **************************************************
//			errorMessage = string.Format
//				(Resources.Messages.Validations.Required,
//				Resources.DataDictionary.LastName);

//			Xunit.Assert.Equal
//				(expected: errorMessage, actual: result.Errors[6].Message);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Empty(result.Successes);
//			Xunit.Assert.Equal(expected: 7, actual: result.Errors.Count);
//			// **************************************************
//		}

//		[Xunit.Fact]
//		public void Test0040()
//		{
//			var result =
//				Domain.Aggregates.Users.User.Create
//				(username: "  AliRezaAlavi  ", password: "  1234512345  ",
//				emailAddress: "  AliReza@GMail.com  ",
//				role: Domain.Aggregates.Users.ValueObjects.Role.Administrator.Value,
//				gender: Domain.SharedKernel.Gender.Male.Value,
//				firstName: "  Ali   Reza  ", lastName: "  Alavi   Asl  ");

//			// **************************************************
//			Xunit.Assert.False(condition: result.IsFailed);
//			Xunit.Assert.True(condition: result.IsSuccess);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: "AliRezaAlavi", actual: result.Value.Username.Value);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: "1234512345", actual: result.Value.Password.Value);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: "AliReza@GMail.com", actual: result.Value.EmailAddress.Value);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: Domain.Aggregates.Users.ValueObjects.Role.Administrator,
//				actual: result.Value.Role);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: Domain.SharedKernel.Gender.Male,
//				actual: result.Value.FullName.Gender);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: "Ali Reza", actual: result.Value.FullName.FirstName.Value);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Equal
//				(expected: "Alavi Asl", actual: result.Value.FullName.LastName.Value);
//			// **************************************************

//			// **************************************************
//			Xunit.Assert.Empty(result.Errors);
//			Xunit.Assert.Empty(result.Successes);
//			// **************************************************
//		}
//	}
//}
