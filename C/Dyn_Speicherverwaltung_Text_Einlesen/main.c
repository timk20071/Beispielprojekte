#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define ASIZE 33

int main() {
    /*
     * Datei Erstellen
     * Text einlesen
     * Wenn ein Text eingelesen wird, muss alle 10 Zeichen mehr Speicherbereich allokiert werden
     * Text in ein File schreiben
     */
    
    char dateiname[ASIZE] = {'\0'};
    char dateinamefinal[ASIZE + 20] = {"./Texte/\0"};
    char* text = (char*) malloc(1 * sizeof(char));
    int i = 0;
    FILE* fptr = NULL;

    printf("Wie soll deine Datei heissen?\n");
    gets(dateiname);
    strcat(dateinamefinal, dateiname);
    strcat(dateinamefinal,".txt");
    fptr = fopen(dateinamefinal, "w");
    if(fptr == NULL){
        printf("Fehler");
        return -1;
    }
    printf("Gib bitte jetzt deinen Text ein:");
    while (text[i - 1] != '\n'){
        scanf("%c", &text[i]);
        if(i % 10 == 0){
            text = realloc(text, (10 * (i + 1) * sizeof(char)));
        }
        i++;
    }
    for (int j = 0; j < i; ++j) {
        fprintf(fptr, "%c", text[j]);
    }

    fclose(fptr);
    return 0;
}