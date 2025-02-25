#!/usr/bin/python3
# Chase Carter
# Lab 6 - Filemaker
# CS 3030 - Scripting Languages

import sys
import shlex
import random

def main():
    # Verify command line parameters and files
    if len(sys.argv) != 4:
        print("Usage: ./filemaker INPUTCOMMANDFILE OUTPUTFILE RECORDCOUNT")
        sys.exit(1)

    input_command_file = sys.argv[1]
    output_file = sys.argv[2]

    try:
        record_count = int(sys.argv[3])
        if record_count <= 0:
            raise ValueError
    except ValueError:
        print("Error: RECORDCOUNT must be a positive integer.")
        sys.exit(1)

    # Read commands load files
    commands = []
    random_files = {}

    try:
        with open(input_command_file, 'r') as infile:
            for line in infile:
                command = shlex.split(line.strip())
                commands.append(command)
                if command[0] == "WORD":
                    label = command[1]
                    filename = command[2].strip('"')
                    try:
                        with open(filename, 'r') as wordfile:
                            random_files[label] = [word.strip() for word in wordfile.readlines()]
                    except Exception as e:
                        print(f"Error: Could not read file {filename}. {e}")
                        sys.exit(1)

    except Exception as e:
        print(f"Error: Could not open command file {input_command_file}. {e}")
        sys.exit(1)

    # Generate records
    output_lines = []
    header = None

    for _ in range(record_count):
        random_data = {}
        current_line = []

        for command in commands:
            cmd_type = command[0]

            if cmd_type == "HEADER":
                header = command[1].encode('utf-8').decode('unicode_escape').rstrip('\n')
            elif cmd_type == "STRING":
                current_line.append(command[1].encode('utf-8').decode('unicode_escape').rstrip('\n'))
            elif cmd_type == "WORD":
                label = command[1]
                if label not in random_data:
                    random_data[label] = random.choice(random_files[label])
                current_line.append(random_data[label])
            elif cmd_type == "INTEGER":
                label = command[1]
                integer = str(random.randint(int(command[2]), int(command[3])))
                random_data[label] = integer
                current_line.append(integer)
            elif cmd_type == "REFER":
                current_line.append(str(random_data[label]))

        output_lines.append(''.join(current_line) + '\n')

    # Write output to file
    try:
        with open(output_file, 'w') as outfile:
            if header:
                outfile.write(header + '\n')
            outfile.writelines(output_lines)
    except Exception as e:
        print(f"Error: Could not open or write to output file {output_file}. {e}")
        sys.exit(1)

if __name__ == "__main__":
    main()