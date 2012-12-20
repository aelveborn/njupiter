BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
CREATE UNIQUE NONCLUSTERED INDEX IX_USER_Property_Timestamp ON dbo.USER_Property
	(
	[Timestamp]
	) ON [PRIMARY]
GO
COMMIT
