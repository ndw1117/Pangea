# Project Pangea

[Markdown Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Here-Cheatsheet)

### Student Info

-   Name: Nick Will
-   Section: 01

## Game Design

-   Camera Orientation: _Side-View_
-   Camera Movement: _Fixed camera (no camera movement)_
-   Player Health: _Lives_
-   End Condition: _Player runs out of lives_
-   Scoring: _The score increases when the player successfully dodges enemies that pass by on the screen. The score increases by a greater amount when the player destroys an enemy using their projectile ability._

### Game Description

_Play as a family of birds in a prehistoric world of light as it faces a great calamity. Survive the falling debris and fight against predators in the air to guide the avian family to safety_

### Controls

-   Movement: The player moves using vector-based movement.
    -   Up: Mouse Movement
    -   Down: Mouse Movement
    -   Left: Mouse Movement
    -   Right: Mouse Movement
-   Fire: Left-Click
    -   Delay: There is a time delay implemented in the code which prevents too many bullets from spawning at once.

Player is stopped upon interaction with the edges of the screen.

## Enemies

Enemies move using vector based movement. Circle collision checking is used between the enemies and the player & projectiles.

- Enemy #1: Meteor
    -   Meteors spawn above the camera view and travel down and to the right.
    -   Colliding with the player or a projectile causes the meteor to be destroyed. Colliding with a projectile also causes the projectile to be destroyed. Colliding with the player also causes the player to lose a life.
- Enemy #2: Predator
    -   Predators spawn to the left of the camera view and travel to the right.
    -   Predators have a random travelling speed within a specified interval.
    -   Colliding with the player or a projectile causes the predator to be destoyed. Colliding with a projectile also causes the projectile to be destroyed. Colliding with the player also causes the player to lose a life.

## Your Additions

The art assets for the game were created using Adobe software, and original music for the game was composed and produced using MuseScore software.
__NOTE:__ To hear the music porperly, the user should be "clicked-in" to the game window.

## Sources

-   Art assets produced using Adobe Illustrator & Photoshop.
-   Music assets produced using MuseScore software.
-   Unity C# concepts taught in IGME 202 at Rochester Institute of Technology were used and referenced in the making of this game.

## Known Issues

There are currently no known issues with the game.
While it is not a bug, it is important to note that in order to properly hear the background music, the user should be focused, or "clicked-in" to the game window.

### Requirements Not Completed

_There are currently no project requirements that have not been completed._

## Future Developments

_Below is a list of developments beyond the scope of the assigned rubric that are intended to be added to the game in the future_

- Increased difficulty of the game
- A "play again" function
- A scrolling background image
- Cooldown on projectile ability with indicator in HUD
- Title screen with main theme audio (audio currently completed, but unused)
- Animated player & enemy sprites
- Cutscenes to provide context and tell the story of the game
- HTML/CSS work on the page that hosts the game


