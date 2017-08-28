# PoeSums kata steps:
1) A list of empty inputs will produce a list of empty outputs.
2) A list of a single zero entry will produce a list of empty outputs.
3) A list of entries whose sum is less than 40 will produce a list of empty outputs.
4) A list of entries whose sum is less than 40 but contains a 20 will produce an output list consisting of a single 20.
5) A list of entries whose sum is exactly 40 containing no 20s will produce an output list whose entries match the input list.
6) The input list of entries from the previous step but add a one to the input list. Should produce the input list minus the one entry.
7) Test the input "19 18 3 2 1" and make sure the output returns a list of three elements that add up to 40 ("19 18 3") and not the list of four elements that add up to 40. ("19 18 2 1").
8) Test the input "19 18 3 15 15 10" and make sure the output returns two lists of three elements that add up to 40 ("19 18 3" & "15 15 10").
9) Test input of eight "10"s and make sure the output returns two lists of four elements that add up to 40 ("10 10 10 10" & "10 10 10 10").
10) Test input list of "15 15 15 10 10 11 9" and make sure the output returns one list of three elements that add up to 40 ("15 15 10").
11) Go back through the previous tests and check for the total of all elements.


<sub> * - Once I entered into the issues that required heavier combinatorial lifting I turned to two different solutions. I initially adapted the code found [here](https://stackoverflow.com/a/7802892) at step 7. I later refactored using this [library](https://www.codeproject.com/Articles/26050/Permutations-Combinations-and-Variations-using-C-G).
