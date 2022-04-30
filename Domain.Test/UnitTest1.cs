//using System;
//using Xunit;

using System.Linq;

namespace Domain.Test
{
	public class UnitTest1
	{
		//[Xunit.Fact]
		//public void Test1()
		//{
		//	Persistence.DatabaseContext
		//		databaseContext = new Persistence.DatabaseContext();

		//	Companies.Company company =
		//		new Companies.Company(name: "Iran Khodro");

		//	databaseContext.Companies.Add(company);

		//	databaseContext.SaveChanges();
		//}

		//[Xunit.Fact]
		//public void Test2()
		//{
		//	Persistence.DatabaseContext
		//		databaseContext = new Persistence.DatabaseContext();

		//	var fullNameResult =
		//		SharedKernel.FullName.Create(gender: SharedKernel.Gender.Male, firstName: "Mohammad", lastName: "Alavi");

		//	if(fullNameResult.IsFailed)
		//	{
		//		return;
		//	}

		//	var customer =
		//		new Customers.Customer(fullName: fullNameResult.Value, email: "x@y.z");

		//	databaseContext.Customers.Add(customer);

		//	databaseContext.SaveChanges();
		//}

		//[Xunit.Fact]
		//public void Test3()
		//{
		//	Persistence.DatabaseContext
		//		databaseContext = new Persistence.DatabaseContext();

		//	var company =
		//		new Domain.Companies.Company(name: "Iran Khodro");

		//	// **************************************************
		//	var emailAddressResult1 =
		//		SharedKernel.EmailAddress.Create(value: "Dariush@Gmail.com");

		//	var fullNameResult1 =
		//		SharedKernel.FullName.Create(gender: SharedKernel.Gender.Male, firstName: "Dariush", lastName: "Tasdighi");

		//	if (fullNameResult1.IsFailed)
		//	{
		//		return;
		//	}

		//	var customer1 =
		//		new Customers.Customer
		//		(fullName: fullNameResult1.Value, emailAddress: emailAddressResult1.Value);

		//	customer1.AssignToCompany(company: company);
		//	customer1.AssignToCompany(company: company);
		//	customer1.AssignToCompany(company: company);

		//	databaseContext.Attach(customer1);
		//	// **************************************************

		//	// **************************************************
		//	var emailAddressResult2 =
		//		SharedKernel.EmailAddress.Create(value: "SaraAlavi@Gmail.com");

		//	var fullNameResult2 =
		//		SharedKernel.FullName.Create(gender: SharedKernel.Gender.Female, firstName: "Sara", lastName: "Alavi");

		//	if (fullNameResult1.IsFailed)
		//	{
		//		return;
		//	}

		//	var customer2 =
		//		new Customers.Customer
		//		(fullName: fullNameResult2.Value, emailAddress: emailAddressResult2.Value);

		//	customer2.AssignToCompany(company: company);

		//	databaseContext.Attach(customer2);
		//	// **************************************************

		//	databaseContext.SaveChanges();

		//	var customer11 =
		//		databaseContext.Customers.ToList()[0];

		//	var customer21 =
		//		databaseContext.Customers.ToList()[1];

		//	string x = "Hello";
		//}
	}
}
