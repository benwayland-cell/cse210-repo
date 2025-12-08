
class UserInterface
{
    // the prompt given for the main menu
    private static string[] mainMenuPrompt = [
        "Input a number to choose what you want to do.",
        "1 - Memorize Scripture",
        "2 - Load Scriptures from file",
        "3 - Quit"
    ];
    private const int MemorizeScriptureNum = 1;
    private const int LoadScriptureFromFileNum = 2;
    // private const int WriteNewScriptureNum = 3;
    private const int QuitNum = 3;
    
    /* Takes all of the scriptures in "filename" and puts it into a list of scriptures */
    private static List<Scripture> ConvertFileToScriptures(string filename)
    {
        // init the list of scriptures we will return
        List<Scripture> scriptureList = new List<Scripture>();

        // Get the lines in the file
        string[] lines = System.IO.File.ReadAllLines(filename);

        // initialization for the loop

        // is true if the next line will start a new scripture
        bool nextLineNewScripture = true;
        // where we'll store the reference that we will add
        Reference newReference = null;
        // where we'll store the verses that we will add
        List<List<Word>> newVerses = new List<List<Word>>();

        foreach (string line in lines)
        {
            if (line == "" && newReference != null && newVerses.Count > 0)
            {
                // we're at a dividing empty line so we add the scripture to the list

                // add the current data we have to a new scripture in scriptureList
                scriptureList.Add(new Scripture(newReference, newVerses));
                newReference = null;
                newVerses = new List<List<Word>>();
                
                nextLineNewScripture = true;
            }
            else if (nextLineNewScripture)
            {
                // we are now looking at the reference and need to parse it
                newReference = StringToReference(line);
                nextLineNewScripture = false;
            }
            else
            {
                // we are looking at a line that has a verse
                newVerses.Add(StringToVerse(line));
            }
        }

        // add the current data for a scripture in case we haven't added it yet
        if (newReference != null && newVerses.Count > 0)
        {
            scriptureList.Add(new Scripture(newReference, newVerses));
        }

        return scriptureList;
    }

    /* Converts a string to a reference
    The string must be formatted like:
    Book chapter:startVerse-endVerse
    or like:
    Book chapter:startVerse

    e.g.
    1 Nephi 3:7-8
    Mosiah 2:17

    Parameters:
        string referenceString: the string that we will be converting
    Return:
        A Reference object with the correct attributes
     */
    private static Reference StringToReference(string referenceString)
    {
        // the book and the numbers after it
        // the next loop will find these two
        string book = "";
        string referenceNumbers = "";

        // search for the first number in the reference, ignore the first
        // (because it could be something like "1 Nephi")
        for (int charIndex = 1; charIndex < referenceString.Count(); charIndex++)
        {
            char currentChar = referenceString[charIndex];
            if (Char.IsNumber(currentChar))
            {
                // splice the line into the book and reference numbers
                book = referenceString.Substring(0, charIndex);
                referenceNumbers = referenceString.Substring(charIndex);
                break;
            }
        }

        // splice the reference numbers so we can get the chapter and verses
        string[] referenceNumbersSplit = referenceNumbers.Split(":");
        int chapter = int.Parse(referenceNumbersSplit[0].Trim());
        string verses = referenceNumbersSplit[1].Trim();

        // get the start and end verse from verses
        int startVerse;
        int endVerse;

        if (!verses.Contains("-"))
        {
            startVerse = int.Parse(verses);
            endVerse = startVerse;
        }
        else
        {
            string[] versesSplit = verses.Split("-");
            startVerse = int.Parse(versesSplit[0].Trim());
            endVerse = int.Parse(versesSplit[1].Trim());
        }



        book = book.Trim();

        return new Reference(book, chapter, startVerse, endVerse);
    }

    /* Converts a string of a verse into a list of Word objects*/
    private static List<Word> StringToVerse(string verseString)
    {
        string[] words = verseString.Split(" ");

        List<Word> willReturn = new List<Word>();
        foreach (string word in words)
        {
            willReturn.Add(new Word(word));
        }

        return willReturn;
    }

    /* Shows the scripture, waits for user to let the program run, hide words in scripture, loop.
    Parameters:
        Scripture scripture: The scripture we will display
     */
    private static void RunMemorizeScripture(Scripture scripture)
    {
        string[] validExitStrings = ["quit", "q"];
        
        string userInput = "";
        bool allWordsHidden = false;
        bool done = false;
        while (!done)
        {
            // show the scripture
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

            // get user input. Also lowercase it
            userInput = Console.ReadLine().ToLower();

            // check if all the words are hidden
            if (allWordsHidden)
            {
                break;
            }

            // hide the words
            allWordsHidden = scripture.HideWords();

            // check if the user input is the same as a string in validExitStrings
            foreach(string exitString in validExitStrings)
            {
                if (exitString == userInput)
                {
                    done = true;
                }
            }
        }

        // clean up the scripture
        scripture.Show();
    }

    /* Gets a number from the user until it is valid.
    Parameters:
        int startBound: The minimum number the output can be (inclusive)
        int endBound: The maximum number the output can be (inclusive)
    */
    private static int GetUserInputInBounds(int startBound, int endBound)
    {
        string userInputString;
        int userInputInt;
        while (true)
        {
            userInputString = Console.ReadLine();


            if (Int32.TryParse(userInputString, out userInputInt))
            {
                if (startBound <= userInputInt && userInputInt <= endBound)
                {
                    return userInputInt;
                }
            }

            Console.WriteLine($"User input invalid, Try again. ({startBound}-{endBound})");
            
        }
    }

    /* Prompts the user to choose a scripture from the given list. It then runs the memorizer on that scripture */
    private static void ChooseScriptureToMemorize(List<Scripture> scriptureList)
    {
        // print each scripture in scriptureList and number each
        Console.Clear();
        for (int scriptureIndex = 0; scriptureIndex < scriptureList.Count(); scriptureIndex++)
        {
            Console.WriteLine($"{scriptureIndex + 1}:");
            scriptureList[scriptureIndex].Display();
            Console.WriteLine();
        }
        
        // get a scripture number from the user
        Console.WriteLine("Choose a scripture: ");
        int userInput = GetUserInputInBounds(1, scriptureList.Count());

        // get the scripture and run the program
        Scripture scriptureToMemorize = scriptureList[userInput - 1];
        RunMemorizeScripture(scriptureToMemorize );
    }

    /* Loads scriptures from a file and adds them to scriptureList */
    private static void LoadScriptureFromFile(ref List<Scripture> scriptureList)
    {
        Console.Clear();
        Console.WriteLine("Input filename to read from.");
        string filename = Console.ReadLine();
        scriptureList.AddRange(ConvertFileToScriptures(filename));
    }

    /* The loop that runs the main menu */
    public static void MainLoop()
    {
        List<Scripture> scriptureList = new List<Scripture>();
        
        int userInput = 0;
        bool done = false;

        while(!done)
        {
            // print the main menu prompt
            Console.Clear();
            foreach(string line in mainMenuPrompt)
            {
                Console.WriteLine(line);
            }

            // get user input
            userInput = GetUserInputInBounds(MemorizeScriptureNum, QuitNum);

            switch (userInput)
            {
                case MemorizeScriptureNum:
                    // Console.WriteLine("Memorize Scripture");
                    ChooseScriptureToMemorize(scriptureList);
                    break;

                case LoadScriptureFromFileNum:
                    // Console.WriteLine("Load scripture from file");
                    LoadScriptureFromFile(ref scriptureList);
                    break;

                case QuitNum:
                    done = true;
                    break;
            }
        }
    }
}