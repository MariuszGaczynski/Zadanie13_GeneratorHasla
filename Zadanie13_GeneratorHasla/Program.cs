using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie13_GeneratorHasla
{
    class Program
    {
        static void Main(string[] args)
        {

            Graphic1();

            Console.WriteLine("\nYou can easily create password choosing from 4 available security levels.");
            Console.WriteLine("You can choose how long is your password. Minimum number od characters is 4");

           int givenNumberOfCharactersInPassword = 0;
            bool correctNumberOfCharactersInPassword = false;
            do
            {
                Console.Write("\n\tHow many characters your password should have ? ... ");
                string answer1 = Console.ReadLine();
                bool isParsable1 = Int32.TryParse(answer1, out int numberOfCharactersInPassword);
                if (isParsable1 && numberOfCharactersInPassword > 100)
                {
                    Console.WriteLine("Password with more then hundred characters ? Who would remember that ?");
                    Console.WriteLine("Try once again with less characters");
                }
                if (isParsable1 && numberOfCharactersInPassword <4)
                {
                    Console.WriteLine("Password should have at least 4 characters");
                    Console.WriteLine("Try once again with more characters");
                }
                else if (isParsable1 && numberOfCharactersInPassword > 1 && numberOfCharactersInPassword <= 100)
                {
                    givenNumberOfCharactersInPassword = numberOfCharactersInPassword;
                    correctNumberOfCharactersInPassword = true;
                }
                else
                {
                    Console.WriteLine("Let me ask you again.");
                }

            } while (correctNumberOfCharactersInPassword == false);



                Console.WriteLine("\n\tChoose what degree of complexity your password should be.\n");
                Console.WriteLine("Level 1 :\n characters are numbers");
                Console.WriteLine("Level 2 :\n characters are numbers and lowercase letters");
                Console.WriteLine("Level 3 :\n characters are numbers, lowercase letters and uppercase letters");
                Console.WriteLine("Level 4 :\n characters are numbers, lowercase letters, uppercase letters\n" +
                    " and special characters\n");
                Console.Write("Type 1 , 2, 3 or 4 to choose appropriate security level : ... ");

            byte givenComplexityLevel = 1;
            bool correctComplexityLevel = false;
            do
            {

                string answer2 = Console.ReadLine();
                bool isParsable2 = Byte.TryParse(answer2, out byte complexityLevel);
                if (isParsable2 && complexityLevel > 1 || complexityLevel < 4)
                {
                    givenComplexityLevel = complexityLevel;
                    correctComplexityLevel = true;
                }
                else
                {
                    Console.Write("Choose between 1 and 4 to get correct password complexity level ... ");
                }
                

            } while (correctComplexityLevel == false);



            List<byte> ListOfSpecificCharacters1 = CreatingListOfSpecificCharacters(1);
            List<byte> ListOfSpecificCharacters2 = CreatingListOfSpecificCharacters(2);
            List<byte> ListOfSpecificCharacters3 = CreatingListOfSpecificCharacters(3);
            List<byte> ListOfSpecificCharacters4 = CreatingListOfSpecificCharacters(4);
            
            List<byte> ListOfPossibleNumbers = CreatingListOfPossibleNumbers(givenComplexityLevel);


            //for (int i = 0; i < ListOfPossibleNumbers.Count; i++)
            //{
            //    Console.WriteLine("Wartość na  pozycji " + i +  " to " + ListOfPossibleNumbers[i]);
            //}

            //Console.WriteLine("Liczba znaków w haśle : " + givenNumberOfCharactersInPassword);
           // Console.WriteLine("Liczba możliwych znaków do hasła : " + ListOfPossibleNumbers.Count);

            bool anotherPassword = true;
            do
            {

                Console.WriteLine("\n\n\t\tLet's create your password !\n");
                
                char[] newPassword = new char[givenNumberOfCharactersInPassword];
                
                int randomNumberIndex = 0;

                if (givenComplexityLevel > 0)
                {
                    
                    int ASCIICodeNumber = ListOfSpecificCharacters1[RandomNumber(ListOfSpecificCharacters1.Count)];
                    char characterInPassword = (char)ASCIICodeNumber;
                    newPassword[RandomNumber(givenNumberOfCharactersInPassword)] = characterInPassword;
                }
                if (givenComplexityLevel > 1 )
                {
                    int ASCIICodeNumber = ListOfSpecificCharacters2[RandomNumber(ListOfSpecificCharacters2.Count)];
                    char characterInPassword = (char)ASCIICodeNumber;

                    bool characterAdded = false;
                    do
                    {
                        randomNumberIndex = RandomNumber(givenNumberOfCharactersInPassword);
                        if (newPassword[randomNumberIndex] == '\0')
                        {
                            newPassword[randomNumberIndex] = characterInPassword;
                            characterAdded = true;
                        }
                    } while (characterAdded == false);
                }
                if (givenComplexityLevel > 2 )
                {
                    int ASCIICodeNumber = ListOfSpecificCharacters3[RandomNumber(ListOfSpecificCharacters3.Count)];
                    char characterInPassword = (char)ASCIICodeNumber;

                    bool characterAdded = false;
                    do
                    {
                        randomNumberIndex = RandomNumber(givenNumberOfCharactersInPassword);
                        if (newPassword[randomNumberIndex] == '\0')
                        {
                            newPassword[randomNumberIndex] = characterInPassword;
                            characterAdded = true;
                        }
                    } while (characterAdded == false);
                }
                if (givenComplexityLevel > 3)
                {
                    int ASCIICodeNumber = ListOfSpecificCharacters4[RandomNumber(ListOfSpecificCharacters3.Count)];
                    char characterInPassword = (char)ASCIICodeNumber;

                    bool characterAdded = false;
                    do
                    {
                        randomNumberIndex = RandomNumber(givenNumberOfCharactersInPassword);
                        if (newPassword[randomNumberIndex] == '\0')
                        {
                            newPassword[randomNumberIndex] = characterInPassword;
                            characterAdded = true;
                        }
                    } while (characterAdded == false);
                }



                for (int i = 0; i < givenNumberOfCharactersInPassword; i++)
                {
                    if (newPassword[i] == '\0')
                    {
                        int ASCIICodeNumber = ListOfPossibleNumbers[RandomNumber(ListOfPossibleNumbers)];
                        char characterInPassword = (char)ASCIICodeNumber;

                        newPassword[i] = characterInPassword;
                    }


                }


                string stringNewPassword = new string(newPassword);
              

                Console.Write($"\n\tYour new password is : ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(stringNewPassword);
                Console.ResetColor();

                Console.WriteLine("________________________________________________________________________________");
                
                
                
                
                Console.WriteLine("\nPress 'Enter' to generate another password with previously given parameters"); ;
                Console.Write("Or press 'E' to Exit ... ");

                bool ContinueOrExit = true;
                do
                {
                    string answer3 = Console.ReadLine().ToLower();
                    if (answer3 == "")
                    {

                    }
                    else if (answer3 == "e")
                    {
                        anotherPassword = false;
                    }
                    else
                    {
                        Console.Write("'Enter' for another password or 'E' to Exit ... ");
                        ContinueOrExit = false;
                    }

                } while (ContinueOrExit == false);


            } while (anotherPassword == true);

            Graphic2();

            Console.ReadLine();




            
        //    Console.WriteLine("Some Random Numbers that are generated are : ");
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        Console.WriteLine(Randfunc(-100, 100));
        //    }
        //}
        //static Random r = new Random();

        //static int Randfunc(int min, int max)
        //{
        //    int n = r.Next(min, max);
        //    return n;
        //}
        }

        private static Random random = new Random((int) DateTime.Now.Ticks);
        private static int RandomNumber(List<byte> ListOfPossibleNumbers)
        {
        
            return random.Next(ListOfPossibleNumbers.Count);

        }

        private static int RandomNumber(int numberOfCharactersInPassword)
        {

            return random.Next(0, numberOfCharactersInPassword);

        }

        public static void Graphic2()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nGj3&sw\"(rm2l#;hvs9<Sa$4)8bz?*^6oHk{c2&=p@Gj3&Cw\"(rs2l#vs8Ke$4)8b?M*^6oHk{2&=Kp@");
            Console.WriteLine("                                                                               ");
            Console.WriteLine("\t\t\tThank you for your cooperation.\t\t               \n" +
                "    \t    If you will need another password come back agian.\t\t       ");
            Console.WriteLine("                                                                               ");
            Console.WriteLine("&=Kp@6oHk{c2&=p@Gj3&Cw\"(rGj3&sw\"(rm2l#;hvs9<Gj3&Cw\"(rs2l#vs8Ke$4)8b?M*^6oHk{2@G\n\n");
            Console.ResetColor();
        }


        public static void Graphic1()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Gj3&sw\"(rm2l#;hvs9<Sa$4)8bz?*^6oHk{c2&=p@Gj3&Cw\"(rs2l#vs8Ke$4)8b?M*^6oHk{2&=Kp@");
            Console.WriteLine("j3&Cw\"(rs2l#vs8Ke$4)8b9<S                            p@Gj3&Cw\"(rs2l#vs8Ke$4)8b?");
            Console.WriteLine(")8bz?*^6oHk{c2&Gj3&sw\"(rm     PASSWORD GENERATOR     @(rs2l#vs8Ke$4)8b9<Sa$4)8b");
            Console.WriteLine("8b?M*^6oHk{2&=rm2l#;hvs9<                            B(rs2l#vs8Ke$4)8b?M*^6oHk{");
            Console.WriteLine("&=Kp@6oHk{c2&=p@Gj3&Cw\"(rGj3&sw\"(rm2l#;hvs9<Gj3&Cw\"(rs2l#vs8Ke$4)8b?M*^6oHk{2@G");
            Console.ResetColor();
        }   


        public static List<byte> CreatingListOfPossibleNumbers (int complexityLevel)
        {
            List<byte> ListOfPossibleNumbers = new List<byte>();
            byte ASCIICodeNumber;

            if (complexityLevel >0)
            {
                for (ASCIICodeNumber = 48; ASCIICodeNumber < 58; ASCIICodeNumber++)
                {
                    ListOfPossibleNumbers.Add(ASCIICodeNumber);
                }


            }
            if (complexityLevel >1)
            {
                for (ASCIICodeNumber = 97; ASCIICodeNumber < 123; ASCIICodeNumber++)
                {
                    ListOfPossibleNumbers.Add(ASCIICodeNumber);
                }

            }
            if (complexityLevel > 2)
            {
                for (ASCIICodeNumber = 65; ASCIICodeNumber < 91; ASCIICodeNumber++)
                {
                    ListOfPossibleNumbers.Add(ASCIICodeNumber);
                }
            }
            if (complexityLevel > 3)
            {
                ListOfPossibleNumbers.Clear();
                for (ASCIICodeNumber = 33; ASCIICodeNumber < 127; ASCIICodeNumber++)
                {
                    ListOfPossibleNumbers.Add(ASCIICodeNumber);
                }

            }

            return ListOfPossibleNumbers;
        }


        public static List<byte> CreatingListOfSpecificCharacters( int givenComplexityLevel)
        {
            List<byte> ListOfSpecificCharacter = new List<byte>();
            byte ASCIICodeNumber;

            switch (givenComplexityLevel)
            {
                case 1:
                    for (ASCIICodeNumber = 48; ASCIICodeNumber < 58; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    break;
                case 2:
                    for (ASCIICodeNumber = 97; ASCIICodeNumber < 123; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    break;
                case 3:
                    for (ASCIICodeNumber = 65; ASCIICodeNumber < 91; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    break;
                case 4:
                    for (ASCIICodeNumber = 33; ASCIICodeNumber < 48; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    for (ASCIICodeNumber = 58; ASCIICodeNumber < 65; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    for (ASCIICodeNumber = 91; ASCIICodeNumber < 97; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    for (ASCIICodeNumber = 123; ASCIICodeNumber < 127; ASCIICodeNumber++)
                    {
                        ListOfSpecificCharacter.Add(ASCIICodeNumber);
                    }
                    break;
                default:
                    break;
            }


            return ListOfSpecificCharacter;
        }
    }
    
}
