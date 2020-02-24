create table BRANCHES
(
    ID INT auto_increment,
    NAME VARCHAR
);

create unique index BRANCHES_ID_UINDEX
    on BRANCHES (ID);

alter table BRANCHES
    add constraint BRANCHES_PK
        primary key (ID);

--------------------------------

create table DIAGNOSIS
(
    ID   INT auto_increment,
    TEXT VARCHAR
);

create unique index DIAGNOSIS_ID_UINDEX
    on DIAGNOSIS (ID);

alter table DIAGNOSIS
    add constraint DIAGNOSIS_PK
        primary key (ID);

----------------------------------

create table DOCTORS
(
    ID    INT auto_increment,
    FNAME VARCHAR,
    LNAME VARCHAR
);

create unique index DOCTORS_ID_UINDEX
    on DOCTORS (ID);

alter table DOCTORS
    add constraint DOCTORS_PK
        primary key (ID);

-------------------------------------

create table PATIENTS
(
    ID INT auto_increment,
    FNAME VARCHAR,
    LNAME VARCHAR
);

create unique index PATIENTS_ID_UINDEX
    on PATIENTS (ID);

alter table PATIENTS
    add constraint PATIENTS_PK
        primary key (ID);

----------------------------------------------


create table VISITS
(
    ID INT auto_increment,
    DOCTOR_ID INT,
    PATIENT_ID INT,
    BRANCH_ID INT,
    DATE DATETIME,
    DIAGNOSIS_ID INT,
    DURATION INT,
    constraint VISITS_PK
        primary key (ID),
    constraint VISITS_BRANCH_FK
        foreign key (BRANCH_ID) references BRANCHES (ID),
    constraint VISITS_DCCTOR_FK
        foreign key (DOCTOR_ID) references DOCTORS (ID),
    constraint VISITS_DIAGNOSIS_FK
        foreign key (DIAGNOSIS_ID) references DIAGNOSIS (ID),
    constraint VISITS_PATIENT_FK
        foreign key (PATIENT_ID) references PATIENTS (ID)
);

create unique index VISITS_ID_UINDEX
    on VISITS (ID);

