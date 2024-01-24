CREATE PROCEDURE [dbo].[spGenres_Delete]
	@ID int
AS
Begin
	Delete from dbo.Genres Where GenreID = @ID
End
