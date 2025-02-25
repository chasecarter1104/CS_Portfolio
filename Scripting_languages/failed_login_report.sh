#!/bin/bash
# Chase Carter
# Lab 3 - Failed Login Report
# CS 3030 - Scripting Languages

#check log file, same as last assignment
if [ $# -ne 1 ]; then
	echo "Usage: flog LOGFILE"
	exit 1
fi

LOGFILE=$1

#save failed password attempts to temp file
grep 'Failed password for ' "$LOGFILE" > temp1

#get user id's and replace invalid with <unknown>
sed -n 's/.*Failed password for \([a-z0-9A-Z_]*\) .*/\1/p' temp1 | sed 's/invalid/\&lt;UNKNOWN\&gt;/' > temp2

#sort user names
sort temp2 > temp3

#count user occurrences
uniq -c temp3 > temp4

#sort user occurrences
sort -k1,1nr -k2,2 temp4 > temp5

#commas in large numbers
rm -f temp6
cat temp5 | while read count userid; do
    printf "%'d %s\n" "$count" "$userid" >> temp6
done < temp5

#HTML output
echo "<html>"
echo "<body><h1>Failed Login Attempts Report as of $(date)</h1>"
echo "<br />"
while read count userid; do
	echo "<br /> $count $userid"
done < temp6
echo "</body></html>"

#bye bye temp files
rm -f temp1 temp2 temp3 temp4 temp5 temp6