using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace Hangman
{
    class Program
    {
        static string sGuillotineSong;
        //Unlicensed 8-bit version of song.
        static string sHangSong;
        //Unlicensed 8-bit version of song.
        static string sWin;
        //Unlicensed 8-Bit version of song.
        static string sLose;
        //Music by Cleyton Kauffman - https://soundcloud.com/cleytonkauffman
        static string sEasterEgg;
        //Unlicenced

        static void Main()
        {
            Console.Clear();

            string sDirectoryPath = Directory.GetCurrentDirectory()+ @"\Resources";
            // Code was inspired by https://stackoverflow.com/questions/6041332/best-way-to-get-application-folder-path

            sGuillotineSong = sDirectoryPath + @"\Guillotineman.wav";
            //Unlicensed 8-bit version of song.
            sHangSong = sDirectoryPath+ @"\Hangman.wav";
            //Unlicensed 8-bit version of song.
            sWin = sDirectoryPath + @"\Win.wav";
            //Unlicensed 8-Bit version of song.
            sLose = sDirectoryPath + @"\Lose.wav"; ;
            //Music by Cleyton Kauffman - https://soundcloud.com/cleytonkauffman
            sEasterEgg = sDirectoryPath + @"\EasterEgg.wav"; ;

            int iCounted = 0;
            int iLives = 0;
            int iDifficulty = 0;
            int iWins = 0;

            string sWord = "";

            string sComputer = "";
            string sHangman = "";
            string sAsterisk = "";

            bool isAlive = true;
            bool isParse = false;
            bool isValid = false;
            bool isHangman = true;
            bool isArcade = false;
            bool isComputer = false;
            bool isLooped = true;

            string[] sEasyArray = { "DOG", "CAT", "DEER", "FOOD", "KITE", "HOG", "PEN", "EAT", "EAR", "DAY", "CUP", "SET", "ICE", "CALL", "JOB", "YEAR", "YELL", "CAP", "HAIR", "WEAR", "NOSE", "FOUR", "CAR", "GAME", "MUG", "LEND", "BOY", "LOG", "POOR", "ANT" };
            string[] sAverageArray = { "SEESAW", "FAMILY", "PUPPET", "PAJAMAS", "KITE", "CHEST", "SHOPPING", "CAST", "GLOVE", "LIBRARY", "MUSIC", "SHAPE", "THROAT", "STORE", "PENNY", "KEY", "SHAKE", "SMILE", "STEP", "FOX", "WHEELBARROW", "SUITCASE", "BASKET", "FRAME", "ROOM", "PULLEY", "FORK", "MONEY", "BARN", "SUSHI", "PANTRY" };
            string[] sDifficultArray = { "JAZZ", "JINK", "BUZZ", "QUIZ", "JIFFY", "HAPHAZARD", "JINX", "KLUTZ", "GAZEBO", "CRYPT", "FJORD", "FISHOOK", "BUNGLER", "CROQUET", "BANJO", "AWKWARD", "IVORY", "MYSTIFY", "OXYGEN", "PAJAMA", "PHLEGM", "POLKA", "QUAD", "OXYGEN", "UNZIP", "YACHT", "ZIPPY", "ZIGZAG", "ZOMBIE", "QUIP" };

            IList<string> StringList = new List<string>();
            StreamReader Dictionary = new StreamReader(sDirectoryPath + @"\Dictionary.txt");
            SoundPlayer RetroMusicPlayer = new SoundPlayer();
            Random Ran = new Random();


            TextFileReader(Dictionary, StringList);
            Console.SetWindowPosition(0, 0);

            while (!isParse)
            {
                Console.WriteLine("\n | 1.Hangman | 2.Guillutineman |");
                Console.WriteLine(" ===============================");
                Console.Write("\n Please choose a game mode(1/2): ");
                try
                {
                    sHangman = Console.ReadLine();
                }
                catch
                {
                    Invalid();
                }
                if (sHangman == "1")
                {
                    isParse = true;
                }
                else if (sHangman == "2")
                {
                    isParse = true;
                    isHangman = false;
                }
                else
                {
                    Invalid();
                }
            }
            isParse = false;
            Console.Clear();
            //This is for the user to choose which type of game they would like

            TitleScreen(isHangman, RetroMusicPlayer);
            //For asthetic purposes only...(Fullscreen recommended). Credit to http://patorjk.com/software/taag/ for the ASCII Art Generator. 

            while (!isValid)
            {
                while (!isParse)
                {
                    Console.Write("\n Would you like to play against the computer?(Y/N): ");
                    try
                    {
                        sComputer = Console.ReadLine()[0].ToString().ToUpper();
                        isParse = true;
                    }
                    catch
                    {
                        Invalid();
                    }
                }
                isParse = false;
                //This is for if they would like to play against the computer

                if (sComputer == "Y")
                {
                    isComputer = true;
                    while (!isParse)
                    {
                        iLives = 6;

                        Console.Write("\n Please choose a difficulty | Easy(1) | Average(2) | Hard(3) | Arcade(4) |: ");
                        try
                        {
                            iDifficulty = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Invalid();
                        }

                        if (iDifficulty == 1)
                        {
                            sWord = sEasyArray[Ran.Next(30)];
                            isParse = true;
                        }
                        else if (iDifficulty == 2)
                        {
                            sWord = sAverageArray[Ran.Next(30)];
                            isParse = true;
                        }
                        else if (iDifficulty == 3)
                        {
                            sWord = sDifficultArray[Ran.Next(30)];
                            isParse = true;
                        }
                        else if (iDifficulty == 4)
                        {
                            iLives = 15;
                            isParse = true;
                            isArcade = true;
                        }
                        else if (iDifficulty > 4 || iDifficulty <= 0)
                        {
                            Invalid();
                        }

                    }
                    isValid = true;
                }
                //This if for if 'Yes' is selected, they will have multiple game modes to choose from.

                else if (sComputer == "N")
                {
                    while (!isParse)
                    {
                        try
                        {
                            Console.Write("\n Player 2 - Enter how many lives you want (Default - 6): ");
                            iLives = int.Parse(Console.ReadLine());
                            isParse = true;
                        }
                        catch
                        {
                            Invalid();
                        }
                    }
                    Console.Clear();
                    isParse = false;

                    Console.Write("\n Player 1 - Please enter a word (You can press 'TAB' to see the word): ");
                    iCounted = -1;
                    while (!isParse)
                    {
                        object Input = Console.ReadKey(true).Key;
                        char cType = Convert.ToChar(Input);

                        if (char.IsLetter(cType))
                        {
                            Console.Clear();
                            Console.Write("\n Player 1 - Please enter a word (You can press 'TAB' to see the word): ");
                            iCounted++;
                            sWord += cType;
                            sAsterisk += "*";
                        }
                        else if (Input is ConsoleKey.Enter && sWord.Count() >= 1)
                        {
                            isParse = true;
                        }
                        else if (Input is ConsoleKey.Backspace && iCounted >= 0)
                        {
                            sWord = sWord.Remove(iCounted, 1);
                            sAsterisk = sAsterisk.Remove(iCounted, 1);
                            if (iCounted >= -1)
                            {
                                iCounted--;
                            }
                        }
                        else if (Input is ConsoleKey.Tab)
                        {
                            Console.Clear();
                            Console.Write("\n Player 1 - Please enter a word (You can press 'TAB' to see the word): " + sWord);
                            Console.ReadKey();
                        }
                        if (sWord.ToUpper() == "JOJO")
                        {
                            EasterEgg(RetroMusicPlayer);
                            Console.ReadKey();
                        }
                        Console.Clear();
                        Console.Write("\n Player 1 - Please enter a word (You can press 'TAB' to see the word): " + sAsterisk);
                    }
                    isValid = true;
                }
                else
                {
                    Invalid();
                }
            }
            //This if for if 'No' is selected, they will have the opportunity to select how many lives they want and what word they insert

            iCounted = 0;
            Console.Clear();

//==============================================================================================================================================================================================================================
            //Game Start

            while (isLooped)
            {
                char cInput = ' ';

                int iPointCounter = 0;
                int iLetter = 0;

                string sUnderscore = "";
                string sWordCaps = "";
                string sIncorrect = "";

                if (isArcade)
                {
                    sWord = StringList[Ran.Next(StringList.Count+1)];
                }

                foreach (char cChar in sWord)
                {
                    sUnderscore += "_,";
                }
                foreach (char cChar in sWord)
                {
                    sWordCaps += sWord[iLetter].ToString().ToUpper() + '_'.ToString();
                    iLetter++;
                }
                isAlive = true;
                //This was used to get around the fact that spaces aren't counted in the foreach loop which caused letters to replace the sUnderscore at the wrong place or return an error when there were less words
                //in sWord than in sUnderscore...

                StringBuilder sUn = new StringBuilder(sUnderscore);
                //This code is from prior experience from last year after encountering a bug in which the string was "read only"...


                while (isAlive)
                {
                    Display(sIncorrect, sUn, iLives, isHangman);
                    try
                    {
                        cInput = Console.ReadLine().ToUpper()[0];
                    }
                    catch
                    {
 
                    }

                    if (char.IsLetter(cInput))
                    {
                        if (sWordCaps.Contains(cInput))
                        {
                            if (sUn.ToString().Contains(cInput))
                            {

                            }
                            else
                            {
                                foreach (char cChar in sUnderscore)
                                {
                                    if (cChar == ',')
                                    {

                                    }
                                    else if (cInput == sWordCaps[iCounted])
                                    {
                                        iPointCounter += 2;
                                        sUn[iCounted] = sWordCaps[iCounted];
                                    }
                                    iCounted++;
                                }
                            }
                        }
                        else if (sIncorrect.Contains(cInput))
                        {

                        }
                        else
                        {
                            sIncorrect += cInput.ToString() + " ";
                            iLives--;
                        }
                    }
                    else
                    {
                        Invalid();
                    }
                    //This is the mechanism to replace underscores with words and check which words havent already been typed as well as awarding points and losing lives

                    if (iLives == 0)
                    {
                        Console.Clear();
                        Display(sIncorrect, sUn, iLives, isHangman);
                        if (isComputer)
                        {
                            RetroMusicPlayer.SoundLocation = sLose;
                            RetroMusicPlayer.Play();
                            Console.WriteLine("\n\n Computer wins... :(");
                            if (isArcade)
                            {
                                Console.WriteLine(" You have " + iWins.ToString() + " wins...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\n Player 1 wins!");
                        }                     
                        Console.WriteLine("\n The word was \"" + sWord + "\"!");
                        Console.Write("\n Press any key to continue...");
                        Console.ReadKey();
                        EndGame();
                    }
                    //This is the life counter, if your life is at 0, Endgame() is excecuted

                    if (iPointCounter == iLetter * 2)
                    {
                        Console.Clear();
                        Display(sIncorrect, sUn, iLives, isHangman);

                        if (isArcade)
                        {
                            iWins++;
                            Console.WriteLine("\n\n Nice! " + iLives.ToString() + " lives remaining!");
                            Console.WriteLine(" Your score is " + iWins.ToString() + "!");
                            iLives += 5;
                            Console.Write("\n\n Press any key to continue...");
                            Console.ReadKey();
                            isAlive = false;
                        }
                        else
                        {
                            RetroMusicPlayer.SoundLocation = sWin;
                            RetroMusicPlayer.Play();
                            if (isComputer)
                            {
                                Console.WriteLine("You win with " + iLives + " lives remaining!");
                            }
                            else
                            {
                                Console.WriteLine("\n\n Player 2 wins with " + iLives + " lives remaining!");
                            }
                            Console.WriteLine("\n The word was \"" + sWord + "\"!");
                            Console.Write("\n\n Press any key to continue...");
                            Console.ReadKey();
                            EndGame();
                        }
                    }
                    //This is your point counter, if you get the amount of points as the counted letters in sUnderscore(Which has spaces), Endgame() is excecuted. Unless it's arcade...

                    iCounted = 0;
                }
            }
        }


        static void Display(string _sIncorrect, StringBuilder _sUn, int _iLives, bool _isHangman)
        {
            Animation(_iLives, _sIncorrect, _isHangman);
            Console.WriteLine("\n\n\t  " + _sUn.Replace(',', ' '));
            Console.Write("\n\n Player 2 - Please insert a letter: ");
        }
        //This is to display anything needed into window.

        static void EndGame()
        {
            bool isAlive = true;
            char cYesNo = 'a';

            while (isAlive)
            {
                Console.Clear();
                Console.Write("\n Would you like to restart? (Y / N): ");
                try
                {
                    cYesNo = Console.ReadLine().ToUpper()[0];
                }
                catch
                {
                   
                }
                if (cYesNo == 'Y')
                {
                    Main();
                }
                else if (cYesNo == 'N')
                {
                    Environment.Exit(0);
                    // This code was inspired by https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console
                }
                else
                {
                    Invalid();
                }
            }
        }
        //This is for when the game has to end

        static void Invalid()
            {
                Console.Write("\n Please insert a valid input.\n\n Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        //Prompts the invalid reply if a wrong button is pressed

        static void Animation(int _iLives, string _sIncorrect, bool _isHangman)
        {
            Console.Clear();
            int i;

            if (_isHangman)
            {
                Console.WriteLine("\n\n\n\n\t     ____");
                Console.WriteLine("\t     |  |");
                if (_iLives >= 6)
                {
                    Console.WriteLine("\t     |  ");
                }
                else if (_iLives <= 5)
                {
                    Console.WriteLine("\t     |  O");
                }
                if (_iLives >= 5)
                {
                    Console.WriteLine("\t     |    ");
                }
                else if (_iLives == 4)
                {
                    Console.WriteLine("\t     |>-");
                }
                else if (_iLives == 3)
                {
                    Console.WriteLine("\t     |>- -<");
                }
                else if (_iLives <= 2)
                {
                    Console.WriteLine("\t     |>-|-<");
                }
                if (_iLives > 1)
                {
                    Console.WriteLine("\t     |");
                }              
                else if (_iLives == 1)
                {
                    Console.WriteLine("\t     | /");
                }
                else if (_iLives < 1)
                {
                    Console.WriteLine("\t     | / \\");
                }
                Console.WriteLine("\t     |");
                Console.WriteLine("\t     |");
                Console.WriteLine("\t     |\t\tMisses: " + _sIncorrect);
                Console.Write("\t    / \\");

                Console.Write("\t\tYou have ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(_iLives.ToString());
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" lives remaining.");
            }
            else if (!_isHangman)
            {
                Console.WriteLine("\t   |       |");
                Console.WriteLine("\t   |=======|");
                Console.WriteLine("\t   |  \\__  |");

                if (_iLives > 0)
                {
                    Console.WriteLine("\t   |     \\_|");
                }
                for (i = 2; i <= _iLives; i++)
                {
                    Console.WriteLine("\t   |       |");
                }

                if (_iLives == 0)
                {
                    Console.WriteLine("\t   |=====\\_|");
                }
                else
                {
                    Console.WriteLine("\t   |=======|");
                }

                if (_iLives >= 3)
                {
                    Console.WriteLine("\t   | ('_') |");
                }
                else if (_iLives == 3)
                {
                    Console.WriteLine("\t   | (o_o) |");
                }
                else if (_iLives == 2)
                {
                    Console.WriteLine("\t   | (O_O) |");
                }
                else if (_iLives == 1)
                {
                    Console.WriteLine("\t   | (;_;) |");
                }
                else if (_iLives == 0)
                {
                    Console.WriteLine("\t   | (x_x) |");
                }

                Console.WriteLine("\t   |=======|");
                Console.WriteLine("\t   |       |\tMisses: " + _sIncorrect);
                Console.WriteLine("\t   |       |");

                Console.Write("\t  []       []\tYou have ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(_iLives.ToString());
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" lives remaining.");
            }
        }

        static private void TextFileReader(StreamReader _f, IList<String> _StringList)
        {
            while (!_f.EndOfStream)
            {
                    _StringList.Add(_f.ReadLine());
            }
        }

        static void TitleScreen(bool _isHangman, SoundPlayer _RetroMusicPlayer)
        {
            if (_isHangman)
            {                
                _RetroMusicPlayer.SoundLocation = sHangSong;
                _RetroMusicPlayer.PlayLooping();

                Console.WriteLine("\n\n\n\n\n\n\n\n\n                                        HHHHHHHHH     HHHHHHHHH                                                                                                       ");                                                                                                            
                Console.WriteLine("                                        H:::::::H     H:::::::H                                                                                                                         ");
                Console.WriteLine("                                        H:::::::H     H:::::::H                                                                                                                         ");            
                Console.WriteLine("                                        HH::::::H     H::::::HH                                                                                                                         ");
                Console.WriteLine("                                          H:::::H     H:::::H    aaaaaaaaaaaaa  nnnn  nnnnnnnn       ggggggggg   ggggg   mmmmmmm    mmmmmmm     aaaaaaaaaaaaa  nnnn  nnnnnnnn           ");
                Console.WriteLine("                                          H:::::H     H:::::H    a::::::::::::a n:::nn::::::::nn    g:::::::::ggg::::g mm:::::::m  m:::::::mm   a::::::::::::a n:::nn::::::::nn         ");
                Console.WriteLine("                                          H::::::HHHHH::::::H    aaaaaaaaa:::::an::::::::::::::nn  g:::::::::::::::::gm::::::::::mm::::::::::m  aaaaaaaaa:::::an::::::::::::::nn        ");
                Console.WriteLine("                                          H:::::::::::::::::H             a::::ann:::::::::::::::ng::::::ggggg::::::ggm::::::::::::::::::::::m           a::::ann:::::::::::::::n       ");
                Console.WriteLine("                                          H:::::::::::::::::H      aaaaaaa:::::a  n:::::nnnn:::::ng:::::g     g:::::g m:::::mmm::::::mmm:::::m    aaaaaaa:::::a  n:::::nnnn:::::n       ");
                Console.WriteLine("                                          H::::::HHHHH::::::H    aa::::::::::::a  n::::n    n::::ng:::::g     g:::::g m::::m   m::::m   m::::m  aa::::::::::::a  n::::n    n::::n       ");
                Console.WriteLine("                                          H:::::H     H:::::H   a::::aaaa::::::a  n::::n    n::::ng:::::g     g:::::g m::::m   m::::m   m::::m a::::aaaa::::::a  n::::n    n::::n       ");
                Console.WriteLine("                                          H:::::H     H:::::H  a::::a    a:::::a  n::::n    n::::ng::::::g    g:::::g m::::m   m::::m   m::::ma::::a    a:::::a  n::::n    n::::n       ");
                Console.WriteLine("                                        HH::::::H     H::::::HHa::::a    a:::::a  n::::n    n::::ng:::::::ggggg:::::g m::::m   m::::m   m::::ma::::a    a:::::a  n::::n    n::::n       ");
                Console.WriteLine("                                        H:::::::H     H:::::::Ha:::::aaaa::::::a  n::::n    n::::n g::::::::::::::::g m::::m   m::::m   m::::ma:::::aaaa::::::a  n::::n    n::::n       ");
                Console.WriteLine("                                        H:::::::H     H:::::::H a::::::::::aa:::a n::::n    n::::n  gg::::::::::::::g m::::m   m::::m   m::::m a::::::::::aa:::a n::::n    n::::n       ");
                Console.WriteLine("                                        HHHHHHHHH     HHHHHHHHH  aaaaaaaaaa  aaaa nnnnnn    nnnnnn    gggggggg::::::g mmmmmm   mmmmmm   mmmmmm  aaaaaaaaaa  aaaa nnnnnn    nnnnnn       ");
                Console.WriteLine("                                                                                                              g:::::g                                                                   ");
                Console.WriteLine("                                                                                                  gggggg      g:::::g                                                                   ");
                Console.WriteLine("                                                                                                  g:::::gg   gg:::::g                                                                   ");
                Console.WriteLine("                                                                                                   g::::::ggg:::::::g                                                                   ");
                Console.WriteLine("                                                                                                    gg:::::::::::::g                                                                    ");
                Console.WriteLine("                                                                                                      ggg::::::gggg                                                                     ");
                Console.WriteLine("                                                                                                         gggggg                                                                         ");
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\tPress any key to start...");
                Console.SetWindowPosition(0, 0);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                _RetroMusicPlayer.SoundLocation = sGuillotineSong;
                _RetroMusicPlayer.PlayLooping();

                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n             GGGGGGGGGGGGG                    iiii  lllllll lllllll                           tttt            iiii                                       MMMMMMMM               MMMMMMMM                         ");
                Console.WriteLine("          GGG::::::::::::G                   i::::i l:::::l l:::::l                        ttt:::t           i::::i                                      M:::::::M             M:::::::M                                     ");
                Console.WriteLine("        GG:::::::::::::::G                    iiii  l:::::l l:::::l                        t:::::t            iiii                                       M::::::::M           M::::::::M                                     ");
                Console.WriteLine("       G:::::GGGGGGGG::::G                          l:::::l l:::::l                        t:::::t                                                       M:::::::::M         M:::::::::M                                     ");
                Console.WriteLine("      G:::::G       GGGGGGuuuuuu    uuuuuu  iiiiiii  l::::l  l::::l    ooooooooooo   ttttttt:::::ttttttt    iiiiiiinnnn  nnnnnnnn        eeeeeeeeeeee    M::::::::::M       M::::::::::M  aaaaaaaaaaaaa  nnnn  nnnnnnnn      ");
                Console.WriteLine("     G:::::G              u::::u    u::::u  i:::::i  l::::l  l::::l  oo:::::::::::oo t:::::::::::::::::t    i:::::in:::nn::::::::nn    ee::::::::::::ee  M:::::::::::M     M:::::::::::M  a::::::::::::a n:::nn::::::::nn    ");
                Console.WriteLine("     G:::::G              u::::u    u::::u   i::::i  l::::l  l::::l o:::::::::::::::ot:::::::::::::::::t     i::::in::::::::::::::nn  e::::::eeeee:::::eeM:::::::M::::M   M::::M:::::::M  aaaaaaaaa:::::an::::::::::::::nn   ");
                Console.WriteLine("     G:::::G    GGGGGGGGGGu::::u    u::::u   i::::i  l::::l  l::::l o:::::ooooo:::::otttttt:::::::tttttt     i::::inn:::::::::::::::ne::::::e     e:::::eM::::::M M::::M M::::M M::::::M           a::::ann:::::::::::::::n  ");
                Console.WriteLine("     G:::::G    G::::::::Gu::::u    u::::u   i::::i  l::::l  l::::l o::::o     o::::o      t:::::t           i::::i  n:::::nnnn:::::ne:::::::eeeee::::::eM::::::M  M::::M::::M  M::::::M    aaaaaaa:::::a  n:::::nnnn:::::n  ");
                Console.WriteLine("     G:::::G    GGGGG::::Gu::::u    u::::u   i::::i  l::::l  l::::l o::::o     o::::o      t:::::t           i::::i  n::::n    n::::ne:::::::::::::::::e M::::::M   M:::::::M   M::::::M  aa::::::::::::a  n::::n    n::::n  ");
                Console.WriteLine("     G:::::G        G::::Gu::::u    u::::u   i::::i  l::::l  l::::l o::::o     o::::o      t:::::t           i::::i  n::::n    n::::ne::::::eeeeeeeeeee  M::::::M    M:::::M    M::::::M a::::aaaa::::::a  n::::n    n::::n  ");
                Console.WriteLine("      G:::::G       G::::Gu:::::uuuu:::::u   i::::i  l::::l  l::::l o::::o     o::::o      t:::::t    tttttt i::::i  n::::n    n::::ne:::::::e           M::::::M     MMMMM     M::::::Ma::::a    a:::::a  n::::n    n::::n  ");
                Console.WriteLine("       G:::::GGGGGGGG::::Gu:::::::::::::::uui::::::il::::::ll::::::lo:::::ooooo:::::o      t::::::tttt:::::ti::::::i n::::n    n::::ne::::::::e          M::::::M               M::::::Ma::::a    a:::::a  n::::n    n::::n  ");
                Console.WriteLine("        GG:::::::::::::::G u:::::::::::::::ui::::::il::::::ll::::::lo:::::::::::::::o      tt::::::::::::::ti::::::i n::::n    n::::n e::::::::eeeeeeee  M::::::M               M::::::Ma:::::aaaa::::::a  n::::n    n::::n  ");
                Console.WriteLine("          GGG::::::GGG:::G  uu::::::::uu:::ui::::::il::::::ll::::::l oo:::::::::::oo         tt:::::::::::tti::::::i n::::n    n::::n  ee:::::::::::::e  M::::::M               M::::::M a::::::::::aa:::a n::::n    n::::n  ");
                Console.WriteLine("             GGGGGG   GGGG    uuuuuuuu  uuuuiiiiiiiillllllllllllllll   ooooooooooo             ttttttttttt  iiiiiiii nnnnnn    nnnnnn    eeeeeeeeeeeeee  MMMMMMMM               MMMMMMMM  aaaaaaaaaa  aaaa nnnnnn    nnnnnn  ");
                Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tPress any key to start...");
                Console.SetWindowPosition(0, 0);
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void EasterEgg(SoundPlayer _RetroMusicPlayer)
        {
            Console.Clear();
            _RetroMusicPlayer.SoundLocation = sEasterEgg;
            _RetroMusicPlayer.PlayLooping();
            Console.WriteLine("   __.--~~.,-.__");
            Console.WriteLine("   `~-._.-(`-.__`-.");
            Console.WriteLine("           \\    `~~`");
            Console.WriteLine("      .--./ \\");
            Console.WriteLine("     /#   \\  \\.--.");
            Console.WriteLine("     \\    /  /#   \\");
            Console.WriteLine("      '--'   \\    /");
            Console.WriteLine("              '--'");
            Console.WriteLine("");
            for (int i = 0; i < 2500; i++)
            {
                Console.Write("rero");
            }
            Console.WriteLine("\n\n   Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }

    
    }

}


