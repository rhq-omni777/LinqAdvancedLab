SELECT [p].[Name], [p].[Price], [c].[Name]
FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON [p].[CategoryId] = [c].[Id]
WHERE [p].[Price] > 500.0