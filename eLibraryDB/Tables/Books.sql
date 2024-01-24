CREATE TABLE [dbo].[Books]
(
	[BookID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Title] NVARCHAR(50) NOT NULL, 
    [ISBN] NVARCHAR(50) NOT NULL, 
    [GenreID] INT NOT NULL FOREIGN KEY REFERENCES Genres(GenreID), 
    [PublishedDate] DATETIME2 NOT NULL, 
    [TotalCopies] INT NOT NULL, 
    [AvailableCopies] INT NOT NULL,
    [TotalPages] INT NOT NULL,
    [PublisherID] INT NOT NULL FOREIGN KEY REFERENCES Publishers(PublisherID), 
    [AuthorID] INT NOT NULL FOREIGN KEY REFERENCES Authors(AuthorID)
)
