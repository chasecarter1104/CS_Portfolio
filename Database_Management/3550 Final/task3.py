from mysql.connector import connect, Error
from secrets import secrets

secret_key = secrets.get('SECRET_KEY')
db_user = secrets.get('DATABASE_USER', 'root')
db_pass = secrets.get('DATABASE_PASSWORD', 'pass')
db_port = secrets.get('DATABASE_PORT', 3306)

try:
    # Connect to the database
    cnx = connect(
        host='localhost',
        user=db_user,
        password=db_pass,
        database='employees'
    )
    cursor = cnx.cursor()

    # Read SQL commands from file
    with open('task3.sql', 'r') as sql_file:
        sql_commands = sql_file.read()

    # Split SQL commands by delimiter (assuming ';' as delimiter)
    sql_commands = sql_commands.split(';')

    # Execute each SQL command
    for command in sql_commands:
        if command.strip():  # Ensure the command is not empty
            cursor.execute(command)

    # Commit the transaction
    cnx.commit()
    print("SQL commands executed successfully.")

except Error as e:
    print(e)

