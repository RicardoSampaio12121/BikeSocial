/*----------------------------------
		Apagar dados
----------------------------------*/


DELETE FROM [dbo].[AthleteFederationRequests]
DELETE FROM [dbo].[AthleteTypes];
DELETE FROM [dbo].[Athletes];
DELETE FROM [dbo].[AthleteParents];
DELETE FROM [dbo].[Achievements];
DELETE FROM [dbo].[AchievementTypes];
DELETE FROM [dbo].[AthleteAchievements];
DELETE FROM [dbo].[AthleteFederationRequests];
DELETE FROM [dbo].[Coaches];
DELETE FROM [dbo].[Directors];
DELETE FROM [dbo].[DirectorTypes];
DELETE FROM [dbo].[Friend];
DELETE FROM [dbo].[PasswordRecoveryCodes];
DELETE FROM [dbo].[Places];
DELETE FROM [dbo].[Plans];
DELETE FROM [dbo].[Prizes];
DELETE FROM [dbo].[ProfileAchievements];
DELETE FROM [dbo].[Profiles];
DELETE FROM [dbo].[RaceInvites];
DELETE FROM [dbo].[RaceResults];
DELETE FROM [dbo].[Races];
DELETE FROM [dbo].[RaceTypes];
DELETE FROM [dbo].[RouteInvites];
DELETE FROM [dbo].[Routes];
DELETE FROM [dbo].[RouteTypes];
DELETE FROM [dbo].[TeamFederationRequests];
DELETE FROM [dbo].[TeamInviteAthletes];
DELETE FROM [dbo].[TeamInviteCoaches];
DELETE FROM [dbo].[Clubs];
DELETE FROM [dbo].[Teams];
DELETE FROM [dbo].[Federations];
DELETE FROM [dbo].[TrainingInvites];
DELETE FROM [dbo].[Trainings];
DELETE FROM [dbo].[TrainingTypes];
DELETE FROM [dbo].[Users];
DELETE FROM [dbo].[UserTypes];
DELETE FROM [dbo].[AthleteFederationRequests];

/*---------------------------------------------
		reset identity tables 

executar se nao quiserem acabar a base de dados
---------------------------------------------*/
/*
DBCC CHECKIDENT ('[AthleteParents]', RESEED, 0);
DBCC CHECKIDENT ('[AthleteFederationRequests]', RESEED, 0);
DBCC CHECKIDENT ('[AthleteTypes]', RESEED, 0);
DBCC CHECKIDENT ('[Athletes]', RESEED, 0);
DBCC CHECKIDENT ('[Achievements]', RESEED, 0);
DBCC CHECKIDENT ('[AchievementTypes]', RESEED, 0);
DBCC CHECKIDENT ('[AthleteAchievements]', RESEED, 0);
DBCC CHECKIDENT ('[AthleteFederationRequests]', RESEED, 0);
DBCC CHECKIDENT ('[Clubs]', RESEED, 0);
DBCC CHECKIDENT ('[Coaches]', RESEED, 0);
DBCC CHECKIDENT ('[Directors]', RESEED, 0);
DBCC CHECKIDENT ('[DirectorTypes]', RESEED, 0);
DBCC CHECKIDENT ('[Federations]', RESEED, 0);
DBCC CHECKIDENT ('[Friend]', RESEED, 0);
DBCC CHECKIDENT ('[PasswordRecoveryCodes]', RESEED, 0);
DBCC CHECKIDENT ('[Places]', RESEED, 0);
DBCC CHECKIDENT ('[Plans]', RESEED, 0);
DBCC CHECKIDENT ('[Prizes]', RESEED, 0);
DBCC CHECKIDENT ('[ProfileAchievements]', RESEED, 0);
DBCC CHECKIDENT ('[Profiles]', RESEED, 0);
DBCC CHECKIDENT ('[RaceInvites]', RESEED, 0);
DBCC CHECKIDENT ('[RaceResults]', RESEED, 0);
DBCC CHECKIDENT ('[Races]', RESEED, 0);
DBCC CHECKIDENT ('[RaceTypes]', RESEED, 0);
DBCC CHECKIDENT ('[RouteInvites]', RESEED, 0);
DBCC CHECKIDENT ('[Routes]', RESEED, 0);
DBCC CHECKIDENT ('[RouteTypes]', RESEED, 0);
DBCC CHECKIDENT ('[TeamFederationRequests]', RESEED, 0);
DBCC CHECKIDENT ('[TeamInviteAthletes]', RESEED, 0);
DBCC CHECKIDENT ('[TeamInviteCoaches]', RESEED, 0);
DBCC CHECKIDENT ('[Teams]', RESEED, 0);
DBCC CHECKIDENT ('[TrainingInvites]', RESEED, 0);
DBCC CHECKIDENT ('[Trainings]', RESEED, 0);
DBCC CHECKIDENT ('[TrainingTypes]', RESEED, 0);
DBCC CHECKIDENT ('[Users]', RESEED, 0);
DBCC CHECKIDENT ('[UserTypes]', RESEED, 0);
*/

