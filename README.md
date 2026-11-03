# Lemonade-Simulator
Lemonade Simulator Mini-Game, I built it just to iron out my systems architecture fundamentals some more. lets get this done!



The main goal of this project was to get hands-on experience building interconnected gameplay systems and understanding how to make them work together without having everything tightly interconnected and harder to maintain/scale overall. The main goal was to maintain code modularity and keep everything as loosely connected as possible to leave room for newer features.

Some of the systems I've been working on:

**Customer Queue System:** Managing customer order and positioning using C# queues, alongside object pooling to reuse customer NPCs instead of constantly instantiating new ones.

**Customer Behaviour:** Managing customer interactions through different states, including waiting, approaching, ordering, and leaving.

**Inventory System & Order Validation:** Checking ingredient requirements before processing orders, including identifying multiple missing ingredients instead of stopping at the first unavailable item.

**Event-Driven Decoupling:** Using C# events to notify other systems when certain gameplay events occur, keeping systems from relying too heavily on direct communication.

**Game Flow:** Handling order progression, countdown timers, game-over conditions, and scene transitions.

## How it all fits together

Solid arrows are direct method calls. Dotted arrows are C# events, where the sender doesn't know or care who's listening.

```mermaid
flowchart TD
    subgraph BUY["Buying supplies"]
        PINT["PlayerInteraction<br/>raycast + E key"] -->|"IInteractable"| SELL["Seller"]
        SELL --> SMENU["ShopMenuUI"]
        SMENU --> SITEM["ShopItemUI<br/>buy click"]
        SITEM -->|"BuyItem()"| PMONEY["PlayerMoney"]
        PMONEY -->|"AddItem()"| INV["PlayerInventory"]
    end

    subgraph LINE["Customer line"]
        SPAWN["CustomerSpawner<br/>C# Queue = the line"]
        POOL["CustomerPool<br/>Stack of reusable NPCs"]
        NPC["CustomerNPC<br/>state machine"]
        PANEL["CustomerNPCPanel<br/>order + missing items text"]
        SPAWN -->|"GetCustomer()"| POOL
        SPAWN -->|"Enqueue + spot in line"| NPC
        NPC -->|"order text"| PANEL
    end

    subgraph SERVE["Serving"]
        SHOPMGR["LemonadeShopManager<br/>coordinator"]
        ORDER["OrderManager<br/>validates + completes orders"]
        RECIPE["Lemonade<br/>recipe + price"]
        ORDER -->|"Requirements"| RECIPE
    end

    subgraph FLOW["Game flow"]
        REWARD["RewardTime"]
        SPEED["SpeedUpTime<br/>every 100 money"]
        TIMER["GameTimer"]
        SCENE["GameSceneManager<br/>singleton"]
        OVER(["Game over scene"])
        REWARD -->|"AddTime(20)"| TIMER
        SPEED -->|"SpeedUpTime()"| TIMER
        SCENE --> OVER
    end

    SHOPTRIG["ShopOpen<br/>trigger zone"] -.->|"PlayerEnteredShop / PlayerExitedShop"| SHOPMGR
    INV -.->|"OnInventoryChanged<br/>unlocks the shop trigger"| SHOPMGR
    SHOPMGR -->|"GetFirstCustomer() / UpdateSpotInLine()"| SPAWN
    SHOPMGR -->|"SetState(Approaching)"| NPC
    SHOPMGR -->|"SetActiveCustomer()"| ORDER

    ORDER -->|"HasEnoughItems() for every ingredient"| INV
    ORDER -->|"missing ingredients list"| PANEL
    ORDER -->|"RemoveItems()"| INV
    ORDER -->|"ReceivePayment()"| PMONEY
    ORDER -->|"SetState(Leaving)"| NPC

    NPC -.->|"FinishedLeaving"| SHOPMGR
    SHOPMGR -->|"DequeueCustomer()"| SPAWN
    SPAWN -->|"ReturnCustomer()"| POOL

    ORDER -.->|"OnOrderCompleted"| REWARD
    TIMER -.->|"OnTimerEnd"| SCENE
```

### Customer states

```mermaid
stateDiagram-v2
    [*] --> Waiting
    Waiting --> Approaching: manager calls them up
    Approaching --> Ordering: reaches the stand
    Ordering --> Ordering: missing ingredients, order rejected
    Ordering --> Leaving: order completed
    Leaving --> Waiting: back in the pool, ready for reuse
```

**What I'm focusing on**

Beyond getting the game working, I want to understand the reasoning behind how systems are structured, how they communicate, and how to keep code maintainable as a project grows.

This project has been a practical way to experiment with C#, OOP, system responsibilities, and solving the little problems that come with making different gameplay systems work together.


Key scripts to take a look at:
- OrderManager.cs
- CustomerNPC.cs
- CustomerPool.cs
- CustomerSpawner.cs
- ShopItemMenu.cs
- Ingredients.cs
