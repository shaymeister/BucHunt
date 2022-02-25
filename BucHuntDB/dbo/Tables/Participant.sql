CREATE TABLE [dbo].[Participant]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AccessCode] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [PhoneNumber] NCHAR(10) NOT NULL
)
