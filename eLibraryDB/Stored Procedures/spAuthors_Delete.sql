CREATE PROCEDURE [dbo].[spAuthors_Delete]
	@ID int
AS
Begin
	Delete from dbo.Authors 
		Where AuthorID = @ID
End
	