USE [VehicleDatabase]
GO

/****** Object:  Table [dbo].[Sales]    Script Date: 28.02.2019 09:21:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales](
	[Sale_ID] [int] IDENTITY(1,1) NOT NULL,
	[Seller] [int] NOT NULL,
	[Buyer] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Vehicle] [int] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Sale_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer_Buyer] FOREIGN KEY([Buyer])
REFERENCES [dbo].[Customer] ([ID])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer_Buyer]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer_Seller] FOREIGN KEY([Seller])
REFERENCES [dbo].[Customer] ([ID])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer_Seller]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Vehicle] FOREIGN KEY([Vehicle])
REFERENCES [dbo].[Vehicle] ([ID])
GO

ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Vehicle]
GO

