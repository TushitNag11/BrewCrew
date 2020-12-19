CREATE TABLE [dbo].[Drink]
(
	[DrinkID] INT NOT NULL PRIMARY KEY IDENTITY(1001, 1), 
    [DrinkName] NVARCHAR(50) NOT NULL, 
    [DrinkDescription] NVARCHAR(150) NOT NULL, 
    [DrinkCalories] INT NOT NULL, 
    [DrinkPrice] DECIMAL(8,2) NOT NULL
)
