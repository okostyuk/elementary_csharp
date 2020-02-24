-- диагнозы, которые были поставлены за последний месяц 
-- в порядке убывания их частоты за все время

select D.TEXT LAST_MONTH_DIAGNOSES, FREQ
from DIAGNOSIS as D
right join (
         select distinct DIAGNOSIS_ID from VISITS
         where DATE BETWEEN DATEADD('MONTH', -1, CURDATE()) AND CURDATE()
         ) as LAST_MONTH_DIAGNOSIS on D.ID = DIAGNOSIS_ID
left join (
    select DIAGNOSIS_ID, COUNT(*) as FREQ
    from VISITS as V
    group by DIAGNOSIS_ID
) as DIAGNOSIS_FREQ on D.ID = DIAGNOSIS_FREQ.DIAGNOSIS_ID
order by FREQ DESC 