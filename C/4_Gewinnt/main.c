#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define SPALTE 7
#define ZEILE 6

int eingabe();
void ausgabe(char spielfeld[ZEILE][SPALTE]);
int abprgewinner(char spielfeld[ZEILE][SPALTE], int count, FILE* fptr);

int main() {
    char spielfeld[ZEILE][SPALTE] = {'\0'};
    int fuellcount[SPALTE] = {0};
    char speicher[SPALTE * ZEILE] = {'\0'};
    int reihenfolge = 0;
    int eing;
    int j = 0;
    int fuellabpr;
    int count = 0;
    int gewinner;
    int ladetyp;
    int l = 0;
    FILE* fptr = NULL;

    printf("Druecke 1, wenn du das letzte Spiel laden moechtest, 2 wenn du das Spiel ueberschreiben willst!\n");
    scanf("%d", &ladetyp);

    if(ladetyp == 1){
        fptr = fopen("savegame.txt", "r");
        if(fptr == NULL){
            printf("Fehler beim Oeffnen der Datei!");
            return 0;
        }

        fgets(speicher, SPALTE * ZEILE, fptr);

        for (int i = 0; i < ZEILE; ++i) {
            for (int k = 0; k < SPALTE; ++k) {
                spielfeld[i][k] = speicher[l];
                l++;
            }
        }
        fclose(fptr);
    }

    while(j != 1) {

        fuellabpr = 0;
        if (reihenfolge % 2 == 0) {
            printf("Spieler x, gib bitte die Spalte ein:");
            while(fuellabpr != 1){
                eing = eingabe();
                (fuellcount[eing]++);
                if (fuellcount[eing] <= ZEILE && eing <= SPALTE && eing >= 0 && eing != -1 && eing != 7) {
                    for (int k = 0; k < ZEILE; ++k) {

                        if (spielfeld[k][eing] != '\0') {
                            spielfeld[k - 1][eing] = 'x';
                            k = 1000;
                        } else if (k == ZEILE - 1) {
                            spielfeld[k][eing] = 'x';
                        }
                    }
                    fuellabpr = 1;
                }
                else {
                    printf("Diese Spalte ist voll oder sie existiert nicht, probieren sie bitte eine andere:");
                }
            }
        }
        else {
            printf("Spieler o, gib bitte die Spalte ein:");
            while(fuellabpr != 1) {
                eing = eingabe();
                (fuellcount[eing]++);

                if(fuellcount[eing] <= ZEILE && eing <= SPALTE - 1 && eing >= 0 && eing != -1 && eing != 7) {
                    for (int k = 0; k < ZEILE; ++k) {
                        if (spielfeld[k][eing] != '\0') {
                            spielfeld[k - 1][eing] = 'o';
                            k = 1000;
                        } else if (k == ZEILE - 1) {
                            spielfeld[k][eing] = 'o';
                        }
                    }
                    fuellabpr = 1;
                }
                else {
                    printf("Diese Spalte ist schon voll oder ungueltig, probieren sie eine andere:");
                }
            }
        }
        fptr = fopen("savegame.txt", "w");

        for (int i = 0; i < ZEILE; ++i) {
            for (int k = 0; k < SPALTE; ++k) {
                switch (spielfeld[i][k]) {
                    case '\0':
                        fputc('\0', fptr);
                        break;
                    case 'x':
                        fputc('x', fptr);
                        break;
                    case 'o':
                        fputc('o', fptr);
                        break;
                    default:
                        printf("Fehler!");
                        break;
                }
            }
        }
        fclose(fptr);
        reihenfolge++;
        count++;
        gewinner = abprgewinner(spielfeld, count, fptr);
        ausgabe(spielfeld);
        if(gewinner == 1){
            printf("\n\n!!! Spieler x hat gewonnen !!!\n\n");
            return 0;
        }
        else if(gewinner == 2){
            printf("\n\n!!! Spieler o hat gewonnen !!!\n\n");
            return 0;
        }
    }
}

int eingabe(){
    int eing;
    scanf("%d", &eing);
    return eing - 1;
}

void ausgabe(char spielfeld[ZEILE][SPALTE]){
    printf("  ");
    for (int i = 1; i <= SPALTE; ++i) {
        printf("%d   ", i);
    }
    printf("\n");
    for (int i = 0; i < ZEILE; ++i) {
        for (int k = 0; k < SPALTE; ++k) {
            printf("+ - ");
        }
        printf("+\n");
        for (int j = 0; j < SPALTE; ++j) {
            printf("| %c ", spielfeld[i][j]);
        }
        printf("|\n");
    }
    for (int k = 0; k < SPALTE; ++k) {
        printf("+ - ");
    }
    printf("+\n");
}

