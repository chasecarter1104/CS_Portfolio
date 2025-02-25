#!/bin/bash
# Chase Carter
# Lab 2 - Search & Report
# CS 3030 - Scripting Languages

#Folder Requirements
if [ $# -ne 1 ]; then
    echo "Usage: srpt FOLDER"
    exit 1
fi

#variables
FOLDER=$1
temp_dir="/tmp/$USER/$(date +%s)"
mkdir -p "$temp_dir"

#Find command
find "$FOLDER" \
  \( -type f -fprintf "$temp_dir/numberoffiles" "\n" \) , \
  \( -type d -fprintf "$temp_dir/numberofdirectories" "\n" \) , \
  \( -type l -fprintf "$temp_dir/numberoflinks" "\n" \) , \
  \( -type f -fprintf "$temp_dir/sizeofallfiles" "%s\n" \) , \
  \( -type f \( -name '*.jpg' -o -name '*.bmp' -o -name '*.gif' \) -fprintf "$temp_dir/numberofgraphicsfiles" "\n" \) , \
  \( -type f -mtime +365 -fprintf "$temp_dir/numberofoldfiles" "\n" \) , \
  \( -type f -size +500k -fprintf "$temp_dir/numberoflargefiles" "\n" \) , \
  \( -type f -name '*.o' -fprintf "$temp_dir/numberoftemporaryfiles" "\n" \) , \
  \( -type f -executable -fprintf "$temp_dir/numberofexecutablefiles" "\n" \)

#calculate counts
fileCnt=$(wc -l < "$temp_dir/numberoffiles")
dirCnt=$(($(wc -l < "$temp_dir/numberofdirectories") - 1))
linkCnt=$(wc -l < "$temp_dir/numberoflinks")
graphicsCnt=$(wc -l < "$temp_dir/numberofgraphicsfiles")
oldFileCnt=$(wc -l < "$temp_dir/numberofoldfiles")
largeFileCnt=$(wc -l < "$temp_dir/numberoflargefiles")
tempFileCnt=$(wc -l < "$temp_dir/numberoftemporaryfiles")
executableFileCnt=$(wc -l < "$temp_dir/numberofexecutablefiles")

#total file size
totalSize=$(awk '{tot+=$1} END {print tot}' "$temp_dir/sizeofallfiles")

#format report
printf "SearchReport %s %s %s\n" "$HOSTNAME" "$FOLDER" "$(date)"
printf "Execution time %'d\n" "$SECONDS"
printf "Directories %'d\n" $dirCnt
printf "Files %'d\n" "$fileCnt"
printf "Sym links %'d\n" "$linkCnt"
printf "Old files %'d\n" "$oldFileCnt"
printf "Large files %'d\n" "$largeFileCnt"
printf "Graphics files %'d\n" "$graphicsCnt"
printf "Temporary files %'d\n" "$tempFileCnt"
printf "Executable files %'d\n" "$executableFileCnt"
printf "TotalFileSize %'d\n" "$totalSize"


rm -rf $temp_dir

exit 0