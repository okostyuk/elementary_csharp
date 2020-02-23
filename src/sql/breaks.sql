//перерывы в работе врача более чем 30 минут, выводятся по уменьшению длительности перерыва. 
//Выводить нужно колонки 
//имя врача, его отделение, дата и время начала перерыва, длительность и конец перева.

select BRANCHES.NAME as "Branch name", 
       DOCTORS.FNAME||' '||DOCTORS.LNAME as "Doctor name", DATEDIFF(MINUTE, DATE, NEXT_DATE) as break_time
from (
         select DOCTOR_ID,
                BRANCH_ID,
                DATE,
                LEAD(DATE, 1, null) OVER (ORDER BY DOCTOR_ID, BRANCH_ID) as NEXT_DATE 
         from visits
         order by BRANCH_ID, DOCTOR_ID, DATE
    ) as BREAKS
join BRANCHES on BRANCHES.ID = BREAKS.BRANCH_ID
join DOCTORS on DOCTORS.ID = BREAKS.DOCTOR_ID
where NEXT_DATE is not null
and DATEDIFF(MINUTE, DATE, NEXT_DATE) > 30
order by DATEDIFF(MINUTE, DATE, NEXT_DATE) desc