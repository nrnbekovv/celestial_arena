# Celestial Arena

> A 3D survival platformer built in Unity where players must dodge dynamic pushing blocks, survive random waves, and stay on the platform. 

## Gameplay Overview

In **Celestial Arena**, the player's goal is to survive waves of incoming blocks that try to push them off the edge. 

* **Mechanics:** Classic platformer controls (WASD, Jump, Double Jump).
* **Progression:** The game features random wave generation. Level 1 consists of 10 waves. Level 2 increases the difficulty with faster block speeds and new hazards.
* **Hazards:** Trap blocks, fire death zones with particle effects, and dynamic lighting.

## Tech Stack & Tools

* **Engine:** Unity 3D
* **Language:** C#
* **Assets:** 3D models, textures, and animations sourced from the Unity Asset Store.

## Key Features & Implementation

* **Core Player Mechanics:** Base movement logic (WASD, Jump, Double Jump reset) and trap block interactions.
* **Dynamic Environment:** Smooth day-night cycle manager and skybox blending for progressive levels.
* **Camera System:** Custom camera switching system for optimal gameplay angles.
* **Game State Management:** Fully functional Main Menu, Settings, Pause system, and Win/Lose states with High Score calculation.
* **Level Architecture:** Managed wave speed transitions and dynamic event triggers.
* **Audio & Visuals:** Integrated sound effects, dynamic lighting, and particle systems for fire death zones.

## Screenshots
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/dc2be405-1a67-4f88-99e2-52376262f81c" />
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/76774afd-244b-4e3a-9192-90fbce1d9c23" />
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/c05a9dfe-68c6-4621-a1cf-38db046dfc72" />
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/e8b572e0-50fc-424c-b6a2-612a871cd10e" />
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/11e086a1-2f8c-4dd7-b454-51e7e4768736" />
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/e62cf720-6ea2-44d4-819e-8c4970985ca4" />
<img width="1920" height="1200" alt="image" src="https://github.com/user-attachments/assets/132de096-e608-4c16-8f28-419610c837e8" />


## How to Run Locally

1. Clone the repository:
`git clone https://github.com/nrnbekovv/celestial_arena.git`

2. Open the project in **Unity Hub** (ensure you have a compatible Unity version installed).

3. Open the `MainMenu` scene (or `Level_1` scene) in the `Scenes` folder.

4. Press the **Play** button in the Unity Editor to start the game.
