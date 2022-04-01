## Day 7-1: Working 9 to 5
#### Write a function that calculates overtime and pay associated with overtime.  
* Working 9 to 5: regular hours
* After 5pm is overtime  

#### Your function gets an array with 4 values:
* Start of working day, in decimal format, (24-hour day notation)
* End of working day. (Same format)
* Hourly rate
* Overtime multiplier  

#### Your function should spit out:
* `"$"` + earned that day (rounded to the nearest hundreth)
### Examples
* `Console.WriteLine(OverTime(new float[] {9, 17, 30, 1.5f}));` -> `"$240.00"`
* `Console.WriteLine(OverTime(new float[] {16, 18, 30, 1.8f}));` -> `"$84.00"`
* `Console.WriteLine(OverTime(new float[] {13.25f, 15, 30, 1.5f}));` -> `"$52.50"`
#
Done [X]