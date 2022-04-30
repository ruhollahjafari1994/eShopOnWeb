namespace Domain.Test.Aggregates.DiscountCoupons.ValueObjects
{
	public class ValidDateToUnitTest : object
	{
		public ValidDateToUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.ValidDateTo.Create(value: null);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.ValidDateTo);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.ValidDateTo.Create(value: System.DateTime.Now.AddDays(-1));

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.GreaterThanOrEqualTo_FieldValue,
				Resources.DataDictionary.ValidDateTo, Resources.DataDictionary.CurrentDate);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.ValidDateTo.Create(value: System.DateTime.Now);

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: System.DateTime.Now.Date, actual: result.Value.Value);
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.ValidDateTo.Create(value: System.DateTime.Now.AddDays(1));

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: result.Value.Value);
		}
	}
}
