using System;
using System.IO;
					
public class Program
{
	private static string[] ones = { " One ", " Two ", " Three ", " Four ", " Five ", " Six ", " Seven ", " Eight ", " Nine " };
	private static string[] tens = { " Ten ", " Twenty ", " Thirty ", " Fourty ", " Fifty ", " Sixty ", " Seventy ", " Eighty ", " Ninenty " };
	private static string[] teens = { " Eleven ", " Twelve ", " Thirteen ", " Fourteen ", " Fifteen ", " Sixteen ", " Seventeen ", " Eighteen ", " Nineteen " };
	private static string[] others = { " Hundred ", " Thousand " };

	public static void Main() 
	{
		var sString = "";
		var sNumericalString = "";
		var sFinalString = "";
		var digitcheck = true;
		var digicount = 0;
		var sAnswer = "";
		var sTextFileline = "";

		System.IO.StreamReader file =
		new System.IO.StreamReader(@" Please change connection string /Test_Textfile.txt");
		while ((sTextFileline = file.ReadLine()) != null)
		{
			sString = "";
			sNumericalString = "";
			digitcheck = true;
			sAnswer = "";

			sString = sTextFileline.ToString();
			

			for (int i = 0; i < (sString.Length); i++)
			{

				if (digitcheck == true)
				{

					if (sString[i] == '1' || sString[i] == '2' || sString[i] == '3' || sString[i] == '4' || sString[i] == '5' || sString[i] == '6' || sString[i] == '7' || sString[i] == '8' || sString[i] == '9' || sString[i] == '0')
					{
						digicount = i;
						if (i != 0 && (sString[i - 1] != ' ' && sString[i - 1] != '1' && sString[i - 1] != '2' && sString[i - 1] != '3' && sString[i - 1] != '4' && sString[i - 1] != '5' && sString[i - 1] != '6' && sString[i - 1] != '7' && sString[i - 1] != '8' && sString[i - 1] != '9' && sString[i - 1] != '0'))
						{
							digitcheck = false;
						}
						else
						{

							if ((digicount + 1) == (sString.Length))
							{
								Console.WriteLine((digicount + 1).ToString());
								sNumericalString = sNumericalString + sString[i];

							}
							else
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
				if ((sNumericalString[0] == '0') && (sNumericalString.Length != 1) && (digitcheck != false) && (sNumericalString != ""))
				{
					for (int i = 1; i < (sNumericalString.Length); i++)
					{
						sFinalString = sFinalString + sNumericalString[i];
					}
					sNumericalString = sFinalString;
				}
			}

			if (digitcheck == false)
			{
				sAnswer = "Invalid input";
			}

			if (digitcheck == true)
			{
				if ((sNumericalString.Length == 1) && (sNumericalString[0] == '0'))
				{
					sAnswer = "Zero";
				}
				else
					if (sNumericalString.Length < 2)
				{
					sAnswer = getOnes(sAnswer, sNumericalString, 0);

				}
				else
					if (sNumericalString.Length >= 2 && sNumericalString.Length < 3)
				{
					if (sNumericalString[0] == '1')
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
				}
				else
					if (sNumericalString.Length >= 3 && sNumericalString.Length < 4)
				{
					if (sNumericalString[1] == '1')
					{
						if (sNumericalString[2] == '0')
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);
							sAnswer = getOthers(sAnswer, 0);
							sAnswer = getTens(sAnswer, sNumericalString, 1);
						}

						else
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);
							sAnswer = getOthers(sAnswer, 0);
							sAnswer = getTeens(sAnswer, sNumericalString, 2);

						}
					}
					else
					{

						sAnswer = getOnes(sAnswer, sNumericalString, 0);
						sAnswer = getOthers(sAnswer, 0);

						if (sNumericalString[1] == '0')
						{
							sAnswer = getTens(sAnswer, sNumericalString, 1);
						}
						else
						{
							sAnswer = getTens(sAnswer, sNumericalString, 1);
						}
						sAnswer = getOnes(sAnswer, sNumericalString, 2);
					}

				}
				else
					if (sNumericalString.Length >= 4 && sNumericalString.Length < 5)
				{
					if ((sNumericalString[2] == '1'))
					{
						if (sNumericalString[3] == '0')
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);

							sAnswer = getOthers(sAnswer, 1);


							sAnswer = getOnes(sAnswer, sNumericalString, 1);
							if (sNumericalString[1] != '0')
							{
								sAnswer = getOthers(sAnswer, 0);
							}


							sAnswer = getTens(sAnswer, sNumericalString, 2);

						}
						else
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 0);

							sAnswer = getOthers(sAnswer, 1);

							sAnswer = getOnes(sAnswer, sNumericalString, 1);
							if (sNumericalString[1] != '0')
							{
								sAnswer = getOthers(sAnswer, 0);
							}

							sAnswer = getTeens(sAnswer, sNumericalString, 3);

						}
					}
					else
					{
						sAnswer = getOnes(sAnswer, sNumericalString, 0);

						sAnswer = getOthers(sAnswer, 1);


						sAnswer = getOnes(sAnswer, sNumericalString, 1);
						if (sNumericalString[1] != '0')
						{
							sAnswer = getOthers(sAnswer, 0);
						}

						switch (sNumericalString[2])
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
					if (sNumericalString.Length >= 5 && sNumericalString.Length < 6)
				{
					if (sNumericalString[0] == '1')
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


					if (sNumericalString[3] == '1')
					{
						if (sNumericalString[4] == '0')
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 2);
							sAnswer = getOthers(sAnswer, 0);
							sAnswer = getTens(sAnswer, sNumericalString, 3);
						}

						else
						{
							sAnswer = getOnes(sAnswer, sNumericalString, 2);
							sAnswer = getOthers(sAnswer, 0);
							sAnswer = getTeens(sAnswer, sNumericalString, 4);

						}
					}
					else
					{

						sAnswer = getOnes(sAnswer, sNumericalString, 2);
						sAnswer = getOthers(sAnswer, 0);

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
					if (sNumericalString.Length >= 6 && sNumericalString.Length < 7)
					{
						sAnswer = getOnes(sAnswer, sNumericalString, 0);
						sAnswer = getOthers(sAnswer, 0);

						if (sNumericalString[1] == '1')
						{
							if (sNumericalString[2] == '0')
							{
								sAnswer = getTens(sAnswer, sNumericalString, 3);

							}
							else
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


						if (sNumericalString[4] == '1')
						{
							if (sNumericalString[5] == '0')
							{
								sAnswer = getOnes(sAnswer, sNumericalString, 3);
								sAnswer = getOthers(sAnswer, 0);
								sAnswer = sAnswer + "and";
								sAnswer = getTens(sAnswer, sNumericalString, 4);
							}

							else
							{
								sAnswer = getOnes(sAnswer, sNumericalString, 3);
								sAnswer = sAnswer + "and";
								sAnswer = getTeens(sAnswer, sNumericalString, 5);

							}
						}
						else
						{

							sAnswer = getOnes(sAnswer, sNumericalString, 3);
							if ((sNumericalString[3] != '0') && (sNumericalString[4] != '0') && (sNumericalString[5] != '0'))
							{
								sAnswer = getOthers(sAnswer, 0);
								sAnswer = sAnswer + "and";
							}



							if (sNumericalString[5] == '0')
							{

								sAnswer = getTens(sAnswer, sNumericalString, 4);
							}
							else
							{
								sAnswer = sAnswer + "and";
								sAnswer = getTens(sAnswer, sNumericalString, 4);
								sAnswer = getOnes(sAnswer, sNumericalString, 5);
							}

						}

					}


				}

			}

			Console.WriteLine(sNumericalString);
			Console.WriteLine(sAnswer);
		}

		file.Close();
	}

	public static string getOnes(string sAnswer, string sNumericalString, int iPosition)
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

	public static string getTens(string sAnswer, string sNumericalString, int iPosition)
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

	public static string getTeens(string sAnswer, string sNumericalString, int iPosition)
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
				sAnswer = sAnswer + tens[3];
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

	public static string getOthers(string sAnswer, int iPosition)
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
