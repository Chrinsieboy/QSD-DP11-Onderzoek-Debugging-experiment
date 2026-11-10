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
