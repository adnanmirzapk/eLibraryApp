CREATE PROCEDURE [dbo].[spTransactions_Upsert]
	@ID int,
	@BorrowerID int,
	@BookID int,
	@BorrowDate datetime2(7),
	@DueDate datetime2(7),
	@ReturnDate datetime2(7)
As
Begin
	if @ID = 0
		Insert into dbo.Transactions (BorrowerID, BookID, BorrowDate, DueDate, ReturnDate)
			Values (@BorrowerID, @BookID, @BorrowDate, @DueDate, @ReturnDate)
	else
		Update dbo.Transactions
		SET
			BorrowerID = @BorrowerID,
			BookID = @BookID,
			BorrowDate = @BorrowDate,
			DueDate = @DueDate,
			ReturnDate = @ReturnDate
				Where TransactionID = @ID
End