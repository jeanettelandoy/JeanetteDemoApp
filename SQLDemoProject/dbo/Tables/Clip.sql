CREATE TABLE [dbo].[Clip]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryId] INT NULL, 
    [Hidden] BIT NULL, 
    [ClipTitle] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Clip_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]),
)
