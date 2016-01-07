  
  alter table ALPHA..WPNAMELIST add IDCATEGORY int
  alter table ALPHA..WPNAMELIST add DECNUM nvarchar(500)
  alter table ALPHA..WPNAMELIST add COMPOSITION nvarchar(max)
  alter table ALPHA..WPNAMELIST add DIMENSIONALDRAWING nvarchar(max)
  alter table ALPHA..WPNAMELIST add POWERSUPPLY nvarchar(500)
  alter table ALPHA..WPNAMELIST add CONFIGURATION nvarchar(1000)
  alter table ALPHA..WPNAMELIST add NOTE nvarchar(max)
  update ALPHA..WPNAMELIST set IDCATEGORY = 1
  -----------------------------------------------------------------------------------------------
  USE [ALPHA]
GO
F:\projects\haltura\SummonManager.git\trunk\changes20151223.sql
/****** Object:  Table [dbo].[CATEGORYLIST]    Script Date: 12/25/2015 15:41:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CATEGORYLIST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CATEGORYNAME] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CATEGORYLIST] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
-------------------------------------------------------------------------------------------------------


  