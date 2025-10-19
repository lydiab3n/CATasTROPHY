

# CATasTROPHY

A small interactive project for Institut Polytechnique Paris' Advanced Programming of Interactive Systems class. 


## Authors

This project was made by [Lydia Benosmane](https://github.com/lydiab3n), [Sidonie Minodier](https://github.com/shidowe) and [Victoria Myot](https://github.com/vmfmyot), 1st year HCI Master students at Paris-Saclay University.

## Project Description

CATasTROPHY is an interactive 2D platformer game where you play as a cowboy cat trying to reunite with your long-lost lover. Move with your keyboard and use voice commands to interact with the various obstacles blocking your way !! No worries if you die : try your luck at the Slot Machine of Fate, and who knows, you might get a second chance !

The world displayed on the screen is linear, and the camera follows the player. To move or jump, simply press the arrows on your keyboard. If faced with an unavoidable obstacle, try to use a voice command : the system will detect the word and react accordingly by disposing of the object blocking your way. Falling into the water or colliding with enemies will be fatal to you : however, with the power of love, you'll be given a second chance through the Slot Machine of Fate. With a simple drag motion performed with the mouse, you can then pull the lever down and gamble for another chance! If lucky enough, you'll be teleported back to the nearest checkpoint; if not, it’s game over and you'll have to start from the beginning. Avoid obstacles and finish the level to claim your beloved cat as a trophy !

## Tools

We’re building our small platformer game using the Unity Game engine, paired with C# to write our scripts. We chose to use Unity because it allows us to combine coding with seamless and easier to manage visuals. Unity’s visual editor and physics system makes it a lot simpler to create and test a game with realistic gravity, collisions, and animations. 

For speech recognition, we’re using Unity’s integrated speech recognition scripting API, Unity.Engine.Window.Speech, as it provides a straightforward way to detect specific voice commands (called keywords) and trigger actions in-game.

All visual assets currently come from the Unity Asset Store or are free-of-use stock images found online. However, we plan to progressively replace some of these with our own custom assets to make the game more unique if time permits.


## Implemented features

Our game currently handles the following features and interactions:
- **Keyboard inputs** : with keyboard arrows or ZQSD (for the gamers using the mighty AZERTY keyboard), the player came move to the left, to the right and even jump

- **Voice commands** : as of now, we have multiple objects that can be interacted with. Such objects include :
    - _BreakableWalls_ that can be broken with the word **_break_**
    - _Trees_ that can be cut down with the word **_cut_**
    - _Bridges_ that can be activated with the word _bridge_ to allow the player to cross over a large gap
    - _Tunnels_ that can be accessed with the word **_dig_** in order to access an underground map
    - _Wings_ : this last particular item works in a slightly different way from the others. Wings will let the player fly upwards, to get out of an underground level. The command **_fly_** will trigger a _volume sensor_, which in turn will propel the player upwards depending on the detected decibels. Saying **_stop_** will then turn the volume sensor off.

- **Mouse interaction** :
    - _Enemies_ : enemies, moving or static, will sometimes appear on the map. To kill them, the player must manually click on them.
    - _Slot Machine_ : when the player dies, a slot machine appears to give them a second chance. The player can interact with it by dragging the lever down with their mouse. If they win, the player gets revived and the level continues at the closest checkpoint. Else, the player is sent back to the beginning of the level.

- **Controller port and haptic feedback** : aside from using keyboard controls, we also added the possibility to use a game controller in order to move. In this case, when a voice command is used, it returns haptic feedback to the player through vibration signals.

- **Item collection** : the player can collect items on the map, which will appear as sunglasses. These items are called _Aura_, and the collecting act called _Aura Farming_. The ending scene will change depending on how much _Aura_ the player has when completing the level.

##  Challenges encountered

Our first challenge, prior to starting our project, was to design a system with various interesting interactions. Our first project idea was CatZino, a Cat Casino riddled with interactions and minigames. However, we were made aware that our interactions, despite being varied, were all constrained through keyboard and mouse. Therefore, we decided to scrap our initial project and change it completely to make a 2D platformer game with voice and keyboard inputs.

When we first started implementing our voice input features, we were using HuggingFace’s Speech Recognition API. However, the online resources available weren’t exactly what we were looking for. In the end, we found that Unity had an integrated speech recognition scripting API, Unity.Engine.Window.Speech, which was much easier to implement into our project and gave us better results.
