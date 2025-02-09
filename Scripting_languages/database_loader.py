#!/usr/bin/python3
# Chase Carter
# Lab 5 - Database Loader
# CS 3030 - Scripting Languages

import sqlite3
import csv
import sys

if len(sys.argv) != 3:
    print("Usage: ./dbload INPUT OUTPUT")
    sys.exit(1)

input_file = sys.argv[1]
output_db = sys.argv[2]

try:
    with open(input_file, 'r') as csvfile:
        reader = csv.reader(csvfile, delimiter=',', quotechar='"')
        
        conn = sqlite3.connect(output_db)
        curs = conn.cursor()
        #Drop tables if exist
        curs.execute('''DROP TABLE IF EXISTS courses''')
        curs.execute('''DROP TABLE IF EXISTS people''')
        #create courses table
        curs.execute('''CREATE TABLE courses (
                id TEXT, 
                subjcode TEXT, 
                coursenumber TEXT, 
                termcode TEXT)''')
        #create people table
        curs.execute('''CREATE TABLE people (
                id TEXT PRIMARY KEY UNIQUE, 
                lastname TEXT, firstname TEXT, 
                email TEXT, 
                major TEXT, 
                city TEXT, 
                state TEXT, 
                zip TEXT)''')

        #skip the first line
        for index, row in enumerate(reader):
            if index == 0:
                continue

            wnumber = row[0]
            firstname = row[1]
            lastname = row[2]
            email = row[3]
            major = row[4]
            course = row[5]
            termcode = row[6]
            city = row[7]
            state = row[8]
            zip_code = row[9]

            coursedata = course.split(" ")
            subjcode = coursedata[0]
            coursenumber = coursedata[1]

            try:
                #INSERT OR IGNORE, avoid errors when inserting
                curs.execute('''INSERT OR IGNORE INTO people (id, lastname, firstname, email, major, city, state, zip) VALUES (?, ?, ?, ?, ?, ?, ?, ?)''', 
                (wnumber, lastname, firstname, email, major, city, state, zip_code))

                curs.execute('''INSERT INTO courses (id, subjcode, coursenumber, termcode) VALUES (?, ?, ?, ?)''', (wnumber, subjcode, coursenumber, termcode))
            #error handling
            except Exception as e:
                print(f"Error inserting data: {e}")
                conn.rollback()
                sys.exit(1)

        conn.commit()
        conn.close()
        sys.exit(0)

#error handling
except Exception as e:
    print(f"Error: {e}")
    sys.exit(1)