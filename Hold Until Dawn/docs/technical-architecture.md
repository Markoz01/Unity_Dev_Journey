# Hold Until Dawn — Technical Architecture

This document translates [game-design-document.md](game-design-document.md) into technical decisions. It assumes a beginner-to-intermediate Unity/C# developer (see [learning-profile.md](learning-profile.md)) and prioritizes proven Unity ecosystem solutions over building everything from scratch — every new package or pattern introduced here is explained, not just prescribed.

## Engine & Render Pipeline

- **Unity 6**, **Universal Render Pipeline (URP)** with the **2D Renderer**.
- **2D Pixel Perfect** package (`com.unity.2d.pixel-perfect`) — a single camera component that keeps pixel art crisp and stable across resolutions instead of hand-rolling resolution/scaling math. Official docs: [2D Pixel Perfect Camera](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@5.0/manual/index.html).
- Sprite import settings: consistent **Pixels Per Unit** across all sprites, **Filter Mode = Point (no filter)**, so pixel art doesn't blur.

## Depth & Sprite Sorting (3/4 top-down look)

The GDD calls for characters with volume, not flat top-down sprites. This is a rendering/sorting decision, not an art-only one:

- Set **Edit > Project Settings > Graphics > Transparency Sort Mode = Custom Axis**, with **Transparency Sort Axis = (0, 1, 0)**.
- Every sprite's **pivot** should sit at the character/object's **feet** (bottom of the sprite), not its center.
- With this setup, Unity sorts sprites by their Y position in the world: things "lower" on screen render in front of things "higher up," which is exactly how a 3/4 top-down game (Stardew Valley-style) fakes depth with 2D sprites.
- Reference: [Unity Manual — 2D Renderer sorting](https://docs.unity3d.com/6000.2/Documentation/Manual/2d-renderer-sorting.html), [How do I do sprite sorting correctly for a top-down 2D RPG? (Unity Discussions)](https://discussions.unity.com/t/how-do-i-do-sprite-sorting-correctly-for-a-top-down-2d-rpg/814833).

## Input

- **Unity Input System** (the modern, action-based package — not the legacy Input Manager), because the project needs to support **PC and mobile** from the same action maps.
- One **Gameplay** action map shared across platforms; on mobile, the **On-Screen Stick** and **On-Screen Button** components feed the same actions a keyboard/gamepad would, so gameplay code never needs to know which platform it's running on.
- Reference: [Unity New Input System: Mobile Inputs](https://ryanjmccoach.medium.com/unity-new-input-system-mobile-inputs-79984dd35283).

## Animation

- **Animator with 2D Simple Directional Blend Trees** for 8-directional movement: two parameters (e.g. `MoveX`, `MoveY`, plus `LastX`/`LastY` to keep facing direction while idle) drive the blend tree instead of maintaining a separate state per direction.
- **Animator Override Controllers** for weapon switching: one base Animator Controller defines the state machine (idle/walk/attack/etc.), and a lightweight override asset swaps just the attack clips per weapon. This avoids duplicating the whole state machine for every weapon.
- Reference: [Top-down movement and attack game mechanics in Unity](https://pavcreations.com/top-down-movement-and-attack-game-mechanics-in-unity/).

## Core Architecture Pattern: ScriptableObject-driven data + event-based communication

Given the beginner level and the preference for guided, explained systems, the project follows Unity's officially recommended pattern for this scale of game:

- **Data lives in ScriptableObjects**, not hardcoded in scripts: weapon stats, enemy stats, loot tables, skill/class definitions are all assets a designer (future-you) can tweak in the Inspector without touching code.
- **Systems avoid hard references to each other.** Instead of the combat script directly calling the UI or the loot system, systems communicate through shared events/callbacks (e.g., a `Health` component fires an `OnDeath` event; whoever cares — loot, XP, UI — subscribes to it). This keeps systems swappable and testable in isolation.
- This is the same pattern Unity documents in [Create modular game architecture with ScriptableObjects (Unity 6)](https://unity.com/resources/create-modular-game-architecture-scriptableobjects-unity-6) and [Separate Game Data and Logic with ScriptableObjects](https://unity.com/how-to/separate-game-data-logic-scriptable-objects).

### Why this over alternatives
- **ECS/DOTS** is unnecessary at this world scale (one small village) and has a steep learning curve — not a good fit for a first project.
- **Pure inheritance-heavy OOP** (e.g., a deep `Enemy` class hierarchy) tends to become rigid as more enemy/weapon variety is added; composition + ScriptableObject data scales better and is easier to explain incrementally.

## System Breakdown

| System | Responsibility | Notes |
|---|---|---|
| `PlayerController` | Reads Input System actions, drives movement | Plain component, no game logic beyond movement |
| `Health` (shared) | HP, damage, death event | Used by both player and enemies — one component, not duplicated logic |
| `CombatSystem` | Melee + ranged attacks, weapon switching | Reads weapon data from a `WeaponData` ScriptableObject; triggers Animator Override per weapon |
| `DayNightCycleManager` | Tracks current phase (Day/Night), raises phase-change events | Drives when the spawner is active and when trainer locations are enterable |
| `WaveSpawner` (night only) | Spawns the horde in waves using coroutines | Modular "wave" data (count, enemy types, timing) as ScriptableObjects |
| `EnemyAI` | Basic state machine (idle/chase/attack) per enemy | Object-pooled, not instantiated/destroyed per spawn |
| `LootSystem` | Weighted random drop table on enemy death | `LootTable` ScriptableObject holds weighted entries (weapon/armor/gold/exp); subscribes to `Health.OnDeath` |
| `ProgressionSystem` | XP, leveling, gear upgrades via Blacksmith | Blacksmith reads player currency/materials, applies `WeaponData`/`ArmorData` upgrades |
| `ClassPathSystem` | Chapel (paladin) / Grove (archery) / Cult (dark magic) trainers | Each trainer location grants stat modifiers or unlocks from a `ClassPathData` ScriptableObject; player can visit more than one — no hard class lock |

## Coding Practices

- Favor **composition over inheritance**; not everything needs to be a `MonoBehaviour` — pure data/logic classes (e.g., a `LootRoll` calculator) don't need the Unity lifecycle.
- **Minimize the number of active `Update()` methods.** Prefer a small number of managers driving logic (or event-driven code) over dozens of scripts each polling every frame.
- **Object pooling** for enemies and projectiles — horde-defense spawns/despawns constantly, and pooling avoids garbage-collection spikes.
- **State machines** for enemy AI and player combat states rather than sprawling `if`/`else` chains.
- Reference: [Unity Manual — Programming best practices](https://docs.unity3d.com/6000.3/Documentation/Manual/programming-best-practices.html), [unity-clean-code guide](https://github.com/sampaiodias/unity-clean-code).

## Folder Structure & Naming

The project currently has `Scripts/`, `Scenes/`, `Settings/` directly under `Assets/`. The recommended structure (to adopt as the first technical task, see [roadmap.md](roadmap.md) Phase 0) organizes by **feature**, which scales better than organizing purely by file type once the number of systems grows:

```
Assets/
  _Project/
    Art/
      Characters/
      Environment/
      UI/
    Audio/
    Prefabs/
      Characters/
      Enemies/
      VFX/
    Scenes/
    Scripts/
      Player/
      Enemies/
      Combat/
      Progression/
      Loot/
      Core/          (managers: DayNightCycleManager, GameManager, etc.)
      UI/
    Settings/
```

- No spaces in folder/file names (Unity CLI tooling can choke on them) — use `PascalCase`.
- One asset type per folder where practical (don't mix `.cs` and `.prefab` in the same folder).
- Keep a clear separation between Art, Scripts, Prefabs, Scenes, Audio — this is the single most agreed-upon piece of advice across Unity's own guidance and community style guides.
- Reference: [Unity — Best practices for organizing your project](https://unity.com/how-to/organizing-your-project), [Unity-Style-Guide (GitHub)](https://github.com/justinwasilenko/Unity-Style-Guide).

## Multiplayer (explicitly not implemented)

Single-player only for this project (multiplayer is a goal for a *future* project, not this one). No networking package, no netcode abstraction layer, and no architectural gymnastics to "leave room" for it — keeping the systems above cleanly separated (event-driven, data-driven) already means a future project could reuse the pattern without Hold Until Dawn itself carrying that complexity now.

## Tooling & Budget

- **Unity** — free.
- **Aseprite** — pixel art tool (already part of the user's toolkit); paid but one-time and industry-standard for this exact art style, easily justified.
- All architecture decisions above use **built-in Unity packages** (Input System, 2D Pixel Perfect, Animator) — no paid asset store dependency is required to build v1.
