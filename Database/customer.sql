USE [VehicleDatabase]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 28.02.2019 09:21:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerType] [varchar](30) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NOT NULL,
	[Income] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

