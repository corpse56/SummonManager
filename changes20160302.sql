USE [ALPHA]
GO

/****** Object:  Table [dbo].[NOTIFICATIONS]    Script Date: 02/03/2016 18:22:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NOTIFICATIONS]') AND type in (N'U'))
DROP TABLE [dbo].[NOTIFICATIONS]
GO

USE [ALPHA]
GO

/****** Object:  Table [dbo].[NOTIFICATIONS]    Script Date: 02/03/2016 18:22:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NOTIFICATIONS](
	[IDNTYPE] [int] NOT NULL,
	[IDSUMMON] [int] NOT NULL,
	[CREATED] [datetime] NULL,
 CONSTRAINT [PK_NOTIFICATIONS_1] PRIMARY KEY CLUSTERED 
(
	[IDNTYPE] ASC,
	[IDSUMMON] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


