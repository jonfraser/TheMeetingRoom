create table Conversation
(
	ID int identity(1,1) not null,
	RoomID int not null,
	Permalink uniqueidentifier not null,
	UserCreated nvarchar(200) not null,
	TimeCreated datetime not null,
	Message nvarchar(max) not null,
	PRIMARY KEY CLUSTERED 
(
	ID ASC
))