CREATE TABLE [dbo].[Produto](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED  ([Id] ASC)
)
