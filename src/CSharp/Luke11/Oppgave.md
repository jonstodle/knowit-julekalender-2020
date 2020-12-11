﻿# Passordhint

_Av Hugo Wallenburg_ 

Alvene har ikke hørt om passordprogrammer, så de må bruke passordhint for å huske på passordene sine. De er også litt slappe med sikkerheten, så de har gjemt passordene sine i hintet.

Følgende prosedyre bestemmer om et ord kan være et hint for passordet vårt:

Vi starter med et mulig hint, for eksempel `juletre` og legger det på første rad:

    juletre

Deretter gjør vi følgende:

Kopier innholdet i siste rad, og fjern den første bokstaven.

    juletre
    uletre

Dytt så de resterende bokstavene ett hakk oppover i alfabetet (`a -> b` og `z -> a`).

    juletre
    vmfusf

Deretter, legg til alfabetplasseringen fra bokstaven over (`a(0) + b(1) = b(1)`, `b(1) + c(2) = d(3)`):

    juletre
    egqylw  <-- v(21) + j(9) % 26 = e(4); m(12) + u(20) % 26 = g(6); f + l = q...

Vi fortsetter med prosedyren over helt til vi er tomme for bokstaver:

    juletre
    egqylw
    lxpki
    jnat
    xou
    mj
    w

Et gyldig hint vil ha passordet i en av kolonnene (ikke nødvendigvis hele kolonnen).

Passordet for eksempelet over kunne vært `jeljxmw`, `ugxnoj`, `lqpau`, `eykt`, `tli`, `rw`, `e`, _eller en hvilken som helst substring av disse_.

Hvilket av [disse ordene](https://julekalender-backend.knowit.no/challenges/11/attachments/hint.txt) er et hint for passordet `eamqia`?
