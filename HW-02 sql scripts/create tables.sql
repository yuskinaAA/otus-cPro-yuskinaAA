DROP TABLE IF EXISTS public."OrderDetails";
DROP TABLE IF EXISTS public."Orders";
DROP TABLE IF EXISTS public."Users";
DROP TABLE IF EXISTS public."Products";

/*Таблица "Products" (Продукты)*/
CREATE TABLE IF NOT EXISTS public."Products"
(
    "ProductID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    "ProductName" varchar(50) NOT NULL,
    "Description" text,
    "Price" numeric(18,2) NOT NULL,
    "QuantityInStock" integer NOT NULL,
    CONSTRAINT "Products_pkey" PRIMARY KEY ("ProductID")
);

/*Таблица "Users" (Пользователи)*/
CREATE TABLE IF NOT EXISTS public."Users"
(
    "UserID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    "UserName" varchar(50) NOT NULL,
    "Email" varchar(50),
    "RegistrationDate" TIMESTAMP(3) DEFAULT current_timestamp(3),
    CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID")
);

/*Таблица "Orders" (Заказы)*/
CREATE TABLE IF NOT EXISTS public."Orders"
(
    "OrderID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    "UserID" integer NOT NULL,
    "OrderDate" TIMESTAMP(3),
    "Status" varchar(20),
    CONSTRAINT "Orders_pkey" PRIMARY KEY ("OrderID"),
	CONSTRAINT fk_orders_users FOREIGN KEY ("UserID") REFERENCES public."Users" ("UserID") ON UPDATE NO ACTION ON DELETE NO ACTION
);

/*Таблица "OrderDetails" (Детали заказа)*/
CREATE TABLE IF NOT EXISTS public."OrderDetails"
(
    "OrderDetailID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY,
    "OrderID" integer NOT NULL,
	"ProductID" integer,
    "Quantity" integer,
    "TotalCost" numeric(18,2),
    CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("OrderDetailID"),
	CONSTRAINT fk_order_details_orders FOREIGN KEY ("OrderID") REFERENCES public."Orders" ("OrderID") ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT fk_order_details_products FOREIGN KEY ("ProductID") REFERENCES public."Products" ("ProductID") ON UPDATE NO ACTION ON DELETE NO ACTION
);