int abprgewinner(char spielfeld[ZEILE][SPALTE], int count, FILE* fptr){
    int gewinner = 0;
    for (int i = 0; i < ZEILE; ++i) {
        for (int j = 0; j < SPALTE - 3; ++j) {//Abprüfung horizontal
            if(spielfeld[i][j] == 'x' && spielfeld[i][j +1] == 'x' && spielfeld[i][j + 2] == 'x' && spielfeld[i][j + 3] == 'x'){
                gewinner = 1;
                spielfeld[i][j] -= 32;
                spielfeld[i][j + 1] -= 32;
                spielfeld[i][j + 2] -= 32;
                spielfeld[i][j + 3] -= 32;
            }
            else if(spielfeld[i][j] == 'o' && spielfeld[i][j +1] == 'o' && spielfeld[i][j + 2] == 'o' && spielfeld[i][j + 3] == 'o'){
                gewinner = 2;
                spielfeld[i][j] -= 32;
                spielfeld[i][j + 1] -= 32;
                spielfeld[i][j + 2] -= 32;
                spielfeld[i][j + 3] -= 32;
            }//abprüfung vertikal
            else if(spielfeld[i][j] == 'x' && spielfeld[i+ 1][j] == 'x' && spielfeld[i+ 2][j] == 'x' && spielfeld[i + 3][j] == 'x'){
                gewinner = 1;
                spielfeld[i][j] -= 32;
                spielfeld[i + 1][j] -= 32;
                spielfeld[i + 2][j] -= 32;
                spielfeld[i + 3][j] -= 32;
            }
            else if(spielfeld[i][j] == 'o' && spielfeld[i + 1][j] == 'o' && spielfeld[i+ 2][j] == 'o' && spielfeld[i + 3][j] == 'o'){
                gewinner = 2;
                spielfeld[i][j] -= 32;
                spielfeld[i + 1][j] -= 32;
                spielfeld[i + 2][j] -= 32;
                spielfeld[i + 3][j] -= 32;
            }//Abprüfung diagonal
            else if(spielfeld[i][j] == 'x' && spielfeld[i+ 1][j + 1] == 'x' && spielfeld[i+ 2][j + 2] == 'x' && spielfeld[i + 3][j + 3] == 'x'){
                gewinner = 1;
                spielfeld[i][j] -= 32;
                spielfeld[i + 1][j + 1] -= 32;
                spielfeld[i + 2][j + 2] -= 32;
                spielfeld[i + 3][j + 3] -= 32;
            }
            else if(spielfeld[i][j] == 'o' && spielfeld[i+ 1][j + 1] == 'o' && spielfeld[i+ 2][j + 2] == 'o' && spielfeld[i + 3][j + 3] == 'o'){
                gewinner = 2;
                spielfeld[i][j] -= 32;
                spielfeld[i + 1][j + 1] -= 32;
                spielfeld[i + 2][j + 2] -= 32;
                spielfeld[i + 3][j + 3] -= 32;
            }
            else if(spielfeld[i][j] == 'x' && spielfeld[i - 1][j + 1] == 'x' && spielfeld[i - 2][j + 2] == 'x' && spielfeld[i - 3][j + 3] == 'x'){
                gewinner = 1;
                spielfeld[i][j] -= 32;
                spielfeld[i - 1][j + 1] -= 32;
                spielfeld[i - 2][j + 2] -= 32;
                spielfeld[i - 3][j + 3] -= 32;
            }
            else if(spielfeld[i][j] == 'o' && spielfeld[i - 1][j + 1] == 'o' && spielfeld[i - 2][j + 2] == 'o' && spielfeld[i - 3][j + 3] == 'o'){
                gewinner = 2;
                spielfeld[i][j] -= 32;
                spielfeld[i - 1][j + 1] -= 32;
                spielfeld[i - 2][j + 2] -= 32;
                spielfeld[i - 3][j + 3] -= 32;
            }
            else if(count == ZEILE * SPALTE){
                printf("\n\n!!! Unentschieden !!!\n\n");
                abort();
            }
        }
    }
    return gewinner;
}