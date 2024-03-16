USE [DB_FIXED_ASSET]
GO

/****** Object:  Table [dbo].[TB_ASSET]    Script Date: 4/1/2562 11:00:39 ******/
DROP TABLE [dbo].[TB_ASSET]
GO

/****** Object:  Table [dbo].[TB_ASSET]    Script Date: 4/1/2562 11:00:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_ASSET](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ASSET_TID] [nvarchar](50) NOT NULL,
	[ROOM_CODE] [nvarchar](50) NULL,
	[ASSET_EPC] [nvarchar](50) NULL,
	[ASSET_FID] [nvarchar](50) NULL,
	[ASSET_LABEL] [nvarchar](200) NULL,
	[ASSET_TYPE] [nvarchar](200) NULL,
	[ASSET_DESCRIPTION] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TB_ASSET] PRIMARY KEY CLUSTERED 
(
	[ASSET_TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  Table [dbo].[TB_ROOM]    Script Date: 4/1/2562 11:01:09 ******/
DROP TABLE [dbo].[TB_ROOM]
GO

/****** Object:  Table [dbo].[TB_ROOM]    Script Date: 4/1/2562 11:01:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_ROOM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ROOM_CODE] [nvarchar](50) NULL,
	[ROOM_TID] [nvarchar](50) NULL,
	[ROOM_EPC] [nvarchar](50) NULL,
	[ROOM_DESCRIPTION] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TB_ROOM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Asset_Save]    Script Date: 4/1/2562 11:01:34 ******/
DROP PROCEDURE [dbo].[Sp_Asset_Save]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Asset_Save]    Script Date: 4/1/2562 11:01:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Asset_Save] -- !!! สำคัญ ต้องเปลี่ยน Activity type
	@RoomCode nvarchar(50),	
	@Epc nvarchar(50),	
	@Tid nvarchar(50),	
	@Fid nvarchar(50),	
	@AssetLabel nvarchar(200),	
	@AssetType nvarchar(200),	
	@AssetDescription nvarchar(1000),	
	@RowCount int output,
	@MessageResult nvarchar(100) output
AS
BEGIN

	-- ===================================================================================
	-- STATE-1: VALIDATION
	--             - CHECK NULL
	--             - CHECK EMPTY
	-- ===================================================================================
	
	-- TID
	IF @Tid is NULL
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid TID! TID cannot be null.';
		return -2;
	end	
	IF @Tid=''
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid TID! TID cannot be empty.';
		return -2;
	end	
	-- FID
	IF @Fid is NULL
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid FID! FID cannot be null.';
		return -2;
	end	
	IF @Fid=''
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid FID! FID cannot be empty.';
		return -2;
	end	

	-- ===================================================================================
	-- STATE-2: SAVE BY INSERT OR UPDATE
	-- ===================================================================================	
	Declare @Id int = null;
	select top 1 @Id = T.ID from TB_ASSET T WHERE T.ASSET_TID = @Tid; -- CHECK EXIST TID

	if @Id is null or @Id=0 /* CRITERIA FOR INSERT NEW*/
	begin
		
		begin try
				
			-- DO INSERT
			print 'INSERTION AS NEW RECORD...'

			INSERT INTO TB_ASSET
			(
				ROOM_CODE,
				ASSET_EPC,
				ASSET_TID,
				ASSET_FID,
				ASSET_LABEL,
				ASSET_TYPE,
				ASSET_DESCRIPTION				
			) 
			VALUES 
			(
				@RoomCode,
				@Epc,
				@Tid,
				@Fid,
				@AssetLabel,
				@AssetType,
				@AssetDescription
			)
			
			set @RowCount = @@ROWCOUNT;
			
			-- RETURN
			IF @RowCount>0 -- INSERTION SUCCESS
			BEGIN
				print 'INSERTION SUCCESS.'
				set @MessageResult = 'Insertion a new asset success.';
				return 0;
			END
			ELSE -- NOTHING
			BEGIN
				print 'INSERTION NOTHING'
				set @MessageResult = 'There is no any save activity.';
				return -1;
			END
		end try
		begin catch
			set @RowCount = 0;
			set @MessageResult = ERROR_MESSAGE();
			return -2;
		end catch
		
	END
	else -- do update the asset recode by TID
	begin
		
		begin try

			print 'UPDATING...'
			
			update TB_ASSET
			set 
				ROOM_CODE = @RoomCode,
				ASSET_EPC = @Epc,
				ASSET_FID = @Fid,
				ASSET_LABEL = @AssetLabel,
				ASSET_TYPE = @AssetType,
				ASSET_DESCRIPTION = @AssetDescription
			where ASSET_TID=@Tid;

			set @RowCount=@@ROWCOUNT;

			-- RETURN
			IF @RowCount>0 -- UPDATED
			BEGIN
				PRINT 'UPDATING SUCCESS';
				set @MessageResult = 'Asset data updated successful.';
				return 0
			END
			ELSE -- NOTHING
			BEGIN
				PRINT 'Nothing updated';
				set @MessageResult = 'There is no any save activity.';
				return -1
			END

		end try
		begin catch
			set @RowCount = 0;
			set @MessageResult = ERROR_MESSAGE();
			return -2;
		end catch

	end

	-- safety
	return -99;

