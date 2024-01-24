CREATE PROCEDURE [dbo].[spGenres_Upsert]
	@ID int,
	@GenreName nvarchar(50)
AS
Begin
	if @ID =0
		Insert into Genres (GenreName) Values (@GenreName)
	else
		update Genres 
		SET
			GenreName = @GenreName
			 Where GenreID = @ID
End
