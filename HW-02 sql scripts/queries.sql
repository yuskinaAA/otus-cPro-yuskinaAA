/*SQL запросы:*/

/*1. Добавление нового продукта*/
INSERT INTO public."Products"
("ProductName", "Description", "Price", "QuantityInStock")
VALUES
('Чайник заварочный', 'Чайник заварочный от бренда Gent, выполнен из качественного термостойкого стекла', 828, 150),
('Колготки', 'Колготки для девочки набор 3 штуки', 568.99, 50),
('Ароматизатор для автомобиля', 'Автовизитка с номером телефона, вращается от солнечной батареи', 1030, 10),
('Чехол д/тел', 'Чехол для телфеона Huawei', 274.99, 1000),
('Платье', 'Льняное платье нарядное', 1944.50, 5),
('Футболка', 'Сиреневая укороченная футболка', 420, 2);

SELECT * FROM public."Products";

/*2. Обновление цены продукта*/
UPDATE public."Products"
SET "Price" = 900
WHERE "ProductID" = 1;

SELECT * FROM public."Products" WHERE "ProductID" = 1;

/*3. Выбор всех заказов определенного пользователя*/
/*тестовые данные*/
INSERT INTO public."Users"
("UserName", "Email")
VALUES
('Anastasia', 'yaa@otus.ru'),
('Sergei', 'pss@otus.ru'),
('Sofi', 'pss-d@otus.ru');

INSERT INTO public."Orders"
("UserID", "OrderDate", "Status")
VALUES
(1, '2023-12-07','Оплачен') RETURNING "OrderID";
	
INSERT INTO public."OrderDetails"
("OrderID", "ProductID", "Quantity", "TotalCost")
VALUES
((SELECT MAX("OrderID") FROM public."Orders"), 2, 1, 568.99),
((SELECT MAX("OrderID") FROM public."Orders"), 6, 2, 840.00);
	
SELECT 
	* 
FROM public."Orders" AS o 
WHERE o."UserID" = 1;

/*4. Вариант1. Расчет общей стоимости заказа.*/
SELECT 
   SUM(od."TotalCost") AS TotalCost
FROM public."OrderDetails" AS od 
WHERE od."OrderID" = 1

/*4. Вариант2. Расчет общей стоимости заказа.*/
SELECT 
   o."OrderDate", o."Status", SUM(od."TotalCost")
FROM public."Orders" AS o
INNER JOIN public."OrderDetails" AS od ON od."OrderID" = o."OrderID"
WHERE od."OrderID" = 1
GROUP BY o."OrderDate", o."Status"

/*5. Подсчет количества товаров на складе*/
SELECT
	SUM(p."QuantityInStock") qt
FROM public."Products" AS p

/*Получение 5 самых дорогих товаров*/
SELECT 
   p.*
FROM public."Products" AS p
ORDER BY "Price" DESC
LIMIT 5

/*Список товаров с низким запасом (менее 5 штук)*/
SELECT
	p."ProductID", p."ProductName", p."Price"
FROM public."Products" AS p
WHERE p."QuantityInStock" < 5