from mysql.connector import connect, Error
from secrets import secrets
db_user = secrets.get('DATABASE_USER', 'root')
db_pass = secrets.get('DATABASE_PASSWORD', 'pass')
db_port = secrets.get('DATABASE_PORT', 3306)

def connect_to_database():
    try:
        # Connect to the database
        cnx = connect(
            host='localhost',
            user=db_user,
            password=db_pass,
            database='employees',
            port=db_port,
            allow_local_infile=True
        )
        return cnx
    except Error as e:
        print(f"Error connecting to MySQL: {e}")
        return None

def retrieve_salary_projection_report():
    cnx = connect_to_database()
    if not cnx:
        return

    cursor = cnx.cursor(dictionary=True)

    try:
        # Query to retrieve salaries and job titles of active employees
        query = """
            SELECT t.title, COUNT(*) as employee_count, SUM(s.salary) as total_salary
            FROM employees e
            JOIN titles t ON e.emp_no = t.emp_no
            JOIN salaries s ON e.emp_no = s.emp_no
            WHERE e.employment_status = 'A'
            AND t.to_date = '9999-01-01'
            AND s.to_date = '9999-01-01'
            GROUP BY t.title
            ORDER BY SUM(s.salary) DESC
        """
        cursor.execute(query)
        rows = cursor.fetchall()

        # Variables for company totals
        total_company_employees = 0
        total_company_salary = 0

        # Generate and print the salary projection report
        print("Salary Projection Report")
        print("========================\n")

        for row in rows:
            title = row['title']
            employee_count = row['employee_count']
            total_salary = row['total_salary']
            average_salary = total_salary / employee_count

            # Accumulate company totals
            total_company_employees += employee_count
            total_company_salary += total_salary

            print(f"Job Title: {title}")
            print(f"Number of Employees: {employee_count}")
            print(f"Total Salary: ${total_salary}")
            print(f"Average Salary: ${average_salary:.2f}\n")

        # Calculate average salary for the entire company
        if total_company_employees > 0:
            average_company_salary = total_company_salary / total_company_employees
        else:
            average_company_salary = 0

        # Print company totals
        print("Company Totals")
        print("==============\n")
        print(f"Total Number of Employees: {total_company_employees}")
        print(f"Total Company Salary: ${total_company_salary}")
        print(f"Average Company Salary: ${average_company_salary:.2f}\n")

    except Error as e:
        print(f"Error retrieving salary projection report: {e}")

    finally:
        # Close cursor and connection
        cursor.close()
        cnx.close()

# Call function to retrieve and print the modified salary projection report
retrieve_salary_projection_report()