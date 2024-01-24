CREATE PROCEDURE [dbo].[spEmployees_GetById]
	@ID int
AS
Begin
	Select * from dbo.Employees Where EmployeeID = @ID
End
