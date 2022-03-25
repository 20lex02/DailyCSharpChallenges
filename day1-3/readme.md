## Day 1-3: Imaginary Coding Interview
Create a function to check if a candidate is qualified in an imaginary coding interview of an imaginary tech startup.  
\
The criteria for a candidate to be qualified in the coding interview is:
1. The candidate should have complete all the questions.
2. The maximum time given for very easy questions is 5 minutes each.
3. The maximum time given for easy questions is 10 minutes each.
4. The maximum time given for medium questions is 15 minutes each.
5. The maximum time given for hard questions is 20 minutes each.
##
If all the above conditions are satisfied, return `"qualified"`, else return `"disqualified"`.  
\
You will be given an array of time taken by a candidate to solve a particular question and the total time taken by the candidate to complete the interview.  
\
Given an array, in a true condition will always be in the format `[very easy, very easy, easy, easy, medium, medium, hard, hard]`.  
\
The maximum time to complete the interview includes a buffer time of 20 minutes.
### Examples
* `Interview(new int [] { 5, 5, 10, 10, 15, 15, 20, 20 })` -> `"qualified"`
* `Interview(new int [] { 2, 3, 8, 6, 5, 12, 10, 18 })` -> `"qualified"`
* `Interview(new int [] { 5, 5, 10, 10, 25, 15, 20, 20 })` -> `"disqualified"`  
(Exceeded the time limit for a medium question.)
* `Interview(new int [] { 5, 5, 10, 10, 15, 15, 20 })` -> `"disqualified"`  
(Did not complete all questions)
#
Done [X]
Bonus: Solve using only array methods [X]