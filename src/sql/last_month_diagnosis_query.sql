select D.TEXT, COUNT(V.*) as FREQ from DIAGNOSIS as D, VISITS as V 
where D.ID = V.DIAGNOSIS_ID
AND V.DATE BETWEEN DATEADD('MONTH', -1, CURDATE()) AND CURDATE()
group by D.TEXT
order by FREQ desc;