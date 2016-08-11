
CREATE VIEW vr_RegSiblings AS
SELECT RSG.StudNum, RSI.FullName, RSI.Current_LevelCode, RSS.SiblingCode
FROM Registration.Student_Info_MF RSI
INNER JOIN Registration.Student_General_Status_MF RSG
ON RSI.StudNum = RSG.StudNum
LEFT OUTER JOIN Registration.Student_Siblings_MF RSS
ON RSG.StudNum = RSS.StudNum