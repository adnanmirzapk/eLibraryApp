CREATE PROCEDURE [dbo].[spPublishers_Delete]
	@ID int
AS
Begin
	Delete from dbo.Publishers
		Where PublisherID = @ID
End
