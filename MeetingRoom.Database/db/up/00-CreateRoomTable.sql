create table Rooms
(
	ID int identity(1,1) not null,
	Name nvarchar(200) not null,
	Permalink uniqueidentifier not null,
	UserCreated nvarchar(200) not null,
	PRIMARY KEY CLUSTERED 
(
	ID ASC
))