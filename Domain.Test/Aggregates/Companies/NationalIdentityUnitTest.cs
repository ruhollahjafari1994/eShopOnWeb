//namespace Domain.Test.Aggregates.Companies
//{
//	public class NationalIdentityUnitTest : object
//	{
//		public NationalIdentityUnitTest() : base()
//		{
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity1()
//		{
//			string value = null;

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required, Resources.DataDictionary.NationalIdentity);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity2()
//		{
//			string value = string.Empty;

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required, Resources.DataDictionary.NationalIdentity);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity3()
//		{
//			string value = "     ";

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required, Resources.DataDictionary.NationalIdentity);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity4()
//		{
//			string value = "1234567890";

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsSuccess);
//			Xunit.Assert.Equal(expected: "1234567890", actual: result.Value.Value);
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity5()
//		{
//			string value = "  1234567890  ";

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsSuccess);
//			Xunit.Assert.Equal(expected: "1234567890", actual: result.Value.Value);
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity6()
//		{
//			string value = "  12345  ";

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.FixLengthNumeric,
//				Resources.DataDictionary.NationalIdentity, Domain.Aggregates.Companies.NationalIdentity.FixLength);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateNationalIdentity7()
//		{
//			string value = "12345abcde";

//			var result =
//				Domain.Aggregates.Companies.NationalIdentity.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.RegularExpression, Resources.DataDictionary.NationalIdentity);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}
//	}
//}
