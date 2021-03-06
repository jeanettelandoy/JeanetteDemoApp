CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryTitle] NVARCHAR(50) NULL, 
    [Active] BIT NOT NULL, 
    [Clips] NVARCHAR(MAX) NULL
)
