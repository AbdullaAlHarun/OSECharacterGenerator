# OSE Character Generator

Console-based character generator for the Old-School Essentials (OSE).


---

##  Overview

This application generates a complete Level 1 OSE character using a simplified ruleset.

The program:
- Rolls ability scores (3d6 in order)
- Applies reroll rules for low averages
- Determines eligible character classes
- Calculates ability modifiers
- Rolls hit points
- Displays the finished character

---

##  Features

- Ability score generation (3–18 range)
- Reroll if average ≤ 8
- Class eligibility based on highest/second-highest prime requisite
- Ability score modifier calculation
- Hit point calculation with Constitution modifier
- Minimum HP rule (minimum 1)
- XP required for level 2 displayed
- Input validation for menu choices and Y/N responses

---

## OOP Principles Demonstrated

### Encapsulation
- Private fields with public properties
- Validation for ability scores (3–18)
- Validation for character name
- Minimum hit point enforcement

### Inheritance
- Abstract base class: `CharacterClass`
- Derived classes:
    - Cleric
    - Fighter
    - MagicUser
    - Thief

### Polymorphism
- Derived classes override base class properties
- Base class references used to interact with class objects

---

##  Technologies Used

- C#
- .NET 8
- Console Application
- Git for version control

---

##  How to Run

1. Open the solution in Rider or Visual Studio.
2. Build the project.
3. Run the console application.
4. Follow on-screen instructions.

---


##  AI Usage Disclosure

AI assistance (ChatGPT) was used to review and validate the class eligibility algorithm,
specifically the implementation of the “top-two distinct ability score” selection logic
used to determine valid character classes based on prime requisites.

This was done to ensure correct handling of edge cases such as duplicate highest values,
tie situations, and compliance with the assignment specification.
---


##  References

- Old-School Essentials Basic Rules v1.4 – Necrotic Gnome
- OSE System Reference Document (SRD)
- - Microsoft Learn – C# Documentation  
    https://learn.microsoft.com/en-us/dotnet/csharp/
