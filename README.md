
# CATasTROPHY

A small interactive project for Institut Polytechnique Paris' Advanced Programming of Interactive Systems class. 
## Authors

This project was made by [Lydia Benosmane](https://github.com/lydiab3n), [Sidonie Minodier](https://github.com/shidowe) and [Victoria Myot](https://github.com/vmfmyot), 1st year HCI Master students at Paris-Saclay University.
## Project Description

CATasTROPHY is an interactive 2D platformer game where you  rescue stranded cats. Move with your keyboard and use voice commands to interact with the various obstacles blocking your way !! No worries if you die : try your luck at the slot machine of fate, and who knows, you might get a second chance !

The world displayed on the screen is linear, and the camera follows the player. To move or jump, simply press the arrows on your keyboard. If faced with an unavoidable obstacle, try to use a voice command : the system will detect the word and react accordingly by disposing of the object blocking your way. Falling, as well as some minor obstacles (e.g. spikes, canons…) will provide damage to the player’s health : if it falls down to 0, a second chance is given and a slot machine appears on-screen. With a simple drag motion performed with the mouse, the player can then pull the lever down and gamble for another chance! If lucky enough, all the health gets restored and the level continues right where it stopped; if not, it’s game over and the player is sent back to the beginning. Avoid obstacles and finish the level to claim your cat as a trophy !

## Tools

We’re building our small platformer game using the Unity Game engine, paired with C# to write our scripts. We chose to use Unity because it allows us to combine coding with seamless and easier to manage visuals. Unity’s visual editor and physics system makes it a lot simpler to create and test a game with realistic gravity, collisions, and animations. 

For speech recognition, we’re using Unity’s integrated speech recognition scripting API, Unity.Engine.Window.Speech, as it provides a straightforward way to detect specific voice commands (called keywords) and trigger actions in-game.

All visual assets currently come from the Unity Asset Store; however, we plan to progressively replace some of these with our own custom assets to make the game more unique if time permits.


## Implemented features

The following features have been implemented : //TODO REWRITE
- **Keyboard inputs** : with keyboard arrows or ZQSD (for the gamers using the mighty AZERTY keyboard), the player came move to the left, to the right and even jump
- **Voice commands** : as of now, we have multiple objects that can be interacted with. Such objects include :
    - _BreakableWalls_ that can be broken with the word _break_
    - _Trees_ that can be cut down with the word _cut_
    - _Bridges_ that can be activated with the word _bridge_ to allow the player to cross over a large gap
    - _Tunnels_ that can be accessed with the word _dig_ in order to access an underground map
    - tbd
- **Mouse interaction** : when the player dies, a slot machine appears to give them a second chance. The player can interact with it by dragging the lever down with their mouse. If they win, the player gets revived and the level continues where it last stopped. Else, the player is sent back to the beginning of the level.
- **Controller port and haptic feedback** : aside from using keyboard controls, we also added the possibility to use a game controller in order to move. In this case, when a voice command is used, it returns haptic feedback to the player through vibration signals.


##  Challenges encountered

Our first challenge, prior to starting our project, was to design a system with various interesting interactions. Our first project idea was CatZino, a Cat Casino riddled with interactions and minigames. However, we were made aware that our interactions, despite being varied, were all constrained through keyboard and mouse. Therefore, we decided to scrap our initial project and change it completely to make a 2D platformer game with voice and keyboard inputs.

When we first started implementing our voice input features, we were using HuggingFace’s Speech Recognition API. However, the online resources available weren’t exactly what we were looking for. In the end, we found that Unity had an integrated speech recognition scripting API, Unity.Engine.Window.Speech, which was much easier to implement into our project and gave us better results.
