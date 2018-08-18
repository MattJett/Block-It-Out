# Block-It-Out

GUI WPF Game

DESCRIPTION
-----------
Academic Project from Spring Quarter 2018, CSCD 371 - .Net Programming with C#
Block-breaker meets Lights-Out style game. With progressivly challenging gameplay for failing, but rewarding when played correctly. Read HOW TO PLAY to get the rules of the game.
Some functionality not implemented yet; work in progress.

HOW TO RUN
----------
In home directory of repository, I've created a shortcut to the .exe launcher. Or you can use Visual Studio 2017 to open my .sln solution file or .csproj project files to view the code. Or just simply open the .cs or .xaml markup files in an editor to view code.

HOW TO PLAY
-----------
Click START button, user mouse or trackpad to move paddle, and "A" key to tilt paddle to left and "D" key to tilt paddle to right. Intercept moving ball to bounce it into a block above. Consecutive hits to a block will break it. Once block is destoyed, new blocks will be reenabled around it like the "Lights Out" game from the 90's. If ball falls below paddle, ball resets but paddle shrinks slightly. If player has to re-break a block, the speed of the ball increases slightly.

KNOWN BUGS
----------
Sometimes if the ball impacts the corner or side of the paddle, a glitch occurs that makes the ball shudder in place frozen. Hard to duplicate. Some typos in pop-up dialog boxes.

NON-FUNCTIONING FEATURES
------------------------
* Can't figure out how to make ball interact with binded control template objects, the objects in question are the blocks. This is why the ball passes right through blocks.
* Cannot find a way to correctly alter path of ball bounce based on tilted angle of paddle.
* Textures in block are missing and sound-effects still havn't been implemented yet.

PLANNED DESIGN UPDATES
----------------------
Sound Effects
* Metal to cinder-block clinking sound when ball intersects paddle. Maybe block as well, but havn't decided if I want blocks to be made out of same material as paddle. Illogical game design.
* Sound of metal ball hitting wood to imitate ball bearing bouncing around in wooden box.
* SFX of points gained and game over.

Textures
* Block textures

Title Screen
* Want to add a launcher title screen at beginning of game or when paused. Could show leaderboard there as well.
