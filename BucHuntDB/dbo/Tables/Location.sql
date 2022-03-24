CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [LocationName] NVARCHAR(50) NOT NULL, 
    [Completion] NVARCHAR(50) NOT NULL, 
    [DecodedQR] NVARCHAR(50) NOT NULL, 
    [UserEntry] NVARCHAR(50) NULL
)
