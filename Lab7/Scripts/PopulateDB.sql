create table Product (
	Id int identity(1, 1) primary key,
	[Name] nvarchar(max) not null,
	Price float not null
	)

create table Customer (
	Id int identity(1, 1) primary key,
	[Name] nvarchar(max) not null,
	Age int not null check (Age > 0)
)

create table [Order] (
	ProductId int not null,
	CustomerId int not null,
	PRIMARY KEY(ProductId, CustomerId),
	FOREIGN key (ProductId) REFERENCES Product(Id),
	FOREIGN key (CustomerId) REFERENCES Customer(Id),
	[Count] int check ([Count] > 0)
)

