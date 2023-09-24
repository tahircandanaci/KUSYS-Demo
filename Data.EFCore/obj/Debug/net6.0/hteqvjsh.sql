IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Customer] (
    [Id] int NOT NULL,
    [Name] varchar(255) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Product] (
    [Id] int NOT NULL,
    [Name] varchar(255) NOT NULL,
    [Price] numeric(38,2) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Order] (
    [Id] int NOT NULL,
    [CustomerId] int NOT NULL,
    [Created] datetime2 NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Stock] (
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Stock_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [OrderItem] (
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL,
    [Total] numeric(38,2) NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([OrderId], [ProductId]),
    CONSTRAINT [FK_OrderItem_Order_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] ON;
INSERT INTO [Customer] ([Id], [Name])
VALUES (1, 'André Secco');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Customer]'))
    SET IDENTITY_INSERT [Customer] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Product]'))
    SET IDENTITY_INSERT [Product] ON;
INSERT INTO [Product] ([Id], [Name], [Price])
VALUES (1, 'Domain-Driven Design: Tackling Complexity in the Heart of Software', 74.99),
(2, 'Agile Principles, Patterns, and Practices in C#', 215.41),
(3, 'Clean Code: A Handbook of Agile Software Craftsmanship', 95.17),
(4, 'Implementing Domain-Driven Design', 126.3),
(5, 'Patterns, Principles, and Practices of Domain-Driven Design', 311.58),
(6, 'Refactoring: Improving the Design of Existing Code', 112.88);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Product]'))
    SET IDENTITY_INSERT [Product] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'Quantity') AND [object_id] = OBJECT_ID(N'[Stock]'))
    SET IDENTITY_INSERT [Stock] ON;
INSERT INTO [Stock] ([ProductId], [Quantity])
VALUES (1, 25),
(2, 12),
(3, 55),
(4, 8),
(5, 14),
(6, 16);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'Quantity') AND [object_id] = OBJECT_ID(N'[Stock]'))
    SET IDENTITY_INSERT [Stock] OFF;
GO

CREATE INDEX [IX_Order_CustomerId] ON [Order] ([CustomerId]);
GO

CREATE INDEX [IX_OrderItem_ProductId] ON [OrderItem] ([ProductId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230920222529_TempMigrationTCD', N'7.0.11');
GO

COMMIT;
GO