/* END */
END
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Asset_SearchByFid]    Script Date: 4/1/2562 11:01:59 ******/
DROP PROCEDURE [dbo].[Sp_Asset_SearchByFid]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Asset_SearchByFid]    Script Date: 4/1/2562 11:01:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Asset_SearchByFid]
	-- Add the parameters for the stored procedure here
	@FID nvarchar(50),
	@RowCount int output,
	@MessageResult nvarchar(200) OUTPUT
AS
BEGIN			
	-- ===================================================================================
	-- STATE-1: VALIDATION
	-- ===================================================================================	
	-- fid
	IF @FID is NULL
	begin
		print 'Invalid TID! TID cannot be null.';
		-- THROW 50031, 'Invalid TID! TID can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid TID! TID cannot be null.';
		return -2;
	end
	IF @FID = ''
	begin
		print 'Invalid TID! TID cannot be empty.';
		-- THROW 50031, 'Invalid TID! TID can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid TID! TID cannot be empty.';
		return -2;
	end

	-- ===================================================================================
	-- STATE-2: QUERY FROM DATABASE
	-- ===================================================================================
	PRINT 'TID = ' + + RTRIM(CAST(@FID AS nvarchar(50)))
	print 'SELECT and join data from TB_ASSET, TB_ROOM and TB_ASSET_TYPE'

	BEGIN TRY

		SELECT  T1.ID, T1.ASSET_TID , T1.ROOM_CODE, T1.ASSET_EPC, T1.ASSET_FID, T1.ASSET_LABEL, T1.ASSET_TYPE, T1.ASSET_DESCRIPTION,
		  T2.ROOM_TID, T2.ROOM_EPC, T2.ROOM_DESCRIPTION		from TB_ASSET T1
		LEFT JOIN TB_ROOM T2
		ON T1.ROOM_CODE=T2.ROOM_CODE
		WHERE T1.ASSET_FID=@FID;
						
		SET @RowCount = @@ROWCOUNT;
			
		print 'Done selection'
		IF @RowCount>0 -- data found.
		BEGIN
			SET @MessageResult = 'Asset found.';
			return 0
		END
		ELSE -- data not found!
		BEGIN
			SET @MessageResult = 'Asset not found!';
			return -1
		END

	END TRY
	BEGIN CATCH
		print 'QUERY ERROR'
		SET @RowCount = 0;
		SET @MessageResult = ERROR_MESSAGE();
		return -2
	END CATCH

	-- SAFETY
	return -99

-- END OF STORE PROCEDURE.
END
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Asset_SearchByTid]    Script Date: 4/1/2562 11:02:20 ******/
DROP PROCEDURE [dbo].[Sp_Asset_SearchByTid]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Asset_SearchByTid]    Script Date: 4/1/2562 11:02:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Asset_SearchByTid]
	-- Add the parameters for the stored procedure here
	@TID nvarchar(50),
	@RowCount int output,
	@MessageResult nvarchar(200) OUTPUT
