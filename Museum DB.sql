create database EgyptianMuseum
GO
use EgyptianMuseum

---------------------------------
create table Employee
 (
     EID int IDENTITY,
	 eName varchar(50) not null,
	 Sex char not null,
	 PhoneNo int,
	 ShiftNo int not null,
	 Job varchar(50) not null,
	 Salary int not null,
	 Position int not null, 
	 Primary Key (EID)
 );
 -------------------------------
 create table PastEmployees
 (
	EID int,
	eName varchar(50) not null,
	Sex char not null,
	PhoneNo int,
	ShiftNo int not null,
	Job varchar(50) not null,
	Salary int not null,
	Position int not null, 
	Primary Key (EID),
 );
 
 -------------------------------
 create table Piece
(
	PID int NOT NULL,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID)
);
 --------------------------------------
create table Piece1
(
	OriginalID int,
	PID int IDENTITY,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID),
	Foreign key (OriginalID) references Piece
);
 --------------------------------------
 create table Piece2
(
	OriginalID int,
	PID int IDENTITY,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID),
	Foreign key (OriginalID) references Piece
);
 --------------------------------------
 create table Piece3
(	OriginalID int,
	PID int IDENTITY,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID),
	Foreign key (OriginalID) references Piece
);
 --------------------------------------
  create table Piece4
(
	OriginalID int,
	PID int IDENTITY,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID),
	Foreign key (OriginalID) references Piece
);
 --------------------------------------
  create table Piece5
(
	OriginalID int,
	PID int IDENTITY,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID),
	Foreign key (OriginalID) references Piece
);
 --------------------------------------
  create table Piece6
(
	OriginalID int,
	PID int IDENTITY,
	Title varchar(50) NOT null,
	DynastyNo int not null,
	Material varchar(50),
	Status varchar(50),
	image varchar(400) null,
	Description varchar (400),
	Primary Key (PID),
	Foreign key (OriginalID) references Piece
);
 --------------------------------------
 create table Tourguide
(
	ID int IDENTITY,
	tName varchar(50) NOT null,
	Sex char not  null,
	PhoneNo int,
	_Status varchar(50) not null,
	University varchar(50),
	Salary int null ,
	Primary Key (ID)
);
--------------------------------------
 create table PastTourguides
(
	ID int,
	tName varchar(50) NOT null,
	Sex char not  null,
	PhoneNo int,
	_Status varchar(50) not null,
	University varchar(50),
	Salary int null ,
	Primary Key (ID)
);
---------------------------------------
create table Accounts
(
      EmployeeID int,
	  Username varchar(50) not null,
	  _Password varchar(50) not null,
	  email varchar(60) default null,
	  Foreign Key(EmployeeID) references Employee,
	  Primary Key (EmployeeID,Username)
);

-----------------------------------------------------------------------------------------------------------------------
 use EgyptianMuseum
  create table Maintenance
  (
  MID INT,
  CatNo int,
  Title varchar(50),
  OriginalID int,
  PieceID int ,
  Type varchar(50),
  StartDate varchar(50),
  EndDate varchar(50),
  primary key (MID),
  Foreign key (OriginalID) references Piece
  );
 

create table Museum
(
	MuseumID int IDENTITY,
	MuseumName varchar(50),
	MuseumCity varchar(50),
	museumCountry varchar(50),
	primary key (MuseumID)
);

insert into Museum
values
('Museum of Islamic Art ','Cairo','Egypt'),
('Museum of Memphis','Cairo','Egypt');


create table LoanFrom
(
	ID int identity,
	MuseumID  int ,
	PieceTitle varchar(50) not null,
	LoanPlace varchar(50) not null,
	StartDate date,
	EndDate date,	
	Period int,
	Primary Key (ID),
	Foreign Key(MuseumID) references Museum,
);

create table LoanTo
(
	ID int identity,
	MuseumID  int ,
	PieceTitle varchar(50) not null,
	LoanPlace varchar(50) not null,
	CatNo int,
	OriginalID int,
	PieceID int,
	Period int,
	StartDate date,
	EndDate date,
	Primary Key (ID),
	Foreign Key(MuseumID) references Museum,
	Foreign key (OriginalID) references Piece
);

