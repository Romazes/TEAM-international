--------------------------------------1-----------------------------------------------------------
/*список плантаций
*/
Select [Name]
From [Practice_4].[dbo].[Plantation]
---------------------------------------2----------------------------------------------------------
/*данные по плантации: список цветов и их количество. 
Столбцы в результате: Id плантации, имя, адрес, имя вида цветов, количество;
*/
SELECT p.[Id] as [id_Plantation], p.[Name] as [Name of PLantation], p.[Address] as [Plnatation Address], 
	   f.[Name] as [Kind of Flower], pf.[Amount] as [Amount on Plantation]
FROM [Practice_4].[dbo].[Plantation] AS p, [Practice_4].[dbo].[Flower] AS f, 
	 [Practice_4].[dbo].[PlantationFlower] AS pf
	 WHERE p.[Id] = pf.[PlantationId] AND f.[Id] = pf.[FlowerId];

---------------------------------------3----------------------------------------------------------
/*данные по видам цветов: для каждого вида количество плантаций, на которых есть цветы данного вида. 
Столбцы в результате: Id вида цветов, имя, количество плантаций 
(должно выводиться имя столбца "Plantations number");
*/

SELECT f.[Id] as [FlowerID], f.[Name] as [FlowerName], COUNT(pf.[PlantationId]) as [Plantations number]
FROM [Practice_4].[dbo].[Plantation] AS p, [Practice_4].[dbo].[Flower] AS f,
	 [Practice_4].[dbo].[PlantationFlower] AS pf
WHERE p.[Id] = pf.[PlantationId] AND f.[Id] = pf.[FlowerId]
GROUP BY f.[Id], f.[Name];
-----------------------------------------4--------------------------------------------------------
/*данные по видам цветов: для каждого вида количество плантаций, 
на которых есть цветы данного вида в количестве больше 1000. 
Столбцы, как и в предыдущем пункте;
*/
SELECT f.[Id] as [FlowerID], f.[Name] as [FlowerName], 
	   COUNT(pf.[PlantationId]) as [Plantations number]
FROM [Practice_4].[dbo].[Flower] AS f
	 INNER JOIN [Practice_4].[dbo].[PlantationFlower] AS pf
	 ON f.[Id] = pf.[FlowerId]
WHERE pf.[Amount] > 1000
GROUP BY f.[Id], f.[Name]
ORDER BY f.[Id]

------------------------------------------5-------------------------------------------------------
/*данные по поставкам: список цветов и их количество (общее по каждому виду), 
поставки которых назначены из определенной плантации. 
Столбцы в результате: Id вида цветов, имя, количество. 
Это будут данные по какой-то одной плантации;
Только те поставки, которые имеют статус "Scheduled"
*/
SELECT f.[Id] as [FlowerID], f.[Name] as [Kind of FLower], sf.[Amount]
FROM [Practice_4].[dbo].[Plantation] AS p, 
	 [Practice_4].[dbo].[Supply] as s,
	 [Practice_4].[dbo].[Flower] AS f
	 INNER JOIN [Practice_4].[dbo].[SupplyFlower] as sf
	 ON f.[Id] = sf.[FlowerId]
WHERE s.[PlantationId] = 5 AND
	s.[Status] = 'Scheduled' 
	AND s.[PlantationId] = p.[Id] 
	AND s.[Id] = sf.[SupplyId]
ORDER BY f.[Id]
-----------------------------------------6--------------------------------------------------------
/*данные по поставкам: успешно выполненные поставки за последний месяц. 
Столбцы в результате: Id поставки, имя плантации, имя склада, дата выполнения поставки.
Поставки со статусом "Closed" за последние 30 дней.
*/
DECLARE @todayDate DATE = GETDATE()
DECLARE @last30Day DATE = DATEADD(DAY, -30, GETDATE())

SELECT s.[Id] as [PlantationID],
	   p.[Name] as [PlantationName],
	   w.[Name] as [WarehouseName],
	   s.[ClosedDate]
FROM [Practice_4].[dbo].[Warehouse] as w,
	 [Practice_4].[dbo].[Plantation] AS p
INNER JOIN [Practice_4].[dbo].[Supply] as s
ON p.[Id] = s.[PlantationId] 
WHERE s.ClosedDate > @last30Day AND s.ClosedDate < @todayDate AND s.[WarehouseId] = w.[Id]
