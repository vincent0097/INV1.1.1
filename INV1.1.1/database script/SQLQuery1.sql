select * from dbo.Customer
select * from dbo.Home

create table Login_SignUp(
     UserID int identity(1,1),
	 UserName NVARCHAR(40) NOT NULL,
     FirstName nvarchar(500)NOT NULL,
	 LastName nvarchar(500)NOT NULL,
	 Password nvarchar(500)NOT NULL,
	 Useremail varchar(500)
)

select * from Users

create table Customers(
    CustomerID int identity(1,1),
	FirstName nvarchar(500)NOT NULL,
	LastName nvarchar(500)NOT NULL,
	CustomerEmail nvarchar(500)NOT NULL,
	PhoneNo int  NOT NULL
)

create table Inventory(
	ProductID int identity(1,1),
	ProductName nvarchar (50) NOT NULL,
	ProductType nvarchar (50) NOT NULL,
	Description nvarchar (500)NOT NULL
)

create table Sales(
	SalesID int identity (1,1),
	DateOfSale datetime,
	ProductID int,
	CostSold money,
	TotalSold money,
	CustomerID int
)

create table Suppliers(
	SuppliersID int identity(1,1),
	SupplierName nvarchar(500) NOT NULL,
	SupplierEmail nvarchar(500) NOT NULL,
	PhoneNo int NOT NULL,
	Address nvarchar NOT NULL,
	ProductID int foreign key references Inventory (ProductID)
)

select * from dbo.Suppliers

create table Purchase(
	PurchseID int identity(1,1),
	DateOfPurchase date NOT NULL,
	PurchaseCost money NOT NULL,
	Amount smallint NOT NULL,
	TotalCost money NOT NULL,
	SupplierID int foreign key references Suppliers (SuppliersID),
	ProductID int foreign key references Customers (CustomerID)
)

alter table dbo.Suppliers(

select * from [INV1.1.1]

