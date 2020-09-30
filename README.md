# NumToWord
Matthew Manuel-  NinetyOne front office assignment
This has been developed using visual studio version 8.7, please run using equivalent version or later, with necessary packages to run C#.
This solution has been developed with the thought that any number converted to a word comes from a pre-defined set of options. As a word can only be from zero, one, two etc. It can then evolve to a double digit such as Ten, twenty etc, and a "Teen" such as eleven, fifteen etc. From this any number can be read along with the corresponding name of a larger number i.e Hundred, Thousand. This solution uses C# as C# enables the indexation of characters within a string. Using the index of characters within a string, I am able to identify what the character is and therefore identify the corresponding number. Using the amount of characters in a number i.e hundreds have 3 characters, thousands have 4 or more etc, I am able to convert a number to a word. This solution uses IF statements to classify the number into their respective lengths, and then convert the number into words, using case statements contained within a function. 
Test data is contained within the Test_Textfile.txt document. Please change connection string within document to relevant locaion.
Assumptions made:
There is only 1 number in a string (i.e "Hello 1234" is valid but "Hello i turn 18 in 2021" is not.
Currency identifiers will invalidate input (i.e "I owe R123" is invalid )
Non-numeric characters immediatly before a number will invalidate input (i,e "X12" and ",11" is invalid")
Assume no number equal to or greater than 1 000 000 will be input and therefore is invalid (See comments in .cs file for relaxing this assumption)
Assume that no values containing only whitespace will be input as test data (i.e " " and "" etc should not be input to the programme) 
Assume that a number with a zero as the first digit is equal to an indentical number with the first digit omitted (i.e "012" = "12")
Assume that non numeric characters within a number will invalidate input (i.e "12,3" and "1@23" etc is invalid")
Assume that a non-numeric character imediatly after a number will not invalidate number (i.e "12@" and "101XY" is valid and the numbers are equivalent to 12 and 101 respectively)
