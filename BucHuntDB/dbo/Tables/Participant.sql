CREATE TABLE [dbo].[Participant] (
    [Id]          INT            NOT NULL,
    [AccessCode]  INT            NULL,
    [FirstName]   NVARCHAR (50)  NULL,
    [LastName]    NVARCHAR (50)  NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [PhoneNumber] NCHAR (10)     NOT NULL,
    [Password] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

