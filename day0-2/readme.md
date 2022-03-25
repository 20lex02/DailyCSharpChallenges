## Day 0-2: Find the bomb
Create a function that finds the word `"bomb"` within a given string (not cave sensitive), if found, return `"DUCK!!!"`, otherwise, return `"Dude chill, there is no bomb."`.
### Examples
* `FindBomb("There is a bomb.")` -> `"Duck!!!"`
* `FindBomb("Hey, did you think there is a bomb?")` -> `"Duck!!!"`
* `FindBomb("This goes boom!!!")` -> `"Dude chill, there is no bomb."`