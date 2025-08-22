### Details

The Adapter design pattern converts the interface of a 
class into another interface clients expect. 
This design pattern lets classes work together that 
couldn‘t otherwise because of incompatible interfaces. 

### Participants

The classes and objects participating in this pattern include:

1. Target   (ChemicalCompound)
defines the domain-specific interface that Client uses.
2. Adapter   (Compound)
adapts the interface Adaptee to the Target interface.
3. Adaptee   (ChemicalDatabank)
defines an existing interface that needs adapting.
4. Client   (AdapterApp)
collaborates with objects conforming to the Target interface.

### Diagram
[Adapter Pattern Diagram]("./Notes/AdapterPatternDiagram.md")