## Day 0-3: Track the Robot (Part 1)
A robot has been given a list of movement instructions. Each instruction is either `left`, `right`, `up` or `down`, followed by a distance to move. The robot starts at [0, 0]. You want to calculate where the robot will end up and return its final position as an array.  
\
To illustrate, if the robot is given the following instructions:  
`new string[] { "right 10", "up 50", "left 30", "down 10" }`  
It will end up 20 left and 40 up from where it started, so we return `new int[] {-20, 40}`
### Examples
* `TrackRobot(new string[] { "right 10", "up 50", "left 30", "down 10" })` -> `[-20, 40]`
* `WriteArray(TrackRobot(new string[] { }))` -> `[0,0]`
* `TrackRobot(new string[] { "right 100", "right 100", "up 500", "up 10000" })` -> `[200,10500]`