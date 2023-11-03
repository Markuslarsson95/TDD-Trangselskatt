# Trängselskatt i Gbg

Trängselskatt tas ut under fastställda tider för fordon som kör in
Göteborgs centrum. Under de timmar då trängselskatt tas ut,
fordon registreras automatiskt på betalstationer.

# Din uppgift

Skriv ett program som beräknar kostnaden för en given uppsättning kommaseparerade
datum och tider då en bil passerar genom betalstationer under en dag.
Baserat på detta ska den skriva ut den totala kostnaden till terminalen.

# TDD funkar på så sätt att du måste stegvis hitta lösningen och skriva tester till problem som växer i komplexitet med varje kommande funktionalitet eller krav.

------------------------------------------------------------------------------------------------

STEG/KRAV 1. Implementera funktionen "RäknaTotalBelopp" som tar en sträng som innehåller datum 
och tid och skriver ut rätt belopp för trängselavgift till terminalen baserat på tabellen nedan:

   |   Interval  | Belopp |
   |    :---:    |   ---: |
   | 06:00–06:29 |   8 kr |
   | 06:30–06:59 |  13 kr |
   | 07:00–07:59 |  18 kr |
   | 08:00–08:29 |  13 kr |
   | 08:30–14:59 |   8 kr |
   | 15:00–15:29 |  13 kr |
   | 15:30–16:59 |  18 kr |
   | 17:00–17:59 |  13 kr |
   | 18:00–18:29 |   8 kr |
   | 18:30–05:59 |   0 kr |

   Exempel:   
   ```csharp
   SkattKalkylator.RäknaTotalBelopp("2023-05-31 17:45");
   // skriver ut "Total avgiften är 13 kr" till terminalen
   ```
------------------------------------------------------------------------------------------------

STEG/KRAV 2. Utöka funktionen så att den kan ta flera, kommaseparerade datumtider
och skriv ut det totala beloppet (summan av varje betalstationsavgift).

   Exempel:   
   ```csharp
   SkattKalkylator.RäknaTotalBelopp("2023-05-31 08:00, 2023-05-31 12:00, 2023-05-31 12:45, 2023-05-31 17:45");
   // skriver ut "Total avgiften är 42 kr" till terminalen
   ```
------------------------------------------------------------------------------------------------

STEG/KRAV 3. Maxbeloppet per dag är 60 kr.

   Exempel:   
   ```csharp
   SkattKalkylator.RäknaTotalBelopp("2023-05-31 07:00, 2023-05-31 07:10, 2023-05-31 07:20, 2023-05-31 07:30");
   // skriver ut "Total avgiften är 60 kr" till terminalen
   ```
------------------------------------------------------------------------------------------------
   
STEG/KRAV 4. Ingen trängselskatt tas ut på lördagar, söndagar eller under juli månad.

   Exempel:   
   ```csharp
   SkattKalkylator.RäknaTotalBelopp("2023-06-03"); // (Lördag) skriver ut "Total avgiften är 0 kr" till terminalen
   SkattKalkylator.RäknaTotalBelopp("2023-06-04"); // (Söndag) skriver ut "Total avgiften är 0 kr" till terminalen
   SkattKalkylator.RäknaTotalBelopp("2023-07-01"); // (Juli) skriver ut "Total avgiften är 0 kr" till terminalen
   ```
------------------------------------------------------------------------------------------------
   
STEG/KRAV 5. En bil som passerar flera betalstationer inom 60 minuter debiteras endast en gång.
Det belopp som i så fall ska betalas är den högsta avgiften bland passagerna.

   Exempel:   
   ```csharp
   SkattKalkylator.RäknaTotalBelopp("2023-05-31 06:20, 2023-05-31 06:45, 2023-05-31 07:10");
   // per pass: 8 kr, 13 kr, 18 kr
   // skriver ut "Total avgiften är 18 kr" till terminalen
   ```
