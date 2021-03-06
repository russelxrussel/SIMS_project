USE [dbSIMS]
GO
/****** Object:  StoredProcedure [dbo].[spUserMenuList]    Script Date: 10/13/2015 18:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spUserMenuList]'Russel'
@UserCode nvarchar(20)

as 
Begin
 
 SELECT * from xSystem.ParentMenu_MF PM
 INNER JOIN xSystem.UserParentMenus UM
 ON PM.ParentID = UM.xParentID and UM.UserCode=@UserCode 
 ORDER BY PM.Arr Asc
 
 
 SELECT  * FROM xSystem.ChildMenu_MF CM
 INNER JOIN xSystem.UserChildMenus UM
 ON CM.ParentID = UM.xParentMenuID and CM.ChildID = UM.xChildMenuID and UM.UserCode=@UserCode --and a.ID = b.xChildMenuID
 Order by CM.Arr ASC
 
 SELECT * FROM xSystem.LeafMenu_MF LM
 INNER JOIN xSystem.UserLeafMenus UM
 ON LM.LeafID = UM.xChildID and UM.UserCode=@UserCode
 Order by LM.Arr ASC
 
End