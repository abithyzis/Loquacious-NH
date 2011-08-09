
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK13A0EC01B96725C]') AND parent_object_id = OBJECT_ID('Customer_Order'))
alter table Customer_Order  drop constraint FK13A0EC01B96725C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Customer_Order]') AND parent_object_id = OBJECT_ID('Customer_Order'))
alter table Customer_Order  drop constraint FK_Customer_Order


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1436656AFB5CCE4]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD1436656AFB5CCE4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B1BAFC1F2]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK59090D7B1BAFC1F2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B39506BFC]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK59090D7B39506BFC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Order_OrderItem]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK_Order_OrderItem


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FAEE84E9A8]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FAEE84E9A8


    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'Customer_Order') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer_Order

    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'OrderItem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table OrderItem

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    if exists (select * from dbo.sysobjects where id = object_id(N'Product') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Product

    create table Customer (
        CustomerId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (CustomerId)
    )

    create table Customer_Order (
        OrderId UNIQUEIDENTIFIER not null,
       CustomerId UNIQUEIDENTIFIER not null,
       primary key (OrderId, CustomerId)
    )

    create table [Order] (
        OrderId UNIQUEIDENTIFIER not null,
       CustomerId UNIQUEIDENTIFIER not null,
       OrderDate DATETIME null,
       primary key (OrderId)
    )

    create table OrderItem (
        OrderItemId UNIQUEIDENTIFIER not null,
       OrderId UNIQUEIDENTIFIER not null,
       ProductId UNIQUEIDENTIFIER not null,
       Price DECIMAL(19,5) not null,
       Quantity INT not null,
       primary key (OrderItemId)
    )

    create table Category (
        CategoryId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(450) null,
       Description NVARCHAR(2000) null,
       ParentCategoryId UNIQUEIDENTIFIER null,
       primary key (CategoryId)
    )

    create table Product (
        ProductId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(450) null,
       Description NVARCHAR(2000) null,
       primary key (ProductId)
    )

    alter table Customer_Order 
        add constraint FK13A0EC01B96725C 
        foreign key (CustomerId) 
        references [Order]

    alter table Customer_Order 
        add constraint FK_Customer_Order 
        foreign key (OrderId) 
        references Customer

    alter table [Order] 
        add constraint FKD1436656AFB5CCE4 
        foreign key (CustomerId) 
        references Customer

    alter table OrderItem 
        add constraint FK59090D7B1BAFC1F2 
        foreign key (OrderId) 
        references [Order]

    alter table OrderItem 
        add constraint FK59090D7B39506BFC 
        foreign key (ProductId) 
        references Product

    alter table OrderItem 
        add constraint FK_Order_OrderItem 
        foreign key (OrderItemId) 
        references [Order]

    alter table Category 
        add constraint FKFA88A7FAEE84E9A8 
        foreign key (ParentCategoryId) 
        references Category