/*----------------------------------------------
	     Inserir dados na tabela Places
----------------------------------------------*/

INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Lamaçães', 'Perto do BK');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Braga', 'Rodovia');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Gualtar', 'UM');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Maximinus', 'Perto do MC');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Avenida da Liberdade', 'Perto da Sé');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Avenida da Liberdade', 'Meo Arena');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Póvoa de Lanhoso', 'Parque do Pontido');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Avenida da Liberdade', 'Parque da Ponto');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Matosinhos', 'Senhora da Hora', 'Norte Shopping');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Braga', 'Perto do Braga Parque');
INSERT INTO [dbo].[Places] ([City], [Town], [PlaceName]) VALUES ('Braga', 'Braga', 'Perto do Nova Arcada');

/*----------------------------------------------
	     Inserir dados na tabela UserTypes
----------------------------------------------*/

INSERT INTO [dbo].[UserTypes] ([name]) VALUES ('athlete');
INSERT INTO [dbo].[UserTypes] ([name]) VALUES ('parent');
INSERT INTO [dbo].[UserTypes] ([name]) VALUES ('director');
INSERT INTO [dbo].[UserTypes] ([name]) VALUES ('coach');
INSERT INTO [dbo].[UserTypes] ([name]) VALUES ('federationFunc');


/*----------------------------------------------
	     Inserir dados na tabela Users
----------------------------------------------*/

/* Atletas */
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Cristina Cruz', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','F', '2012-02-21T18:10:00', 961111111, 1, 1, 'exemplo1@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Ricardo Sampaio', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111112, 3, 1, 'exemplo2@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Filipe Gajo', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111113, 2, 1, 'exemplo3@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Joana Nikki', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','F', '2012-02-21T18:10:00', 961111114, 4, 1, 'exemplo4@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Paula Rodrigues', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','F', '2012-02-21T18:10:00', 961111115, 6, 1, 'exemplo5@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Nuno Ayy', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111116, 8, 1, 'exemplo6@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Ronnie Coleman', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111117, 10, 1, 'exemplo7@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Dorian Yates', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','F', '2012-02-21T18:10:00', 961111118, 3, 1, 'exemplo8@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Chris Bumstead', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111119, 5, 1, 'exemplo9@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Phil Heath', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111121, 7, 1, 'exemplo10@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Dexter Jackson', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111122, 9, 1, 'exemplo11@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex], [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Frank Zane', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','F', '2012-02-21T18:10:00', 961111123, 2, 1, 'exemplo12@hotmail.com');

/*Treinadores*/
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('John Meadows', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111124, 4, 4, 'exemplo13@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Dennis James', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','M', '2012-02-21T18:10:00', 961111125, 1, 4, 'exemplo14@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Chris Lewis', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so', 'M', '2012-02-21T18:10:00', 961111126, 7, 4, 'exemplo15@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Charles Glass', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so', 'M', '2012-02-21T18:10:00', 961111127, 9, 4, 'exemplo16@hotmail.com');

/*diretores*/
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Glassy Glass', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so', 'M', '2012-02-21T18:10:00', 961111128, 4, 3, 'exemplo17@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('James Bond', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so', 'M', '2012-02-21T18:10:00', 961111129, 1, 3, 'exemplo18@hotmail.com');
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Luisa Rodrigues', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so','F', '2012-02-21T18:10:00', 961111131, 7, 3, 'exemplo19@hotmail.com');

