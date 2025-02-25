TITLE CS2810 Assembler Template

; Student Name:
; Assignment Due Date:

INCLUDE Irvine32.inc
.data
	;--------- Enter Data Here
    vSemester BYTE "CS2810 Summer Semester 2024", 0
    vAssignment BYTE "Assembler Assignment #5", 0
    vName BYTE "Chase Carter", 0
	PromptGuess BYTE "Guess a number between 0 and 100: ",0
	GuessAgainPrompt BYTE "Guess Again: ",0
	HighMsg BYTE " is too high. ",0
	LowMsg BYTE " is too low. ",0
	CorrectMsg BYTE" is Correct!",0
	AgainMsg BYTE "Play again? (1 for Yes, 0 for No)",0
	vCarriageReturn BYTE 13, 10, 0

.code
main PROC
	;--------- Enter Code Below Here

	; Clear the screen
    call Clrscr
    
    ; Display Semester
    mov dh, 4
    mov dl, 0
    call Gotoxy
    mov edx, OFFSET vSemester
    call WriteString

    ; Display Assignment
    mov dh, 5
    mov dl, 0
    call Gotoxy
    mov edx, OFFSET vAssignment
    call WriteString

    ; Display Name
    mov dh, 6
    mov dl, 0
    call Gotoxy
    mov edx, OFFSET vName
    call WriteString

	call Randomize
	
	Game:
		mov edx, OFFSET vCarriageReturn
		call WriteString
		mov eax, 101
		call RandomRange
		mov ebx, eax

	Guess:
		mov edx, OFFSET vCarriageReturn
		call WriteString
		mov edx, OFFSET PromptGuess
		call WriteString
		call ReadDec

		cmp eax, ebx
		jl tooLow
		jg tooHigh
		je Correct

	GuessAgain:
		mov edx, OFFSET vCarriageReturn
		call WriteString
		mov edx, OFFSET GuessAgainPrompt
		call WriteString
		call ReadDec

		cmp eax, ebx
		jl tooLow
		jg tooHigh
		je correct

	Correct:
		mov edx, eax
		call WriteDec
		mov edx, OFFSET CorrectMsg
		call WriteString
		jmp playAgain

	tooLow:
		mov edx, eax
		call WriteDec
		mov edx, OFFSET LowMsg
		call WriteString
		jmp GuessAgain

	tooHigh:
		mov edx, eax
		call WriteDec
		mov edx, OFFSET HighMsg
		call WriteString
		jmp GuessAgain

	playAgain:
		mov edx, OFFSET vCarriageReturn
		call WriteString
		mov edx, OFFSET AgainMsg
		call WriteString
		call ReadDec

		cmp eax, 1
		je Game
		cmp eax, 0
		jz TheEnd


	TheEnd:
		exit
		


	xor ecx, ecx
	call ReadChar

	exit
main ENDP

END main