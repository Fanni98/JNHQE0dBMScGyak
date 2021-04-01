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

//1. feladat
var q1 = Customers.Select(c => new {name = c.FullName, age = c.Age}).OrderBy(c => c.age);
q1.Dump();

//2. feladat 
var q2 = Customers.Where(c => c.Age > 28).OrderByDescending(c => c.FullName);
q2.Dump();

//3.feladat
var q3 = Products.Where(p => p.Category.Contains("ház"));
q3.Dump();

//4. feladat 
var maxValue = Products.Max(p => p.Price);
var q4 = Products
			.Where(p => p.Price == maxValue)
			.Select( p => new {
				productName = p.ProductName, price = p.Price
			});
q4.Dump();

//5. feladat
var avgPrice = Math.Round((double) Products.Average(p => p.Price));
avgPrice.Dump();

var q5 = Products
			.Where(p => p.Price < avgPrice)
			.Select( p => new {
				productName = p.ProductName, price = p.Price
			});
q5.Dump();

//6. feladat 
var q6 = Products.Where(p => p.Category == "divat").Count();
q6.Dump();

//7. feladat Írassuk ki minden rendeléshez a hozzá tartozó termékek árának összegét!
var q7 = Orders
			.Join(Orderproducts, o => o.Id, op => op.OrderId, (o, op) => new {o, op})
			.Join(Products, oop => oop.op.ProductId, p => p.Id, (oop, p) => new {oop, p})
			.GroupBy(result => result.oop.o.Id)
			.Select(
				groups => new {
					orderId = groups.Key,
					count = groups.Select(g => g.p.Price).Aggregate((p1, p2) => (p1 + p2))
				}
			);
q7.Dump();

//8. feladat 
var q8 = Customers
			.Join(Orders, c => c.Id, o => o.Customer, (c, o) => new {c, o})
			.Join(Orderproducts, oc => oc.o.Id, op => op.OrderId, (oc, op) => new {oc, op})
			.Join(Products, ocop => ocop.op.ProductId, p => p.Id, (ocop, p) => new {ocop, p})
			.GroupBy(result => result.ocop.oc.c.FullName)
			.Select(groups => new {fullName = groups.Key, count = groups.Count()});
q8.Dump();