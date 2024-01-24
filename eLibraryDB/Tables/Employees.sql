CREATE TABLE [dbo].[Employees]
(
	[EmployeeID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Position] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NULL
)
