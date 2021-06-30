# Enriche
 
Enriche is a single player quiz game that includes a very simple plot and setting. It was designed to be both fun and challenging for the player.

<h2 align="center">GUI</h2>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/start_screen.png" alt="startScreen" width="200"/> <img src="https://github.com/Kuroh00/Enriche/blob/main/docs/settings.png" alt="settings" width="200"/></p>

<h2 align="center">Gameplay</h2>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/chara_select.gif" alt="charaSelect" width="600"/></p>
<p align="center" style="text-align: justify">The player is able to choose between 2 characters; John(Male) and Jane(Female)</p>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/stage_1_sample_gameplay.gif" alt="stage1" width="200"/> <img src="https://github.com/Kuroh00/Enriche/blob/main/docs/stage_2_sample_gameplay.gif" alt="stage2" width="200"/> <img src="https://github.com/Kuroh00/Enriche/blob/main/docs/stage_3_sample_gameplay.gif" alt="stage3" width="200"/></p>
<p align="center" style="text-align: justify">The game comprises a total of three stages. In each stage the player starts with four lives and is given a total of 15 random questions out of 20 questions available to answer. The player can randomly get coins for bonus points or hearts to replenish lives when choosing the correct answer. The player can only have 4 lives at most and extra hearts will be converted to points.</p>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/wrongAnswer.gif" alt="WrongAnswer" width="200"/> <img src="https://github.com/Kuroh00/Enriche/blob/main/docs/outOfTime.gif" alt="OutOfTime" width="200"/> <img src="https://github.com/Kuroh00/Enriche/blob/main/docs/OutOfLives.gif" alt="OutOfLives" width="200"/></p>
<p align="center" style="text-align: justify">One life is deducted when choosing a wrong answer or when the timer runs out. Losing all four lives results in a Game Over and will be redirected to the results screen.</p>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/resultsAndSave.gif" alt="ResultsAndSave" width="200"/></p>
<p align="center" style="text-align: justify">When the player finishes all three stages or runs out of lives. He/She will be able to choose whether to save the new high score(only if eligible) or not.</p>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/HighScore.png" alt="HighScore" width="200"/></p>
<p align="center" style="text-align: justify">The Top 5 High Scores can be viewed by clicking the stats button from the home screen.</p>

<h2 align="Center">Backend Development</h2>
<p align="center" style="text-align: justify">This game was developed using the Unity Game Engine with the scripts being written in C# language using Visual Studio.</p>
<p align="center"><img src="https://github.com/Kuroh00/Enriche/blob/main/docs/Unity.png" alt="Unity" width="200"/> <img src="https://github.com/Kuroh00/Enriche/blob/main/docs/Visual%20Studio.png" alt="VS" width="200"/></p>
<p align="center" style="text-align: justify">The questions used in this game are stored in sciptable objects. The questions are divided according to topic and loaded by stage. The questions are randomly selected with their choices also randomly placed to avoid any patterns. Player data are saved in binary .dat files for security.</p>
