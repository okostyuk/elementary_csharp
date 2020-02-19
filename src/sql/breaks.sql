select * from 
(
    select D.LNAME, B.NAME,
           DATEDIFF(
                   MINUTE,
                   DATE,
                   (LEAD(DATE, 1, DATE) OVER (ORDER BY DATE))
       ) as break
    from VISITS V
             join DOCTORS D on V.DOCTOR_ID = D.ID
             join BRANCHES B on V.BRANCH_ID = B.ID
    order by break              
) as BREAKS
where BREAKS.break > 30