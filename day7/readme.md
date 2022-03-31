## Day 7: Possibility decoder *(medium)*
Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, get all the possible ways it can be decoded.
### Examples
* `GetPossibleMessages("111")` -> `["aaa","ak","ka"]`
* `GetPossibleMessages("31416")` -> `["cadaf","cadp","cnaf","cnp"]`
* `GetPossibleMessages("112524")` -> `["aabebd","aabex","aaybd","aayx","alebd","alex","kbebd","kbex","kybd","kyx"]`
* `GetPossibleMessages("")` -> `[ ]`
### Notes
You can assume the messages are decodable. For example, `"001"` is not allowed.
#
Done [X]