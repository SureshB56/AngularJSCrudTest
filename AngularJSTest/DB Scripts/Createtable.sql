
CREATE TABLE [dbo].[UserTable](
	[UserTableID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
	[IsDelete] [int] NULL,
	[Createddate] [datetime] NULL,
)

