######### Endless Runner ##########

Overview:

Endless Runner is a simple 3D endless platformer game built with Unity game engine. The objective is to navigate a procedurally generated level, collecting coins and power-ups to survive as long as possible. The game features a clean user interface, dynamic camera effects, and responsive player controls.

This project was developed to practice core game development concepts in Unity, including:

a. Procedural content generation

b. UI/UX implementation (Main Menu, Pause Menu, In-game HUD)

c. Collision handling and physics

d. Time and score management

e. Object-oriented programming principles


Features:

a. Main Menu & Pause Menu: Players can start a new game or quit directly from the menu.

b. Procedural Level Generation: Levels are dynamically created as the player progresses, ensuring a unique experience every time.

c. Collectible System: Collect coins to increase your score and power-ups to boost your character's speed and FOV.

d. Dynamic Camera: The camera's field of view smoothly adjusts when a power-up is collected, adding to the sense of speed.

e. Stumble Animation: A "stumble" animation is triggered upon collision, providing clear visual feedback.

f. Game State Management: The game seamlessly handles states for playing, pausing, and game over.

Things to be added/fixed later:

a. The coins and power-ups may not seem to be disappearing when the player is collecting them at increased speed. The prefabs disappear after half a second later, allowing the sfx to play after the player collects them.

b. Quit button from pause menu may/mayn't exit the game, however the Quit button in main menu works.

c. There's no option for quitting or restarting the level once the game is over, press alt+f4 to quit the game.

d. No scoreboard exhibiting the score history has been added yet.


How to Play:

Objective: Collect as many coins as you can while avoiding obstacles. The game ends when the timer runs out.

Movement: Use the Left and Right arrow keys to move.

Pause: Press the Escape key to pause or unpause the game.

Quit: Use the "Quit" button in the Main Menu to exit the application.

Setup and Installation

This project requires Unity version 6000.0.39f1


Clone the repository:

git clone https://github.com/K1LLERB0T/Endless-Runner.git


This project is licensed under the MIT License. See the LICENSE file for details.
