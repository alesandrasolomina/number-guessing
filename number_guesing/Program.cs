namespace number_guessing;
class Program
{
    static void Main(string[] args)
    {
        // greetings
        Console.WriteLine("hello stranger. this is a number guessing game");

        // requiring the game mode
        string? modeInp = "";
        do
        {
            Console.WriteLine("pick a mode. do you wanna be the guesser?(yes or no answers pls)");
            modeInp = Console.ReadLine();
        }

        while (modeInp != "yes" && modeInp != "no");

        // setting the game variables - CAN THE GUESSER BE ENUM?
        bool isMachineGuessing;
        int attempts;
        string guesser;

        if (modeInp == "no")
        {
            isMachineGuessing = true;
            guesser = "the machine";
        }
        else
        {
            isMachineGuessing = false;
            guesser = "yourself";
        }

        // method to check that user entered a num
        static int GetInt()
        {
            var inpt = Console.ReadLine();
            int num = 0;
            if (int.TryParse(inpt, out num))
            {
                num = int.Parse(inpt);
            }
            else
            {
                Console.WriteLine("a number (not zero) is needed");
            }
            return num;
        }

        // requiring number of attempts
        do
        {
            Console.WriteLine($"how many guessing attempts do you wanna grant to {guesser}?");
            attempts = GetInt();
        }

        while (attempts == 0);



        // initializing a game object. probably need to add number range choice as well(following section and previous)
        var game = new Game(isMachineGuessing, attempts, 0, 100);
        game.BinSearch();

    }

    // maybe need to restrict number of attempts to max int 
    // maybe need to let input min and max number
    // make the lines more readable


}
