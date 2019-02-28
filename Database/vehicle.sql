USE [VehicleDatabase]
GO

/****** Object:  Table [dbo].[Vehicle]    Script Date: 28.02.2019 09:21:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[Brand] [varchar](30) NOT NULL,
	[Model] [varchar](30) NOT NULL,
	[Kilowatt] [int] NOT NULL,
	[Seats] [int] NOT NULL,
	[Preowned] [int] NOT NULL,
	[Owner] [int] NOT NULL,
 CONSTRAINT [PK_Vehicle2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle2_Customer] FOREIGN KEY([Owner])
REFERENCES [dbo].[Customer] ([ID])
GO

ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle2_Customer]
GO

