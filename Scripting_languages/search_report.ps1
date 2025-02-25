#!/usr/bin/env pwsh
# Chase Carter
# Lab 7 - Search & Report
# CS 3030 - Scripting Languages


# Arguments and folder
if ($args.Length -ne 1) {
    Write-Host "Usage: srpt.ps1 FOLDER"
    exit 1
}

# Variables
$folder = $args[0]
$todaysDate = Get-Date
$hostname = hostname

# Retrieve file objects
$items = Get-ChildItem -Recurse -Path $folder

# Initialize counts
$directoryCount = 0
$fileCount = 0
$symLinkCount = 0
$oldFileCount = 0
$largeFileCount = 0
$graphicsFileCount = 0
$tempFileCount = 0
$executableFileCount = 0
$totalFileSize = 0

# Calculate old files (365 days old)
$oldDateThreshold = (Get-Date).AddDays(-365)

# Iterate through all files
foreach ($item in $items) {
    if ($item.PSIsContainer) {
        # Count directories (excluding the root folder)
        if ($item.FullName -ne $folder) {
            $directoryCount++
        }
    } elseif ($item.GetType().Name -eq "FileInfo") {
        # Check if the item is a symbolic link
        if ($item.Attributes -band [System.IO.FileAttributes]::ReparsePoint) {
            # Count symbolic links
            $symLinkCount++
            continue
        }
        
        # Regular files
        $fileCount++
        $totalFileSize += $item.Length
        
        # Count old files
        if ($item.LastWriteTime -lt $oldDateThreshold) {
            $oldFileCount++
        }
        
        # Count large files
        if ($item.Length -gt 500000) {
            $largeFileCount++
        }
        
        # Count graphics files
        if ($item.Name -match '\.jpg$|\.gif$|\.bmp$') {
            $graphicsFileCount++
        }
        
        # Count temporary files
        if ($item.Name -match '\.o$') {
            $tempFileCount++
        }
        
        # Count executable files
        if ($item.Name -match '\.bat$|\.ps1$|\.exe$') {
            $executableFileCount++
        }
    }
}

# Format and output the report
Write-Host "SearchReport $hostname $folder $todaysDate"
Write-Host "Directories $($directoryCount.ToString("N0"))"
Write-Host "Files $($fileCount.ToString("N0"))"
Write-Host "Sym links $($symLinkCount.ToString("N0"))"
Write-Host "Old files $($oldFileCount.ToString("N0"))"
Write-Host "Large files $($largeFileCount.ToString("N0"))"
Write-Host "Graphics files $($graphicsFileCount.ToString("N0"))"
Write-Host "Temporary files $($tempFileCount.ToString("N0"))"
Write-Host "Executable files $($executableFileCount.ToString("N0"))"
Write-Host "TotalFileSize $($totalFileSize.ToString("N0"))"
exit 0