USE [dbSIMS]
GO

-- =============================================
-- Author:		RUSSEL VASQUEZ
-- Create date: 07/28/2016
-- Description:	SIMS- UPDATE MEDICINE STOCK - ADDING
-- COMMAND: UPDATE
-- =============================================

ALTER PROC [dbo].[spUPDATE_MEDICINE_STOCK_UP]
@BATCHID int,
@MEDCODE nvarchar(3),
@QUANTITY int

WITH ENCRYPTION
AS
BEGIN


UPDATE Health.Medicine_Stock_MF
SET stockOnHand = stockOnHand + @QUANTITY
WHERE BatchID=@BATCHID and medCode=@MEDCODE



END
