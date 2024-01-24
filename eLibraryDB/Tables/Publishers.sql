CREATE TABLE [dbo].[Publishers]
(
	[PublisherID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [PublisherName] NVARCHAR(100) NOT NULL, 
    [Address] NVARCHAR(200) NULL, 
    [PhoneNumber] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL
)
