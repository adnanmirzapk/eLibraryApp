CREATE PROCEDURE [dbo].[spBorrowers_Upsert]
	@ID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Address nvarchar(200),
	@PhoneNumber nvarchar(50),
	@Email nvarchar(50)
AS
Begin
	if @ID = 0
		Insert into dbo.Borrowers (FirstName, LastName, Address, PhoneNumber, Email)
			Values(@FirstName, @LastName, @Address, @PhoneNumber, @Email)
	else
		Update dbo.Borrowers
		SET
			FirstName = @FirstName,
			LastName = @LastName,
			Address = @Address,
			PhoneNumber = @PhoneNumber,
			Email = @Email
				WHERE BorrowerID = @ID
End