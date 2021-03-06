CREATE PROCEDURE [dbo].[spCategoryFilteredByTitle]
	@CategoryTitle nvarchar(50)
	
AS
begin
	select [Id], [CategoryTitle], [Active], [Clips]
	from dbo.Category
	where CategoryTitle = @CategoryTitle
end
