
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA88A7FA81DE95AC]') AND parent_object_id = OBJECT_ID('Category'))
alter table Category  drop constraint FKFA88A7FA81DE95AC


    if exists (select * from dbo.sysobjects where id = object_id(N'Customer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Customer

    if exists (select * from dbo.sysobjects where id = object_id(N'[Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Order]

    if exists (select * from dbo.sysobjects where id = object_id(N'Category') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Category

    create table Customer (
        CustomerId UNIQUEIDENTIFIER not null,
       Name NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       primary key (CustomerId)
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
       ParentId UNIQUEIDENTIFIER null,
       primary key (CategoryId)
    )

    alter table Category 
        add constraint FKFA88A7FA81DE95AC 
        foreign key (ParentId) 
        references Category
