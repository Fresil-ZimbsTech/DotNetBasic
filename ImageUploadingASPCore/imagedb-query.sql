create database imageDb;

create table Product
(
Id int primary key identity,
Name varchar(50) not null,
price int not null,
image_path  varchar(5000) not null,
);