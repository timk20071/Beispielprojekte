#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <limits.h>

void insertionSort(int arr[]);
void printArray(int arr[], int n);
size_t starttimer();
size_t endtimer();
void auswertung(size_t, size_t, int);
void SelectionSort(int[]);
void BubbleSort(int[]);

#define SIZE 99999

int main() {
    /*
     * Aufgabe:
     * jeden Sortieralgorithmus ein Array mit einer vordefinierten Größe an zufälligen Werten sortieren zu lassen
     * Geschwindigkeit aller Sortieralgorithmen ausgeben
     */
    int arr[SIZE] = {0};
    int arr2[SIZE] = {0};
    int arr3[SIZE] = {0};
    int n = sizeof(arr) / sizeof(arr[0]);
    size_t start;
    size_t end;
    int methode = 0;

    srand(time(NULL));

    for (int i = 0; i < SIZE; ++i) {
        arr[i] = rand() % 10;
        arr2[i] = arr[i];
        arr3[i] = arr[i];
    }

    printf("Original array: ");
    printArray(arr, n);
    printf("\n");

    start = starttimer();
    insertionSort(arr2);
    end = endtimer();
    auswertung(start, end, methode);
    methode++;

    start = starttimer();
    BubbleSort(arr3);
    end = endtimer();
    auswertung(start, end, methode);
    methode++;

    start = starttimer();
    SelectionSort(arr);
    end = endtimer();
    auswertung(start, end, methode);

    return 0;
}


void insertionSort(int arr2[]) {
    int i, key, j;
    for (i = 1; i < SIZE; i++) {
        key = arr2[i];
        j = i - 1;

        while (j >= 0 && arr2[j] > key) {
            arr2[j + 1] = arr2[j];
            j = j - 1;
        }
        arr2[j + 1] = key;
    }
}

void printArray(int arr[], int n) {
    int i;
    for (i = 0; i < n; i++)
        printf("%d ", arr[i]);
    printf("\n");
}

size_t starttimer(){
    return clock();
}

size_t endtimer(){
    return clock();
}

void auswertung(size_t start, size_t end, int methode){
    float sekunden;

    sekunden = ((float)end - (float)start) / (float) CLOCKS_PER_SEC;
    if(methode == 0){
        printf("Insertion Sort: ");
    }
    else if(methode == 1){
        printf("Bubble Sort: ");
    }
    else if(methode == 2){
        printf("Selection Sort: ");
    }
    else{
        printf("Fehler");
    }
    printf("%.2fs", sekunden);
}

void BubbleSort(int arr[]){
    int zwischenspeicher;

    printf("\n");
    for (int i = 0; i < SIZE; ++i) {
        for (int j = 0; j < SIZE-1; ++j) {
            if(arr[j] > arr[j+1]){
                zwischenspeicher = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = zwischenspeicher;
            }
        }
    }
}

void SelectionSort(int arr[]) {

    int maxwert;
    int j;
    int maxstelle = 0;
    int zwischenspeicher;
    int sortierstelle = SIZE-1;

    printf("\n");

    for (int i = 0; i < SIZE; ++i) {
        maxwert = INT_MIN;
        for (int j = 0; j <= sortierstelle; ++j) {
            if (maxwert < arr[j]) {
                maxstelle = j;
                maxwert = arr[j];
            }
        }
        zwischenspeicher = arr[sortierstelle];
        arr[sortierstelle] = arr[maxstelle];
        arr[maxstelle] = zwischenspeicher;
        sortierstelle--;
    }
/*
    for (int i = 0; i < SIZE; ++i) {
        maxwert = INT_MIN;
        for (j = 0; j < sortierstelle; ++j) {
            if (maxwert < arr[j]) {
                maxstelle = j;
                maxwert = arr[j];
            }
        }
        zwischenspeicher = arr[sortierstelle];
        arr[sortierstelle] = arr[maxstelle];
        arr[maxstelle] = zwischenspeicher;
        sortierstelle--;
    }
    */
}
