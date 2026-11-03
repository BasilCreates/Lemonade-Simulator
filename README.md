# Lemonade-Simulator
Lemonade Simulator Mini-Game, I built it just to iron out my fundamentals some more. 3-week timeline, lets get this done!


The project explores how independent systems can work together to manage customer interactions, queue progression, inventory requirements, and order processing.

Key Technical Implementations:

Customer Queue Management: Uses C# queues and object pooling to manage customer lifecycles, reduce unnecessary instantiation, and maintain queue positioning as customers arrive and leave.

Customer State Management: Implements state-based customer behaviour to control transitions between waiting, approaching, ordering, and leaving.

Inventory Validation: Uses requirement-based checks to verify ingredient availability before processing transactions, identifying and reporting multiple missing ingredients rather than failing on the first unavailable item.

Event-Driven Communication: Uses C# events to communicate gameplay outcomes between systems, reducing direct dependencies between components.

Gameplay Flow Management: Coordinates order completion, customer progression, countdown-based round limits, and scene transitions.

Engineering Focus

The primary goal is to explore modular gameplay architecture, clear separation of responsibilities, and reliable communication between interconnected systems. The project emphasizes solving practical gameplay problems through maintainable C# implementations rather than relying on monolithic scripts.
