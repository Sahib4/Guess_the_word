using System;
using System.Threading;

namespace HangerMan
{
    class MainClass
    {
    public static void Main(string[] args)
    {
        string[] messages = {@"
    db   db  .d8b.  d8b   db  d888b  d88888b   .88b  d88.  .d8b.  d8b   db    d888b   .d8b.  .88b  d88. d88888b
    88   88 d8' `8b 888o  88 88' Y8b 88'       88'YbdP`88 d8' `8b 888o  88   88' Y8b d8' `8b 88'YbdP`88 88'    
    88ooo88 88ooo88 88V8o 88 88      88ooooo   88  88  88 88ooo88 88V8o 88   88      88ooo88 88  88  88 88ooooo
    88~~~88 88~~~88 88 V8o88 88  ooo 88~~~~~   88  88  88 88~~~88 88 V8o88   88  ooo 88~~~88 88  88  88 88~~~~~
    88   88 88   88 88  V888 88. ~8~ 88.       88  88  88 88   88 88  V888   88. ~8~ 88   88 88  88  88 88.    
    YP   YP YP   YP VP   V8P  Y888P  Y88888P   YP  YP  YP YP   YP VP   V8P    Y888P  YP   YP YP  YP  YP Y88888",
        @"
       d888b   .d8b.  .88b  d88. d88888b    .d88b.  db    db d88888b d8888b.
      88' Y8b d8' `8b 88'YbdP`88 88'       .8P  Y8. 88    88 88'     88  `8D
      88      88ooo88 88  88  88 88ooooo   88    88 Y8    8P 88ooooo 88oobY'
      88  ooo 88~~~88 88  88  88 88~~~~~   88    88 `8b  d8' 88~~~~~ 88`8b  
      88. ~8~ 88   88 88  88  88 88.       `8b  d8'  `8bd8'  88.     88 `88.
      Y888P  YP   YP YP  YP  YP Y88888P    `Y88P'     YP    Y88888P 88   YD",
        @"
        db    db  .d88b.  db    db   db   d8b   db d888888b d8b   db
       ` 8b  d8' .8P  Y8. 88    88   88   I8I   88   `88'   888o  88
          8bd8'  88    88 88    88   88   I8I   88    88    88V8o 88
           88    88    88 88    88   Y8   I8I   88    88    88 V8o88
           88    `8b  d8' 88b  d88   `8b d8'8b d8'   .88.   88  V888
           YP     `Y88P'  ~Y8888P'    `8b8' `8d8'  Y888888P VP   V8P"};
        string[] countdown = { @"
                        
                                 db
                                o88
                                 88
                                 88
                                 88",
                                @"
                                .d888b.
                                VP  `8D
                                   odD'
                                 .88'  
                                j88.   
                                888888D",
                                    @"
                                d8888b.
                                VP  `8D
                                  oooY'
                                  ~~~b.
                                db   8D
                                Y8888P'",
                                    @"
                                  j88D 
                                 j8~88 
                                j8' 88 
                                V88888D
                                    88 
                                    VP ",
                                    @"
                                 ooooo
                                 8P~~~~
                                dP     
                                V8888b.
                                    `8D
                                88oobY'" };
        Random rnd = new Random();
        string[] words = { "slam", "space", "opinion", "queen", "rehabilitation", "cold", "fragment", "deck", "provincial", "coup" };

        bool gameOver = false;

        string startWord = $"{ words[rnd.Next(0, words.Length)]}";
        char[] maskStartWord = new string('_', startWord.Length).ToCharArray();
        string guessedChar = "";
        string listguessedChar = "";


        int guessingTries = startWord.Length * 2;
        int violations = 0;

        Console.CursorVisible = false;
        Console.WriteLine(messages[0]);
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine(@"
            d888b   .d8b.  .88b  d88. d88888b   .d8888. d888888b  .d8b.  d8888b. d888888b .d8888.   d888888b d8b   db
           88' Y8b d8' `8b 88'YbdP`88 88'       88'  YP `~~88~~' d8' `8b 88  `8D `~~88~~' 88'  YP     `88'   888o  88
           88      88ooo88 88  88  88 88ooooo   `8bo.      88    88ooo88 88oobY'    88    `8bo.        88    88V8o 88
           88  ooo 88~~~88 88  88  88 88~~~~~     `Y8b.    88    88~~~88 88`8b      88      `Y8b.      88    88 V8o88
           88. ~8~ 88   88 88  88  88 88.       db   8D    88    88   88 88 `88.    88    db   8D     .88.   88  V888
            Y888P  YP   YP YP  YP  YP Y88888P   `8888Y'    YP    YP   YP 88   YD    YP    `8888Y'   Y888888P VP   V8P");
        Thread.Sleep(1000);
        Console.Clear();

        for (int i = countdown.Length; i >0; i--){
            Console.WriteLine(countdown[i-1]);
            Thread.Sleep(1000);
            Console.Clear();
            }

        while (!gameOver)
        {
           Console.WriteLine("Guess The Word: {0}", new string(maskStartWord));
           Console.WriteLine("Gussed Characters: {0}", listguessedChar);
           Console.WriteLine("You have {0} tries left", guessingTries);
           Console.WriteLine();
           Console.Write("Your next guess is: ");

           guessedChar = Console.ReadLine();
           listguessedChar += guessedChar[0] + ", ";

           if (guessedChar.Length > 1)
           {
                    if(violations >=1)
                    {
                        guessingTries--;
                    }

             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("\nYou have you Enter only ONE char!!!");
             Console.WriteLine("You will loose two tries after TWO Violations!!");
             Thread.Sleep(2000);
             Console.ResetColor();
             violations++;
           }

                if (startWord.Contains(guessedChar[0].ToString()))
           {
              for (int i = 0; i < startWord.Length; i++)
                    {
                        if (startWord[i] == (guessedChar[0]))
                        {
                            maskStartWord[i] = (guessedChar[0]);
                        }
                    }

           }
           guessingTries--;

            if (guessingTries == 0)
                {
                  gameOver = true;
                  Console.WriteLine(messages[1]);
                }
            else if(!(new string(maskStartWord).Contains("_")))
                {
                    gameOver = true;
                    Console.WriteLine(messages[2]);
                }
                Thread.Sleep(1000);
                Console.Clear();
        }

            

        }
    }
}
