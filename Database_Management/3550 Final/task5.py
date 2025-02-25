import datetime
from mysql.connector import connect, Error
from secrets import secrets

secret_key = secrets.get('SECRET_KEY')
db_user = secrets.get('DATABASE_USER', 'root')
db_pass = secrets.get('DATABASE_PASSWORD', 'pass')
db_port = secrets.get('DATABASE_PORT', 3306)

# Percentage raise mapping based on job titles
raise_mapping = {
    'Assistant Engineer': 0.05,
    'Engineer': 0.075,
    'Manager': 0.10,
    'Senior Engineer': 0.07,
    'Senior Staff': 0.065,
    'Staff': 0.05,
    'Technique Leader': 0.08
}

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

    cursor = cnx.cursor()

    try:
        # Step 1: Identify remaining employees (active)
        cursor.execute("SELECT emp_no FROM employees WHERE employment_status = 'A'")
        active_employees = [emp_no[0] for emp_no in cursor.fetchall()]

        for emp_no in active_employees:
            # Step 2: Retrieve job title
            cursor.execute(f"SELECT title FROM titles WHERE emp_no = {emp_no} ORDER BY to_date DESC LIMIT 1")
            title = cursor.fetchone()[0]

            # Step 3: Determine percentage raise based on job title
            if title in raise_mapping:
                percentage_raise = raise_mapping[title]
            else:
                percentage_raise = 0.0  # Default case if title not found

            # Step 4: Retrieve current salary details
            cursor.execute(f"SELECT salary, from_date, to_date FROM salaries WHERE emp_no = {emp_no} ORDER BY to_date DESC LIMIT 1")
            current_salary, current_from_date, current_to_date = cursor.fetchone()

            # Step 5: Calculate new salary
            new_salary = current_salary * (1 + percentage_raise)

            # Step 6: Calculate the new from_date and to_date for current and new records
            new_from_date = datetime.date.today()
            new_to_date = datetime.date(9999, 1, 1)

            # Step 7: Update the current salary to_date
            cursor.execute("""
                UPDATE salaries
                SET to_date = %s
                WHERE emp_no = %s AND to_date = %s
            """, (new_from_date, emp_no, current_to_date))

            # Step 8: Insert a new salary record for the next salary period
            cursor.execute("""
                INSERT INTO salaries (emp_no, salary, from_date, to_date)
                VALUES (%s, %s, %s, %s)
            """, (emp_no, new_salary, new_from_date, new_to_date))

        # Commit changes
        cnx.commit()
        print("Salaries updated successfully.")

    except Error as e:
        print(f"Error: {e}")

    finally:
        # Close cursor and connection
        cursor.close()

except Error as e:
    print(f"Error connecting to MySQL: {e}")

finally:
    # Close connection
    if 'cnx' in locals() or 'cnx' in globals():
        cnx.close()