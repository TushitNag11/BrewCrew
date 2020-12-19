CREATE TABLE [dbo].[Order]
(
	[OrderID] INT NOT NULL PRIMARY KEY IDENTITY(10001, 1), 
    [CustomerID] INT NOT NULL, 
    [TotalPrice] DECIMAL(8,2) NOT NULL, 
    [Date] DATE NOT NULL, 
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [Customer]([CustomerID]) 
    ON UPDATE CASCADE
    
)
