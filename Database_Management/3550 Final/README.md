This includes the Final Project for CS 3550 - Advanced Database Management.

This project covered everything we learned throughout the semester, and allowed us to implement the concepts in a realistic situation.

Task2:
This file attempts to establish a connection to a MySQL database using credentials from a secrets module (which stores sensitive information like the secret key, database user, password, and port). If successful, it prints the connection object; if there's an error, it prints the error message.

Task3:
This file connects to a MySQL database, reads SQL commands from a file (in this case, task3.sql), and executes them on the employees table. The SQL commands involve altering the table structure by adding new columns (email, phone_number, personal_email) and updating the employee records to set emails and phone numbers based on certain rules.

Task4:
This script connects to a MySQL database, reads SQL commands from a file (task4.sql), and executes them. It modifies the employees table by adding new columns (employment_status, termination_date). Then, it loads employee data from a CSV file (employees_cuts.csv) into a temporary table, updates the employment status and termination date for certain employees, and commits the changes to the database.

Task5:
This script connects to a MySQL database and updates salary records for employees based on their job title. It retrieves a list of active employees, checks their job title, calculates a raise based on predefined percentages, and then updates their salary in the database. It creates a new salary record with the updated salary and adjusts the "to_date" of the old salary record.

Task6:
This Python script connects to a MySQL database, retrieves a salary projection report for active employees, and displays it. It groups employees by their job titles and calculates the total salary, average salary, and the number of employees for each title. It then computes the overall company totals, including the total salary and average salary for all active employees.

Task7:
This Python script connects to both a MySQL database and a MongoDB instance to retrieve employee data and corresponding bonuses. It fetches active employees from MySQL and retrieves their years of service. It then finds the appropriate bonus from MongoDB based on the years of service and writes the results into a BonusReport.txt file.