CREATE PROCEDURE [dbo].[spAuthors_Upsert]
	@ID int,
	@FirstName nvarchar(50),
	@Lastname nvarchar(50),
	@DateOfBirth datetime2(7),
	@Nationality nvarchar(20)
AS
Begin
	if @ID = 0
		insert into dbo.Authors(FirstName, LastName, DateOfBirth, Nationality)
				Values(@FirstName, @Lastname, @DateOfBirth, @Nationality)
	else
		update dbo.Authors 
		  Set
			FirstName = @FirstName,
			LastName = @Lastname,
			DateOfBirth = @DateOfBirth,
			Nationality = @Nationality
				Where AuthorID = @ID
End

