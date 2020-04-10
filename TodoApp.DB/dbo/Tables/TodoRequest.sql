CREATE TABLE [dbo].[TodoRequest] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (500) NOT NULL,
    [IsComplete]  BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

