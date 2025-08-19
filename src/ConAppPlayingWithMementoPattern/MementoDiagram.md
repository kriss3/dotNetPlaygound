``` mermaid

class Memento {
    - state
    + GetState() any
    + SetState(value: any) void
}

class Caretaker {
    + memento: Memento
}

%% Relationships
Caretaker o-- Memento : holds
Originator ..> Memento : create / restore

%% Notes
note for Originator "return new Memento(state)"
note for Memento "state = m.GetState()"
