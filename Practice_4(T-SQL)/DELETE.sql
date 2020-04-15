USE [Practice_4]
GO

DELETE FROM [dbo].[Flower]
      WHERE Name = 'Aloe'
GO

DELETE FROM [dbo].[PlantationFlower]
      WHERE PlantationId = 6 AND FlowerId = 8
GO
