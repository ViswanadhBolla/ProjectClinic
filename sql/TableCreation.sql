create database clinic

use clinic

create table UserInfo(
	username varchar(10) primary key, 
	firstname varchar(30) not null,
	lastname varchar(30) not null,
	userpassword varchar(15) not null
	);

select * from UserInfo

create table DoctorInfo(
	docID int identity(1001,1) primary key,
	firstname varchar(30) not null,
	lastname varchar(30) not null,
	gender varchar(20) not null,
	specialization varchar(50) not null,
	shiftstart time(0) not null,
	shiftend time(0) not null
	);

select * from DoctorInfo

create table patientInfo(
	patientID int identity(10001,1) primary key,
	firstname varchar(30) not null,
	lastname varchar(30) not null,
	gender varchar(30) not null,
	age int not null,
	DOB date not null
	);

select * from patientInfo

create table appointments(
	patientID int ,
	doctorID int,
	appointTime datetime,
	foreign key(patientID) references patientInfo(patientID),
	foreign key(doctorID) references DoctorInfo(docID)
	);

select * from appointments

insert into UserInfo values('user1001','viswanadh','bolla','userpass@1001')

insert into DoctorInfo values('doc1FN','doc1LN','Male','General Medicine','09:00:00','12:00:00');
insert into DoctorInfo values('doc2FN','doc2LN','Female','General Medicine','13:00:00','16:00:00');
insert into DoctorInfo values('doc3FN','doc3LN','Female','Internal Medicine','10:00:00','12:00:00');
insert into DoctorInfo values('doc4FN','doc4LN','Others','Internal Medicine','14:00:00','16:00:00');

go
create proc insertPatientData @firstname varchar(30),@lastname varchar(30),@gender varchar(30),@age int,@dob date
as
insert into patientInfo values(@firstname,@lastname,@gender,@age,@dob)

insert into appointments values(10004,1001,'08-27-2022 10:00:00')