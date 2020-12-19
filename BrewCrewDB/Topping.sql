CREATE TABLE [dbo].[Topping]
(
	[ToppingID] INT NOT NULL PRIMARY KEY IDENTITY(2001, 1), 
    [ToppingName] NVARCHAR(50) NOT NULL, 
    [ToppingDescription] NVARCHAR(100) NOT NULL, 
    [ToppingCalories] INT NOT NULL, 
    [ToppingPrice] DECIMAL(8,2) NOT NULL
)
