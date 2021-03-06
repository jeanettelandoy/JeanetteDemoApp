CREATE VIEW [dbo].[FullCategory]
	AS SELECT 
	[p].[Id] as CategoryId, [p].[CategoryTitle], [p].[Active], [p].[Clips], 
	[a].[Id], [a].[Hidden], [a].[ClipTitle]
	FROM dbo.Category p
	left join dbo.Clip a on p.Id = a.CategoryId
