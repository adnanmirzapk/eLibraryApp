CREATE PROCEDURE [dbo].[spEmployees_Delete]
	@ID int
AS
Begin
	Delete from dbo.Employees Where EmployeeID = @ID
End
