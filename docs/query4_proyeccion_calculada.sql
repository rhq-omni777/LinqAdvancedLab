SELECT [p].[Name], [p].[Price], [c].[Name] AS [Categoria], [p].[Price] * 1.21 AS [PrecioConIVA], [p].[Price] * CAST([p].[Stock] AS decimal(18,2)) AS [ValorInventario]
FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON [p].[CategoryId] = [c].[Id]
WHERE [p].[Stock] > 0
ORDER BY [p].[Price] * CAST([p].[Stock] AS decimal(18,2)) DESC