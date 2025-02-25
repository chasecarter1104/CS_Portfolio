#!/usr/bin/env pwsh
# Chase Carter
# Lab 8 - Database Loader
# CS 3030 - Scripting Languages

param (
    [string]$inputCsv,
    [string]$outputDb
)

# Usage message
if (-not ($inputCsv -and $outputDb)) {
    Write-Host "Usage: ./dbload.ps1 INPUTCSV OUTPUTDB"
    exit 1
}

# Import CSV file
try {
    $csv = Import-Csv $inputCsv -Delimiter "," -ErrorAction Stop
} catch {
    Write-Host "Error opening CSV file: $_"
    exit 1
}

# Load SQLite DLL and open connection
try {
    Add-Type -Path "dlls/System.Data.SQLite.dll"
    $con = New-Object -TypeName System.Data.SQLite.SQLiteConnection
    $con.ConnectionString = "Data Source=$outputDb"
    $con.Open()
} catch {
    Write-Host "Error opening database file: $_"
    exit 1
}

# Begin transaction for create
$transaction = $con.BeginTransaction("create")

# Drop tables if exist
$sql = $con.CreateCommand()
$sql.CommandText = 'DROP table if exists people'
[void]$sql.ExecuteNonQuery()
$sql.CommandText = 'DROP table if exists courses'
[void]$sql.ExecuteNonQuery()

# Create people table
$sql.CommandText = 'CREATE table people (id text primary key unique,
  lastname text, firstname text, email text, major text,
  city text, state text, zip text);'
[void]$sql.ExecuteNonQuery()

# Create courses table
$sql.CommandText = 'CREATE table courses (id text,
  subjcode text, coursenumber text, termcode text);'
[void]$sql.ExecuteNonQuery()

# Commit the table creation
[void]$transaction.Commit()

# Insert from csv
foreach ($row in $csv) {
    $transaction = $con.BeginTransaction("addpersontransaction")

    # Insert or replace into people table
    $sql.CommandText = "INSERT OR REPLACE INTO people (id, firstname, lastname, email, major, city, state, zip)
        VALUES (@id, @firstname, @lastname, @email, @major, @city, @state, @zip);"
    [void]$sql.Parameters.Clear()
    [void]$sql.Parameters.AddWithValue("@id", $row.wnumber)
    [void]$sql.Parameters.AddWithValue("@firstname", $row.firstname)
    [void]$sql.Parameters.AddWithValue("@lastname", $row.lastname)
    [void]$sql.Parameters.AddWithValue("@email", $row.email)
    [void]$sql.Parameters.AddWithValue("@major", $row.major)
    [void]$sql.Parameters.AddWithValue("@city", $row.city)
    [void]$sql.Parameters.AddWithValue("@state", $row.state)
    [void]$sql.Parameters.AddWithValue("@zip", $row.zip)
    [void]$sql.ExecuteNonQuery()

    # Extract data
    $courseData = $row.course -split " "
    $subjcode = $courseData[0]
    $coursenumber = $courseData[1]

    # Insert into courses table
    $sql.CommandText = "INSERT INTO courses (id, subjcode, coursenumber, termcode)
        VALUES (@id, @subjcode, @coursenumber, @termcode);"
    [void]$sql.Parameters.Clear()
    [void]$sql.Parameters.AddWithValue("@id", $row.wnumber)
    [void]$sql.Parameters.AddWithValue("@subjcode", $subjcode)
    [void]$sql.Parameters.AddWithValue("@coursenumber", $coursenumber)
    [void]$sql.Parameters.AddWithValue("@termcode", $row.termcode)
    [void]$sql.ExecuteNonQuery()

    # Commit transaction
    [void]$transaction.Commit()
}

# Close database connection
$con.Close()

exit 0