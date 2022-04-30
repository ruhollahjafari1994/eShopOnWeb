//namespace Domain.Test.Aggregates.Companies
//{
//	public class CompanyNameUnitTest : object
//	{
//		public CompanyNameUnitTest() : base()
//		{
//		}

//		[Xunit.Fact]
//		public void CreateCompanyName1()
//		{
//			string value = null;

//			var result =
//				Domain.Aggregates.Companies.CompanyName.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required, Resources.DataDictionary.CompanyName);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateCompanyName2()
//		{
//			string value = string.Empty;

//			var result =
//				Domain.Aggregates.Companies.CompanyName.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required, Resources.DataDictionary.CompanyName);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateCompanyName3()
//		{
//			string value = "     ";

//			var result =
//				Domain.Aggregates.Companies.CompanyName.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.Required, Resources.DataDictionary.CompanyName);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}

//		[Xunit.Fact]
//		public void CreateCompanyName4()
//		{
//			string value = "  Company 1   ";

//			var result =
//				Domain.Aggregates.Companies.CompanyName.Create(value: value);

//			Xunit.Assert.True(condition: result.IsSuccess);
//			Xunit.Assert.Equal(expected: "Company 1", actual: result.Value.Value);
//		}

//		[Xunit.Fact]
//		public void CreateCompanyName5()
//		{
//			string value = "  Company     1   ";

//			var result =
//				Domain.Aggregates.Companies.CompanyName.Create(value: value);

//			Xunit.Assert.True(condition: result.IsSuccess);
//			Xunit.Assert.Equal(expected: "Company 1", actual: result.Value.Value);
//		}

//		[Xunit.Fact]
//		public void CreateCompanyName6()
//		{
//			string value = "Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1Company1";

//			var result =
//				Domain.Aggregates.Companies.CompanyName.Create(value: value);

//			Xunit.Assert.True(condition: result.IsFailed);

//			string errorMessage = string.Format
//				(Resources.Messages.Validations.MaxLength,
//				Resources.DataDictionary.CompanyName, Domain.Aggregates.Companies.CompanyName.MaxLength);

//			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
//		}
//	}
//}
