BEGIN TRANSACTION;
GO

ALTER TABLE [Produto] ADD [Custo] decimal(18,2) NOT NULL DEFAULT 0.0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250121003310_ProdutoAddCusto', N'8.0.12');
GO

COMMIT;
GO

