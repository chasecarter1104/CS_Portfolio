TITLE CS2810 Assembler Template

; Student Name: Chase Carter
; Assignment Due Date: 7-20-24

INCLUDE Irvine32.inc
.data
    ; Data Section
    vSemester BYTE "CS2810 Summer Semester 2024", 0
    vAssignment BYTE "Assembler Assignment #2", 0
    vName BYTE "Chase Carter", 0
    vTimeField BYTE "--:--:--", 0
    promptMsg BYTE "Enter FAT16 file time in hex format: ", 0
.code
main PROC
    ; Clear the screen
    call Clrscr
    
    ; Display Semester
    mov dh, 7
    mov dl, 20
    call Gotoxy
    mov edx, OFFSET vSemester
    call WriteString

    ; Display Assignment
    mov dh, 8
    mov dl, 20
    call Gotoxy
    mov edx, OFFSET vAssignment
    call WriteString

    ; Display Name
    mov dh, 9
    mov dl, 20
    call Gotoxy
    mov edx, OFFSET vName
    call WriteString

    ; Prompt for File time
    mov dh, 11
    mov dl, 20
    call Gotoxy
    mov edx, OFFSET promptMsg
    call WriteString

    ; Read hexadecimal input
    call ReadHex
    ror ax, 8

    mov ecx, eax

    ; Extract hours
    and ax, 1111100000000000b
    shr ax, 11
    mov bh, 10
    div bh
    add ax, 3030h
    mov word ptr [vTimeField+0], ax

    mov eax, ecx

    ; Extract minutes
    and ax, 0000011111100000b
    shr ax, 5
    mov bh, 10
    div bh
    add ax, 3030h
    mov word ptr [vTimeField+3], ax

    mov eax, ecx

    ; Extract seconds
    and ax, 0000000000011111b
    shl ax, 1
    mov bh, 10
    div bh
    add ax, 3030h   ; Convert to ASCII
    mov word ptr [vTimeField+6], ax

    ; Display decoded file time
    mov dh, 12 
    mov dl, 20 
    call Gotoxy
    mov edx, OFFSET vTimeField
    call WriteString


    
    call readchar
    exit



main ENDP

END main