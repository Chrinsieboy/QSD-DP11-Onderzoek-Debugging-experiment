# DebuggingExperiment - Order Processing System

Dit project is een C# .NET 10 console-applicatie, speciaal opgezet als gecontroleerd experiment voor SE-studenten (met kennis van leerjaar 1 en 2) voor het onderzoeken van foutopsporing (debugging). 

Het doel is om te meten hoe snel en accuraat studenten een ingebouwde logische fout (bug) kunnen vinden in onbekende code, met behulp van ofwel **logging** of een **interactieve debugger**.

---

## Applicatie Overzicht

De applicatie simuleert de berekening van een winkelmandje:
1. De code loopt door de lijst met items in de bestelling.
2. Items die **niet op voorraad** zijn, moeten genegeerd/overgeslagen worden.
3. Items die **wel op voorraad** zijn, worden opgeteld.
4. Als de totale bestelwaarde onder de € 50,00 blijft, wordt er € 5,00 verzendkosten gerekend.

---

## Verwacht vs. Actueel Resultaat

* **Bestelling:**
  - Toetsenbord (€ 30.00) - Op voorraad
  - Muismat (€ 10.00) - Niet op voorraad
  - Webcam (€ 45.00) - Op voorraad
  - USB Kabel (€ 5.00) - Op voorraad

* **Verwachte totaalprijs:**  
  `30 + 45 + 5` = **€ 80,00** (Geen verzendkosten want € 80 > € 50)

* **Actuele uitkomst bij uitvoering (Door de bug!):**  
  **€ 35,00** *(RESULTAAT: FOUT)*

---

## De Oorzaak van de Bug (Root Cause)

In `OrderProcessor.cs` (methode `CalculateTotal`) staat in de `foreach` loop een fout in de controle op voorraad:

```csharp
if (!item.InStock)
{
    break; // BUG: Stopt de hele loop! Moet 'continue;' zijn.
}
```

Omdat er een `break` staat in plaats van een `continue`, stopt de loop zodra de "Muismat" wordt verwerkt. De Webcam en USB Kabel worden nooit berekend. Hierdoor is het subtotaal slechts € 30,00. Omdat dit onder de € 50 is, komt er € 5 verzendkosten bij, wat leidt tot het (foutieve) eindbedrag van € 35,00.

---

## Regels voor deelnemers aan het experiment

* **groep a (logging):** mogen uitsluitend `console.writeline` / log-statements toevoegen (bijv. om te zien wanneer de loop stopt). Het gebruik van IDE breakpoints is **niet** toegestaan.
* **Groep B (Debugger):** Mogen uitsluitend breakpoints en step-execution (Step Over/Into) gebruiken. Het toevoegen van nieuwe print/log-statements is **niet** toegestaan.
