CREATE TABLE [dbo].[Transactions]
(
	[TransactionID] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [BorrowerID] INT NOT NULL FOREIGN KEY REFERENCES Borrowers(BorrowerID), 
    [BookID] INT NOT NULL FOREIGN KEY REFERENCES Books(BookID), 
    [BorrowDate] DATETIME2 NOT NULL, 
    [DueDate] DATETIME2 NOT NULL, 
    [ReturnDate] DATETIME2 NOT NULL,

)
