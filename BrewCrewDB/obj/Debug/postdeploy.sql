/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use BrewCrewDB

GO
/*Inserting admin and customer details*/
INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[CustomerEmail],[CustomerPhone]) VALUES('Jasmine','Kaur','admin@brewcrew.com','1234567789');
INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[CustomerEmail],[CustomerPhone]) VALUES('Tushit','Kanuri','tushit@gmail.com','5678912398')
INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[CustomerEmail],[CustomerPhone]) VALUES('Gurjit','Multani','gurjit@gmail.com','7783878292');
INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[CustomerEmail],[CustomerPhone]) VALUES('Ravjagir','Singh','rouble@gmail.com','7788912398');
INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[CustomerEmail],[CustomerPhone]) VALUES('Karen','Rilka','karen@gmail.com','9034567789');
INSERT INTO Customer([CustomerFirstName],[CustomerLastName],[CustomerEmail],[CustomerPhone]) VALUES('Vlad','Bors','vlad@gmail.com','8778912398');

GO

/*Inserting all Drinks*/
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Matcha Red Bean Milk Tea','A spin on traditional Matcha green, topped with red bean for added flavour',540,4.15);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Hazelnut Chocolate Milk Tea','A decadent combination of rich, chocolatey, and nutty all in one',340,4.50);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Caramel Milk Tea','Smooth and creamy with the bold taste of caramel',410,4.75);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Jasmine Green Milk Tea','A fragnant and delicate brew, paired with the rich creaminess of milk tea',270,4.10);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('BrewCrew Pearl Milk Tea','Tapioca pearls add a pleasant texture to our signature milk tea, a best selling fan favorite',350,5.99);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Grass Jelly Roasted Milk Tea','Our most popular drink! Grass jelly adds a satisfying texture to our delicious classic roasted milk tea ',220,5.20);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Red Bean Pearl Milk Tea','Sweet and full-bodied, our signature milk tea served with tapioca pearls and red beans',410,5.45);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Earl Grey Milk Tea','One of the most recognized flavoured teas in the world: bold and rich with a subtle hint of citrus',270,5.15);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('BrewCrew Triple','Our popular roasted milk tea paired with our top three toppings: pearls, grass jelly, and pudding to create a decadent and flavourful combination',400,7.10);
INSERT INTO Drink([DrinkName],[DrinkDescription],[DrinkCalories],[DrinkPrice]) VALUES('Wintermelon Milk Tea','A summer-time favorite, our wintermelon milk tea has a sweet, robust caramel flavour',260,6.78);

GO

/*Inserting all Toppings*/
INSERT INTO Topping([ToppingName],[ToppingDescription],[ToppingCalories],[ToppingPrice]) VALUES('Coffee Jelly','Coffee jelly is a jelly dessert flavored with coffee and sugar',34,0.55);
INSERT INTO Topping([ToppingName],[ToppingDescription],[ToppingCalories],[ToppingPrice]) VALUES('Coconut Jelly','Coconut jelly is a dessert produced by the fermentation of coconut water',45,0.45);
INSERT INTO Topping([ToppingName],[ToppingDescription],[ToppingCalories],[ToppingPrice]) VALUES('Pearls','Pearls are small balls of tapioca starch ',68,0.59);
INSERT INTO Topping([ToppingName],[ToppingDescription],[ToppingCalories],[ToppingPrice]) VALUES('Grass Jelly','Grass jelly is a jelly of mint taste and slightly bitter',32,0.99);
INSERT INTO Topping([ToppingName],[ToppingDescription],[ToppingCalories],[ToppingPrice]) VALUES('Mango Jelly','Mango jelly is a jelly dessert flavored with Mango',90,0.50);

GO

INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (2, 10.69, '2020-04-05');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (3, 24.67, '2020-04-08');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (4, 28.50, '2020-04-05');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (5, 5.00, '2020-04-05');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (6, 61.22, '2020-04-08');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (2, 21.54, '2020-04-09');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (3, 74.28, '2020-04-10');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (6, 20.94, '2020-04-08');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (4, 44.55, '2020-04-09');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (6, 22.40, '2020-04-05');
INSERT INTO [Order]([CustomerID],[TotalPrice],[Date]) VALUES (3, 19.78, '2020-04-10');
GO

INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10001, 1005, 2003, 2);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10002, 1001, 2001, 2);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10002, 1002, 2003, 3);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10003, 1004, 2003, 5);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10003, 1002, 2001, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10004, 1002, 2005, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10005, 1006, 2002, 2);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10005, 1010, 2003, 6);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10005, 1008, 2001, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10006, 1009, 2002, 2);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10006, 1007, 2004, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10007, 1006, 2004, 12);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10008, 1005, 2004, 3);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10009, 1010, 2004, 5);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10009, 1006, 2005, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10010, 1008, 2002, 4);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10011, 1007, 2002, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10011, 1009, 2004, 1);
INSERT INTO OrderDetails([OrderID],[DrinkID],[ToppingID],[DrinkQuantity]) VALUES (10011, 1006, 2003, 1);
GO
