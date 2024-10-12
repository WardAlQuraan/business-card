## BusinessCardBackend
This is the backend service for the Business Card application, built using Entity Framework Core and SQL Server.

## Project Description
This project provides the backend service for storing and managing business card information. It exposes a set of APIs that allow users to perform operations like creating, reading, updating, and deleting business card records, as well as uploading and serving images.


## Technologies Used
  1- .NET Core
  2- Entity Framework Core
  3- SQL Server
  4- ASP.NET Core Web API

## Installation
To set up the project locally, follow these steps:
  1- Clone the repository: (git clone https://github.com/WardAlQuraan/business-card.git)
  2- Navigate into the project directory: (cd BusinessCardBackend)
  3- Install the necessary dependencies: (dotnet restore)

## Database Backup
To download the database backup, follow these steps:
  1. Visit the [database dump](https://github.com/WardAlQuraan/business-card/blob/main/BusinessCardDump/BusinessCardDump.sql) file on GitHub.
  2. Copy the commands and run the script on your local machine
  3. if you want to test data please run the following commands to store them on your local database
     

  

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('John Doe', '1990-01-01', 'Male', '123-456-7890', 'john.doe@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Jane Smith', '1985-02-14', 'Female', '987-654-3210', 'jane.smith@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Michael Johnson', '1992-03-03', 'Male', '555-123-4567', 'michael.johnson@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Emily Davis', '1988-04-22', 'Female', '444-555-6789', 'emily.davis@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Chris Brown', '1995-05-12', 'Male', '222-333-4444', 'chris.brown@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Sarah Wilson', '1991-06-30', 'Female', '666-777-8888', 'sarah.wilson@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('David Clark', '1987-07-25', 'Male', '111-222-3333', 'david.clark@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Laura Martinez', '1983-08-14', 'Female', '888-999-0000', 'laura.martinez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Daniel Lewis', '1989-09-19', 'Male', '777-888-9999', 'daniel.lewis@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Olivia Walker', '1993-10-02', 'Female', '555-666-7777', 'olivia.walker@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('James Allen', '1986-11-11', 'Male', '444-555-6666', 'james.allen@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Sophia Hall', '1994-12-05', 'Female', '333-444-5555', 'sophia.hall@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Matthew Young', '1990-01-20', 'Male', '222-333-4444', 'matthew.young@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Isabella Hernandez', '1987-02-28', 'Female', '999-888-7777', 'isabella.hernandez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Ethan King', '1995-03-15', 'Male', '444-333-2222', 'ethan.king@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Ava Wright', '1991-04-17', 'Female', '666-555-4444', 'ava.wright@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Alexander Scott', '1993-05-22', 'Male', '111-222-3333', 'alexander.scott@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Mia Green', '1988-06-10', 'Female', '888-999-0000', 'mia.green@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Benjamin Adams', '1994-07-01', 'Male', '222-111-3333', 'benjamin.adams@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Charlotte Baker', '1992-08-05', 'Female', '555-666-7777', 'charlotte.baker@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Jacob Nelson', '1986-09-16', 'Male', '333-222-4444', 'jacob.nelson@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Amelia Carter', '1990-10-30', 'Female', '777-888-9999', 'amelia.carter@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Daniel Mitchell', '1985-11-28', 'Male', '111-222-3333', 'daniel.mitchell@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Ella Perez', '1994-12-24', 'Female', '999-888-7777', 'ella.perez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('William Roberts', '1989-01-13', 'Male', '444-555-6666', 'william.roberts@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Grace Turner', '1993-02-19', 'Female', '222-111-3333', 'grace.turner@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('James White', '1987-03-22', 'Male', '555-666-7777', 'james.white@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Zoe Scott', '1991-04-11', 'Female', '888-999-0000', 'zoe.scott@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Liam Hall', '1995-05-30', 'Male', '444-555-6666', 'liam.hall@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Chloe Lee', '1988-06-05', 'Female', '333-222-4444', 'chloe.lee@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Lucas Allen', '1992-07-22', 'Male', '777-888-9999', 'lucas.allen@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Megan King', '1990-08-30', 'Female', '111-222-3333', 'megan.king@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Elijah Wright', '1993-09-17', 'Male', '222-333-4444', 'elijah.wright@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Sofia Martinez', '1986-10-02', 'Female', '555-666-7777', 'sofia.martinez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Jackson Brown', '1995-11-12', 'Male', '888-999-0000', 'jackson.brown@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Avery Scott', '1991-12-15', 'Female', '444-555-6666', 'avery.scott@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Sebastian Davis', '1989-01-26', 'Male', '333-222-4444', 'sebastian.davis@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Natalie Young', '1990-02-22', 'Female', '777-888-9999', 'natalie.young@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Gabriel Thompson', '1984-03-15', 'Male', '111-222-3333', 'gabriel.thompson@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Samantha Hill', '1995-04-18', 'Female', '222-333-4444', 'samantha.hill@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Ryan Garcia', '1987-05-20', 'Male', '555-666-7777', 'ryan.garcia@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Victoria Perez', '1991-06-12', 'Female', '888-999-0000', 'victoria.perez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Joseph Martinez', '1989-07-23', 'Male', '444-555-6666', 'joseph.martinez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Madison Robinson', '1994-08-11', 'Female', '333-222-4444', 'madison.robinson@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Owen Turner', '1993-09-05', 'Male', '777-888-9999', 'owen.turner@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Maya Lewis', '1986-10-15', 'Female', '111-222-3333', 'maya.lewis@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Henry Cooper', '1991-11-24', 'Male', '222-333-4444', 'henry.cooper@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Lily Rogers', '1990-12-30', 'Female', '555-666-7777', 'lily.rogers@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Dylan Reed', '1988-01-08', 'Male', '888-999-0000', 'dylan.reed@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Hailey Wood', '1992-02-25', 'Female', '444-555-6666', 'hailey.wood@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Evan Price', '1993-03-29', 'Male', '333-222-4444', 'evan.price@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Nora Bell', '1985-04-16', 'Female', '777-888-9999', 'nora.bell@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Caleb Gray', '1991-05-12', 'Male', '111-222-3333', 'caleb.gray@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Scarlett Diaz', '1986-06-07', 'Female', '222-333-4444', 'scarlett.diaz@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Jack Morales', '1990-07-23', 'Male', '555-666-7777', 'jack.morales@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Claire Stewart', '1992-08-16', 'Female', '888-999-0000', 'claire.stewart@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Chase Sanchez', '1995-09-10', 'Male', '444-555-6666', 'chase.sanchez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Lillian Price', '1993-10-24', 'Female', '333-222-4444', 'lillian.price@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Anthony Bennett', '1984-11-15', 'Male', '777-888-9999', 'anthony.bennett@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Lucy Foster', '1992-12-20', 'Female', '111-222-3333', 'lucy.foster@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Joshua Hughes', '1987-01-30', 'Male', '222-333-4444', 'joshua.hughes@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Sadie Sanders', '1991-02-05', 'Female', '555-666-7777', 'sadie.sanders@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Isaac Rivera', '1989-03-12', 'Male', '888-999-0000', 'isaac.rivera@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Samantha Hughes', '1993-04-19', 'Female', '444-555-6666', 'samantha.hughes@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Aaron Rivera', '1986-05-22', 'Male', '333-222-4444', 'aaron.rivera@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Evelyn Gonzalez', '1990-06-11', 'Female', '777-888-9999', 'evelyn.gonzalez@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Noah Wood', '1994-07-17', 'Male', '111-222-3333', 'noah.wood@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Maya Carter', '1992-08-27', 'Female', '222-333-4444', 'maya.carter@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Nathaniel Cooper', '1988-09-21', 'Male', '555-666-7777', 'nathaniel.cooper@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Ariana Lee', '1990-10-14', 'Female', '888-999-0000', 'ariana.lee@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Thomas Wright', '1986-11-04', 'Male', '444-555-6666', 'thomas.wright@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Hailey Wright', '1991-12-18', 'Female', '333-222-4444', 'hailey.wright@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Alexander Foster', '1995-01-09', 'Male', '777-888-9999', 'alexander.foster@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Peyton Young', '1990-02-15', 'Female', '111-222-3333', 'peyton.young@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Carter Thompson', '1994-03-29', 'Male', '222-333-4444', 'carter.thompson@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Gianna White', '1989-04-24', 'Female', '555-666-7777', 'gianna.white@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Dominic Hall', '1993-05-19', 'Male', '888-999-0000', 'dominic.hall@example.com');

INSERT INTO [PS_BUSINESS_CARD].[dbo].[BUSINESS_CARD] ([NAME], [DOB], [GENDER], [PHONE], [EMAIL])
VALUES ('Sophie Martinez', '1991-06-30', 'Female', '444-555-6666', 'sophie.martinez@example.com');
