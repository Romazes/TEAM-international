SET IDENTITY_INSERT [Practice_4].[dbo].[Flower] ON

INSERT [Practice_4].[dbo].[Flower]
		([Id],
		[Name])
VALUES 
	(1, 'Rosa')

SET IDENTITY_INSERT [Practice_4].[dbo].[Flower] OFF
-------------------------------------------------------------------------
INSERT INTO [Practice_4].[dbo].[Flower]
           ([Name])
     VALUES
		   ('Chamomile'),
		   ('Aster'),
		   ('Lily'),
		   ('Tulip')
GO
-------------------------------------------------------------------------
SELECT TOP (1000) [Id]
      ,[Name]
  FROM [Practice_4].[dbo].[Flower]