AS
BEGIN			
	-- ===================================================================================
	-- STATE-1: VALIDATION
	-- ===================================================================================	
	-- tid
	IF @TID is NULL
	begin
		print 'Invalid TID! TID cannot be null.';
		-- THROW 50031, 'Invalid TID! TID can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid TID! TID cannot be null.';
		return -2;
	end
	-- empty
	IF @TID = ''
	begin
		print 'Invalid TID! TID cannot be empty.';
		-- THROW 50031, 'Invalid TID! TID can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid TID! TID cannot be empty.';
		return -2;
	end

	Declare @Id_room int = null;
	select top 1 @Id_room = T.ID from TB_ROOM T WHERE T.ROOM_TID = @Tid; -- CHECK EXIST TID
	if @Id_room is not null or @Id_room <> 0
	begin
				print 'TID is duplicate in ROOM.'
				set @RowCount=0;
				set @MessageResult = 'TID is duplicate in ROOM.';
				return -2;
	end
	-- ===================================================================================
	-- STATE-2: QUERY FROM DATABASE
	-- ===================================================================================
	PRINT 'TID = ' + + RTRIM(CAST(@TID AS nvarchar(50)))
	print 'SELECT and join data from TB_ASSET, TB_ROOM and TB_ASSET_TYPE'

	BEGIN TRY

		SELECT  T1.ID, T1.ASSET_TID , T1.ROOM_CODE, T1.ASSET_EPC, T1.ASSET_FID, T1.ASSET_LABEL, T1.ASSET_TYPE, T1.ASSET_DESCRIPTION,
		  T2.ROOM_TID, T2.ROOM_EPC, T2.ROOM_DESCRIPTION
		from TB_ASSET T1
		LEFT JOIN TB_ROOM T2
		ON T1.ROOM_CODE=T2.ROOM_CODE
		WHERE T1.ASSET_TID=@TID;
						
		SET @RowCount = @@ROWCOUNT;
			
		print 'Done selection'
		IF @RowCount>0 -- data found.
		BEGIN
			SET @MessageResult = 'Asset found.';
			return 0
		END
		ELSE -- data not found!
		BEGIN
			SET @MessageResult = 'Asset not found!';
			return -1
		END

	END TRY
	BEGIN CATCH
		print 'QUERY ERROR'
		SET @RowCount = 0;
		SET @MessageResult = ERROR_MESSAGE();
		return -2
	END CATCH

	-- SAFETY
	return -99

-- END OF STORE PROCEDURE.
END
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Room_Save]    Script Date: 4/1/2562 11:02:36 ******/
DROP PROCEDURE [dbo].[Sp_Room_Save]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Room_Save]    Script Date: 4/1/2562 11:02:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Room_Save] -- !!! สำคัญ ต้องเปลี่ยน Activity type
	@Epc nvarchar(50),	
	@Tid nvarchar(50),
	@RoomCode nvarchar(50),
	@RoomDescription nvarchar(1000),	
	@RowCount int output,
	@MessageResult nvarchar(100) output
