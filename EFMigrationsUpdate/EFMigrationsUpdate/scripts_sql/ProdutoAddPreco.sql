BEGIN TRANSACTION;
GO

ALTER TABLE [Produto] ADD [Preco] decimal(18,2) NOT NULL DEFAULT 0.0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250121002645_ProdutoAddPreco', N'8.0.12');
GO

COMMIT;
GO

