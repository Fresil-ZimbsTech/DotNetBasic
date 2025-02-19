create database CrudADOdb;

create table Employee
(
Id int primary key identity,
name varchar(50) not null,
gender varchar(50) not null,
age int not null,
designation varchar(50) not null,
city varchar(50) not null
);

Go
Create procedure spAddEmployee
(
@name varchar(50) ,
@gender varchar(50) ,
@age int,
@designation varchar(50) ,
@city varchar(50) 
)
as
begin 
Insert into Employee (name,gender,age,designation,city)
values (@name,@gender,@age,@designation,@city)
end

go
Create procedure adUpdateEmployee
(
@Id int,
@name varchar(50) ,
@gender varchar(50) ,
@age int,
@designation varchar(50) ,
@city varchar(50) 
)
as
begin
update Employee set name = @name , gender = @gender , age = @age , designation = @designation , city = @city
where id = @Id
end

go
Create procedure adDeleteEmployee
(
@Id int 
)
as
begin
delete from Employee where id = @Id
end
go

Create procedure adGetAllEmployee

as
begin
		select * from Employee order by id
end