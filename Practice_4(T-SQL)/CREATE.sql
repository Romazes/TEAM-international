----------------------------------CREATE TABLE 'Plantation'--------------------------------------------
CREATE TABLE Plantation
(  
    Id int NOT NULL IDENTITY(1,1),
    Name varchar(50) NOT NULL,
	Address varchar(100) NOT NULL,
	CONSTRAINT PK_Plantation_Id PRIMARY KEY(Id)
);

----------------------------------CREATE TABLE 'Flower'--------------------------------------------
CREATE TABLE Flower
(  
    Id INT NOT NULL IDENTITY(1,1),
	Name varchar(50) NOT NULL,
	CONSTRAINT PK_Flower_Id PRIMARY KEY(Id)
);


----------------------------------CREATE TABLE 'PlantationFlower'--------------------------------------------
CREATE TABLE PlantationFlower
( PlantationId INT NOT NULL,
FlowerId INT NOT NULL,
Amount INT NOT NULL,
PRIMARY KEY (PlantationId, FlowerId),
CONSTRAINT FK_Plantation_Id FOREIGN KEY(PlantationId)
REFERENCES Plantation(Id)
ON UPDATE CASCADE
ON DELETE CASCADE,
CONSTRAINT FK_Flower_Id FOREIGN KEY(FlowerId)
REFERENCES Flower(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
);

----------------------------------CREATE TABLE 'Warehouse'--------------------------------------------
CREATE TABLE Warehouse
(  
    Id int NOT NULL IDENTITY(1,1),
    Name varchar(50) NOT NULL,
	Address varchar(100) NOT NULL,
	CONSTRAINT PK_Warehouse_Id PRIMARY KEY(Id)
);

----------------------------------CREATE TABLE 'WarehouseFlower'--------------------------------------------
CREATE TABLE WarehouseFlower
( 
	WarehouseId INT NOT NULL,
	FlowerId INT NOT NULL,
	Amount INT NOT NULL,
	PRIMARY KEY (WarehouseId, FlowerId),
	CONSTRAINT FK_Warehouse_Id FOREIGN KEY(WarehouseId)
	REFERENCES Warehouse(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_WarehouseFlower_Id FOREIGN KEY(FlowerId)
	REFERENCES Flower(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);

----------------------------------CREATE TABLE 'Supply'--------------------------------------------
CREATE TABLE Supply
(  
    Id int NOT NULL IDENTITY(1,1),
    PlantationId int NOT NULL,
	WarehouseId int NOT NULL,
	ScheduledDate date,
	ClosedDate date,
	Status varchar(20),
	CONSTRAINT PK_Supply_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Plantation_Supply_Id FOREIGN KEY(PlantationId)
	REFERENCES Plantation(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_Warehouse_Supply_Id FOREIGN KEY(WarehouseId)
	REFERENCES Warehouse(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);

----------------------------------CREATE TABLE 'SupplyFlower'--------------------------------------------
CREATE TABLE SupplyFlower
( 
	SupplyId INT NOT NULL,
	FlowerId INT NOT NULL,
	Amount INT NOT NULL,
	PRIMARY KEY (SupplyId, FlowerId),
	CONSTRAINT FK_Supply_Id FOREIGN KEY(SupplyId)
	REFERENCES Supply(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	CONSTRAINT FK_Flower_Supply_Id FOREIGN KEY(FlowerId)
	REFERENCES Flower(Id)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);
