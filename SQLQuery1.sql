ALTER TABLE [dbo].[laporan] WITH CHECK ADD FOREIGN KEY([id_buku])
REFERENCES [dbo].[buku] ([id_buku])