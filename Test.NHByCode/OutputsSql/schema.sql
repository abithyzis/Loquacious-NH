
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE171AE6E8DF8A3F1]') AND parent_object_id = OBJECT_ID('Customer_Orders'))
alter table Customer_Orders  drop constraint FKE171AE6E8DF8A3F1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK_Customer_Orders]') AND parent_object_id = OBJECT_ID('Customer_Orders'))
alter table Customer_Orders  drop constraint FK_Customer_Orders


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FAEE84E9A8]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FAEE84E9A8


    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'Customer_Orders') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer_Orders

    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    create table Customer (
        CustomerId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (CustomerId)
    )

    create table Customer_Orders (
        OrderId UNIQUEIDENTIFIER not null,
       ProductId UNIQUEIDENTIFIER not null
    )

    create table [Order] (
        OrderId UNIQUEIDENTIFIER not null,
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

    alter table Customer_Orders 
        add constraint FKE171AE6E8DF8A3F1 
        foreign key (ProductId) 
        references [Order]

    alter table Customer_Orders 
        add constraint FK_Customer_Orders 
        foreign key (OrderId) 
        references Customer

    alter table Category 
        add constraint FKFA88A7FAEE84E9A8 
        foreign key (ParentCategoryId) 
        references Category
