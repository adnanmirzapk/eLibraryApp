CREATE PROCEDURE [dbo].[spPublishers_Upsert]
	@ID int,
	@PublisherName nvarchar(100),
	@Address nvarchar(200),
	@PhoneNumber nvarchar(50),
	@Email nvarchar(50)
AS
Begin
	If @ID = 0
		insert into dbo.Publishers(PublisherName, Address, PhoneNumber, Email)
			Values (@PublisherName, @Address, @PhoneNumber, @Email)
	else
		update dbo.Publishers
		Set
			PublisherName = @PublisherName,
			Address = @Address,
			PhoneNumber = @PhoneNumber,
			Email = @Email
			Where PublisherID = @ID
End