AS
BEGIN

	-- ===================================================================================
	-- STATE-1: VALIDATION
	--             - CHECK NULL
	--             - CHECK EMPTY
	-- ===================================================================================
	
	-- TID
	IF @Tid is NULL
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid TID! TID cannot be null.';
		return -2;
	end	
	IF @Tid=''
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid TID! TID cannot be empty.';
		return -2;
	end	
	-- FID
	IF @RoomCode is NULL
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid Room Code! Room Code cannot be null.';
		return -2;
	end	
	IF @RoomCode=''
	begin
		set @RowCount = 0;
		set @MessageResult = 'Invalid Room Code! Room Code cannot be empty.';
		return -2;
	end	

	-- ===================================================================================
	-- STATE-2: SAVE BY INSERT OR UPDATE
	-- ===================================================================================	
	Declare @Id int = null;
	select top 1 @Id = R.ID from TB_ROOM R WHERE R.ROOM_CODE = @RoomCode; -- CHECK EXIST TID

	if @Id is null or @Id=0 /* CRITERIA FOR INSERT NEW*/
	begin
		
		begin try
				
			-- DO INSERT
			print 'INSERTION AS NEW RECORD...'

			INSERT INTO TB_ROOM
			(
				ROOM_EPC,
				ROOM_TID,
				ROOM_CODE,
				ROOM_DESCRIPTION
			) 
			VALUES 
			(
				@Epc,
				@Tid,
				@RoomCode,
				@RoomDescription
			)
			
			set @RowCount = @@ROWCOUNT;
			
			-- RETURN
			IF @RowCount>0 -- INSERTION SUCCESS
			BEGIN
				print 'INSERTION SUCCESS.'
				set @MessageResult = 'Insertion a new Room success.';
				return 0;
			END
			ELSE -- NOTHING
			BEGIN
				print 'INSERTION NOTHING'
				set @MessageResult = 'There is no any save activity.';
				return -1;
			END
		end try
		begin catch
			set @RowCount = 0;
			set @MessageResult = ERROR_MESSAGE();
			return -2;
		end catch
		
	END
	else -- do update the asset recode by TID
	begin
		
		begin try

			print 'UPDATING...'
			
			update TB_ROOM
			set 
				ROOM_EPC = @Epc,
				ROOM_TID = @Tid,
				ROOM_CODE = @RoomCode,
				ROOM_DESCRIPTION = @RoomDescription
			where ROOM_CODE=@RoomCode;

			set @RowCount=@@ROWCOUNT;

			-- RETURN
			IF @RowCount>0 -- UPDATED
			BEGIN
				PRINT 'UPDATING SUCCESS';
				set @MessageResult = 'Room data updated successful.';
				return 0
			END
			ELSE -- NOTHING
			BEGIN
				PRINT 'Nothing updated';
				set @MessageResult = 'There is no any save activity.';
				return -1
			END

		end try
		begin catch
			set @RowCount = 0;
			set @MessageResult = ERROR_MESSAGE();
			return -2;
		end catch

	end

	-- safety
	return -99;

/* END */
END
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Room_SearchByRoomCode]    Script Date: 4/1/2562 11:02:55 ******/
DROP PROCEDURE [dbo].[Sp_Room_SearchByRoomCode]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Room_SearchByRoomCode]    Script Date: 4/1/2562 11:02:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Room_SearchByRoomCode]
	-- Add the parameters for the stored procedure here
	@RoomCode nvarchar(50),
	@RowCount int output,
	@MessageResult nvarchar(200) OUTPUT
AS
BEGIN			
	-- ===================================================================================
	-- STATE-1: VALIDATION
	-- ===================================================================================	
	-- fid
	IF @RoomCode is NULL
	begin
		print 'Invalid Room Code! Room Code cannot be null.';
		-- THROW 50031, 'Invalid Room Code! Room Code can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid Room Code! Room Code cannot be null.';
		return -2;
	end
	IF @RoomCode = ''
	begin
		print 'Invalid Room Code! Room Code cannot be empty.';
		-- THROW 50031, 'Invalid Room Code! Room Code can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid Room Code! Room Code cannot be empty.';
		return -2;
	end

	-- ===================================================================================
	-- STATE-2: QUERY FROM DATABASE
	-- ===================================================================================
	PRINT 'Room Code = ' + + RTRIM(CAST(@RoomCode AS nvarchar(50)))
	print 'SELECT and join data from TB_ROOM'

	BEGIN TRY

		SELECT   T1.ID, T1.ROOM_CODE, T1.ROOM_TID, T1.ROOM_EPC, T1.ROOM_DESCRIPTION,
		 T2.ASSET_TID , T2.ASSET_EPC, T2.ASSET_FID, T2.ASSET_LABEL, T2.ASSET_TYPE, T2.ASSET_DESCRIPTION
		from  TB_ROOM T1
		LEFT JOIN TB_ASSET T2
		ON T1.ROOM_CODE = T2.ROOM_CODE
		WHERE T1.ROOM_CODE = @RoomCode;
						
		SET @RowCount = @@ROWCOUNT;
			
		print 'Done selection'
		IF @RowCount>0 -- data found.
		BEGIN
			SET @MessageResult = 'Room found.';
			return 0
		END
		ELSE -- data not found!
		BEGIN
			SET @MessageResult = 'Room not found!';
			return -1
		END

	END TRY
	BEGIN CATCH
		print 'QUERY ERROR'
		SET @RowCount = 0;
		SET @MessageResult = ERROR_MESSAGE();
		return -2
	END CATCH

	-- SAFETY
	return -99

