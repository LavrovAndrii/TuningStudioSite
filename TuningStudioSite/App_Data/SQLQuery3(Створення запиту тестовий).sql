/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[Title]
      ,[IdClient]
      ,[IdMaster]
      ,[Description]
      ,[DateTime]
  FROM [TuningStudio].[dbo].[3rdMasterOrders]