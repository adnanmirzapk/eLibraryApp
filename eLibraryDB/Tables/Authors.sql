CREATE TABLE [dbo].[Authors]
(
	[AuthorID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIME2 NOT NULL, 
    [Nationality] NVARCHAR(20) NOT NULL
) 
