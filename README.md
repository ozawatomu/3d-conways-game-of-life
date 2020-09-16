# 3D Conway's Game of Life

<img src="https://upload.wikimedia.org/wikipedia/commons/e/e5/Gospers_glider_gun.gif" width="200" alt="2D Conway's Game of Life">

[Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) is a cellular automaton created in 1970. It is a simulation of cells surviving in an environment amongst other cells. Cells have two states, they are either dead (white) or alive (black). At each time step, a new generation of cells are created based on the states of the previous generation. To check whether a cell will be alive or dead in the new generation, we examine it's 8 surrounding neighbor cells and follow these rules:

1. A living cell remains living if it has between 2 and 3 living neighbors.
2. A dead cell will become alive if it has between 3 and 3 living neighbors.

This program simulates this concept but with an extra dimension. The cells are now cubes and are visible if they're alive and invisible if they're dead. There are now 26 neighboring cells (like a 3x3x3 cube). Here's the result:

<img src="2333.gif" width="600" alt="Rule: 2333">

The problem is, the rules from the 2D game does not create a stable system in 3D. Here we can see and explosive growth of cells. So we will change the rules a little bit. Here are the new rules:

1. A living cell remains living if it has between ***A*** and ***B*** living neighbors.
2. A dead cell will become alive if it has between ***C*** and ***D*** living neighbors.

Now we can play with the variables ***A***, ***B***, ***C***, and ***D***. A shorthand for a rule will be written as ***ABCD***. We also need to play with the initial formation of cells. Currently the initial state is determined by a randomiser placing cells in each location based on a probability. This probability will be called ***Initial Density***. Here are the results of some interesting configurations:

<img src="4535.gif" width="500" alt="Rule: 4535"><img src="4555.gif" width="500" alt="Rule: 4555">
<img src="5655.gif" width="500" alt="Rule: 5655"><img src="5767.gif" width="500" alt="Rule: 5767">
<img src="10_21_10_21.gif" width="500" alt="Rule: 10 21 10 21"><img src="5777.gif" width="500" alt="Rule: 5777">
<img src="5877.gif" width="500" alt="Rule: 5877"><img src="6755.gif" width="500" alt="Rule: 6755">
