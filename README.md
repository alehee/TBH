# TBH (Tibia~~Best~~Healer)
![It's a front pic!](https://github.com/alehee/TBH/blob/master/github_resources/github_front.png?raw=true)

## Description
Tibia~~Best~~Healer is a simple C# project that uses client's screenshots function to check your health and mana level and, if necessary, triggers specific hotkeys to heal you up! Constant screenshoting can be hard for the Tibia client so be prepared for some input lag!

And the most important - **don't use this on official servers and main characters**, I created this as a 'fun to make' project and some sort of challenge to myself

## Used technology
Technology I used for this project:
* C#
* C# WinForms

## Installation
There's two ways: you can download the master branch with code, check how it's working and compile whole application in *Visual Studio 2019*, or simply download it from link below and run it from *TBH.exe*

  ### Requirements
  * Windows 7 or higher
  * Tibia 12 client
  
  ### Download
  Download [here](https://drive.google.com/file/d/15gha9LmTGoyQCRnhV8CJMvNlvycQ-2cc/view?usp=sharing) latest version, uzip and **run** the **TBH.exe** file.
  
## How to use
It's simple to use but needs some preparation

First of all, let me present you the main (and only) panel in the program
![It's a panel pic!](https://github.com/alehee/TBH/blob/master/github_resources/panel.png?raw=true)
* ![Simple color](https://via.placeholder.com/15/000000/000000?text=+) button to reset Tibia path (you choose the path on first use)
* ![Simple color](https://via.placeholder.com/15/C3C3C3/000000?text=+) log buffer, it shows some information about the program up to date
* ![Simple color](https://via.placeholder.com/15/FF0000/000000?text=+) secure heal option is a double heal hotkey trigger, you can check this if you want
* ![Simple color](https://via.placeholder.com/15/FF6C00/000000?text=+) textbox for information below what HP% you want to trigger heal hotkey (default is 50%)
* ![Simple color](https://via.placeholder.com/15/FFFF00/000000?text=+) textbox for information below what MP% you want to trigger mana hotkey (default is 50%)
* ![Simple color](https://via.placeholder.com/15/00FF00/000000?text=+) calibration button, more about it below
* ![Simple color](https://via.placeholder.com/15/AA00FF/000000?text=+) on/off bot button, simple
* ![Simple color](https://via.placeholder.com/15/FFBAFA/000000?text=+) current bot status

### First use
First of all you need to **prepare your client to the program**.
* Go to settings, and set the **Screenshot Hotkey** to **/**
* Save settings and close settings window
* Run *TBH.exe* from unziped or compiled folder and in the dialog box select Tibia main folder (program will save it)

As the Venorians say - *gz*, now we need to set the program settings

* Run *TBH.exe* from unziped or compiled folder
* Enter under what HP% and MP% the bot should trigger hotkeys and then what key should it use for it (program will save it)

Now your preparations are done! Let's use it!

### Every use
On each time you need to do this steps:

* Run *TBH.exe* from unziped or compiled folder
* Make sure you are logged in Tibia on character you want to use
* Click *Get Calibration* button and fast toggle to Tibia client, program will get necessary information
* Make sure you filled HP% and MP% textboxes and lists
* If the log says calibration was done, you can click *Toggle*, get back to the client
* You are ready to play!

As I wrote before, screenshots for client are tough so be prepared for some lag!

Have fun!
  
## Thank you!
Thank you for peeking at my project!

If you're interested check out my other stuff [here](https://github.com/alehee)
