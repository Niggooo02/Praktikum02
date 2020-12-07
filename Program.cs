using System;

namespace Praktikum_02 {
    class Program {
        static void Main(string[] args) {
            int eingabe;
            int summeTeiler;        //Aufgabe c: Summe der Teiler
            int tausender, hunderter, zehner, einer;       //Aufgabe d, e: Speichern einzelne Ziffern der Eingabe (vier ausreichend, da nur Zahlen bis 9999 akzeptiert werden)
            int anzahlGerade = 0, anzahlUngerade = 0;        //Aufgabe d: Speichern die Anzahl an geraden und ungeraden Ziffern
            int ersteZiffer = 0, letzteZiffer = 0;        //Aufgabe e: Speichern erste und letzte Ziffer der eingegebenen Zahl
            Console.Write("Geben Sie eine Zahl größer gleich 10 und kleiner als 10.000 ein: ");
            eingabe = Convert.ToInt32(Console.ReadLine());
            while (eingabe < 10 || eingabe >= 10000) {  //Eingabe wiederholen, wenn Zahl kleiner zehn oder größer gleich 10.000
                Console.WriteLine("Ungültige Eingabe, bitte wiederholen");
                Console.WriteLine("");
                Console.Write("Geben Sie eine Zahl größer gleich 10 und kleiner als 10.000 ein: ");
                eingabe = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("");
            //ab hier ist eingabe immer größer gleich 10 und kleiner 10.000

            //Aufgabe b
            if (eingabe < 1000) {    //10 <= eingabe < 1000
                Console.WriteLine($"50er kleiner als {eingabe}: ");
                for (int i = 50; i < eingabe; i += 50) { //mit jeder Iteration erhöht sich i um 50; bricht ab, sobald i größer als die eingabe oder gleich ist
                    Console.WriteLine(i);   //i ist immer ein Vielfaches von 50 und wird ausgegeben, solange i kleiner als die eingegebene Zahl ist
                }
                if(eingabe <= 50) {
                    Console.WriteLine("Keine");     //Zahlen bis einschließlich 50 haben keine 50er-Teiler, deswegen wird die for-Schleife (Z. 25) sofort abgebrochen
                }
            } else {    //1000 <= eingabe < 10.000
                Console.WriteLine($"500er kleiner als {eingabe}: ");
                for (int i = 500; i < eingabe; i += 500) { //mit jeder Iteration erhöht sich i um 500; bricht ab, sobald i größer oder gleich der eingegebenen Zahl ist
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("");

            //Aufgabe c
            Console.WriteLine($"Teiler von {eingabe}: ");
            summeTeiler = 0;
            for (int i = 2; i < eingabe; i++) { //zählt alle Zahlen zwischen 2 und der eingegebenen Zahl durch | Start bei i = 2, da die eins in der Aufgabenstellung ausgenommen wurde
                if (eingabe % i == 0) {      //Prüfung, ob eingabe durch i ganzzahlig teilbar ist
                    summeTeiler += i;
                    Console.WriteLine(i);   //Wenn ganzzahlig teilbar: i ausgeben
                }
            }
            if (summeTeiler == 0) {  //Summe aller Teiler = 0 -> es gibt keine Teiler -> Primzahl
                Console.WriteLine($"{eingabe} ist eine Primzahl.");
            } else {    //Wenn eingabe keine Primzahl ist
                Console.WriteLine($"Die Summe aller echten Teiler von 3587 ist {summeTeiler}.");
            }
            Console.WriteLine("");

            //Aufgabe d
            hunderter = 0;
            tausender = 0;  //evtl gibt es keine Hunderter oder Tausender -> standardmäßig auf 0

            einer = eingabe % 10;
            zehner = (eingabe / 10) % 10;
            //evtl gibt es keine Hunderter oder Tausender
            if (eingabe >= 100) {
                hunderter = (eingabe / 100) % 10;
            }
            if (eingabe >= 1000) {
                tausender = (eingabe / 1000) % 10;
            }

            if (einer % 2 == 0) {    //Ganzzahlig durch zwei teilbar? Wenn ja -> gerade, nein -> ungerade
                anzahlGerade++;
            } else {
                anzahlUngerade++;
            }

            if (zehner % 2 == 0) {    //Ganzzahlig durch zwei teilbar? Wenn ja -> gerade, nein -> ungerade
                anzahlGerade++;
            } else {
                anzahlUngerade++;
            }

            if (eingabe >= 100) {       //Hat die Zahl eine Ziffer beim Hunderter?
                if (hunderter % 2 == 0) {    //Ganzzahlig durch zwei teilbar? Wenn ja -> gerade, nein -> ungerade
                    anzahlGerade++;
                } else {
                    anzahlUngerade++;
                }
            }

            if (eingabe >= 1000) {      //Hat die Zahl eine Ziffer beim Tausender?
                if (tausender % 2 == 0) {    //Ganzzahlig durch zwei teilbar? Wenn ja -> gerade, nein -> ungerade
                    anzahlGerade++;
                } else {
                    anzahlUngerade++;
                }
            }

            Console.WriteLine($"Die Zahl {eingabe} hat {anzahlGerade} gerade und {anzahlUngerade} ungerade Ziffern.");
            Console.WriteLine("");

            //Aufgabe e
            letzteZiffer = einer;       //letzte Ziffer ist immer der Einer

            //Erste Ziffer ermitteln
            if (eingabe >= 1000) {
                ersteZiffer = tausender;
            } else if (eingabe >= 100) {
                ersteZiffer = hunderter;
            } else {
                ersteZiffer = zehner;
            }
            Console.WriteLine($"Das Produkt der ersten und der letzten Ziffer von {eingabe} ist {ersteZiffer} * {letzteZiffer} = {ersteZiffer * letzteZiffer}.");
        }
    }
}