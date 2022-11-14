CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) ,
	[EmployeeName] [nvarchar](500) ,
	[Department] [nvarchar](500) ,
	[DateOfJoining] [datetime] ,
	[PhotoFileName] [nvarchar](500) 
)

CREATE TABLE dbo.Pual(
	PualId int IDENTITY(1,1) ,
	PualName nvarchar(500) ,
	Department nvarchar(500) , 
)

select * from dbo.Pual
select * from dbo.Employee

CREATE TABLE Pal(
	PalId int IDENTITY(1,1) ,
	PalName nvarchar(500) ,
	Department nvarchar(500) , 
)

create table Jon(
     FirstName nvarchar(500),
	 LastName nvarchar(500),
	 JoinID int identity(1,1)
)

select * from dbo.Jon

CREATE TABLE dbo.[User]
(
    UserID INT IDENTITY(1,1) NOT NULL,
    LoginName NVARCHAR(40) NOT NULL,
    PasswordHash BINARY(64) NOT NULL,
    FirstName NVARCHAR(40) NULL,
    LastName NVARCHAR(40) NULL,
    CONSTRAINT [PK_User_UserID] PRIMARY KEY CLUSTERED (UserID ASC)
)

insert into dbo.[User] (LoginName, PasswordHash, FirstName, LastName) values( 'itsvince97','', 'Vincent', 'Mageria')

INSERT into [dbo].[Employee] ([EmployeeName], [Department], [DateOfJoining], [PhotoFileName]) VALUES ('Bob', 'IT', '2021-06-17', 'anonymous.png')
