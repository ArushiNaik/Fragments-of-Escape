# Fragments of Escape

A suspense-driven survival horror game built in Unity, where the player is trapped in a haunted environment and must find a way to escape while surviving escalating danger.

<p align="center">
  <img src="https://img.shields.io/badge/Engine-Unity-000000?style=for-the-badge&logo=unity" alt="Unity" />
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp" alt="C#" />
  <img src="https://img.shields.io/badge/Genre-Horror-8B0000?style=for-the-badge" alt="Horror" />
</p>

## Overview

Fragments of Escape is a Unity horror project centered around exploration, tension, and survival. Players navigate a haunted environment, interact with objects, uncover clues, and attempt to escape before danger overwhelms them.

This project combines:

- atmospheric exploration
- puzzle and progression systems
- survival/stealth-style tension
- environmental storytelling
- win/lose gameplay flow
- immersive sound-driven horror atmosphere

## Features

- First-person or third-person style exploration gameplay
- Atmosphere-rich horror ambience and layered audio design
- Input-driven interactions and menu flow
- Inventory, puzzle, and progression systems
- Pause menu and game-over/win states
- Unity URP setup with Input System integration
- Modular structure for future expansion and iteration

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
├── README.md
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

If you want to update movement, interaction, pause, or gameplay mappings, use the Unity Input System editor.

## Gameplay Loop

The core gameplay loop is built around:

1. exploring the environment
2. discovering key items or clues
3. interacting with objects and puzzle systems
4. surviving danger or threatening encounters
5. escaping before the game ends

## Development Notes

This project is structured for iterative development and future expansion. You can build on it by:

- adding new levels and scenes
- expanding the puzzle logic in `Assets/ScriptsGame`
- improving the UI flow for pause, victory, and game-over states
- replacing or enhancing visual and audio assets

## Tools and Assets

The project includes support for:

- Unity URP
- Unity Input System
- TextMeshPro
- custom C# gameplay scripts
- stylized horror art and audio assets

## Contributing

Contributions are welcome if you want to improve gameplay, polish, bug fixes, or add new systems.

To contribute:

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Open a pull request

## License

This repository does not currently include an explicit license file. If you plan to distribute or publish the project, consider adding a suitable open-source or commercial license.

## Author

Project repository: `ArushiNaik/Fragments-of-Escape`

## Screenshots and Media

The repository contains several game assets, audio files, and UI elements, including:

- `Assets/Horror Ambience.mp3`
- `Assets/background.mp3`
- `Assets/QuitButton.jpeg`
- multiple scene and prefab assets under `Assets/`

## Contact

For questions or collaboration, reach out through the GitHub repository or the project owner profile associated with this repository.
