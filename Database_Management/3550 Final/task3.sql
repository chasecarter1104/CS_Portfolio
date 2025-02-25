ALTER TABLE employees
ADD COLUMN email VARCHAR(255);
ALTER TABLE employees ADD COLUMN phone_number VARCHAR(13);

alter table employees add column personal_email varchar(255);

-- Update email addresses
UPDATE employees e
JOIN (
    SELECT 
        emp_no,
        CONCAT(LOWER(SUBSTRING(first_name, 1, 1)), last_name) AS base_email,
        ROW_NUMBER() OVER (PARTITION BY last_name, SUBSTRING(first_name, 1, 1) ORDER BY emp_no) - 1 AS num_suffix
    FROM employees
) AS email_data ON e.emp_no = email_data.emp_no
SET e.email = CONCAT(email_data.base_email, CASE WHEN email_data.num_suffix > 0 THEN email_data.num_suffix ELSE '' END, '@company.net');


-- Update employees table to add unique personal emails for senior employees
UPDATE employees e
JOIN (
    SELECT 
        e.emp_no,
        CONCAT(LOWER(SUBSTRING(e.first_name, 1, 1)), e.last_name) AS base_email,
        ROW_NUMBER() OVER (PARTITION BY LOWER(SUBSTRING(e.first_name, 1, 1)), e.last_name ORDER BY e.emp_no) - 1 AS num_suffix
    FROM employees e
    JOIN titles t ON t.emp_no = e.emp_no
    WHERE t.title LIKE '%Senior%'
) AS email_data ON e.emp_no = email_data.emp_no
SET e.personal_email = CONCAT(email_data.base_email, CASE WHEN email_data.num_suffix > 0 THEN email_data.num_suffix ELSE '' END, '@personal.com');


-- Update employees table to add phone numbers
UPDATE employees
SET phone_number = CONCAT('801-6', 
                          LPAD(FLOOR(emp_no / 10000), 2, '0'), 
                          '-', 
                          LPAD(emp_no % 10000, 4, '0'))
WHERE emp_no is not null;

