namespace Domain.Test.Aggregates.DiscountCoupons.ValueObjects
{
	public class DiscountPercentUnitTest : object
	{
		public DiscountPercentUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.DiscountPercent.Create(value: null);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.DiscountPercent);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.DiscountPercent.Create(value: -1);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Range,
				Resources.DataDictionary.DiscountPercent,
				Domain.Aggregates.DiscountCoupons.ValueObjects.DiscountPercent.Minimum,
				Domain.Aggregates.DiscountCoupons.ValueObjects.DiscountPercent.Maximum);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.DiscountPercent.Create(value: 101);

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.Range,
				Resources.DataDictionary.DiscountPercent,
				Domain.Aggregates.DiscountCoupons.ValueObjects.DiscountPercent.Minimum,
				Domain.Aggregates.DiscountCoupons.ValueObjects.DiscountPercent.Maximum);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.ValueObjects.DiscountPercent.Create(value: 50);

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: result.Value.Value);
		}
	}
}
