SELECT COUNT(*) FROM Admission.App_Info_MF AAI
INNER JOIN [192.168.2.5].ISAMSDB.dbo.vr_SimsReservedNew ZRN
ON AAI.AppNum = ZRN.app_num