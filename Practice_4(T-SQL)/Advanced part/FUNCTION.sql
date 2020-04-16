IF OBJECT_ID('Checking_Amount_Flowers_For_Supply', 'FN') IS NOT NULL 
DROP FUNCTION [dbo].Checking_Amount_Flower_For_Supply
GO
CREATE FUNCTION [dbo].Checking_Amount_Flowers_For_Supply
	( @UserInput_FlowerId as INT,   
	  @UserInput_PlantationId AS INT,
	  @UserInput_Amount as INT) 
	RETURNS BIT
	AS 
	BEGIN
		IF EXISTS(SELECT pf.[FlowerId], pf.[Amount]
		FROM [Practice_4].[dbo].[PlantationFlower] as pf
		WHERE @UserInput_FlowerId = pf.[FlowerId] AND pf.[PlantationId] = @UserInput_PlantationId
		AND pf.[Amount] >= @UserInput_Amount)
			RETURN 1			
		Return 0
	END; 
GO

--CALL function
SELECT [Practice_4].[dbo].Checking_Amount_Flowers_For_Supply(1, 1, 200)
AS extension 
