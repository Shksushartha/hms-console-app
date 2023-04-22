CREATE TABLE admin(
    name VARCHAR(100),
    email VARCHAR(100),
    password varchar(100)
)

CREATE TABLE patient(
    name varchar(100),
    email varchar(100),
    contact int,
    password varchar(100)
)

CREATE TABLE doctor(
    name VARCHAR(100),
    email VARCHAR(100),
    faculty VARCHAR(100),
)

INSERT into admin(name,email,[password])
VALUES('sush','asd','asd')

select * from doctor;