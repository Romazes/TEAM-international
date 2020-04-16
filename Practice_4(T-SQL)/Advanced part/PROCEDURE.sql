USE [Practice_4];
GO
IF OBJECT_ID('[dbo].SupplyClosing', 'P') IS NOT NULL
DROP PROCEDURE [dbo].SupplyClosing
GO
CREATE PROCEDURE [dbo].SupplyClosing
@UserInput_supplyId AS INT
AS

BEGIN
	DECLARE @ClientMessage NVARCHAR(100);
	BEGIN TRY
	-- test @supplyId
	IF NOT EXISTS(SELECT 1 FROM [dbo].Supply as s
				  WHERE s.[Id] = @UserInput_supplyId)
		BEGIN
			SET @ClientMessage = 'Suppy id ' + CAST(@UserInput_supplyId AS VARCHAR) + ' is invalid';
			THROW 50000, @ClientMessage, 0;
		END
	--Change Supply statys from 'InProgress' to 'Closed'
	DECLARE @currentSupplyStatus VARCHAR(50),
			@plantationId INT,
			@warehouseId INT;
	SELECT @plantationId = s.[PlantationId], 
		   @warehouseId = s.[WarehouseId], 
		   @currentSupplyStatus = s.[Status]
	FROM [dbo].[Supply] as s
	WHERE s.[Id] = @UserInput_supplyId

	IF(@currentSupplyStatus = 'InProgress')
		BEGIN
			UPDATE
				[dbo].[Supply]
			SET
				[Status] = 'Closed',
				[ClosedDate] = GETDATE()
			WHERE
				[Id] = @UserInput_supplyId;
		END
	--Update 
	DECLARE
		@flowerId INT,
		@amount INT
	BEGIN
		SELECT @flowerId = sf.FlowerId, @amount = sf.Amount
		FROM [dbo].[SupplyFlower] as sf
		WHERE sf.SupplyId = @UserInput_supplyId

		UPDATE 
			[dbo].[PlantationFlower]
		SET
			[Amount] -= @amount
		WHERE
			[PlantationFlower].[PlantationId] = @plantationId AND [PlantationFlower].[FlowerId] = @flowerId

		DELETE FROM [dbo].[SupplyFlower]
		WHERE [SupplyId] = @UserInput_supplyId AND [FlowerId] = @flowerId			

		UPDATE
			[dbo].[WarehouseFlower]
		SET
			[WarehouseId] = @warehouseId,
			[FlowerId] = @flowerId,
			[Amount] += @amount

	END
	END TRY
	BEGIN CATCH
	THROW;
	END CATCH;
END;
GO

EXEC [dbo].[SupplyClosing] @USERINPUT_supplyId = 12
