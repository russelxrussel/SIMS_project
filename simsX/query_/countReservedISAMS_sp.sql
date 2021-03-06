USE [ISAMSDB]
GO
/****** Object:  StoredProcedure [dbo].[Sims_CountReservedStudent]    Script Date: 11/09/2015 11:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[Sims_CountReservedStudent]
as
BEGIN

Select SUM(case when b.level_type='P' and b.level_code = '1' then 1 else 0 end) as P1,
SUM(case when b.level_type='P' and b.level_code = '2' then 1 else 0 end) as P2,
SUM(case when b.level_type='P' and b.level_code = '3' then 1 else 0 end) as P3,
SUM(case when b.level_type='G' and b.level_code = '1' then 1 else 0 end) as G1,
SUM(case when b.level_type='G' and b.level_code = '2' then 1 else 0 end) as G2,
SUM(case when b.level_type='G' and b.level_code = '3' then 1 else 0 end) as G3,
SUM(case when b.level_type='G' and b.level_code = '4' then 1 else 0 end) as G4,
SUM(case when b.level_type='G' and b.level_code = '5' then 1 else 0 end) as G5,
SUM(case when b.level_type='G' and b.level_code = '6' then 1 else 0 end) as G6,
SUM(case when b.level_type='H' and b.level_code = 'I' then 1 else 0 end) as G7,
SUM(case when b.level_type='H' and b.level_code = 'II' then 1 else 0 end) as G8,
SUM(case when b.level_type='H' and b.level_code = 'III' then 1 else 0 end) as G9,
SUM(case when b.level_type='H' and b.level_code = 'IV' then 1 else 0 end) as G10,
COUNT(a.stud_no) as TOTAL

From Csh_Tran_TF a
Inner Join Student_MF b
ON 
a.stud_no = b.stud_no
where a.desigfee_code = '2901' and a.sch_year = '2016' and a.or_no is not null and a.tran_stat = '2'

END