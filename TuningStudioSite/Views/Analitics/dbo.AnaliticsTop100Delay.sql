CREATE VIEW [dbo].[AnaliticsTasksDone]
SELECT        TOP (100) PERCENT Id, Title, IdClient, IdMaster, Description, DateTime
FROM            dbo.Tasks
WHERE        (DateTime < { fn NOW() })
ORDER BY DateTime