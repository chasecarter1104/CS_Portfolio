ALTER TABLE employees ADD COLUMN employment_status char(1) DEFAULT 'A';
ALTER TABLE employees ADD COLUMN termination_date DATE;

START TRANSACTION;

CREATE TEMPORARY TABLE temp_employees_cuts (
    emp_no INT PRIMARY KEY
);

LOAD DATA LOCAL INFILE 'C:/Users/chase/OneDrive - weber.edu/3550/test_db-master/test_db-master/scripts/employees_cuts.csv'
INTO TABLE temp_employees_cuts
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(emp_no);

UPDATE employees
SET employment_status = 'T',
    termination_date = CURDATE()
WHERE emp_no IN (SELECT emp_no FROM temp_employees_cuts);

DROP TEMPORARY TABLE temp_employees_cuts;

COMMIT;

