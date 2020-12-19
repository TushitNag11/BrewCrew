CREATE TABLE [dbo].[Customer]
(
	[CustomerID] INT NOT NULL PRIMARY KEY IDENTITY,
    [CustomerFirstName] NVARCHAR(50) NOT NULL, 
    [CustomerLastName] NVARCHAR(50) NOT NULL, 
    [CustomerEmail] NVARCHAR(50) NOT NULL, 
    [CustomerPhone] NVARCHAR(10) NOT NULL
)
