CREATE TABLE [dbo].[Imagem](
	[IdProduto] [bigint] NOT NULL,
	[ImageArray] [varbinary](max) NOT NULL
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([IdProduto] ASC)
) 

ALTER TABLE [dbo].[Imagem]  WITH CHECK ADD  CONSTRAINT [FK_Imagem_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Produto] ([Id])

ALTER TABLE [dbo].[Imagem] CHECK CONSTRAINT [FK_Imagem_Produto]