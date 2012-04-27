SET NOCOUNT ON
GO
USE [TRM]
GO
CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_Update]
	@ID numeric(18, 0),
	@ID_GD_THANH_TOAN numeric(18, 0),
	@DESCRIPTION nvarchar(250),
	@ID_NOI_DUNG_THANH_TOAN numeric(18, 0),
	@REFERENCE_CODE nvarchar(250),
	@SO_LUONG_HE_SO numeric(21, 3),
	@DON_GIA_TT numeric(21, 3)
AS
UPDATE [dbo].[GD_THANH_TOAN_DETAIL]
SET 
	[ID_GD_THANH_TOAN] = @ID_GD_THANH_TOAN,
	[DESCRIPTION] = @DESCRIPTION,
	[ID_NOI_DUNG_THANH_TOAN] = @ID_NOI_DUNG_THANH_TOAN,
	[REFERENCE_CODE] = @REFERENCE_CODE,
	[SO_LUONG_HE_SO] = @SO_LUONG_HE_SO,
	[DON_GIA_TT] = @DON_GIA_TT
WHERE
	[ID] = @ID
GO

CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_UpdateAllWID_GD_THANH_TOANLogic]
	@ID_GD_THANH_TOAN numeric(18, 0),
	@ID_GD_THANH_TOANOld numeric(18, 0)
AS
UPDATE [dbo].[GD_THANH_TOAN_DETAIL]
SET
	[ID_GD_THANH_TOAN] = @ID_GD_THANH_TOAN
WHERE
	[ID_GD_THANH_TOAN] = @ID_GD_THANH_TOANOld
GO

CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_UpdateAllWID_NOI_DUNG_THANH_TOANLogic]
	@ID_NOI_DUNG_THANH_TOAN numeric(18, 0),
	@ID_NOI_DUNG_THANH_TOANOld numeric(18, 0)
AS
UPDATE [dbo].[GD_THANH_TOAN_DETAIL]
SET
	[ID_NOI_DUNG_THANH_TOAN] = @ID_NOI_DUNG_THANH_TOAN
WHERE
	[ID_NOI_DUNG_THANH_TOAN] = @ID_NOI_DUNG_THANH_TOANOld
GO

CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_Delete]
	@ID numeric(18, 0)
AS
DELETE FROM [dbo].[GD_THANH_TOAN_DETAIL]
WHERE
	[ID] = @ID
GO

CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_DeleteAllWID_GD_THANH_TOANLogic]
	@ID_GD_THANH_TOAN numeric(18, 0)
AS
DELETE
FROM [dbo].[GD_THANH_TOAN_DETAIL]
WHERE
	[ID_GD_THANH_TOAN] = @ID_GD_THANH_TOAN
GO

CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_DeleteAllWID_NOI_DUNG_THANH_TOANLogic]
	@ID_NOI_DUNG_THANH_TOAN numeric(18, 0)
AS
DELETE
FROM [dbo].[GD_THANH_TOAN_DETAIL]
WHERE
	[ID_NOI_DUNG_THANH_TOAN] = @ID_NOI_DUNG_THANH_TOAN
GO

-- //// Try-to-lock-and-compare Stored procedure.
CREATE PROCEDURE [dbo].[pr_GD_THANH_TOAN_DETAIL_IsUpdatable]
	@ID_GD_THANH_TOAN numeric(18, 0),
	@DESCRIPTION nvarchar(250),
	@ID_NOI_DUNG_THANH_TOAN numeric(18, 0),
	@REFERENCE_CODE nvarchar(250),
	@SO_LUONG_HE_SO numeric(21, 3),
	@DON_GIA_TT numeric(21, 3),
	@op_Error_Code int OUTPUT
/* DESCRIPTION:
|| Procedure nay dung de check 1 record trong bang cm_dm_tu_dien
|| 1. xem co lock duoc record nhu vay khong , 
||	a)thu lock neu khong lock duoc thi user khac dang lock 
||    b) neu khong co thi da bi xoa 
|| 2. xem co giong ban dau khong, neu khong giong thi da bi thay
*/
AS
BEGIN
/*********************************************
|| COMMON SETTINGS
**********************************************/
SET NOCOUNT ON
/**********************************************************
|| DECLARATION
***********************************************************/
	declare @v_ID_GD_THANH_TOAN numeric(18, 0)
	declare @v_DESCRIPTION nvarchar(250)
	declare @v_ID_NOI_DUNG_THANH_TOAN numeric(18, 0)
	declare @v_REFERENCE_CODE nvarchar(250)
	declare @v_SO_LUONG_HE_SO numeric(21, 3)
	declare @v_DON_GIA_TT numeric(21, 3)
	 -- 1.a) neu khong lock duoc => ai do dang dung du lieu
	select 
	@v_ID_GD_THANH_TOAN = ID_GD_THANH_TOAN ,
	@v_DESCRIPTION = DESCRIPTION ,
	@v_ID_NOI_DUNG_THANH_TOAN = ID_NOI_DUNG_THANH_TOAN ,
	@v_REFERENCE_CODE = REFERENCE_CODE ,
	@v_SO_LUONG_HE_SO = SO_LUONG_HE_SO ,
	@v_DON_GIA_TT = DON_GIA_TT 
	 from GD_THANH_TOAN_DETAIL with (updlock, rowlock, nowait)
	 where ID =  @ID
	 -- 1.b) khong co du lieu  => du lieu da bi xoa mat roi 
	if ( @v_ID is null )
	begin
		set @OP_ERROR_CODE = dbo.C_RECORD_DELETED()
		raiserror ('RECORD_DELETED',16,1)
		goto ERROR_HANDLER
	end
	/*2. so sanh cac gia tri co giong  nhau khong */	
	 if (
	isnull( @v_ID_GD_THANH_TOAN,dbo.C_Extrem_Number() ) <> isnull( @ID_GD_THANH_TOAN ,dbo.C_Extrem_Number() )  OR 
	isnull( @v_DESCRIPTION,dbo.C_Extrem_Str() ) <> isnull( @DESCRIPTION ,dbo.C_Extrem_Str() )  OR 
	isnull( @v_ID_NOI_DUNG_THANH_TOAN,dbo.C_Extrem_Number() ) <> isnull( @ID_NOI_DUNG_THANH_TOAN ,dbo.C_Extrem_Number() )  OR 
	isnull( @v_REFERENCE_CODE,dbo.C_Extrem_Str() ) <> isnull( @REFERENCE_CODE ,dbo.C_Extrem_Str() )  OR 
	isnull( @v_SO_LUONG_HE_SO,dbo.C_Extrem_Number() ) <> isnull( @SO_LUONG_HE_SO ,dbo.C_Extrem_Number() )  OR 
	isnull( @v_DON_GIA_TT,dbo.C_Extrem_Number() ) <> isnull( @DON_GIA_TT ,dbo.C_Extrem_Number() ) 
	)
	begin
		set @OP_ERROR_CODE = dbo.C_RECORD_UPDATED()
		raiserror ('RECORD_CHANGED',16,1)
		goto ERROR_HANDLER
	end
		return
	/********************************************************* 
	|| ERROR HANDLING
	*********************************************************/
	ERROR_HANDLER:
END
GO

