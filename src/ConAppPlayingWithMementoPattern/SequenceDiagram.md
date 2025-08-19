sequenceDiagram
    participant Client
    participant Originator
    participant Caretaker
    participant Memento

    %% Save current state
    Client->>Originator: setState("State #1")
    Client->>Originator: CreateMemento()
    Originator-->>Client: m1: Memento
    Client->>Caretaker: save(m1)
    Caretaker->>Caretaker: store m1

    %% Undo / restore
    Client->>Caretaker: get last memento
    Caretaker-->>Client: m1
    Client->>Originator: SetMemento(m1)
    Originator->>Memento: GetState()
    Memento-->>Originator: state
    Originator->>Originator: restore state
