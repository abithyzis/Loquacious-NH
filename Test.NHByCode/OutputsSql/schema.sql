
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK13A0EC01B96725C]') AND parent_object_id = OBJECT_ID('Customer_Order'))
alter table Customer_Order  drop constraint FK13A0EC01B96725C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Customer_Orders]') AND parent_object_id = OBJECT_ID('Customer_Order'))
alter table Customer_Order  drop constraint FK_Customer_Orders


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1436656AFB5CCE4]') AND parent_object_id = OBJECT_ID('[Order]'))
alter table [Order]  drop constraint FKD1436656AFB5CCE4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FAEE84E9A8]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FAEE84E9A8


    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'Customer_Order') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer_Order

    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    create table Customer (
        CustomerId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (CustomerId)
    )

    create table Customer_Order (
        OrderId UNIQUEIDENTIFIER not null,
       CustomerId UNIQUEIDENTIFIER not null
    )

    create table [Order] (
        OrderId UNIQUEIDENTIFIER not null,
       CustomerId UNIQUEIDENTIFIER not null,
       OrderDate DATETIME null,
       primary key (OrderId)
    )

    create table Category (
        CategoryId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(450) null,
       Description NVARCHAR(2000) null,
       ParentCategoryId UNIQUEIDENTIFIER null,
       primary key (CategoryId)
    )

    alter table Customer_Order 
        add constraint FK13A0EC01B96725C 
        foreign key (CustomerId) 
        references [Order]

    alter table Customer_Order 
        add constraint FK_Customer_Orders 
        foreign key (OrderId) 
        references Customer

    alter table [Order] 
        add constraint FKD1436656AFB5CCE4 
        foreign key (CustomerId) 
        references Customer

    alter table Category 
        add constraint FKFA88A7FAEE84E9A8 
        foreign key (ParentCategoryId) 
        references Category
