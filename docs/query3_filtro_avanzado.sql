SELECT [p].[Name], [p].[Price], [c].[Name]
FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON [p].[CategoryId] = [c].[Id]
WHERE ([p].[Price] > 100.0 AND [p].[Stock] < 20) OR [p].[Name] LIKE N'%Laptop%'
ORDER BY [p].[Price] DESC