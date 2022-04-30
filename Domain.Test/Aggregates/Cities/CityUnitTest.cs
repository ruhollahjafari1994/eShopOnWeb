namespace Domain.Test.Aggregates.Cities
{
	public class CityUnitTest : object
	{
		public CityUnitTest() : base()
		{
		}

		[Xunit.Fact]
		public void Test0010()
		{
			var result =
				Domain.Aggregates.Cities.City.Create(province: null, name: null);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Province);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Successes);
			Xunit.Assert.Equal(expected: 2, actual: result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0020()
		{
			var result =
				Domain.Aggregates.Cities.City.Create(province: null, name: string.Empty);

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Province);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Successes);
			Xunit.Assert.Equal(expected: 2, actual: result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0030()
		{
			var result =
				Domain.Aggregates.Cities.City.Create(province: null, name: "     ");

			// **************************************************
			Xunit.Assert.True(condition: result.IsFailed);
			Xunit.Assert.False(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			string errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Province);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[0].Message);
			// **************************************************

			// **************************************************
			errorMessage = string.Format
				(Resources.Messages.Validations.Required, Resources.DataDictionary.Name);

			Xunit.Assert.Equal(expected: errorMessage, actual: result.Errors[1].Message);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Successes);
			Xunit.Assert.Equal(expected: 2, actual: result.Errors.Count);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0040()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: null);

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
		public void Test0050()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: string.Empty);

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
		public void Test0060()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "     ");

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
		public void Test0070()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "     ");

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
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "My City");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "My City", actual: result.Value.Name.Value);
			Xunit.Assert.Equal(expected: provinceResult.Value, actual: result.Value.Province);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0090()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "   My City   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "My City", actual: result.Value.Name.Value);
			Xunit.Assert.Equal(expected: provinceResult.Value, actual: result.Value.Province);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}

		[Xunit.Fact]
		public void Test0100()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var result =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "   My   City   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal(expected: "My City", actual: result.Value.Name.Value);
			Xunit.Assert.Equal(expected: provinceResult.Value, actual: result.Value.Province);
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
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var cityResult =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "My City");

			var result =
				cityResult.Value.Update(name: null);

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
		public void Test0120()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var cityResult =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "My City");

			var result =
				cityResult.Value.Update(name: null);

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
		public void Test0130()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var cityResult =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "My City");

			var result =
				cityResult.Value.Update(name: string.Empty);

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
		public void Test0140()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var cityResult =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "My City");

			var result =
				cityResult.Value.Update(name: "     ");

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
		public void Test0150()
		{
			var provinceResult =
				Domain.Aggregates.Provinces.Province.Create(name: "My Province");

			var cityResult =
				Domain.Aggregates.Cities.City.Create
				(province: provinceResult.Value, name: "My City");

			var result =
				cityResult.Value.Update(name: "   New   My   City   ");

			// **************************************************
			Xunit.Assert.False(condition: result.IsFailed);
			Xunit.Assert.True(condition: result.IsSuccess);
			// **************************************************

			// **************************************************
			Xunit.Assert.Equal
				(expected: "New My City", actual: cityResult.Value.Name.Value);

			Xunit.Assert.Equal
				(expected: provinceResult.Value, actual: cityResult.Value.Province);
			// **************************************************

			// **************************************************
			Xunit.Assert.Empty(collection: result.Errors);
			Xunit.Assert.Empty(collection: result.Successes);
			// **************************************************
		}
	}
}
