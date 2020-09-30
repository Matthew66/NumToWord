using System;
using System.IO;
					
public class Program
{
	// A set of four arrays have been declared to hold the various "bulidng blocks" that make up words.
	// They are accessed through private get methods below the Main()
	// private is the default implementation in C#
	// Using arrays ensure that we can easily add or remove new "building blocks" even though the way we interpert numbers is hihgly unlikely to change
	private static string[] ones = { " One ", " Two ", " Three ", " Four ", " Five ", " Six ", " Seven ", " Eight ", " Nine " };
	private static string[] tens = { " Ten ", " Twenty ", " Thirty ", " Fourty ", " Fifty ", " Sixty ", " Seventy ", " Eighty ", " Ninenty " };
	private static string[] teens = { " Eleven ", " Twelve ", " Thirteen ", " Fourteen ", " Fifteen ", " Sixteen ", " Seventeen ", " Eighteen ", " Nineteen " };
	private static string[] others = { " Hundred ", " Thousand " };

	public static void Main()
	{
		//Variales used are first instanciated 
		var sString = ""; // This variable will be used to store the line from the text file
		var sNumericalString = ""; // This variable will be used to store the number extracted from the text file line
		var sFinalString = "";//Temprary variable used witin validation
		var digitcheck = true; // A boolean variable used to keep track if the input string meets the validation requirements and is valid or not.
		var digicount = 0; // A variable to keep track of the character index 
		var sAnswer = ""; // This variable keeps track of the final answer i.e the number converted to a word
		var sTextFileline = ""; // The line read from the textfile

		System.IO.StreamReader file =
		   new System.IO.StreamReader(@"Please change connection string /Test_Textfile.txt"); // Please change the connection string to the test textfile
		while ((sTextFileline = file.ReadLine()) != null) // Logic to read from file, line by line
		{
			sString = ""; // We initialise the variables being used within the programme. 
			sNumericalString = "";
			digitcheck = true;
			sAnswer = "";

			sString = sTextFileline.ToString(); // We turn the text file line to a string, this is arguably redundant, and argiably needs to be placed within a try catch block.
			

			for (int i = 0; i < (sString.Length); i++) // This portion of code validates the input and extarcts the number in text read from the text file line
			{

				if (digitcheck == true)
				{
					//For each character index in the string, we check the character in index postion i, in index positon i-1, and in index postion i+1 for characters that will invalidate the input.
							if (sString[i] == '1' || sString[i] == '2' || sString[i] == '3' || sString[i] == '4' || sString[i] == '5' || sString[i] == '6' || sString[i] == '7' || sString[i] == '8' || sString[i] == '9' || sString[i] == '0')
							{
								digicount = i;
								if (i != '0'  && (sString[i - 1] != ' ' && sString[i - 1] != '1' && sString[i - 1] != '2' && sString[i - 1] != '3' && sString[i - 1] != '4' && sString[i - 1] != '5' && sString[i - 1] != '6' && sString[i - 1] != '7' && sString[i - 1] != '8' && sString[i - 1] != '9' && sString[i - 1] != '0'))
								{
									digitcheck = false;
								}
								else
								{

									if ((digicount + 1) == (sString.Length)) // In the above if, we have validated the character in index i-1, therefore if it is valid, we need to add the character in index i to the Numerical string. This is because the character index, and the actual postion within the string are offset by 1, as the index starts from 0, and the string.length starts incrementing from 1.
									{
										sNumericalString = sNumericalString + sString[i];

									}
									else // if the next value is not equal to the string . length, we can proceed to validate it, and if it is valid, we append it to the numerical string
									{
										if (sString[digicount + 1] != ' ' || (sString[digicount + 1] != '1' || sString[digicount + 1] != '2' || sString[digicount + 1] != '3' || sString[digicount + 1] != '4' || sString[digicount + 1] != '5' || sString[digicount + 1] != '6' || sString[digicount + 1] != '7' || sString[digicount + 1] != '8' || sString[digicount + 1] != '9' || sString[digicount + 1] != '0'))

										{
											sNumericalString = sNumericalString + sString[i];
										}
									}


								}

							}

					
				}

			}

			if (digitcheck != false)
			{
				if ((sNumericalString != ""))
				{
					if ((sNumericalString[0] == '0') && (sNumericalString.Length != 1) && (digitcheck != false)) // Once we have obtained a Numerical String, this logic cheks if the character in index postion zero is a "0", if it is, it removes this character. However if the string is length of one, and the chracter in index zero is a zero, we do not remove the character.
					{
						for (int i = 1; i < (sNumericalString.Length); i++)
						{
							sFinalString = sFinalString + sNumericalString[i];
						}
						sNumericalString = sFinalString;
					}
				}
				
			}

			if (digitcheck == false) // Assign a message to display that the input is invalid
			{
				sAnswer = "Invalid input";
			}

			if (digitcheck == true) //This if statement controls wherter the code to convert the numerical string to a word will execute, we only want to convert valid input
			{
				if ((sNumericalString.Length == 1) && (sNumericalString[0] == '0')) //Check if value is a zero
				{
					sAnswer = "Zero";
				}
				else
					if (sNumericalString.Length < 2) // Check if string being evaluated is of length one
				{
					sAnswer = getOnes(sAnswer, sNumericalString, 0); // If string is of length two, it is a singular digit, we call the function "getOnes".
					//Three values are passed to the function, the variable to which the number must be appended, the numerical string containing the number, and the index we want to evaluate within the numerical string, in this case index positon zero.

				}
				else
					if (sNumericalString.Length >= 2 && sNumericalString.Length < 3) //If statement evaluates if the numerical string is two digits,
				{
					if (sNumericalString[0] == '1') // If the first value is a 1, the number will form part of the "teens" or will simply be a ten
					{
						if (sNumericalString[1] == '0') // If the second postion is  a 0, we know the number is 10, we call the fuction getTens to get the answer
						{
							sAnswer = getTens(sAnswer, sNumericalString, 0);

						}
						else
						{
							sAnswer = getTeens(sAnswer, sNumericalString, 1); // Else we know if the first character in the index is a 1, and the second is not a zero, we can call the getTeens function, as the answer is a value in the Teens

						}
					}
					else
					{
						sAnswer = getTens(sAnswer, sNumericalString, 0); // If the first digit is not a one, we know there is no posibility of an "Eleven", or "Thirteen", therefore we call the function getTens and getOnes and concatenate the two words to form a final answer
						sAnswer = getOnes(sAnswer, sNumericalString, 1);
					}
				}
				else
					if (sNumericalString.Length >= 3 && sNumericalString.Length < 4) // If the numerical string being evaluated is of length 3 , we know it is in the "Hundreds"
				{
					if (sNumericalString[1] == '1') // We check if the first value is a one, and the second value is a zero, or not a zero.
					{
						if (sNumericalString[2] == '0')
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);
							sAnswer = getOthers(sAnswer, 0); // The function getOthers is used to add the word "Hundred" or "Thousand to the string answer"
							sAnswer = getTens(sAnswer, sNumericalString, 1);
						}

						else
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);
							sAnswer = getOthers(sAnswer, 0);
							sAnswer = getTeens(sAnswer, sNumericalString, 2); // Again we checked if the second value in the string (the first index) is a 1, and the third value is not a zero, we know that there is a "teen"w ithin the numerical string

						}
					}
					else
					{

						sAnswer = getOnes(sAnswer, sNumericalString, 0); // If the second value in the numerical string is not a one, we know there is no possibility of a "Teens" i.e One hundred thirteen
						sAnswer = getOthers(sAnswer, 0); //getOthers function called to obtain "Hundreds" identifier

						if (sNumericalString[1] == '0') //If statement checks if first index in character (Second value in number) is a zero, if it is a zero, the final value in the number just needs to be evaluated
						{	sAnswer = getOnes(sAnswer, sNumericalString, 2);
						}
						else // If the second value in the numerical string is not a zero,we know that we need to evalue both second and third values to obtain a final answer
						{
							sAnswer = getTens(sAnswer, sNumericalString, 1);
							sAnswer = getOnes(sAnswer, sNumericalString, 2);
						}
						
					}

				}
				else
					if (sNumericalString.Length >= 4 && sNumericalString.Length < 5) // If the numerical string being evaluated is of length 4 , we know it is in the "Thousands"

				{
				
					if ((sNumericalString[2] == '1')) //Again we check if there is the possibility of a "Twelve or Thirteen" in the numerical string
					{
						if (sNumericalString[3] == '0') // If the third index in the charahcter is a zero, we know there is a "Ten" and no posibility of a value in the "Teens"
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);

							sAnswer = getOthers(sAnswer, 1);


							sAnswer = getOnes(sAnswer, sNumericalString, 1);
							if (sNumericalString[1] != '0') // If the character in the first index is not a zero, we know that there is a "hundred" within the number
							{
								sAnswer = getOthers(sAnswer, 0);
							}


							sAnswer = getTens(sAnswer, sNumericalString, 2); 

						}
						else // Else if the third index character is not a zero, we know that there is a "Teens"in the final answer
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);

							sAnswer = getOthers(sAnswer, 1);

							sAnswer = getOnes(sAnswer, sNumericalString, 1);
							if (sNumericalString[1] != '0') // If the character in the first index is not a zero, we know that there is a "hundred" within the number

							{
								sAnswer = getOthers(sAnswer, 0);
							}

							sAnswer = getTeens(sAnswer, sNumericalString, 3);

						}
					}
					else // Else since it has been checked if the value in index two is a one, if it is not a one, there is not a one, and the number can be evaluated otherwise
					{
						sAnswer = getOnes(sAnswer, sNumericalString, 0);

						sAnswer = getOthers(sAnswer, 1);


						sAnswer = getOnes(sAnswer, sNumericalString, 1);
						if (sNumericalString[1] != '0')  // If the character in the first index is not a zero, we know that there is a "hundred" within the number

						{
							sAnswer = getOthers(sAnswer, 0);
						}

						switch (sNumericalString[2]) // Instead of passing the numerical string to function getTens, a case statement is used to add the word "and" to the final aswer, a future version may make use of a seperate method to take care of "and"and place it appropriately in the final answer, as opposed to hard coding it.
						{
							case ('1'):
								sAnswer = sAnswer + tens[0];
								break;
							case ('2'):
								sAnswer = sAnswer + "and" + tens[1];
								break;
							case ('3'):
								sAnswer = sAnswer + "and" + tens[2];
								break;
							case ('4'):
								sAnswer = sAnswer + "and" + tens[3];
								break;
							case ('5'):
								sAnswer = sAnswer + "and" + tens[4];
								break;
							case ('6'):
								sAnswer = sAnswer + "and" + tens[5];
								break;
							case ('7'):
								sAnswer = sAnswer + "and" + tens[6];
								break;
							case ('8'):
								sAnswer = sAnswer + "and" + tens[7];
								break;
							case ('9'):
								sAnswer = sAnswer + "and" + tens[8];
								break;
						}
						sAnswer = getOnes(sAnswer, sNumericalString, 3);


					}
				}

				else
					if (sNumericalString.Length >= 5 && sNumericalString.Length < 6)  // If the numerical string being evaluated is of length 5 , we know it is in the "Tens of Thousands"

				{ //A value in the "Tens of thousands (YY XXX)"consitsts of a first portion in the  "Tens (YY) " and a second portion in the "hundreds (XXX)"
					if (sNumericalString[0] == '1') // We need to evaluate if the first portion of the "tens of thousands (YY)" is a value in the teens or not.
					{
						if (sNumericalString[1] == '0')
						{
							sAnswer = getTens(sAnswer, sNumericalString, 0);

						}
						else
						{
							sAnswer = getTeens(sAnswer, sNumericalString, 1);

						}
					}
					else
					{
						sAnswer = getTens(sAnswer, sNumericalString, 0);
						sAnswer = getOnes(sAnswer, sNumericalString, 1);
					}

					sAnswer = getOthers(sAnswer, 1);


					if (sNumericalString[3] == '1') // This section of code evaluates if the second potion of the "Tens of thousands (XXX)" contains the possibltiy of a value in the "Teens"
					{
						if (sNumericalString[4] == '0')
						{
							if ((sNumericalString[2] != '0')) // This logic checks if character in index positon two is not a zero, when it is not a zero, we know that there has to be a "hundreds" in the second portion
							{
								sAnswer = getOnes(sAnswer, sNumericalString, 2);
								sAnswer = getOthers(sAnswer, 0);
							}
							sAnswer = getTens(sAnswer, sNumericalString, 3);
						}

						else
						{
							if ((sNumericalString[2] != '0'))
							{
								sAnswer = getOnes(sAnswer, sNumericalString, 2);
								sAnswer = getOthers(sAnswer, 0);
							}
							sAnswer = getTeens(sAnswer, sNumericalString, 4);

						}
					}
					else
					{
						if ( (sNumericalString[2] != '0'))
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 2);
							sAnswer = getOthers(sAnswer, 0); 
						}

						

						if (sNumericalString[3] == '0')
						{
							sAnswer = getTens(sAnswer, sNumericalString, 3);
						}
						else
						{
							sAnswer = getTens(sAnswer, sNumericalString, 3);
						}
						sAnswer = getOnes(sAnswer, sNumericalString, 4);
					}

				}
				else
				{
					if (sNumericalString.Length >= 6 && sNumericalString.Length < 7) // If the numerical string being evaluated is of length 6 , we know it is in the "Hundreds of Thousands"
																					 //A value in the "Hundreds of thousands (ZYY XXX)"consitsts of a first portion in the "Hundreds with thousands(Y)", a portion in  "Tens (YY) " and a third portion in the "hundreds (XXX)"
					{
						sAnswer = getOnes(sAnswer, sNumericalString, 0); //Here we simply gather the inital hundreds of thousands (Y) portion.
						sAnswer = getOthers(sAnswer, 0);

						if (sNumericalString[1] == '1') //Next we evaluate the "Tens(YY) " portion which is esentially the same to the evaluatio of "Tens"in the Tens of thousands above.
						{
							if (sNumericalString[2] == '0') // If the character in index 2 is a zero, and the character in index 1 is a one, we have determined that there is no teens, but a "Ten"
							{
								sAnswer = getTens(sAnswer, sNumericalString, 1);

							}
							else // If the character in index 2 is a zero, and the character in index 1 is NOT a one, we have dterermined that there is a value of "Teens"

							{
								sAnswer = getTeens(sAnswer, sNumericalString, 2);

							}
						}
						else
						{
							sAnswer = getTens(sAnswer, sNumericalString, 1);
							sAnswer = getOnes(sAnswer, sNumericalString, 2);
						}

						sAnswer = getOthers(sAnswer, 1);


						if (sNumericalString[4] == '1') //Next we evaluate the "Tens(YY) " portion which is esentially the same to the evaluatio of "Tens"in the Tens of thousands above.
						{
							if (sNumericalString[5] == '0')
							{
								if ((sNumericalString[3] != '0'))
								{
									sAnswer = getOnes(sAnswer, sNumericalString, 3);
									sAnswer = getOthers(sAnswer, 0);
								}
								sAnswer = sAnswer + "and"; // again we have to manually add "and"to the answer string, a more elegant solution would be to have a function that appends to the string sAnswer.
								sAnswer = getTens(sAnswer, sNumericalString, 4);
							}

							else
							{
								if ((sNumericalString[3] != '0'))
								{
									sAnswer = getOnes(sAnswer, sNumericalString, 3);
									sAnswer = getOthers(sAnswer, 0);
								}
								sAnswer = sAnswer + "and";
								sAnswer = getTeens(sAnswer, sNumericalString, 5);

							}
						}
						else
						{

							if (sNumericalString[3] != '0')
							{
								sAnswer = getOnes(sAnswer, sNumericalString, 3);
								sAnswer = getOthers(sAnswer, 0);
							}


							if ((sNumericalString[3] != '0') && (sNumericalString[4] != '0') && (sNumericalString[5] != '0'))
							{

								sAnswer = sAnswer + "and";
							}



							if (sNumericalString[5] == '0')
							{

								sAnswer = getTens(sAnswer, sNumericalString, 4);
							}
							else
							{

								sAnswer = getTens(sAnswer, sNumericalString, 4);
								sAnswer = getOnes(sAnswer, sNumericalString, 5);
							}

						}

					}
					else
					{//This final else captures numbers greater than six digits. While this may seem restrictive, I believe i have demonstrated that this solution can validate numbers irrelevant of length.
						//I have also shown that the solution has been designed with high levels of cohesion, as all that would need to be changed to incorporate a value of seven digits would be to adjust the "others array", and adusting the getOthers() method
						//Once this is done, the code can be adapted to incorporate the above logic for converting the hundreds of thousands.
						// Arguably this can be done for values with a larger amount of digits, however for values approaching greater digits, a solution with even higher cohesion where there a functions that convert thousands, hundreds of thounsands, etc will be beneficial.
						sAnswer = "Number too large";
					}


				}

			}
			Console.WriteLine(sTextFileline);
			Console.WriteLine(sNumericalString);
			Console.WriteLine(sAnswer);
		}

		file.Close();
	}

	//  Private methods are the default accessability
	// A private method can be invoked from a public method, such as the public Main()
	//There are four functions getOnes, getTeens, getTens and getOthers
	// These functions ensure high cohesion within the Main(), as the main(), however a better souliton would split the validation and processing of the Numerical String into a word into further functions such as validateInput() and getNumericalToWord()
	// Although the way we interperet or read a number may not change, this soultion arguably has an acceptable level of coupling
	private static string getOnes(string sAnswer, string sNumericalString, int iPosition) 
	{
		switch (sNumericalString[iPosition])
		{
			case ('1'):
				sAnswer = sAnswer + ones[0];
				break;
			case ('2'):
				sAnswer = sAnswer + ones[1];
				break;
			case ('3'):
				sAnswer = sAnswer + ones[2];
				break;
			case ('4'):
				sAnswer = sAnswer + ones[3];
				break;
			case ('5'):
				sAnswer = sAnswer + ones[4];
				break;
			case ('6'):
				sAnswer = sAnswer + ones[5];
				break;
			case ('7'):
				sAnswer = sAnswer + ones[6];
				break;
			case ('8'):
				sAnswer = sAnswer + ones[7];
				break;
			case ('9'):
				sAnswer = sAnswer + ones[8];
				break;
		}
		return sAnswer;

	}

	private static string getTens(string sAnswer, string sNumericalString, int iPosition)
	{
		switch (sNumericalString[iPosition])
		{
			case ('1'):
				sAnswer = sAnswer + tens[0];
				break;
			case ('2'):
				sAnswer = sAnswer + tens[1];
				break;
			case ('3'):
				sAnswer = sAnswer + tens[2];
				break;
			case ('4'):
				sAnswer = sAnswer + tens[3];
				break;
			case ('5'):
				sAnswer = sAnswer + tens[4];
				break;
			case ('6'):
				sAnswer = sAnswer + tens[5];
				break;
			case ('7'):
				sAnswer = sAnswer + tens[6];
				break;
			case ('8'):
				sAnswer = sAnswer + tens[7];
				break;
			case ('9'):
				sAnswer = sAnswer + tens[8];
				break;
		}
		return sAnswer;

	}

	private static string getTeens(string sAnswer, string sNumericalString, int iPosition)
	{
		switch (sNumericalString[iPosition])
		{
			case ('1'):
				sAnswer = sAnswer + teens[0];
				break;
			case ('2'):
				sAnswer = sAnswer + teens[1];
				break;
			case ('3'):
				sAnswer = sAnswer + teens[2];
				break;
			case ('4'):
				sAnswer = sAnswer + teens[3];
				break;
			case ('5'):
				sAnswer = sAnswer + teens[4];
				break;
			case ('6'):
				sAnswer = sAnswer + teens[5];
				break;
			case ('7'):
				sAnswer = sAnswer + teens[6];
				break;
			case ('8'):
				sAnswer = sAnswer + teens[7];
				break;
			case ('9'):
				sAnswer = sAnswer + teens[8];
				break;
		}
		return sAnswer;

	}

	private static string getOthers(string sAnswer, int iPosition)
	{
		switch (iPosition)
		{
			case (0):
				sAnswer = sAnswer + others[0];
				break;
			case (1):
				sAnswer = sAnswer + others[1];
				break;

		}
		return sAnswer;

	}

}