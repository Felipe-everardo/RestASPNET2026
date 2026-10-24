CREATE TABLE dbo.person (
	[id] int NOT NULL IDENTITY(1,1),
	[first_name] varchar(80) not null,
	[last_name] varchar(80) not null,
	[address] varchar(100) not null,
	[gender] varchar(6) not null,
	primary key ([id])
)
