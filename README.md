# Fragments of Escape 🕯️

**Unity 6000.3.10f1 · C#**

Explore, piece together clues and find a way out. A Unity horror project combining puzzle interactions, progression and tense encounters.

[Portfolio](https://github.com/ArushiNaik) · [Browse source](https://github.com/ArushiNaik/Fragments-of-Escape)

## What to explore

- Exploration and object interaction.
- Key fragments, lock puzzles and inventory-related systems.
- Health, pause, game-over and win states.
- Boss-fight scripts and scene progression.

## A guide to the code

- `Assets/Scenes/MainMenu.unity` — menu entry point
- `Assets/Scenes/Game.unity` — game scene
- `Assets/PlayerInteractor.cs` — interaction handling
- `Assets/LastPuzzle` — key puzzle systems
- `Assets/Scenes/BossFight` — combat and final progression

## Run locally

Clone the repository and add its root in Unity Hub. Install **Unity 6000.3.10f1**, matching `ProjectSettings/ProjectVersion.txt`, then let packages and assets import.

Open `Assets/Scenes/MainMenu.unity` and press Play. Keep the checked-in package configuration when opening the project rather than upgrading the editor automatically.

### Controls

Review `Assets/GameInputActions.inputactions` and `Assets/InputSystem_Actions.inputactions` for action mappings.

## Project notes

This README describes the checked-in game project. Editor import and gameplay were not retested during the documentation update. Third-party assets, packages and sample content retain their original attribution and licensing; inclusion does not imply original authorship of every asset.

## Context

A project in [Arushi Naik’s portfolio](https://github.com/ArushiNaik).