create table Ptransfer
( 
	ID int identity,
	PieceTitle varchar(50) not null,
	LoanPlace varchar(50) not null,
	CatNo int,
	Period int,
	Primary Key (ID)
);

----------------------------------------------------------------------------------------------------------
create table Trips
 (
     TID int identity,
	 Months int  not null,
	 Dayss int not null,
	 yearss int not null,
	 NumbOfForeignStudents int not null,
	 NumbOfForeignNormal int not null,
	 NumbOfEgyptianStudents int not null,
	 NumbOfEgyptianNormal int not null, 
	 Price int not null,
	 Organisation varchar(50) not null,
	 HRid int not null,
	 tgID int not null,
	 Foreign Key(tgID) references Tourguide,
	 Foreign Key(HRid) references Employee,
	 Primary Key (TID)
 );

 create table Ticket
(
	ID int identity,
	Tmonth int,
	Tday int,
	Tyear int,
	EgyptianStudents int,
	EgyptianNormal int,
	ForeignStudents int,
	ForeignNormal int,
	TotalNumOfPeople int,
	PriceEgypStudent int,
	PriceEgypNormal int,
	PriceForeignStudent int,
	PriceForeignNormal int,
	TotalPrice int,
	Primary Key (Tmonth,Tday)
);

create table TicketPrices
(	ID int,
	PEN int not null,
	PES int not null,
	PFN int not null,
	PFS int not null,
	primary key (ID)
);

create table Organization
(
ID int identity,
Name varchar(100),
Country varchar(50),
Primary Key (ID)

);

INSERT INTO Organization 
values
('Egypt Tours','Egypt'),
('Tourists Tours','Egypt')

 INSERT INTO Trips
 values
 (5,14,2018,20,30,0,10,1600,'Egypt Tours',3,4)

 INSERT INTO Ticket
 values
 (5,14,2018,20,30,0,10,60,100,300,0,1200,1600)

 INSERT INTO TicketPrices
 values
 (1,10,5,120,60)
----------------------------------------------------------------------------------------------------------
 INSERT INTO Employee
  values
  ('Marwan Amer Elsayed','M',01003678920,1,'Receptionist',2000,1)

 INSERT INTO Employee
  values
  ('Ahmed Mohamed Ali','M',01127836579,2,'Janitor',800,1),
  ('Ali Ibrahim Hassan','M',01246583646,1,'Janitor',800,1),
  ('Nada Hatem Mohamed','F',01025672789,1,'Researcher',3000,1),
  ('Ali Tarek Khaled','M',01009802783,2,'Security',1500,1),
  ('Ahmed Tarek Khaled','M',01289028768,1,'Security',1500,1),
  ('Tarek Khaled Sayed','M',01009837689,1,'Security Supervisor',3500,2),
  ('Mohamed Ahmed Gamal','M',01091892783,2,'Researcher',3000,1),
  ('Rawan Khaled Mohamed','F',01089207834,2,'Researchers Supervisor',4000,2),
  ('Rawan Ahmed Amgad','F',01118902738,2,'HR',3000,1)
 
 INSERT INTO Employee
  values
  
  ('Marina Nabil Hatem','F',01127364893,1,'HR',3000,1),
  ('Mariam Ali Youssef','F',01259202736,1,'HR Supervisor',4000,2),
  ('Marwan Amr Khaled','M',01009873678,2,'Receptionist',2000,1),
  ('Malek Mohamed Ali','M',01098767567,2,'Receptionists Supervisor',4000,2),
  ('Rayan Ibrahim Hassan','F',01287362798,2,'Receptionist',2000,1)

  INSERT INTO Employee
  values
 
  ('Hatem Mohamed Ali','M',01009287367,1,'HR',3000,1),
  ('Ali Nabil Mohamed','M',01287898789,1,'General Manager',12000,3)

  INSERT INTO Employee
  values
 
  ('Youssef Hassan Mahmoud','M',01028798098,1,'Treasury Supervisor',3500,2),
  ('Ali Hosni Sayed','M',01049089789,1,'Monuments Supervisor',3500,1),
  ('Samy Hisham Ahmed','M',01234098098,2,'Monuments Supervisor',3500,1),
  ('Nour Ali Sayed','F',01135678935,1,'Monuments Supervisor',3500,1),
  ('Taha Nabil Ali','M',01078736726,2,'Janitors Supervisor',1500,2)
  -----------------------------------------------------------------------------
 INSERT INTO PastEmployees
  values
 
  (18,'Gamal Ibrahim Maged','M',01298902789,1,'Treasury',2500,1)
  -----------------------------------------------------------------------------
 INSERT INTO Accounts
 values
  (1,'marwanamer','asdfg5jk','marwanamer55@gmail.com'),
  (12,'mariamali','asdfghjk', 'mariamali23@hotmail.com'),
  (15,'rayanibrahim','q3ertyui', NULL),
  (17,'alinabil','qwerty5i', NULL),
  (18,'gamalibrahim','qw6rtyui', NULL),
  (21,'samyhisham','qwert5ui', NULL),
  (9, 'salma','12345678',NULL)
  


  ----------------------------------------------------------------
 INSERT INTO Ticket
  values
  (278178,'13-1-2018',10,'Adult','Regular'),
   (279828,'15-1-2018',5,'Adult','Student'),
    (279988,'17-1-2018',50,'Adult','Foregin'),
	 (289299,'19-1-2018',10,'Child','Regular')
