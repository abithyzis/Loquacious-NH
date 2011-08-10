
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1436656AFB5CCE4]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD1436656AFB5CCE4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FA9D3EBDB4]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FA9D3EBDB4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FA39506BFC]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FA39506BFC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK952904EB9D3EBDB4]') AND parent_object_id = OBJECT_ID('Product'))
alter table Product  drop constraint FK952904EB9D3EBDB4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B1BAFC1F2]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK59090D7B1BAFC1F2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59090D7B39506BFC]') AND parent_object_id = OBJECT_ID('OrderItem'))
alter table OrderItem  drop constraint FK59090D7B39506BFC


    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

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
       ProductId UNIQUEIDENTIFIER null,
       primary key (CategoryId)
    )

    create table Product (
        ProductId UNIQUEIDENTIFIER not null,
       Version INT not null,
       Name NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       Discontinued BIT null,
       CategoryId UNIQUEIDENTIFIER null,
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
        add constraint FKFA88A7FA9D3EBDB4 
        foreign key (CategoryId) 
        references Category

    alter table Category 
        add constraint FKFA88A7FA39506BFC 
        foreign key (ProductId) 
        references Product

    alter table Product 
        add constraint FK952904EB9D3EBDB4 
        foreign key (CategoryId) 
        references Category

    alter table OrderItem 
        add constraint FK59090D7B1BAFC1F2 
        foreign key (OrderId) 
        references [Order]

    alter table OrderItem 
        add constraint FK59090D7B39506BFC 
        foreign key (ProductId) 
        references Product
