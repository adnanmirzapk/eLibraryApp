CREATE PROCEDURE [dbo].[spBooks_GetById]
	@ID int
AS
Begin
	Select * from dbo.Books Where BookID = @ID		
End
