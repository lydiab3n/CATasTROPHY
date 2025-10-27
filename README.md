

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

All of the visual assets currently come from the Unity Asset Store or are free-of-use stock images found online, except the Slot Machine button which was drawn by Lydia, to give a pinch of personality and uniqueness to our UI.


## Implemented features

Our game currently handles the following features and interactions:
- **Keyboard inputs** : with keyboard arrows or ZQSD (for the gamers using the mighty AZERTY keyboard), the player came move to the left, to the right and even jump

- **Voice commands** : as of now, we have multiple objects that can be interacted with. Such objects include :
    - _BreakableWalls_ that can be broken with the word **_break_**
    - _Trees_ that can be cut down with the word **_cut_**
    - _Bridges_ that can be activated with the word _bridge_ to allow the player to cross over a large gap
    - _Tunnels_ that can be accessed with the word **_dig_** in order to access an underground map
    - _Wings_ : this last particular item works in a slightly different way from the others. Wings will let the player fly upwards, to get out of an underground level. The command **_fly_** will trigger an animation, which in turn will propel the player upward.

- **Mouse interaction** :
    - _Enemies_ : enemies, moving or static, will sometimes appear on the map. To kill them, the player must manually click on them. Additionally, some of the moving enemies are paired with an ominous _spatial audio_, which gets triggered when the player gets close to them.
    - _Slot Machine_ : when the player dies, a slot machine appears to give them a second chance. The player can start it by dragging the lever down with their mouse. If they win, the player gets revived and the level continues at the closest checkpoint (identifiable in the map as a glowing blue light). Else, the player is sent back to the beginning of the level. However, this slot machine event only happens once : the next death triggers an immediate Game Over.

- **Controller port and haptic feedback** : aside from using keyboard controls, we also added the possibility to use a game controller in order to move. In this case, when a voice command is used, it returns haptic feedback to the player through vibration signals. Each voice command has its own unique intensity and duration !

- **Item collection** : the player can collect items on the map, which will appear as sunglasses. These items are called _Aura_, and the collecting act called _Aura Farming_. The ending scene will change depending on how much _Aura_ the player has when completing the level. The player's Aura is displayed at the top right corner of the screen in game mode.

##  Challenges encountered

Our first challenge, prior to starting our project, was to design a system with various interesting interactions. Our first project idea was CatZino, a Cat Casino riddled with interactions and minigames. However, we were made aware that our interactions, despite being varied, were all constrained through keyboard and mouse. Therefore, we decided to scrap our initial project and change it completely to make a 2D platformer game with voice and keyboard inputs.

When we first started implementing our voice input features, we were using HuggingFace’s Speech Recognition API. However, the online resources available weren’t exactly what we were looking for. In the end, we found that Unity had an integrated speech recognition scripting API, Unity.Engine.Window.Speech, which was much easier to implement into our project and gave us better results.

Finally, as this was our first time using Unity to make a 2D game, we had to teach ourselves all the basics through YouTube tutorials and online forums. Despite the time spent learning how to use this game engine and the tight deadline, we managed to implement all our main ideas into the process and the learning process was very enjoyable !

## Future work

Although we managed to make our big ideas come true and achieved the main goal of this class, which was to build a system with various diverse interactions, we still have a few ideas for the future of CATasTROPHY.

First, we want to **switch the flying animation to a volume sensor interaction**. Ideally, saying "fly" would _trigger the volume sensor_. Then, depending on how much _decibels_ the system hears, it would propel the player upwards accordingly. Finally, saying "stop" would _turn the volume sensor off_. This idea was actually half-implemented in our project, but wasn't exactly working like we wanted. Because of the imminent deadline, we decided to temporarily scrap it for a more polished and finished look, and replaced it by a nice animation.

Next we want to add more levels to our game. Why limit the player to a single map when there is so much potential ? We also believe that a game should be fun, and for this reason, we can't possibly restrict it to a single (albeit fun) level.

Finally, we would like to make CATasTROPHY prettier overall, by replacing our current free assets by our own custom ones. Since we're using sprites from different assets packages, they don't really blend together. Therefore, drawing our own would make the objects and character seem like they're actually part of their own world, as well as give our game a unique visual identity. Additionally, would like to add customization to our game, so that the player can customize the main cat and their lover.
