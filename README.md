# Fragments of Escape

A suspense-driven survival horror game built in Unity, where the player is trapped in a haunted environment and must find a way to escape while surviving escalating danger.

This project includes a mix of exploration, puzzle interaction, combat-avoidance mechanics, audio-driven atmosphere, and a full escape-game loop with win/lose states.

## Overview

Fragments of Escape is a Unity horror project focused on:

- atmospheric exploration
- interactive objects and puzzle progression
- survival / stealth-style tension
- environmental storytelling
- player death and game-over flow
- win-state progression after completing the escape objective

## Features

- First-person or third-person style exploration gameplay
- Horror ambience and layered sound design
- Input-driven interactions and menu flow
- Inventory, puzzle, and progression systems
- Pause menu and game-over/win screens
- Unity URP setup with Input System integration
- Scriptable, modular project structure for future expansion

## Repository Structure

```text
.
├── Assets/
│   ├── Animations/
│   ├── Audio/
│   ├── Scenes/
│   ├── ScriptsGame/
│   ├── Settings/
│   ├── Chords/
│   ├── HealthHeartSystem/
│   ├── Inventory System - Kinnly/
│   ├── PauseGame/
│   ├── Win/
│   └── ...
├── ProjectSettings/
├── Packages/
├── Build/
├── .gitignore
├── .gitattributes
├── .vsconfig
├── Fragments-of-Escape.slnx
├── Fragments of Escape.slnx
├── Assembly-CSharp.csproj
└── README.md
```

## Getting Started

### Requirements

- Unity Hub
- Unity 2022.3 LTS or newer
- Git installed for version control

### Run the project

1. Clone the repository:

   ```bash
   git clone https://github.com/ArushiNaik/Fragments-of-Escape.git
   ```

2. Open the project folder in Unity Hub.
3. Let Unity import the project and resolve packages.
4. Open the main scene from the `Assets/Scenes` folder.
5. Press Play to run the game.

## Controls

The project uses Unity's Input System configuration. You can review and customize controls in the input files under:

- `Assets/GameInputActions.inputactions`
- `Assets/InputSystem_Actions.inputactions`

If you want to update the movement, interaction, pause, or gameplay mappings, use the Unity Input System editor.

## Gameplay Notes

This repository appears to contain a horror escape game with a progression loop built around:

- exploring the environment
- discovering key items or clues
- interacting with objects or puzzle systems
- avoiding danger or surviving threatening encounters
- escaping before the game ends

## Development Notes

This project is a Unity-based game prototype/production project and is structured for iterative game development. You can extend it by:

- adding custom scenes and levels
- wiring new puzzle logic in the `Assets/ScriptsGame` folder
- modifying UI flows for game over, pause, or win states
- replacing or expanding sound and visual assets

## Assets and Tools Used

The project includes support for:

- Unity URP
- Unity Input System
- TextMeshPro
- 2D/2.5D game asset workflows
- custom C# gameplay scripts

## License

This repository does not currently include an explicit license file. If you plan to distribute or publish the project, consider adding an appropriate open-source or commercial licensing file.

## Contributing

Contributions are welcome if you want to improve gameplay, polish, bug fixes, or add new systems. To contribute:

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Open a pull request

## Author

Project repository: ArushiNaik/Fragments-of-Escape

## Screenshots / Media

The repository contains several game assets, audio files, and UI elements, including:

- `Assets/Horror Ambience.mp3`
- `Assets/background.mp3`
- `Assets/QuitButton.jpeg`
- multiple scene and prefab assets under `Assets/`

## Contact

For questions or collaboration, reach out through the GitHub repository or the project owner profile associated with this repository.
