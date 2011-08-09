
    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    if exists (select * from dbo.sysobjects where id = object_id(N'Product') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Product

    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'OrderItem') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table OrderItem

    if exists (select * from dbo.sysobjects where id = object_id(N'Orders') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Orders

    create table Category (
        CategoryId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(450) null,
       Description NVARCHAR(2000) null,
       primary key (CategoryId)
    )

    create table Product (
        ProductId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(450) null,
       Description NVARCHAR(2000) null,
       primary key (ProductId)
    )

    create table Customer (
        CustomerId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (CustomerId)
    )

    create table OrderItem (
        OrderItemId UNIQUEIDENTIFIER not null,
       Price DECIMAL(19,5) null,
       Quantity INT null,
       primary key (OrderItemId)
    )

    create table Orders (
        OrderId UNIQUEIDENTIFIER not null,
       OrderDate DATETIME null,
       primary key (OrderId)
    )
