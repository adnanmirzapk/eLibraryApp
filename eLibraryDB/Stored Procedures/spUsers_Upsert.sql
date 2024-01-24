CREATE PROCEDURE [dbo].[spUsers_Upsert]
	@ID int,
	@UserName nvarchar(100),
	@Password nvarchar(100),
	@BorrowerID int,
	@IsStaff bit,
	@EmployeeID int
As
Begin
	If @ID =0 
		if @BorrowerID = 0
			Insert into dbo.Users(UserName, Password, IsStaff, EmployeeID)
				Values (@UserName, @Password, @IsStaff, @EmployeeID)
		if @EmployeeID = 0
			Insert into dbo.Users(UserName, Password, BorrowerID, IsStaff)
				Values (@UserName, @Password, @BorrowerID, @IsStaff)
	Else
		if @BorrowerID = 0
			Update dbo.Users
			SET 
				UserName = @UserName,
				Password = @Password,
				IsStaff = @IsStaff,
				EmployeeID = @EmployeeID
					WHERE UserID = @ID
		if @EmployeeID = 0
			Update dbo.Users
			SET 
				UserName = @UserName,
				Password = @Password,
				BorrowerID = @BorrowerID,
				IsStaff = @IsStaff
					WHERE UserID = @ID
End