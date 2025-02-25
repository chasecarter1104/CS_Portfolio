#!/usr/bin/python3
# Chase Carter
# Lab 4 - Temp
# CS 3030 - Scripting Languages

#Welcome message
print("Welcome to the CS 3030 Temperature Conversion Program\n")

#Create the menu
def main_menu():
	print("\n\tMain Menu\n")
	print("\n\t1:Fahrenheit to Celsius")
	print("\n\t2:Celsius to Fahrenheit")
	print("\n\t3:Exit program\n")
	return input("\n\tPlease enter 1, 2 or 3:")


#F to C conversion
def fahrenheitToCelsius(fahrenheit):
    return(fahrenheit - 32.0) * (5.0/9.0)

#C to F conversion
def celsiusToFahrenheit(celsius):
    return(9.0/5.0) * celsius + 32.0

#exiting,choices 1,2,3, error handling, conversion printing.
while True:
    choice = main_menu()
    if choice == "3":
        print("Exiting Program.")
        break
    elif choice == "1":
        try:
            fahrenheit = float(input("Please enter degrees Fahrenheit:"))
            celsius = fahrenheitToCelsius(fahrenheit)
            print ("\n%.1f degrees Fahrenheit equals %.1f degrees Celsius" % (fahrenheit, celsius))
        except ValueError:
            print("Invalid entry")
    elif choice == "2":
        try:
            celsius = float(input("Please enter degrees Celsius:"))
            fahrenheit = celsiusToFahrenheit(celsius)
            print ("\n%.1f degrees Celsius equals %.1f degrees Fahrenheit" % (celsius, fahrenheit))
        except ValueError:
            print("Invalid entry")
    else:
        print("Invalid entry")
