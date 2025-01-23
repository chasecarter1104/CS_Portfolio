from pymongo import MongoClient
import mysql.connector
from mysql.connector import Error
from secrets import secrets
from secrets import mongo_uri
import os

# MongoDB connection
uri = mongo_uri.get('uri')


client = MongoClient(uri)
db = client['employee_appreciation']
collection = db['bonuses']


# Fetch MongoDB data
def fetch_mongo_data():
    return list(collection.find({}))

# MySQL connection
secret_key = secrets.get('SECRET_KEY')
db_user = secrets.get('DATABASE_USER', 'root')
db_pass = secrets.get('DATABASE_PASSWORD', 'pass')
db_port = secrets.get('DATABASE_PORT', 3306)

# Get the directory of the current script
script_dir = os.path.dirname(os.path.abspath(__file__))
output_file_path = os.path.join(script_dir, 'BonusReport.txt')

try:
    cnx = mysql.connector.connect(
        host='localhost',
        user=db_user,
        password=db_pass,
        database='employees'
    )
    cursor = cnx.cursor()
    
    # Fetch employee data, including employment status
    query = """
    SELECT emp_no, hire_date, employment_status 
    FROM employees 
    WHERE employment_status = 'A';
    """
    cursor.execute(query)
    employees = cursor.fetchall()
    
    # Fetch MongoDB data
    bonuses = fetch_mongo_data()

    # Open the output file in write mode
    with open(output_file_path, 'w') as file:
        # Process and write the results to the file
        for emp_no, hire_date, status in employees:
            # Calculate years of service
            years_of_service = (2024 - hire_date.year)  # Assume current year is 2024
            
            # Find the appropriate bonus
            for bonus in bonuses:
                if years_of_service == bonus['yearsOfService']:
                    file.write(f"Employee ID: {emp_no} - Bonus: ${bonus['bonusAmount']}\n")

except Error as e:
    print(f"MySQL Error: {e}")

finally:
    if 'cnx' in locals() and cnx.is_connected():
        cursor.close()
        cnx.close()