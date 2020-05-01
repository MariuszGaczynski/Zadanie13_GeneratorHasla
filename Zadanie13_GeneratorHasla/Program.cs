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

            int givenNumberOfCharactersInPassword = 0;
            bool correctNumberOfCharactersInPassword = false;
            do
            {
                Console.Write("How many characters your password should have ? ... ");
                string answer1 = Console.ReadLine();
                bool isParsable1 = Int32.TryParse(answer1, out int numberOfCharactersInPassword);
                if (isParsable1 && numberOfCharactersInPassword > 100)
                {
                    Console.WriteLine("Password with more then hundred characters ? Who would remember that ?");
                    Console.WriteLine("Try once again with less characters");
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



                Console.WriteLine("\nChoose what degree of complexity your password sholud be.");
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



            List<byte> ListOfPossibleNumbers = CreatingListOfPossibleNumbers(givenComplexityLevel);


            for (int i = 0; i < ListOfPossibleNumbers.Count; i++)
            {
                Console.WriteLine("Wartość na  pozycji " + i +  " to " + ListOfPossibleNumbers[i]);
            }

            Console.WriteLine("Liczba znaków w haśle : " + givenNumberOfCharactersInPassword);
            Console.WriteLine("Liczba możliwych znaków do hasła : " + ListOfPossibleNumbers.Count);

            bool anotherPassword = true;
            do
            {

                Console.WriteLine("Let's create your password !");
                string newPassword = "";

                for (int i = 0; i < givenNumberOfCharactersInPassword; i++)
                {
                    int ASCIICodeNumber = ListOfPossibleNumbers[RandomNumber(ListOfPossibleNumbers)];
                    char characterInPassword = (char)ASCIICodeNumber;

                    newPassword += characterInPassword;



                }

                Console.WriteLine("Your new password is : " + newPassword);

                
                    Console.WriteLine("Press 'Enter' to generate another password with previously given parameters"); ;
                    Console.WriteLine("Or press 'E' to Exit");

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


    public static void Graphic1 ()
        {
            Console.WriteLine("Password Generator");
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
    }
    
}
