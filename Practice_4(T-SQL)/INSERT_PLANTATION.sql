SET IDENTITY_INSERT [Practice_4].[dbo].[Plantation] ON

INSERT [Practice_4].[dbo].[Plantation]
		([Id],
		[Name],
		[Address])
VALUES 
	(1, 'Plantation1', 'Kharkiv')

SET IDENTITY_INSERT [Practice_4].[dbo].[Plantation] OFF
-------------------------------------------------------------------------
INSERT INTO [Practice_4].[dbo].[Plantation]
           ([Name],
		   [Address])
     VALUES
		   ('Plantation2', 'Kyiv'),
		   ('Plantation3', 'Poltava'),
		   ('Plantation4', 'Dnipro'),
		   ('Plantation5', 'Lviv')
GO
---------------------------------------------------------------------------
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Address]
  FROM [Practice_4].[dbo].[Plantation]
