CREATE TABLE OrderMicroserviceOrder
(
	Id uniqueidentifier PRIMARY KEY,
	CreateAt Datetime not null,
    OrderStatus smallint not null 
);

CREATE TABLE OrderMicroserviceOrderItem
(
	Id uniqueidentifier PRIMARY KEY,
    Value decimal(10,2) not null,
    OrderId uniqueidentifier not null,
    ItemId uniqueidentifier not null,
);

ALTER TABLE OrderMicroserviceOrderItem
   ADD CONSTRAINT FK_OrderMicroserviceOrder_OrderMicroserviceOrderItem FOREIGN KEY (OrderId)
      REFERENCES OrderMicroserviceOrder (Id);


-- drop table OrderMicroserviceOrderItem
-- drop table OrderMicroserviceOrder