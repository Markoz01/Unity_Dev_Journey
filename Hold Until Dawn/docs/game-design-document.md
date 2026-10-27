# Hold Until Dawn — Game Design Document

## Elevator Pitch

A lone defender stands between a small medieval village and the horde that comes for it every night. By day, the village is quiet enough to visit the blacksmith and the scattered trainers who can shape who you become; by night, you are the only thing standing between the village and ruin.

## Genre

Single-player, action-RPG hybrid with a horde-defense night phase. Third-person-adjacent top-down perspective, real-time combat, RPG-style character progression.

## Core Loop

1. **Day phase** — the village is safe. The player travels between fixed points of interest to prepare for the coming night:
   - **The Blacksmith** — upgrade and improve equipment.
   - **Class trainer locations** — visit specific places to grow specific character paths (see Character Progression). Visiting is optional and can be mixed; nothing locks the player into a single path by force.
2. **Night phase** — a horde of enemies converges on the village. The player fights them directly, in real time, with no allies and no built defenses to lean on. Surviving until dawn ends the night and returns to the day phase.
3. Loot gathered at night (gear, gold, experience) is what fuels day-phase progression, closing the loop.

## World

- A single village and its immediate surroundings — deliberately small and contained for a first project.
- **Not planned for v1, but intentionally not discarded:** a nearby dungeon to explore, and the ability to travel to other villages. These are logical extensions of the same world and are reflected as later phases in [roadmap.md](roadmap.md), not cut from the vision.

## Tone & Setting

- Dark medieval fantasy. Tense, threatened, low-hope-but-not-hopeless — the atmosphere the title *Hold Until Dawn* implies.
- Narrative is minimal for v1 (no dialogue trees or story branches planned yet) but the setting should support later lore: why the horde comes, what the village is protecting, what the trainers represent.

## Core Mechanics

### Combat
- Real-time, both **melee and ranged**, with multiple distinct weapons rather than a single fixed moveset.
- The player is the only combatant during night phase — no recruited allies, no automated defenses (these ideas exist but are deferred; see below).

### Character Progression
- **Gear:** the Blacksmith improves/upgrades the player's equipment using resources gathered at night.
- **Class paths / build identity**, unlocked by visiting distinct locations rather than a single generic skill tree screen:
  - A **chapel** grows paladin-oriented aptitudes.
  - A **grove**, home to an archery trainer, grows ranged/bow aptitudes.
  - A **cult** teaches demoniac magic.
  - (Additional trainer locations are expected to be added over time — the system should be built to support more than three.)
- The player is not forced into a single class; visiting multiple locations should be a valid way to build a hybrid character, since nothing in the concept restricts it to one path.

### Loot
- Enemies drop **weapons, armor, gold, and experience**. These are the only resources feeding the day-phase progression systems (Blacksmith upgrades, presumably level-ups from experience).

## Explicitly Out of Scope for v1 (deferred, not cancelled)

These were part of early brainstorming and were deliberately cut back to keep the first build learnable, **not because they are bad ideas** — they are preserved here so they aren't lost:

- Recruiting and paying visiting heroes to help defend the village.
- A farmer or other non-combat NPC role joining the village.
- Building defenses during the day (e.g., turrets).

If any of these return, they belong in a later roadmap phase, expanding the same loop rather than replacing it.

## Camera & Art Direction

- **2D pixel art**, top-down camera.
- Characters and objects use a **3/4 perspective with visible volume/shading** (not flat top-down) — reference points: *Stardew Valley*, *Eastward*, *Enter the Gungeon*.
- Depth is handled through Y-axis sprite sorting so overlapping sprites read correctly despite being 2D (see [technical-architecture.md](technical-architecture.md)).

## Platform & Scope

- **Target platforms:** PC and mobile.
- **Multiplayer:** none for v1. Multiplayer (co-op or otherwise) is explicitly a **future-project** idea, not a goal for this game — the architecture should stay simple and not be bent out of shape trying to future-proof for it.
- **Budget:** free/open-source tools preferred; paid tools are acceptable if clearly justified by a real gain.

## Long-Term Vision (preserved, sequenced — not reduced)

Hold Until Dawn's full ambition, to be realized in later phases:
- Hero recruitment and a pay-to-stay economy.
- Village construction/defenses (e.g., turrets).
- A farmer or production-oriented NPC role.
- A nearby dungeon to explore for extra loot/progression.
- Traveling between villages.

See [roadmap.md](roadmap.md) for how these are sequenced.
