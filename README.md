# CollectionGame
Simple game where you have to combine matching numbers on a grid to reach a high score.

To play this in the command line, run DebugOutput.exe in Release, and use wasd and enter for up/left/down/right, and use b to end the program.

Or, to play with the UI, run CollectionGameInterface.exe in Release, and use either wasd or the direction buttons.


# How does it work?
You will notice three projects in the root:
* The library
* The interface
* Debug output

The main one is the library, since this contains all the logic and data of the game. The other two just interface with the library and create their own instances of the game, meaning they are independant of each other.
The UI uses Windows Productivity Foundation, which is an xaml based graphics API for .NET. This was chosen for its handling of grid containers, which were important to allow for easy rendering on the grid.

If you look through the code, you will notice an unused Score variable. This is something I plan to add at a later date.
