# Hold Until Dawn — Learning Profile

This file tracks what the developer already understands and what still needs explaining, so future sessions don't re-ask what's already known or skip explanations that are actually needed. **Update this file incrementally as sessions progress — do not overwrite it from scratch.**

## Current Level (as of project start)

- Comfortable with basic C# syntax.
- Has **not yet** built a state machine, and has **not yet** worked with the Animator for 3/4-perspective directional sprites.
- Broader context: learning Unity/game dev from scratch across multiple personal projects, working toward a professional-quality portfolio. Has prior hands-on experience (from other projects) with camera-relative movement, jump mechanics, third-person camera collision, and a basic player attack/combat system — so general MonoBehaviour/component fundamentals are not brand new, even though this project's specific systems (2D, top-down, Animator-driven) are.

## Working Preferences

- Prefers **proven Unity ecosystem solutions over building everything from scratch**.
- Wants **every new package, pattern, or system explained before or as it's used** — not just handed working code to copy.
- Top priority (explicitly stated): keep the project **well organized with clear folder structure** from the start, not something patched together and cleaned up later.

## Concepts Introduced in Planning (pending hands-on explanation when first implemented)

These appear in [technical-architecture.md](technical-architecture.md) and will need a real explanation the first time each is actually built, not just referenced:

- ScriptableObjects as data containers (what they are, why they're not just "another script").
- Event-driven communication between systems (why systems shouldn't hold direct references to each other).
- 2D Pixel Perfect Camera setup and why pixel art needs it.
- Transparency Sort Axis / Y-sort (why a 2D top-down game needs custom sprite sorting to fake depth).
- Animator 2D Simple Directional Blend Trees (8-directional movement) — **built 2026-08-24, but hand-authored directly in the asset files rather than walked through in the Animator/Animation windows** (Marcos explicitly chose the "just do it in the files" option over the guided-Editor-UI option when asked). So the *implementation* exists but the *real explanation* this profile calls for still hasn't happened — still owed to him whenever it's relevant (e.g. before he builds the next one for an enemy/NPC).
- Animator Override Controllers (weapon switching without duplicating the state machine).
- New Input System action maps (and how the same actions later map to on-screen mobile controls).
- Coroutines (used by the night wave spawner).
- Object pooling (why enemies/projectiles shouldn't be instantiated/destroyed every time).
- State machines (for enemy AI and player combat states).
- Weighted random loot tables (the weighted-sum-and-roll algorithm).

## Notes for Future Sessions

- This is the developer's first 2D top-down project — most prior experience across other projects has been 3D/third-person, so don't assume 2D-specific concepts (sprite sorting, pixel-perfect cameras, 2D physics/colliders) carry over automatically.
- Follow the golden rule from the architect skill: never suggest cutting the game's scope. The deferred features in [game-design-document.md](game-design-document.md) (heroes, construction, farmer, dungeon, other villages, multiplayer) are sequenced in [roadmap.md](roadmap.md), not abandoned — don't re-raise "maybe simplify further" as a suggestion.
