use Shipper

create table Shipper
(
ShipperID bigint identity(1,1) not null,
Primary Key(ShipperID),
[Login] varchar(50) not null,
[Password] binary(20) not null,
EMail varchar(50) not null,
Adress varchar(50) not null,
Phone varchar(20) not null,
[Description] varchar(200)
)
use Shipper
alter table Shipper
--alter column [Password] varchar(20) not null 

alter column [Password] varbinary(20) not null 
use Shipper
create table Customer
(
CustomerID bigint identity(1,1) not null,
Primary Key(CustomerID),
EMail varchar(50) not null,
Adress varchar(50) not null,
Phone varchar(20) not null,
[Description] varchar(200)
)


use Shipper
--drop table [Order]
create table [Order]
(
OrderID bigint identity(1,1) not null,
Primary Key(OrderID),
CustomerIDKEY bigint not null references Customer(CustomerID),
ShipperIDKEY bigint not null references Shipper(ShipperID),
Price numeric(15,2) not null,
[Date] datetime not null,
Comment varchar(200)
)


create table Item
(
ItemID bigint identity(1,1) not null,
Primary Key(ItemID),
[Name] varchar(50) not null,
Price numeric(15,2) not null,
OnStock bigint not null
)

use Shipper
create table AddToOrder
(
OrderIDKEY bigint not null references [Order](OrderID),
ItemIDKEY bigint not null references Item(ItemID),
Amount int not null
)
use Shipper
drop table  Customer [Order] AddToOrder Shipper


use Shipper
--delete from Item
--where ItemID>=3

select * from Item
 order by [Name] ASC

insert into Item 
values
--('White Shirt', 900.00, 145)
('Black Shirt',900,105)


use Shipper
insert into Customer
values('whiteisblack@gmai.com','West St. 42', '096455520', 'No Description')
delete from Customer where CustomerID=1

use Shipper
select * from Shipper Customer

insert into Shipper
values('GrennOn', 1234, 'grennon@gmai.com','South St. 86', '067459821','No Description')
delete from Shipper where ShipperID=2
use Shipper
insert into [Order]
values (1,3,0.00, GETDATE(),'NoComment')

select * from [Order] where OrderID=1

delete from [Order] where OrderID=3



