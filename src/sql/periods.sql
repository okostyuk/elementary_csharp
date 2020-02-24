-- число пациентов, проходящих прием, сгруппированных по времени прихода с 
-- 7-10, 10-13, 13-16, 16-19

select PERIOD, count(*) as "Visits count"
from (
         select case
                    when HOUR(DATE) < 7  then 'other'
                    when HOUR(DATE) < 10 then '7-10'
                    when HOUR(DATE) < 13 then '10-13'
                    when HOUR(DATE) < 16 then '13-16'
                    when HOUR(DATE) < 19 then '16-19'
                    else 'other'
                    end as PERIOD
         from VISITS
         )
group by PERIOD