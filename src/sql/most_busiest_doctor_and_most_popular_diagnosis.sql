-- статистику по отделениям: 
-- вывести для каждого отделения 
-- врача, который больше всего работал 
-- и самый частый диагноз (по всем врачам) 
-- за последние три месяца

select distinct
    B.NAME BRANCH,
    (
        select D.LNAME||' ('||count(*)||' visits)'
        from VISITS v2
                 join DOCTORS D on v2.DOCTOR_ID = D.ID
        where V2.BRANCH_ID=BRANCH_TO_DOCTOR.BRANCH_ID
        group by LNAME LIMIT 1
        ) as MOST_LOADED_DOCTOR,
    BRANCH_TO_DIAG.DIAGNOSIS_ID as MOST_COMMON_DIAGNOSIS
from VISITS BRANCH_TO_DOCTOR
left join
     (
         select
             B_TO_MAX.BRANCH_ID,
             (
                 select DIAG_TABLE.TEXT
                 from (
                          select BRANCH_ID, DIAGNOSIS_ID, count(*) as cnt from VISITS
                          group by BRANCH_ID, DIAGNOSIS_ID
                      ) as DIAG_CNT
                 left join DIAGNOSIS DIAG_TABLE on DIAG_TABLE.ID = DIAG_CNT.DIAGNOSIS_ID 
                 where B_TO_MAX.BRANCH_ID = DIAG_CNT.BRANCH_ID
                 and B_TO_MAX.MAX_VAL = DIAG_CNT.cnt 
                 LIMIT 1
             ) as DIAGNOSIS_ID
         from (
                  select V2.BRANCH_ID, max(V2.cnt) as MAX_VAL
                  from (
                           select V.BRANCH_ID, count(*) as cnt from VISITS V
                           group by BRANCH_ID, DIAGNOSIS_ID
                       ) as V2
                  group by V2.BRANCH_ID) as B_TO_MAX
     ) as BRANCH_TO_DIAG
on BRANCH_TO_DIAG.BRANCH_ID = BRANCH_TO_DOCTOR.BRANCH_ID
left join BRANCHES B on BRANCH_TO_DOCTOR.BRANCH_ID = B.ID