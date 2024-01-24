CREATE PROCEDURE [dbo].[spAuthors_GetById]
	@ID int
AS
Begin
	Select * from Authors Where AuthorID = @ID
End