----------------------------------------------------
INSERT INTO Piece
	
values
(1,'Psusennes I Mask',21,'Gold','On-Display','c:\Images\P I Mask.jpg','A golden mask covering the mummy of King Psusennes I. It consists of two pieces connected by nails.'),
(2,'Rahotep and Nofret',19,'Stone','In-Transfer','c:\Images\rahotep_nofret.jpg','Two colored statues of Prince Rahotep and Queen Nofert.'),
(3,'King Cobra Statue',12,'Colored Jewels','Under-Maintenance','c:\Images\king cobra statue.jpg','This statue is made of gold, it belonged to king Senusret II who used to put it on top of his crown. The statue has several colored jewels decorating it.'),
(4,'King Tutankhamuns Coffin',18,'Gold Glass paste','On-Display','c:\Images\Tut Ankh mummy-small.jpg','A tomb made of gold and glass paste.'),
(5,'A Pair of Golden Bracelets'	,19,'Gold, Colored Jewels','On-Display','c:\Images\golden bracelets.jpg','A pair of bracelets that belonged to king Ramesses II, decorated by colored jewels.'),	
(6,'Menkaure and his Family',4,'Stone','On-Display','c:\Images\Menkaure & his family.jpg','A statue portraying king Menkaure and his family, made from stone.	'),
(7,'Statue of King Djoser',3,'White Stone','On-Display','c:\Images\King Djoser.jpg','A statue portraying king Djoser, made from white stone.'),
(8,'Statue of King Khafra',	4,'Yellow Stone','On-Display','c:\Images\KhafraQuefren.jpg','A statue portraying king Khafra, made from yellow stone.'),
(9,'Statue of King Mentuhotep II',11,'Stone','In-Transfer','c:\Images\Mentuhotep_Seated.jpg', 'A colored statue of king Mentuhotep II seated.'),
(10,'King Akhenaten and his wife Nefertiti',18,'Stone','Under-Maintenance','c:\Images\Ikhnatoon & his family.jpg','The colored carvings on the stone portary the king, his wife and his daughters.'),
(11,'Statue of King Akhenaten',18,'Stone','On-Display','c:\Images\Akhenaten_statue.jpg','A statue portraying king Akhenaten made of stone.'),
(12,'King Amenhotep III and his Wife',18,'Stone','On-Display','c:\Images\Amenhotep_III_statue.jpg','Two large statues of King Amenhotep III and his wife made of stone.'),	
(13,'Statue of Queen Hatshepsut	',18,'Dark stone','	Under-Maintenance','c:\Images\Hatshepsut.jpg','A statue of Queen Hatshepsut made of dark stone.'),
(14,'Statue of King Seti I',19,'Dark stone','In-Transfer','c:\Images\Seti I.jpg','A statue of King Seti I made of dark stone.'),
(15,'Mask of Queen Tuya',19,'	Gold','On-Display','c:\Images\Mummy_mask_of_Yuya.jpg','A mask of Queen Tuya made of gold.');
-------------------------------------------------------------------------------------------------------------
INSERT INTO Piece2 (OriginalID, Title, DynastyNo, Material, Status, image, Description)
values
(6,'Menkaure and his Family',4,'Stone','On-Display','c:\Images\Menkaure & his family.jpg','A statue portraying king Menkaure and his family, made from stone.	'),
(7,'Statue of King Djoser',3,'White Stone','On-Display','c:\Images\King Djoser.jpg','A statue portraying king Djoser, made from white stone.'),
(8,'Statue of King Khafra',	4,'Yellow Stone','On-Display','c:\Images\KhafraQuefren.jpg','A statue portraying king Khafra, made from yellow stone.');
-------------------------------------------------------------------------------------------------------------
INSERT INTO Piece3 (OriginalID, Title, DynastyNo, Material, Status, image, Description)
values
(3,'King Cobra Statue',12,'Colored Jewels','Under-Maintenance','c:\Images\king cobra statue.jpg','This statue is made of gold, it belonged to king Senusret II who used to put it on top of his crown. The statue has several colored jewels decorating it.'),
(9,'Statue of King Mentuhotep II',11,'Stone','In-Transfer','c:\Images\Mentuhotep_Seated.jpg', 'A colored statue of king Mentuhotep II seated.');
-------------------------------------------------------------------------------------------------------------
INSERT INTO Piece4 (OriginalID, Title, DynastyNo, Material, Status, image, Description)
values
(1,'Psusennes I Mask',21,'Gold','On-Display','c:\Images\P I Mask.jpg','A golden mask covering the mummy of King Psusennes I. It consists of two pieces connected by nails.'),
(2,'Rahotep and Nofret',19,'Stone','In-Transfer','c:\Images\rahotep_nofret.jpg','Two colored statues of Prince Rahotep & Queen Nofert.'),
(4,'King Tutankhamuns Coffin',18,'Gold Glass paste','On-Display','c:\Images\Tut Ankh mummy-small.jpg','A tomb made of gold and glass paste.'),
(5,'A Pair of Golden Bracelets'	,19,'Gold, Colored Jewels','On-Display','c:\Images\golden bracelets.jpg','A pair of bracelets that belonged to king Ramesses II, decorated by colored jewels.'),	
(10,'King Akhenaten and his wife Nefertiti',18,'Stone','Under-Maintenance','c:\Images\Ikhnatoon & his family.jpg','The colored carvings on the stone portary the king, his wife and his daughters.'),
(11,'Statue of King Akhenaten',18,'Stone','On-Display','c:\Images\Akhenaten_statue.jpg','A statue portraying king Akhenaten made of stone.'),
(12,'King Amenhotep III and his Wife',18,'Stone','On-Display','c:\Images\Amenhotep_III_statue.jpg','Two large statues of King Amenhotep III and his wife made of stone.'),	
(13,'Statue of Queen Hatshepsut	',18,'Dark stone','	Under-Maintenance','c:\Images\Hatshepsut.jpg','A statue of Queen Hatshepsut made of dark stone.'),
(14,'Statue of King Seti I',19,'Dark stone','In-Transfer','c:\Images\Seti I.jpg','A statue of King Seti I made of dark stone.'),
(15,'Mask of Queen Tuya	',19,'	Gold','On-Display','c:\Images\Mummy_mask_of_Yuya.jpg','A mask of Queen Tuya made of gold.');
-------------------------------------------------------------------------------------------------------------

INSERT INTO Tourguide
  values
  ('Mohamed Ali Youssef','M',01007897678,'Intern','Cairo University',0),
  ('Hussien Amr Youssef','M',01117898767,'Intern','Azhar University',0),
  ('Nada Ahmed Ibrahim','F',01214562567,'Intern','Helwan University',0),
  ('Salma Ali Amr','F',01235678787,'Fulltime','Cairo University',2500),
  ('Mostafa Ali Youssef','M',0105678787,'Fulltime','Ain Shams University',2500),
  ('Abduallah Ahmed Sayed','M',01087689876,'Part-time','Mansoura University',2000),
  ('Dina Amr Mohamed','F',0105678887,'Intern','Ain Shams University',0),
  ('Alia Ahmed Ibrahim','F',01096768787,'Part-time','Cairo University',2000),
  ('Sally Youssef Ali','F',0107888787,'Intern','Cairo University',0),
  ('Selim Mahmoud Ali','M',0105655437,'Intern','Helwan University',0);

  -----------------------------------------------------------------------------------------------------------------------

  