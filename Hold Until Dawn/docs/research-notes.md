# Hold Until Dawn — Research Notes

Sources consulted while writing [technical-architecture.md](technical-architecture.md), and why each recommendation was chosen. Unity and its ecosystem move quickly — if a session comes back to this later and something looks outdated, re-check the official docs link first.

## ScriptableObject-driven architecture
- [Create modular game architecture with ScriptableObjects (Unity 6)](https://unity.com/resources/create-modular-game-architecture-scriptableobjects-unity-6) — official Unity guidance, current for Unity 6. Primary source for the "data in ScriptableObjects, systems decoupled via events" pattern used throughout the architecture doc.
- [Separate Game Data and Logic with ScriptableObjects](https://unity.com/how-to/separate-game-data-logic-scriptable-objects) — official, reinforces the same pattern with a simpler example.
- [Unity Architecture: Scriptable Object Pattern (Medium)](https://medium.com/@simon.nordon/unity-architecture-scriptable-object-pattern-0a6c25b2d741) — community perspective, cross-checked against the official docs above; consistent with them.
- Chosen over ECS/DOTS (too much complexity for a single small village at this learning stage) and over deep inheritance hierarchies (rigid as content grows).

## Folder structure & naming
- [Unity — Best practices for organizing your project](https://unity.com/how-to/organizing-your-project) — official, current.
- [Unity-Style-Guide (GitHub, justinwasilenko)](https://github.com/justinwasilenko/Unity-Style-Guide) — long-standing, widely cited community style guide; used to confirm the "no spaces, PascalCase, one file type per folder" conventions are still standard practice.
- Consensus across both: organize by feature over strict-by-type once a project grows past a handful of scripts, which fits a project planning multiple systems (combat, progression, loot, etc.) from the start.

## Pixel-perfect camera & sprite depth (3/4 top-down look)
- [Unity Manual — 2D Pixel Perfect Camera (URP, Unity 6)](https://docs.unity3d.com/6000.6/Documentation/Manual/urp/2d-pixelperfect-prep-sprites.html) — official, version-matched to Unity 6.
- [Unity Manual — 2D Renderer sorting](https://docs.unity3d.com/6000.2/Documentation/Manual/2d-renderer-sorting.html) — official; source for the Custom Axis (0,1,0) Transparency Sort Axis technique that fakes depth/volume with 2D sprites in a top-down game.
- [How do I do sprite sorting correctly for a top-down 2D RPG? (Unity Discussions)](https://discussions.unity.com/t/how-do-i-do-sprite-sorting-correctly-for-a-top-down-2d-rpg/814833) — community thread confirming pivot-at-feet + custom axis is the standard real-world approach, not just a manual example.

## Wave spawning & day/night cycle
- [Spawning Waves of Enemies in Unity (Medium)](https://micha-l-davis.medium.com/spawning-waves-of-enemies-in-unity-fc42caf6df56)
- [Implementing a Wave System for Enemy Spawning in Unity (Medium)](https://medium.com/@phiktional/implementing-a-wave-system-for-enemy-spawning-in-unity-ebf820e7a936)
- Both converge on the same shape: a coroutine-driven spawn manager with data describing each wave (count, enemy types, timing), which matches the ScriptableObject-driven approach used everywhere else in this project's architecture. No official Unity manual page covers this specifically — it's an established community pattern, cross-checked across two independent write-ups that agree.

## Class/skill progression
- [Building a Robust Skill Tree in Unity with Scriptable Objects (Wayline)](https://www.wayline.io/blog/unity-skill-tree-scriptable-objects) — describes a three-layer (data/logic/UI) architecture; the data layer (ScriptableObject-defined skills/unlocks) is directly applicable to the Chapel/Grove/Cult trainer locations.
- Cross-referenced against general ScriptableObject sources above — consistent pattern, no conflicts found.

## Loot tables
- [Unity — How to Create a Weighted Loot Table (Medium)](https://medium.com/@kshesho/unity-how-to-create-a-weighted-loot-table-3bcbf478eaf9)
- [The Weighted Random System Unity Trick... (Outscal)](https://outscal.com/blog/unity-weighted-random-system-loot-drops)
- Both describe the same weighted-sum-and-roll algorithm; standard enough that it's treated as settled, not experimental.

## Animation: 8-directional movement & weapon switching
- [Top-down Movement and Attack Game Mechanics in Unity (Pav Creations)](https://pavcreations.com/top-down-movement-and-attack-game-mechanics-in-unity/) — source for the 2D Simple Directional blend tree setup (`MoveX`/`MoveY` + last-direction parameters).
- Weapon switching via Animator Override Controllers is standard, official Unity functionality (not tied to a single blog source) — avoids duplicating the state machine per weapon.

## Mobile input
- [Unity New Input System: Mobile Inputs (Medium)](https://ryanjmccoach.medium.com/unity-new-input-system-mobile-inputs-79984dd35283) — On-Screen Stick/Button components mapped onto the same action maps used for PC input, so gameplay code stays platform-agnostic.

## C# / Unity coding practices
- [Unity Manual — Programming best practices (Unity 6)](https://docs.unity3d.com/6000.3/Documentation/Manual/programming-best-practices.html) — official, current for Unity 6.
- [unity-clean-code (GitHub, sampaiodias)](https://github.com/sampaiodias/unity-clean-code) — community guide, consistent with the official manual on composition-over-inheritance and minimizing `Update()` usage.
- Both converge on: avoid unnecessary `MonoBehaviour` inheritance for pure data/logic, minimize active `Update()` loops, use object pooling, use state machines for behavior — all reflected in the coding practices section of the architecture doc.

## A note on staleness
Most sources above are dated for Unity 6 specifically or are recent (2025–2026) community write-ups; nothing here relies on pre-Unity-6 APIs. The wave-spawner and loot-table patterns are community-sourced (no single official Unity manual page covers them end-to-end) but were cross-checked against at least two independent sources each before being written into the architecture doc.
