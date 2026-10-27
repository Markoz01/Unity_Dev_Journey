# Hold Until Dawn — Roadmap

Sequenced from the current empty project to the full vision in [game-design-document.md](game-design-document.md). Nothing in the long-term vision is dropped — the later phases exist specifically to carry it forward. Each phase assumes the previous one is playable, even if rough, before moving on.

## Phase 0 — Project Foundation
- Reorganize `Assets/` into the feature-based structure defined in [technical-architecture.md](technical-architecture.md) (`Assets/_Project/...`).
- Confirm URP 2D Renderer + 2D Pixel Perfect package are installed and configured.
- Set Transparency Sort Axis to Custom Axis (0, 1, 0) project-wide.
- Import a first placeholder pixel art character (any free/temp asset) to validate the pipeline end-to-end before committing real art time.

## Phase 1 — Movement & Camera
- Player top-down movement via the new Input System.
- 8-directional Animator blend tree (`MoveX`/`MoveY`, idle facing retained via `LastX`/`LastY`).
- Pixel Perfect Camera following the player.
- Validate Y-sort depth works with at least two overlapping sprites (player + a static prop).

## Phase 2 — Core Combat (melee only)
- One melee weapon, one attack animation, hitbox/damage dealing.
- Shared `Health` component (usable by player and enemies alike).
- One basic enemy with a simple chase-and-attack state machine.
- Player can die and the night can be "lost" — establishes the stakes loop even before it's polished.

## Phase 3 — Ranged Weapons & Weapon Switching
- Add a ranged weapon (projectile-based).
- Animator Override Controller setup so weapon switching doesn't require duplicating the state machine.
- `WeaponData` ScriptableObject established as the pattern for all future weapons.

## Phase 4 — Night Wave Spawner + Day/Night Cycle
- `DayNightCycleManager` driving explicit Day/Night phases.
- `WaveSpawner` using coroutines and pooled enemies, data-driven via ScriptableObject wave definitions.
- This is the first point where the core "hold the village until dawn" loop is actually playable, even with placeholder art and one enemy type.

## Phase 5 — Loot System
- `LootTable` ScriptableObject with weighted entries (weapon, armor, gold, experience).
- Enemies drop loot on death via the shared `Health.OnDeath` event — no combat/enemy code needs to know loot exists.

## Phase 6 — Progression: Blacksmith & Leveling
- Currency (gold) and materials collected at night feed a Blacksmith upgrade screen during the day.
- Experience feeds a basic leveling system (stat growth).

## Phase 7 — Class Paths (Chapel / Grove / Cult)
- `ClassPathData` ScriptableObject pattern for trainer locations.
- Implement the three initial locations from the GDD: Chapel (paladin), Grove (archery), Cult (dark magic).
- Confirm the system supports the player visiting more than one path without being hard-locked, and is easy to extend with a fourth/fifth location later.

## Phase 8 — Mobile Support
- On-Screen Stick + On-Screen Buttons wired into the same action maps used on PC.
- UI scaling/readability pass for touch and smaller screens.

## Phase 9 — Escalation & Polish
- Difficulty curve across nights (more/tougher enemies over time).
- Game feel pass: hit-stop, screen shake, SFX, particle feedback on hits/loot/level-up.
- First real (non-placeholder) art pass across characters and the village.

---

## Future Phases (long-term vision, deliberately not cut)

These were part of the original brainstorm and are preserved here rather than discarded, per the project's golden rule of never reducing scope:

- **Phase 10 — Village Construction & Defenses:** turrets and other buildable defenses during the day.
- **Phase 11 — Recruitable Heroes:** heroes visit the village and can be paid to stay and help defend it; introduces an economy trade-off (spend resources on gear vs. on allies).
- **Phase 12 — Farmer / Production NPC Role:** a non-combat NPC contributing resources over time.
- **Phase 13 — Nearby Dungeon:** a dedicated explorable space near the village for extra loot/progression, breaking from the single-contained-map scope of v1.
- **Phase 14 — Traveling Between Villages:** expands the world beyond a single village.
- **Phase 15 — Multiplayer (separate future project):** not planned for Hold Until Dawn itself, but the event-driven, data-driven architecture from Phase 0 onward is exactly the kind of foundation that would make a future multiplayer project easier, without this project needing to carry that complexity now.
