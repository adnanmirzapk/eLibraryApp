CREATE PROCEDURE [dbo].[spEmployees_Upsert]
	@ID int, 
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Position nvarchar(50),
	@Email nvarchar(50),
	@PhoneNumber nvarchar(50)
AS
Begin
	if @ID = 0
		insert into dbo.Employees(FirstName, LastName, Position, Email, PhoneNumber)
			Values(@FirstName, @LastName, @Position, @Email, @PhoneNumber)
	else
		update dbo.Employees
			Set
				FirstName = @FirstName,
				LastName = @LastName,
				Position = @Position,
				Email = @Email,
				PhoneNumber = @PhoneNumber
					Where EmployeeID = @ID
End
