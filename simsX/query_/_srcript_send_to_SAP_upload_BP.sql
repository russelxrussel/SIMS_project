
Select a.StudNum, (a.LastName + ', ' + a.FirstName + ' ' + a.MI + '.') as FuName,
	  a.Entry_LevelCode,
	  (a.Street  + ', ' + br.BarangayDesc + ', ' + cr.CityDesc) as Address,
	  a.TelNo, a.MobileNo, a.InitialContact
 
from Registration.Student_Info_MF a
inner join Utilities.Barangay_RF br
on br.BarangayCode = a.BarangayCode
inner join Utilities.CityProvince_RF cr
on cr.CityCode = a.CityCode
where StudTypeCode = 'N' or StudTypeCode = 'R'
ORDER BY StudNuM
