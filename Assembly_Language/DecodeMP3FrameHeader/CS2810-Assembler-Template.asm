TITLE CS2810 Assembler Template

; Student Name: Chase Carter
; Assignment Due Date: 7-28-24

INCLUDE Irvine32.inc
.data
	;--------- Enter Data Here
	vSemester BYTE "CS2810 Summer Semester 2024", 0
    vAssignment BYTE "Assembler Assignment #2", 0
    vName BYTE "Chase Carter", 0
    promptMsg BYTE "Enter MP3 Frame Header: ",0
    
    vMpeg25 BYTE "MPEG Version 2.5",0
    vMpeg20 BYTE "MPEG Version 2.0",0
    vMpeg10 BYTE "MPEG Version 1.0",0
    vMpegRE BYTE "MPEG Reserved",0

    ; Layer Description Strings
    vLayer11 BYTE "Layer I", 0
    vLayer10 BYTE "Layer II", 0
    vLayer01 BYTE "Layer III", 0
    vLayerRE BYTE "Reserved", 0

    ; Sampling Rate Strings
	vSRMPEG100 BYTE "Sampling Rate: 44100Hz",0
	vSRMPEG101 BYTE "Sampling Rate: 48000Hz",0
	vSRMPEG110 BYTE "Sampling Rate: 32000Hz",0

	vSRMPEG200 BYTE "Sampling Rate:22050Hz",0
	vSRMPEG201 BYTE "Sampling Rate:24000Hz",0
	vSRMPEG210 BYTE "Sampling Rate:16000Hz",0

	vSRMPEG2500 BYTE "Sampling Rate:11025",0
	vSRMPEG2501 BYTE "Sampling Rate:12000",0
	vSRMPEG2510 BYTE "Sampling Rate:8000",0
	vSRMPEGRESERVED BYTE "Sampling Rate:RESERVED",0

.code
main PROC
	;--------- Enter Code Below Here
    ; Clear the screen
	call Clrscr

	; Display Semester
    mov dh, 12
    mov dl, 12
    call Gotoxy
    mov edx, OFFSET vSemester
    call WriteString

    ; Display Assignment
    mov dh, 13
    mov dl, 12
    call Gotoxy
    mov edx, OFFSET vAssignment
    call WriteString

    ; Display Name
    mov dh, 14
    mov dl, 12
    call Gotoxy
    mov edx, OFFSET vName
    call WriteString

    ; Prompt for MP3 frame header
    mov dh, 16
    mov dl, 12
    call Gotoxy
    mov edx, OFFSET promptMsg
    call WriteString

    ; Read hexadecimal input
    call ReadHex

    mov ecx, eax

    ; Decode and display MPEG Audio Version ID
    mov dh, 17
    mov dl, 12
    call Gotoxy
    mov eax, ecx
    call DisplayVersion

    ; Decode and display Layer Description
    mov dh, 18
    mov dl, 12
    call Gotoxy
    mov eax, ecx
    call DisplayLayer

    ; Decode and display Sampling Rate
    mov dh, 19
    mov dl, 12
    call Gotoxy
    mov eax, ecx
    call DisplayRate


    jmp theEnd


    DisplayVersion:

	    and eax, 00000000000110000000000000000000b
	    shr eax, 19

        cmp eax, 00b
        jz dMpeg25

        cmp eax, 01b
        jz dMpegRE

        cmp eax, 10b
        jz dMpeg20

    dMPEG10:
	    mov edx, offset vMPEG10
	    jmp DisplayString

    dMpeg25:
        mov edx, offset vMpeg25
        jmp DisplayString

    dMpegRE:
        mov edx, offset vMpegRE
        jmp DisplayString

    dMpeg20:
        mov edx, offset vMpeg20
        jmp DisplayString



    DisplayLayer:

        ; Decode and display Layer Description
		and eax, 00000000000001100000000000000000b
		shr eax, 17

        ; Compare and display layer
        cmp eax, 00b
        jz dLayerRE

        cmp eax, 01b
        jz dLayer01

        cmp eax, 10b
        jz dLayer10

        cmp eax, 11b
        jz dLayer11

    dLayer11:
        mov edx, OFFSET vLayer11
        jmp DisplayString

    dLayerRE:
        mov edx, OFFSET vLayerRE
        jmp DisplayString

    dLayer10:
        mov edx, OFFSET vLayer10
        jmp DisplayString

    dLayer01:
        mov edx, OFFSET vLayer01
        jmp DisplayString


    DisplayRate:

	    and eax, 00000000000110000000110000000000b
	    shr eax, 10


	    cmp eax, 11000000000b
	    jz dSRMPEG100


	    cmp eax, 10000000000b
	    jz dSRMPEG200

	    cmp eax, 00000000000b
	    jz dSRMPEG2500


	    cmp eax, 11000000001b
	    jz dSRMPEG101

	    cmp eax, 10000000001b
	    jz dSRMPEG201

	    cmp eax, 00000000001b
	    jz dSRMPEG2501

	    cmp eax, 11000000010b
	    jz dSRMPEG110


	    cmp eax, 10000000010b 
	    jz dSRMPEG210

	    cmp eax, 00000000010b
	    jz dSRMPEG2510

	    cmp eax, 11000000011b
	    jz dSRMPEGRESERVED

	    cmp eax, 10000000011b
	    jz dSRMPEGRESERVED

	    cmp eax, 00000000011b
	    jz dSRMPEGRESERVED


	dSRMPEG100:
	    mov edx, offset vSRMPEG100
	    jmp DisplayString


	dSRMPEG200:
	    mov edx, offset vSRMPEG200
	    jmp DisplayString


	dSRMPEG2500:
	    mov edx, offset vSRMPEG2500
	    jmp DisplayString
	
	dSRMPEG101:
	    mov edx, offset vSRMPEG101
	    jmp DisplayString


	dSRMPEG201:
	    mov edx, offset vSRMPEG201
	    jmp DisplayString


	dSRMPEG2501:
	    mov edx, offset vSRMPEG2501
	    jmp DisplayString


	dSRMPEG110:
	    mov edx, offset vSRMPEG110
	    jmp DisplayString


	dSRMPEG210:
	    mov edx, offset vSRMPEG210
	    jmp DisplayString


	dSRMPEG2510:
	    mov edx, offset vSRMPEG2510
	    jmp DisplayString

	
	dSRMPEGRESERVED:
	    mov edx, offset vSRMPEGRESERVED
	    jmp DisplayString

    DisplayString:
        call WriteString


        ret

    theEnd:
        call ReadChar
        exit

    main ENDP

END main