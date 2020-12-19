CREATE TABLE [dbo].[OrderDetails]
(
	[OrderID] INT NOT NULL , 
    [DrinkID] INT NOT NULL, 
    [ToppingID] INT NOT NULL, 
    [DrinkQuantity] INT NOT NULL,
    PRIMARY KEY ([OrderID],[DrinkID],[ToppingID]),
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([OrderID]) REFERENCES [Order]([OrderID])
    ON UPDATE CASCADE,
    CONSTRAINT [FK_OrderDetail_Drink] FOREIGN KEY ([DrinkID]) REFERENCES [Drink]([DrinkID])
    ON UPDATE CASCADE,
    CONSTRAINT [FK_OrderDetail_Topping] FOREIGN KEY ([ToppingID]) REFERENCES [Topping]([ToppingID])
    ON UPDATE CASCADE
     
)
