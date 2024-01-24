CREATE PROCEDURE [dbo].[spGenres_GetById]
	@ID int
AS
Begin
	Select * from dbo.Genres Where GenreID = @ID
End
	