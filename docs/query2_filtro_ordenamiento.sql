SELECT [p].[Name], [p].[Price], [c].[Name]
FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON [p].[CategoryId] = [c].[Id]
WHERE [p].[Stock] > 0 AND [p].[Price] < 1000.0
ORDER BY [p].[Price]