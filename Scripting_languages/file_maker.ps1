#!/usr/bin/env pwsh
# Chase Carter
# Lab 9 - PowerShell Filemaker
# CS 3030 - Scripting Languages

# Verify command-line parameters
if ($args.length -ne 3) {
    write-host "Usage: ./filemaker.ps1 <commandfile> <outputfile> <recordcount>"
    exit 1
}

$commandFile = $args[0]
$outputFile = $args[1]
$recordCount = $args[2]

# Validate record count
if ($recordCount -match '^\d+$' -and $recordCount -gt 0) {
    $recordCount = [int]$recordCount
} else {
    write-host "Error: RECORDCOUNT must be a positive integer."
    exit 1
}

# Read command file
try {
    $inputCommands = Get-Content -path $commandFile -erroraction stop
} catch {
    write-host ("Error opening or reading command file: $($_)")
    exit 1
}

# Prepare for output file creation
try {
    New-Item -path $outputFile -force -erroraction stop | out-null
} catch {
    write-host ("Error opening output file: $($_)")
    exit 1
}

# Load word files into a dictionary
$randomFiles = @{}

foreach ($command in $inputCommands) {
    if ($command -match '^WORD\s+(\w+)\s+"(.*)"$') {
        $label = $matches[1]
        $fileName = $matches[2]
        try {
            $randomFiles[$fileName] = Get-Content -path $fileName -erroraction stop
        } catch {
            write-host ("Error reading word file $($fileName): $($_)")
            exit 1
        }
    }
}

# Write function for writing to file
function writeToFile($outputFile, $outputString) {
    $outputString = $outputString -replace [regex]::escape("\t"), "`t"
    $outputString = $outputString -replace [regex]::escape("\n"), "`n"
    try {
        Add-Content -path $outputFile -value $outputString -nonewline
    } catch {
        write-host "Error writing to file $($outputFile): $_"
        exit 1
    }
}

# Process commands and generate records
$headerWritten = $false

for ($i = 0; $i -lt $recordCount; $i++) {
    $randomData = @{}
    $currentLine = ""

    foreach ($command in $inputCommands) {
        if ($command -match '^HEADER\s+"(.*)"$') {
            if (-not $headerWritten) {
                writeToFile $outputFile "$($matches[1])"
                $headerWritten = $true
            }
        } elseif ($command -match '^STRING\s+"(.*)"$' -or $command -match "^STRING\s+'(.*)'$") {
            $stringValue = $matches[1]
            $currentLine += $stringValue
        } elseif ($command -match '^WORD\s+(\w+)\s+"(.*)"$') {
            $label = $matches[1]
            $fileName = $matches[2]
            $randomWord = Get-Random -InputObject $randomFiles[$fileName]
            $randomData[$label] = $randomWord
            $currentLine += $randomWord
        } elseif ($command -match '^INTEGER\s+(\w+)\s+(\d+)\s+(\d+)$') {
            $label = $matches[1]
            $min = [int]$matches[2]
            $max = [int]$matches[3]
            $randomInt = Get-Random -Minimum $min -Maximum ($max + 1)
            $randomData[$label] = $randomInt
            $currentLine += $randomInt
        } elseif ($command -match '^REFER\s+(\w+)$') {
            $referLabel = $matches[1]
            $currentLine += $randomData[$referLabel]
        }
    }

    writeToFile $outputFile "$currentLine"
}

write-host "File generation completed."