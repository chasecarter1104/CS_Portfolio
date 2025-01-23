TITLE CS2810 Assembler Template

; Student Name: Chase Carter
; Assignment Due Date: 

INCLUDE Irvine32.inc
.data
	;--------- Enter Data Here
	vSemester BYTE "CS2810 Summer Semester 2024", 0
    vAssignment BYTE "Assembler Assignment #4", 0
    vName BYTE "Chase Carter", 0
	vPromptMsg BYTE "Enter FAT16 file date in hex format: ",0

	vArray BYTE "January ",0,"  "
		   BYTE "February ",0," "
		   BYTE "March ",0,"    "
		   BYTE "April ",0,"    "
		   BYTE "May ",0,"      "
		   BYTE "June ",0,"     "
		   BYTE "July ",0,"     "
		   BYTE "August ",0,"   "
		   BYTE "September ",0
		   BYTE "October ",0,"  "
		   BYTE "November ",0," "
		   BYTE "December ",0," "

	vSuffixes BYTE "--stndrdthththththththththththththththththstndrdthththththththst",0
	vSuffix BYTE "--",0
	vDateField BYTE "----, ----",0

.code
main PROC
	;--------- Enter Code Below Here

    ; Clear the screen
	call Clrscr

	; Display Semester
    mov dh, 4
    mov dl, 33
    call Gotoxy
    mov edx, OFFSET vSemester
    call WriteString

    ; Display Assignment
    mov dh, 5
    mov dl, 33
    call Gotoxy
    mov edx, OFFSET vAssignment
    call WriteString

    ; Display Name
    mov dh, 6
    mov dl, 33
    call Gotoxy
    mov edx, OFFSET vName
    call WriteString

	; Message Prompt FAT16
	mov dh, 8
    mov dl, 33
    call Gotoxy
    mov edx, OFFSET vPromptMsg
    call WriteString

    ; Read hexadecimal input
    call ReadHex
	ror ax, 8
	mov ecx, eax
	mov dh, 10
	mov dl, 33
	call gotoxy

	; Month
	and ax, 0000000111100000b
	shr ax, 5
	sub ax, 1
	mov edx, offset [vArray]
	mov bl, 11
	mul bl

	add edx, eax
	call WriteString

	; Day
	mov eax, ecx
	and ax, 0000000000011111b

	; Suffix
	shl eax, 1
	mov edx, offset [vSuffixes]
	add edx, eax
	mov bx, word ptr [edx]
	mov word ptr [vDateField+2],bx


	mov eax, ecx
	and ax, 0000000000011111b
	mov bh, 10
	div bh
	add ax, 3030h
	mov word ptr [vDateField],ax

	; Year
	mov eax, ecx
	and ax, 1111111000000000b
	shr ax, 9
	add ax, 1980
	xor dx,dx
	mov bx, 1000
	div bx
	add al, 30h
	mov byte ptr [vDateField+6],al
	mov ax, dx
	xor dx, dx
	mov bx, 100
	div bx
	add al, 30h
	mov byte ptr [vDateField+7],al
	mov ax,dx
	mov bl, 10
	div bl
	add ax, 3030h
	mov word ptr [vDateField+8],ax

	mov edx, OFFSET vDateField
	call WriteString

	
	call readchar

	exit

main ENDP

END main