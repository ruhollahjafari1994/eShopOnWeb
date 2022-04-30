namespace Domain.Test.Aggregates.DiscountCoupons
{
	public class DiscountCouponUnitTest : object
	{
		public DiscountCouponUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: null, validDateFrom: null, validDateTo: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.DiscountPercent);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.ValidDateFrom);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.ValidDateTo);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[2].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: 3, actual: result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(2),
				validDateTo: System.DateTime.Now.AddDays(1));

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.GreaterThanOrEqualTo_TwoFields,
				Resources.DataDictionary.ValidDateTo, Resources.DataDictionary.ValidDateFrom);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(1),
				validDateTo: System.DateTime.Now.AddDays(2));

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: result.Value.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: result.Value.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(2).Date, actual: result.Value.ValidDateTo.Value);
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(1),
				validDateTo: System.DateTime.Now.AddDays(1));

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: result.Value.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: result.Value.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: result.Value.ValidDateTo.Value);
		}

		[Xunit.Fact]
		public void Test0050()
		{
			var mainResult =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(1),
				validDateTo: System.DateTime.Now.AddDays(2));

			Xunit.Assert.True(condition: mainResult.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: mainResult.Value.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: mainResult.Value.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(2).Date, actual: mainResult.Value.ValidDateTo.Value);

			var discountCoupon = mainResult.Value;

			var result =
				discountCoupon.Update(discountPercent: null, validDateFrom: null, validDateTo: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.DiscountPercent);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.ValidDateFrom);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.ValidDateTo);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[2].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: 3, actual: result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0060()
		{
			var mainResult =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(1),
				validDateTo: System.DateTime.Now.AddDays(2));

			Xunit.Assert.True(condition: mainResult.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: mainResult.Value.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: mainResult.Value.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(2).Date, actual: mainResult.Value.ValidDateTo.Value);

			var discountCoupon = mainResult.Value;

			var result =
				discountCoupon.Update(discountPercent: 70,
				validDateFrom: System.DateTime.Now.AddDays(2),
				validDateTo: System.DateTime.Now.AddDays(1));

			Xunit.Assert.True(condition: result.IsFailed);

			string errorMessage = string.Format
				(Resources.Messages.Validations.GreaterThanOrEqualTo_TwoFields,
				Resources.DataDictionary.ValidDateTo, Resources.DataDictionary.ValidDateFrom);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);

			Xunit.Assert.Single(result.Errors);
		}

		[Xunit.Fact]
		public void Test0070()
		{
			var mainResult =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(1),
				validDateTo: System.DateTime.Now.AddDays(2));

			Xunit.Assert.True(condition: mainResult.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: mainResult.Value.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: mainResult.Value.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(2).Date, actual: mainResult.Value.ValidDateTo.Value);

			var discountCoupon = mainResult.Value;

			var result =
				discountCoupon.Update(discountPercent: 70,
				validDateFrom: System.DateTime.Now.AddDays(3),
				validDateTo: System.DateTime.Now.AddDays(4));

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: 70, actual: discountCoupon.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(3).Date, actual: discountCoupon.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(4).Date, actual: discountCoupon.ValidDateTo.Value);
		}

		[Xunit.Fact]
		public void Test0080()
		{
			var mainResult =
				Domain.Aggregates.DiscountCoupons
				.DiscountCoupon.Create(discountPercent: 50,
				validDateFrom: System.DateTime.Now.AddDays(1),
				validDateTo: System.DateTime.Now.AddDays(2));

			Xunit.Assert.True(condition: mainResult.IsSuccess);
			Xunit.Assert.Equal(expected: 50, actual: mainResult.Value.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(1).Date, actual: mainResult.Value.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(2).Date, actual: mainResult.Value.ValidDateTo.Value);

			var discountCoupon = mainResult.Value;

			var result =
				discountCoupon.Update(discountPercent: 70,
				validDateFrom: System.DateTime.Now.AddDays(4),
				validDateTo: System.DateTime.Now.AddDays(4));

			Xunit.Assert.True(condition: result.IsSuccess);
			Xunit.Assert.Equal(expected: 70, actual: discountCoupon.DiscountPercent.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(4).Date, actual: discountCoupon.ValidDateFrom.Value);
			Xunit.Assert.Equal(expected: System.DateTime.Now.AddDays(4).Date, actual: discountCoupon.ValidDateTo.Value);
		}
	}
}
