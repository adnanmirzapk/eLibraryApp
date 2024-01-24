CREATE PROCEDURE [dbo].[spBooks_Upsert]
	@ID int,
	@Title nvarchar(50),
	@ISBN nvarchar(50),
	@GenreID int,
	@PublishedDate datetime2(7),
	@TotalCopies int,
	@AvailableCopies int,
	@TotalPages int,
	@PublisherID int,
	@AuthorID int
AS
Begin
	If @ID = 0 
		Insert into dbo.Books (Title, ISBN, GenreID, PublishedDate, TotalCopies, AvailableCopies, TotalPages, PublisherID, AuthorID)
			Values (@Title, @ISBN, @GenreID, @PublishedDate, @TotalCopies, @AvailableCopies, @TotalPages, @PublisherID, @AuthorID)
	Else
		Update dbo.Books
		SET
			Title = @Title,
			ISBN = @ISBN,
			GenreID = @GenreID,
			PublishedDate = @PublishedDate,
			TotalCopies = @TotalCopies,
			AvailableCopies = @AvailableCopies,
			TotalPages = @TotalPages,
			PublisherID = @PublisherID,
			AuthorID = @AuthorID
			Where BookID = @ID
End
