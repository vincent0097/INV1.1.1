CREATE TABLE Users(
	UserID int identity (1,1)PRIMARY KEY,
	UserName nvarchar (50) NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Password nvarchar (50) NOT NULL,
	Email nvarchar(50) NOT NULL,
	PhoneNo int,
)

CREATE TABLE Customers(
	CustomerID int identity (1,1)PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
	PhoneNo int,
)

CREATE TABLE Inventory(
	InventoryID int identity (1,1)PRIMARY KEY,
	ProductName nvarchar (50) NOT NULL,
	ProductType nvarchar (50) NOT NULL,
	Description nvarchar (500)NOT NULL
)

create table Sales(
	SalesID int identity (1,1)PRIMARY KEY,
	CustomerID int NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
	DateOfSale datetime NOT NULL,
	ProductID int NOT NULL FOREIGN KEY REFERENCES Inventory(InventoryID),
	CostSold money NOT NULL,
	TotalSold money NOT NULL
)

create table Suppliers(
	SupplierID int identity (1,1)PRIMARY KEY,
	SupplierName nvarchar (500),
	ProductID int NOT NULL FOREIGN KEY REFERENCES Inventory(InventoryID),
	Email nvarchar(50) NOT NULL,
	PhoneNo int NOT NULL,
	Address nvarchar(500)
)

create table Purchases(
	PurchaseID int identity (1,1)PRIMARY KEY,
	SupplierID int NOT NULL FOREIGN KEY REFERENCES Suppliers(SupplierID),
	ProductID int NOT NULL FOREIGN KEY REFERENCES Inventory(InventoryID),
	CostOfPurchase money NOT NULL,
	TotalCost money NOT NULL,
	DateOfPurchase datetime 
)

CREATE TABLE Transactions(
	TransactionID int identity (1,1)PRIMARY KEY,
	UserID int NOT NULL FOREIGN KEY REFERENCES Users(UserID),
	CustomerID int NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
	DateOfPurchase datetime,
	SalesID int NOT NULL FOREIGN KEY REFERENCES Sales(SalesID),
	AmountTransacted money
)

// script used to create the database with changes to be made inside

select * from dbo.Inventory

insert into Inventory values ('1','beans','kplc','50')


select * from inventory where productID =1