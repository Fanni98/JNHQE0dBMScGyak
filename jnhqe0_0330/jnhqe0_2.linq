<Query Kind="Statements">
  <Connection>
    <ID>5c57251e-dc8f-4335-bbc6-e342ffa79823</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAARyOPsIUhZUCbaIaleDSwRgAAAAACAAAAAAAQZgAAAAEAACAAAACvnMX6H7Nabh19gajictwK6Ej4c4lBl0BREMuPnDG/ygAAAAAOgAAAAAIAACAAAAA4weFNJPPPTuOZWpHE+8DAY5HgtpW4i2s42lUupwdxB0AAAACIWR5HhHWwLbunx7dwfSz+ODbN6ecjYfhgfLDgys5M+Z9s+QWu4iTYQQFLCZPdJC7HtDmlj3GjH3XPytuM/RZLQAAAACZXRfs40Mkny9D1QkfybQDRrod58mEAEPw72qXHBIvkEOqBw0OtKKuiwzKdMq7GbZNYncdSVVzmTkcc40mIg8Q=</CustomCxString>
    <Server>localhost</Server>
    <Database>linq</Database>
    <UserName>root</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAARyOPsIUhZUCbaIaleDSwRgAAAAACAAAAAAAQZgAAAAEAACAAAADIFPjWb+ohLOfs9+rF2MrvpW2eCm4KH9vSbex2UBjrvAAAAAAOgAAAAAIAACAAAABKbi0IedYpMUcDyUzFypw6B1a0R5bsSpK97xyPzaKi0hAAAADW5NSZXuOXp223ArXxIjGnQAAAAGy/aCNkEh2IB3AX6jYxa4+XOe8fIx+t3m68Ug3rgaRiXcG1sI5D6ExRfbehLstf7s65fX91GqInnqiu+8etfXQ=</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DisplayName>localhost_msc_gyak</DisplayName>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	while(true) {
		Console.WriteLine();
		Console.WriteLine("--Menu---");
		Console.WriteLine("Add new customer (1)");
		Console.WriteLine("Add new product (2)");
		Console.WriteLine("Create new order (3)");
		Console.WriteLine("Delete customer (4)");
		Console.WriteLine("Delete product (5)");
		Console.WriteLine("List customers (6)");
		Console.WriteLine("List products (7)");
		Console.WriteLine("List orders (8)");
		Console.WriteLine("Search in products (9)");
		Console.WriteLine("Find products by customer (10)");
		Console.WriteLine("Quit (11)");
		Console.WriteLine();
		
		string menuInput = Util.ReadLine("What would you like to do?");
		
		switch(menuInput) {
			case "1" :
				addNewCustomer();
				break;
			case "2":
				addNewProduct();
				break;
			case "3":
				addNewOrder();
				break;
			case "11":
				Console.WriteLine("Bye.");
				return;
			default:
				Console.WriteLine("Invalid command.");
				break;
		}
	}
}

void addNewCustomer() {
	try {
		Console.WriteLine("Add new customer.");
		
		int id = int.Parse(Util.ReadLine("Id:"));
		string fullName = Util.ReadLine("FullName:");
		int age = int.Parse(Util.ReadLine("Age:"));
		
		Customers customer = new Customers { Id = id, FullName = fullName, Age = age };
	
		Customers.InsertOnSubmit(customer);
		SubmitChanges();
		
		Console.WriteLine("Customer successfully created.");
	} catch(Exception e) {
		Console.WriteLine("Failed to create customer: " + e.Message);
	}
}

void addNewProduct() {
	try {
		Console.WriteLine("Add new product.");
	
		int id = int.Parse(Util.ReadLine("Id:"));
		string productName = Util.ReadLine("ProductName:");
		string category = Util.ReadLine("Category:");
		int price = int.Parse(Util.ReadLine("Price:"));
		
		Products product = new Products {
			Id = id,
			ProductName = productName,
			Category = category,
			Price = price 
		};
		
		Products.InsertOnSubmit(product);
		SubmitChanges();
		
		Console.WriteLine("Product successfully created.");
	} catch(Exception e) {
		Console.WriteLine("Failed to create product: " + e.Message);
	}

}

void addNewOrder() {
	try {
		Console.WriteLine("Create new order.");
	
		int orderId = int.Parse(Util.ReadLine("OrderId:"));
		int customerId = int.Parse(Util.ReadLine("CustomerId:"));
		string productIdsString = Util.ReadLine("ProductIds(separated by comma):");
		string[] separatedProductIdsString = productIdsString.Split(',');
		int[] productIds = Array.ConvertAll(separatedProductIdsString, s => int.Parse(s));
		
		Orders order = new Orders { Id = orderId, Customer = customerId };
		Orders.InsertOnSubmit(order);
		
		foreach (int productId in productIds) {
			Orderproducts orderProduct = new Orderproducts {OrderId = orderId, ProductId = productId};
			Orderproducts.InsertOnSubmit(orderProduct);
		}
		
		SubmitChanges();
		
		Console.WriteLine("Order successfully created.");
	} catch(Exception e) {
		Console.WriteLine("Failed to create order: " + e.Message);
	}
}