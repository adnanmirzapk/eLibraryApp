CREATE TABLE [dbo].[Users]
(
	[UserID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [UserName] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(100) NOT NULL, 
    [BorrowerID] INT NULL FOREIGN KEY REFERENCES Borrowers(BorrowerID), 
    [IsStaff] BIT NULL, 
    [EmployeeID] INT NULL FOREIGN KEY REFERENCES Employees(EmployeeID)
)
