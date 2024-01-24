CREATE TABLE [dbo].[Borrowers]
(
	[BorrowerID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(200) NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL
)
