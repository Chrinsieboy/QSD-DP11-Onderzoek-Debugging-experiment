# DebuggingExperiment - Order Processing System (Versie B)

Dit project is een C# .NET 10 console-applicatie, speciaal opgezet als gecontroleerd experiment voor SE-studenten voor het onderzoeken van foutopsporing (debugging). 

Het doel is om te meten hoe snel en accuraat studenten een ingebouwde logische fout (bug) kunnen vinden in onbekende code, met behulp van ofwel **logging** of een **interactieve debugger**.

---

## Applicatie Overzicht

De applicatie berekent de kostprijs van een samengesteld product (Bill of Materials).
Omdat producten (zoals wielen) meerdere keren in een assemblage (Tree structuur) kunnen voorkomen, wordt er een `Dictionary<string, decimal>` gebruikt als cache (Hashmap). Als een onderdeel al berekend is, wordt de prijs uit de cache gehaald om rekenkracht te besparen.

---

## Verwacht vs. Actueel Resultaat

* **Assemblage:**
  - Sportwagen X (Chassis) - € 5000,00
  - 4 x Wiel Set. 
    *(Een Wiel Set kost € 10 voor assemblage + € 50 voor de Band + € 40 voor de Velg = € 100,00 per set).*

* **Verwachte totaalprijs:**  
  `€ 5000 + (4 * € 100)` = **€ 5400,00**

* **Actuele uitkomst bij uitvoering (Door de bug!):**  
  **€ 5130,00** *(RESULTAAT: FOUT)*

---

## Regels voor Deelnemers aan het Experiment

* **Groep A (Logging):** Mogen uitsluitend `Console.WriteLine` / log-statements toevoegen (bijv. om te zien wanneer de loop stopt). Het gebruik van IDE breakpoints is **niet** toegestaan.
* **Groep B (Debugger):** Mogen uitsluitend breakpoints en step-execution (Step Over/Into) gebruiken. Het toevoegen van nieuwe print/log-statements is **niet** toegestaan.

---

## De Oorzaak van de Bug (Root Cause)

In `PriceCalculator.cs` zit een typische caching fout. 
De recursieve functie berekent het totaalbedrag (inclusief sub-items) in de variabele `totalCost`. Bij het wegschrijven naar de dictionary-cache gaat het echter mis:

```csharp
// FOUT: De kale basisprijs (€ 10) wordt opgeslagen in plaats van de berekende totalCost (€ 100)!
_priceCache[component.Name] = component.BasePrice; 
```

**Wat er gebeurt tijdens uitvoering:**
1. **Wiel 1:** Staat niet in cache. Wordt keurig berekend naar `100`. Resultaat = 100.
2. **De bug slaat toe:** Hij slaat de `BasePrice` op in de cache: `[Wiel Set] = 10`.
3. **Wiel 2, 3 en 4:** Staan in de cache! Het programma haalt vrolijk `10` uit de dictionary in plaats van `100`.
4. Het totaal wordt daardoor: `5000 + 100 + 10 + 10 + 10 = 5130`.

**Fix:** Verander de foutieve regel naar `_priceCache[component.Name] = totalCost;`.