-- END OF STORE PROCEDURE.
END
GO


USE [DB_FIXED_ASSET]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Room_SearchByTID]    Script Date: 4/1/2562 11:03:13 ******/
DROP PROCEDURE [dbo].[Sp_Room_SearchByTID]
GO

/****** Object:  StoredProcedure [dbo].[Sp_Room_SearchByTID]    Script Date: 4/1/2562 11:03:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Room_SearchByTID]
	-- Add the parameters for the stored procedure here
	@TID nvarchar(50),
	@RowCount int output,
	@MessageResult nvarchar(200) OUTPUT
AS
BEGIN			
	-- ===================================================================================
	-- STATE-1: VALIDATION
	-- ===================================================================================	
	-- fid
	IF @TID is NULL
	begin
		print 'Invalid Room TID! Room TID cannot be null.';
		-- THROW 50031, 'Invalid Room TID! Room TID can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid Room TID! Room TID cannot be null.';
		return -2;
	end
	IF @TID = ''
	begin
		print 'Invalid Room TID! Room TID cannot be empty.';
		-- THROW 50031, 'Invalid Room TID! Room TID can not be NULL.', 1;  
		set @RowCount=0;
		set @MessageResult = 'Invalid Room TID! Room TID cannot be empty.';
		return -2;
	end

	Declare @Id_asset int = null;
	select top 1 @Id_asset = T.ID from TB_ASSET T WHERE T.ASSET_TID = @Tid; -- CHECK EXIST TID
	if @Id_asset is not null or @Id_asset <> 0
	begin
				print 'TID is duplicate in ASSET.'
				set @RowCount=0;
				set @MessageResult = 'TID is duplicate in ASSET.';
				return -2;
	end
	-- ===================================================================================
	-- STATE-2: QUERY FROM DATABASE
	-- ===================================================================================
	PRINT 'Room TID = ' + + RTRIM(CAST(@TID AS nvarchar(50)))
	print 'SELECT and join data from TB_ROOM'

	BEGIN TRY

		SELECT   T1.ID, T1.ROOM_CODE, T1.ROOM_TID, T1.ROOM_EPC, T1.ROOM_DESCRIPTION,
		 T2.ASSET_TID , T2.ASSET_EPC, T2.ASSET_FID, T2.ASSET_LABEL, T2.ASSET_TYPE, T2.ASSET_DESCRIPTION		  
		from  TB_ROOM T1
		LEFT JOIN TB_ASSET T2
		ON T1.ROOM_CODE = T2.ROOM_CODE
		WHERE T1.ROOM_TID = @TID;
						
		SET @RowCount = @@ROWCOUNT;
			
		print 'Done selection'
		IF @RowCount>0 -- data found.
		BEGIN
			SET @MessageResult = 'Room found.';
			return 0
		END
		ELSE -- data not found!
		BEGIN
			SET @MessageResult = 'Room not found!';
			return -1
		END

	END TRY
	BEGIN CATCH
		print 'QUERY ERROR'
		SET @RowCount = 0;
		SET @MessageResult = ERROR_MESSAGE();
		return -2
	END CATCH

	-- SAFETY
	return -99

-- END OF STORE PROCEDURE.
END
GO


