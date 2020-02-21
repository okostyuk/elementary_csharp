//список врачей, по каждому указано 
-- количество посетивших его пациентов за все время, 
-- среднее число пациентов в месяц, 
-- самый частый диагноз, 
-- в порядке убывания среднего числа пациентов за месяц"CLINIC.DB"

select D.LNAME, Q1.TOTAL_UNIQUE_PATIENTS, Q2.AVG_VISITS_PER_MONTH
from DOCTORS as D
         left join (
    select DOCTOR_ID, count(DOCTOR_ID) as TOTAL_UNIQUE_PATIENTS
    from (
             select DOCTOR_ID, count(*) from VISITS
             group by DOCTOR_ID, PATIENT_ID
         )
    group by DOCTOR_ID
) as Q1 on D.ID = Q1.DOCTOR_ID
         left join (
    select DOCTOR_ID, AVG(CNT) as AVG_VISITS_PER_MONTH
    from (
             select DOCTOR_ID, MONTH(DATE) as _MONTH, count(*) as CNT
             from VISITS
             group by DOCTOR_ID, _MONTH
         )
    group by DOCTOR_ID
) as Q2 on D.ID = Q2.DOCTOR_ID
         left join (
    select Q3.DOCTOR_ID, max(Q3.DIAGNOSIS_ID) as MOST_FREQ_DIAG
    from (
             select DOCTOR_ID, DIAGNOSIS_ID, count(*) CNT from VISITS
             group by DOCTOR_ID, DIAGNOSIS_ID
         ) as Q3
    where Q3.CNT = (
        select max(CNT)
        from
            (
                select DOCTOR_ID, DIAGNOSIS_ID, count(*) CNT from VISITS
                group by DOCTOR_ID, DIAGNOSIS_ID
            ) as SUB
        where SUB.DOCTOR_ID = SUB.DOCTOR_ID
          and SUB.DIAGNOSIS_ID = DIAGNOSIS_ID
        )
    group by DOCTOR_ID
) as Q3 on D.ID = Q3.DOCTOR_ID;




