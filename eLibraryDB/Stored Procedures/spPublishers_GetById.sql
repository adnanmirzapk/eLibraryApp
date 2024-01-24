CREATE PROCEDURE [dbo].[spPublishers_GetById]
	@ID int
AS
Begin
	Select * from dbo.Publishers Where PublisherID = @ID
End
