CREATE TABLE [dbo].[Books] (
    [Book ID]   INT           NOT NULL,
    [Title]     NVARCHAR(100) NULL,
    [Author]    VARCHAR (50)  NULL,
    [Publisher] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Book ID] ASC)
);

