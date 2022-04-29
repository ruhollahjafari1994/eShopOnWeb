namespace ViewModels.DiscountCoupons
{
	public class DiscountCouponRequestViewModel : object
	{
		public DiscountCouponRequestViewModel() : base()
		{
		}

		public int? DiscountPercent { get; set; }

		public System.DateTime? ValidDateTo { get; set; }

		public System.DateTime? ValidDateFrom { get; set; }
	}
}