/*funionario federação*/
INSERT INTO [dbo].[Users] ([username], [password], [sex],  [birthDate], [contact], [PlacesId], [UserTypesId], [email]) VALUES ('Jonhy Jota', 'C0GZq/On/8YHVeMKomWlhBCXfCfnB2NgMSdp2OniRKNxp/so', 'M','2012-02-21T18:10:00', 961111132, 3, 5, 'exemplo20@hotmail.com');



/*----------------------------------------------
	     Inserir dados na tabela Profiles
----------------------------------------------*/
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes]) 
VALUES (1, 'Perfil', 0,0,0,1,0,1,0);

INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (2, 'Perfil', 0,1,1,1,0,0,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes]) 
VALUES (3, 'Perfil', 0,0,1,0,1,0,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (4, 'Perfil', 0,1,0,1,0,1,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes]) 
VALUES (5, 'Perfil', 0,1,1,0,0,1,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (6, 'Perfil', 0,1,1,1,0,0,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (7, 'Perfil', 0,0,0,1,1,0,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (8, 'Perfil', 0,1,1,1,1,1,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (9, 'Perfil', 0,0,0,0,0,0,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes]) 
VALUES (10, 'Perfil', 0,1,0,1,0,0,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (11, 'Perfil', 0,1,0,0,0,1,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (12, 'Perfil', 0,0,0,0,1,0,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (13, 'Perfil', 0,1,1,1,1,1,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes]) 
VALUES (14, 'Perfil', 0,0,1,1,0,1,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (15, 'Perfil', 0,1,1,1,0,1,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (16, 'Perfil', 0,0,0,1,1,1,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (17, 'Perfil', 0,1,1,1,1,0,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (18, 'Perfil', 0,1,1,0,0,0,0);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes]) 
VALUES (19, 'Perfil', 0,1,0,1,0,1,1);
INSERT INTO [dbo].[Profiles] ([UsersId], [description], [profileVisibility], [commentsPermission], [unfriendContactPermission], 
[unfriendTrofyVisualization], [privateTrainings], [privateRaces], [privateRoutes])  
VALUES (20, 'Perfil', 0,0,1,0,1,1,1);


/*----------------------------------------------
	     Inserir dados na tabela AthleteTypes
----------------------------------------------*/
INSERT INTO [dbo].[AthleteTypes] ([Name]) VALUES ('Sprint');
INSERT INTO [dbo].[AthleteTypes] ([Name]) VALUES ('Endurance');


/*----------------------------------------------
	     Inserir dados na tabela AthleteParents
----------------------------------------------*/
insert into [dbo].[AthleteParents] ([UsersId])
	values(2);

/*----------------------------------------------
	     Inserir dados na tabela Athletes
----------------------------------------------*/
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (1, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId],[AthleteParentsId]) VALUES (2, 2, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (3, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (4, 2);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (5, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (6, 2);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (7, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (8, 2);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (9, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (10, 2);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (11, 1);
INSERT INTO [dbo].[Athletes] ([usersId], [AthleteTypesId]) VALUES (12, 2);



/*----------------------------------------------
	     Inserir dados na tabela Clubs
----------------------------------------------*/
INSERT INTO [dbo].[Clubs] ([Name], [PlacesId]) VALUES ('Benfas', 2);
INSERT INTO [dbo].[Clubs] ([Name], [PlacesId]) VALUES ('Ports', 3);
INSERT INTO [dbo].[Clubs] ([Name], [PlacesId]) VALUES ('SCP', 1);


/*----------------------------------------------
	     Inserir dados na tabela DirectorTypes
----------------------------------------------*/
INSERT INTO [dbo].[DirectorTypes] ([Name]) VALUES ('CEO');

/*----------------------------------------------
	     Inserir dados na tabela Directors
----------------------------------------------*/
INSERT INTO [dbo].[Directors] ([UsersId], [DirectorTypesId], [ClubsId]) VALUES (17, 1, 1);
INSERT INTO [dbo].[Directors] ([UsersId], [DirectorTypesId], [ClubsId]) VALUES (18, 1, 2);
INSERT INTO [dbo].[Directors] ([UsersId], [DirectorTypesId], [ClubsId]) VALUES (19, 1, 3);

/*----------------------------------------------
	     Inserir dados na tabela Federations
----------------------------------------------*/
INSERT INTO [dbo].[Federations] ([Name]) VALUES ('FPC');
INSERT INTO [dbo].[Federations] ([Name]) VALUES ('SCB');

/*----------------------------------------------
	     Inserir dados na tabela TrainingTypes
----------------------------------------------*/
INSERT INTO [dbo].[TrainingTypes] ([Name]) VALUES ('Subidas');
INSERT INTO [dbo].[TrainingTypes] ([Name]) VALUES ('Descanso ativo');
INSERT INTO [dbo].[TrainingTypes] ([Name]) VALUES ('Sprints');
INSERT INTO [dbo].[TrainingTypes] ([Name]) VALUES ('Intervalado');
INSERT INTO [dbo].[TrainingTypes] ([Name]) VALUES ('Endurance');
INSERT INTO [dbo].[TrainingTypes] ([Name]) VALUES ('Rotação');

/*----------------------------------------------
	     Inserir dados na tabela RouteTypes
----------------------------------------------*/
INSERT INTO [dbo].[RouteTypes] ([Name]) VALUES ('Estrada');
INSERT INTO [dbo].[RouteTypes] ([Name]) VALUES ('Monte');
INSERT INTO [dbo].[RouteTypes] ([Name]) VALUES ('Misto');

/*----------------------------------------------
	     Inserir dados na tabela Route
----------------------------------------------*/
/*DELETE FROM [dbo].[Routes];
DBCC CHECKIDENT ('[Routes]', RESEED, 0);*/
Insert into [dbo].[Routes] ([UsersId], [Public], [Description],[dateTime],[EstimatedTime], [Distance], [PlacesId],[RouteTypesId]) 
				Values(1,1,'Rota Margem do Homem','2022-05-13',3,200,11,2);
Insert into [dbo].[Routes] ([UsersId], [Public], [Description],[dateTime],[EstimatedTime], [Distance], [PlacesId],[RouteTypesId]) 
				Values(1,0,'À Descoberta de Braga','2022-09-25',4,1000,11,3);
Insert into [dbo].[Routes] ([UsersId], [Public], [Description],[dateTime],[EstimatedTime], [Distance], [PlacesId],[RouteTypesId]) 
				Values(4,1,'Senhora da Hora','2020-04-26',4,1000,9,1);

/*----------------------------------------------
	     Inserir dados na tabela RouteInvites
----------------------------------------------*/
Insert into [dbo].[RouteInvites] ([UsersId], [RoutesId], [Confirmation])
		values(2,1,1);
Insert into [dbo].[RouteInvites] ([UsersId], [RoutesId], [Confirmation])
		values(3,1,0);


/*----------------------------------------------
	     Inserir dados na tabela RaceTypes
----------------------------------------------*/
INSERT INTO [dbo].[RaceTypes] ([Name]) VALUES ('Estrada');
INSERT INTO [dbo].[RaceTypes] ([Name]) VALUES ('Monte');
INSERT INTO [dbo].[RaceTypes] ([Name]) VALUES ('Misto');

/*----------------------------------------------
	     Inserir dados na tabela Race
----------------------------------------------*/
insert into [dbo].[Races] ([description], [distance], [estimateTime], [dateTime], [FederationsId], [RaceTypesId], [PlacesId], [State])
values ('Passeio Braga',100,3,'2020-03-14',1,1,1,'aberta');
insert into [dbo].[Races] ([description], [distance], [estimateTime], [dateTime], [FederationsId], [RaceTypesId], [PlacesId], [State])
values ('Passeio UM',500,6,'2021-12-14',1,3,5,'aberta');

/*----------------------------------------------
	     Inserir dados na tabela RaceResults
----------------------------------------------*/
insert into [dbo].[RaceResults] ([RacesId], [AthletesId], [Position])
	values(1,1,3);
insert into [dbo].[RaceResults] ([RacesId], [AthletesId], [Position])
	values(1,2,4);
insert into [dbo].[RaceResults] ([RacesId], [AthletesId], [Position])
	values(1,3,2);
insert into [dbo].[RaceResults] ([RacesId], [AthletesId], [Position])
	values(2,2,4);
insert into [dbo].[RaceResults] ([RacesId], [AthletesId], [Position])
	values(2,1,1);

/*----------------------------------------------
	     Inserir dados na tabela RaceInvites
----------------------------------------------*/
insert into [dbo].[RaceInvites] ([RacesId], [AthletesId], [Confirmation])
	values(1,1,1);
insert into [dbo].[RaceInvites] ([RacesId], [AthletesId], [Confirmation])
	values(2,1,0);
insert into [dbo].[RaceInvites] ([RacesId], [AthletesId], [Confirmation])
	values(2,2,1);
insert into [dbo].[RaceInvites] ([RacesId], [AthletesId], [Confirmation])
	values(1,2,0);

/*----------------------------------------------
	     Inserir dados na tabela AchievementTypes
----------------------------------------------*/
insert into [dbo].[AchievementTypes] ([Name]) values('Coroa');
insert into [dbo].[AchievementTypes] ([Name]) values('Troféu Azul');
insert into [dbo].[AchievementTypes] ([Name]) values('Troféu Dourado');
insert into [dbo].[AchievementTypes] ([Name]) values('Troféu Verde');

/*----------------------------------------------
	     Inserir dados na tabela Achievement
----------------------------------------------*/
insert into [dbo].[Achievements] ([Name], [AchievementTypesId], [PlacesId])
	values('Aventuras de Braga', 1, 2);
insert into [dbo].[Achievements] ([Name], [AchievementTypesId], [PlacesId])
	values('À Beira Mar', 3, 6);

/*----------------------------------------------
	     Inserir dados na tabela AthleteAchievements
----------------------------------------------*/
insert into [dbo].[AthleteAchievements] ([AthletesId], [AchievementsId], [AchievementDate])
	values(1,1,'2022-02-10');
insert into [dbo].[AthleteAchievements] ([AthletesId], [AchievementsId], [AchievementDate])
	values(2,2,'2021-11-25');

/*----------------------------------------------
	     Inserir dados na tabela AthleteFederationRequests
----------------------------------------------*/
insert into [dbo].[AthleteFederationRequests] ([AthletesId], [FederationsId])
	values(1,1);
insert into [dbo].[AthleteFederationRequests] ([AthletesId], [FederationsId])
	values(2,1);
insert into [dbo].[AthleteFederationRequests] ([AthletesId], [FederationsId])
	values(4,1);

/*----------------------------------------------
	     Inserir dados na tabela Training
----------------------------------------------*/
insert into [dbo].[Trainings] ([Name], [dateTime], [EstimatedTime], [Distance], [PlacesId], [TrainingTypesId])
	values('puxa perna','2020-04-15',3,100,1,1);
insert into [dbo].[Trainings] ([Name], [dateTime], [EstimatedTime], [Distance], [PlacesId], [TrainingTypesId])
	values('volta','2021-10-15',3,200,3,6);

/*----------------------------------------------
	     Inserir dados na tabela TrainingInvites
----------------------------------------------*/
insert into [dbo].[TrainingInvites] ([TrainingsId], [AthletesId], [Confirmation])
	values(1,1,1);
insert into [dbo].[TrainingInvites] ([TrainingsId], [AthletesId], [Confirmation])
	values(1,2,0);
insert into [dbo].[TrainingInvites] ([TrainingsId], [AthletesId], [Confirmation])
	values(1,3,1);

/*----------------------------------------------
	     Inserir dados na tabela Friend
----------------------------------------------*/
insert into [dbo].[Friend] ([solicitorId], [recieptientId], [status], [timeSent])
	values(1,2,1,'2021-12-15');
insert into [dbo].[Friend] ([solicitorId], [recieptientId], [status], [timeSent])
	values(3,4,0,'2021-10-25');


/*----------------------------------------------
	     Inserir dados na tabela Plans
----------------------------------------------*/
insert into [dbo].[Plans] ([description], [startTime], [finishTime], [EstimatedTime])
	values('inciante','2021-02-21','2021-05-20',40);
insert into [dbo].[Plans] ([description], [startTime], [finishTime], [EstimatedTime])
	values('inciante2','2021-06-21','2021-10-10',60);
insert into [dbo].[Plans] ([description], [startTime], [finishTime], [EstimatedTime])
	values('intermédia','2021-04-12','2021-11-02',150);

/*----------------------------------------------
	     Inserir dados na tabela Prizes
----------------------------------------------*/
insert into [dbo].[Prizes] ([Name], [raceId])
	values('Melhor de Braga',1);

insert into [dbo].[Prizes] ([Name], [raceId])
	values('Atitude',1);

insert into [dbo].[Prizes] ([Name], [raceId])
	values('Aluno Rapido',2);

insert into [dbo].[Prizes] ([Name], [raceId])
	values('classico Braga',1);


/*----------------------------------------------
	     Inserir dados na tabela ProfileAchievements
----------------------------------------------*/
insert into [dbo].[ProfileAchievements] ([ProfileId], [AthleteAchievementId])
	values(1,1);
insert into [dbo].[ProfileAchievements] ([ProfileId], [AthleteAchievementId])
	values(2,2);
insert into [dbo].[ProfileAchievements] ([ProfileId], [AthleteAchievementId])
	values(1,2);
insert into [dbo].[ProfileAchievements] ([ProfileId], [AthleteAchievementId])
	values(3,1);

/*----------------------------------------------
	     Inserir dados na tabela Teams
----------------------------------------------*/
insert into [dbo].[Teams] ([ClubsId], [Name], [PlacesId], [FederationsId])
	values(3,'todos juntos',2, 1);
insert into [dbo].[Teams] ([ClubsId], [Name], [PlacesId])
	values(2,'Braga',3);
insert into [dbo].[Teams] ([ClubsId], [Name], [PlacesId])
	values(1,'somos mais',4);


/*----------------------------------------------
	     Inserir dados na tabela Coaches
----------------------------------------------*/
INSERT INTO [dbo].[Coaches] ([UsersId], [TeamsId]) VALUES (13,1);
INSERT INTO [dbo].[Coaches] ([UsersId], [TeamsId]) VALUES (14,2);
INSERT INTO [dbo].[Coaches] ([UsersId]) VALUES (15);
INSERT INTO [dbo].[Coaches] ([UsersId]) VALUES (16);

/*----------------------------------------------
	     Inserir dados na tabela TeamFederationRequests
----------------------------------------------*/
insert into [dbo].[TeamFederationRequests] ([TeamsId], [FederationsId])
	values(1,1);
insert into [dbo].[TeamFederationRequests] ([TeamsId], [FederationsId])
	values(2,1);
insert into [dbo].[TeamFederationRequests] ([TeamsId], [FederationsId])
	values(3,1);

/*----------------------------------------------
	     Inserir dados na tabela [TeamInviteAthletes]
----------------------------------------------*/
insert into [dbo].[TeamInviteAthletes] ([TeamsId], [AthletesId], [TrainingsId])
	values(1,1,1);
insert into [dbo].[TeamInviteAthletes] ([TeamsId], [AthletesId])
	values(2,1);

/*----------------------------------------------
	     Inserir dados na tabela [TeamInviteCoaches]
----------------------------------------------*/
insert into [dbo].[TeamInviteCoaches] ([TeamsId], [CoachesId])
	values(1,1);
insert into [dbo].[TeamInviteCoaches] ([TeamsId], [CoachesId])
	values(3,2);


/*----------------------------------------------
	     Inserir dados na tabela Friend
----------------------------------------------*/
insert into [dbo].[PasswordRecoveryCodes] ([UsersId], [code], [requestDate])
	values(1,1111,'2021-10-25');
	