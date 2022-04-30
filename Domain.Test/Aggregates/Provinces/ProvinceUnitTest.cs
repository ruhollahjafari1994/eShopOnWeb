namespace Domain.Test.Aggregates.Provinces
{
	public class ProvinceUnitTest : object
	{
		public ProvinceUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.Provinces.Province.Create(name: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.Aggregates.Provinces.Province.Create(name: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.Aggregates.Provinces.Province.Create(name: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var result =
				Domain.Aggregates.Provinces.Province.Create(name: "Province 1");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Province 1", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0050()
		{
			var result =
				Domain.Aggregates.Provinces.Province.Create(name: "   Province 1   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Province 1", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0060()
		{
			var result =
				Domain.Aggregates.Provinces.Province.Create(name: "   Province   1   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "Province 1", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0070()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.AddCity(cityName: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0080()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.AddCity(cityName: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0090()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.AddCity(cityName: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0100()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.AddCity(cityName: "City 1");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "City 1", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: provinceResult.Value.Cities);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0110()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.AddCity(cityName: "   City 1   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "City 1", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: provinceResult.Value.Cities);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0120()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.AddCity(cityName: "   City   1   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "City 1", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: provinceResult.Value.Cities);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0130()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var cityResult =
				provinceResult.Value.AddCity(cityName: "   City   1   ");

			var result =
				provinceResult.Value.AddCity(cityName: "   City   2   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "City 2", actual: result.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: 2, actual: provinceResult.Value.Cities.Count);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0140()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var cityResult =
				provinceResult.Value.AddCity(cityName: "   City   1   ");

			var result =
				provinceResult.Value.AddCity(cityName: "     City     1     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Repetitive, Resources.DataDictionary.CityName);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0150()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.RemoveCity(cityName: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0160()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.RemoveCity(cityName: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0170()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.RemoveCity(cityName: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0180()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var result =
				provinceResult.Value.RemoveCity(cityName: "   City   1   ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.NotFound, Resources.DataDictionary.City);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0190()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var cityResult =
				provinceResult.Value.AddCity(cityName: "   City   1   ");

			var result =
				provinceResult.Value.RemoveCity(cityName: "   City   2   ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.NotFound, Resources.DataDictionary.City);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: provinceResult.Value.Cities);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0200()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "Province");

			var cityResult =
				provinceResult.Value.AddCity(cityName: "   City   1   ");

			var result =
				provinceResult.Value.RemoveCity(cityName: "     City     1     ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: provinceResult.Value.Cities);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0210()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				provinceResult.Value.Update(name: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0220()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				provinceResult.Value.Update(name: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0230()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				provinceResult.Value.Update(name: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Single(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0240()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				provinceResult.Value.Update(name: "New My Province");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: provinceResult.Value.Cities);

			Xunit.Assert.Equal
				(expected: "New My Province", actual: provinceResult.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0250()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				provinceResult.Value.Update(name: "   New My Province   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: provinceResult.Value.Cities);

			Xunit.Assert.Equal
				(expected: "New My Province", actual: provinceResult.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0260()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				provinceResult.Value.Update(name: "   New   My   Province   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: provinceResult.Value.Cities);

			Xunit.Assert.Equal
				(expected: "New My Province", actual: provinceResult.Value.Name.Value);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}
	}
}
