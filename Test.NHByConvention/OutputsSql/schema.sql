
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1436656AFB5CCE4]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD1436656AFB5CCE4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FAEE84E9A8]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FAEE84E9A8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Product_Category_CategoryId]') AND parent_object_id = OBJECT_ID('Product_Category'))
alter table Product_Category  drop constraint FK_Product_Category_CategoryId


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Product_Category_ProductId]') AND parent_object_id = OBJECT_ID('Product_Category'))
alter table Product_Category  drop constraint FK_Product_Category_ProductId


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B1BAFC1F2]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK59090D7B1BAFC1F2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B39506BFC]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK59090D7B39506BFC


    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    if exists (select * from dbo.sysobjects where id = object_id(N'Product_Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Product_Category

    if exists (select * from dbo.sysobjects where id = object_id(N'Product') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Product

    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'OrderItem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table OrderItem

    create table [Order] (
        OrderId UNIQUEIDENTIFIER not null,
       Version INT not null,
       CustomerId UNIQUEIDENTIFIER null,
       OrderDate DATETIME null,
       primary key (OrderId)
    )

    create table Category (
        CategoryId UNIQUEIDENTIFIER not null,
       Version INT not null,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       ParentCategoryId UNIQUEIDENTIFIER null,
       primary key (CategoryId)
    )

    create table Product_Category (
        ProductId UNIQUEIDENTIFIER not null,
       CategoryId UNIQUEIDENTIFIER not null,
       primary key (CategoryId, ProductId)
    )

    create table Product (
        ProductId UNIQUEIDENTIFIER not null,
       Version INT not null,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Discontinued BIT null,
       primary key (ProductId)
    )

    create table Customer (
        CustomerId UNIQUEIDENTIFIER not null,
       Version INT not null,
       Name NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (CustomerId)
    )

    create table OrderItem (
        OrderItemId UNIQUEIDENTIFIER not null,
       Version INT not null,
       OrderId UNIQUEIDENTIFIER null,
       ProductId UNIQUEIDENTIFIER null,
       Price DECIMAL(19,5) null,
       Quantity INT null,
       primary key (OrderItemId)
    )

    alter table [Order] 
        add constraint FKD1436656AFB5CCE4 
        foreign key (CustomerId) 
        references Customer

    alter table Category 
        add constraint FKFA88A7FAEE84E9A8 
        foreign key (ParentCategoryId) 
        references Category

    alter table Product_Category 
        add constraint FK_Product_Category_CategoryId 
        foreign key (CategoryId) 
        references Product

    alter table Product_Category 
        add constraint FK_Product_Category_ProductId 
        foreign key (ProductId) 
        references Category

    alter table OrderItem 
        add constraint FK59090D7B1BAFC1F2 
        foreign key (OrderId) 
        references [Order]

    alter table OrderItem 
        add constraint FK59090D7B39506BFC 
        foreign key (ProductId) 
        references Product
