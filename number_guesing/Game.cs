namespace number_guessing;
class Game
        {
            public Game(bool isMachineGuessing, int attempts, int first, int last)
            {
                IsMachineGuessing = isMachineGuessing;
                Attempts = attempts;
                First = first;
                Last = last;

            }
            
            public int Attempts { get; set;}
            public bool IsMachineGuessing {get; set;}

            public int First { get; set;}
            public int Last { get; set;}

            public void RulesExplaining()
            {
                if (IsMachineGuessing)
                {
                    Console.WriteLine($"pick a number from 0 to 100(including). do not tell anybody yet. machine is gonna try to guess the number in {this.Attempts} attempts");
                    Console.WriteLine("if the guess was right - type 'yes', otherwise - type 'no'");
                    Console.WriteLine("also type '-'(minus), if your number is less than the guess");
                    Console.WriteLine("or '+'(plus) if your number is more");
                }
                else
                {
                    Console.WriteLine($"you have {this.Attempts} attempts");
                }
            }
            public void BinSearch()
            {
                if (IsMachineGuessing)
                {
                    do 
                    {
                        // starting with the middle of the given range
                        
                        int middle = (this.Last - this.First) / 2 + this.First;

                        //requiring yes or no answer
                        string? answer = "";
                        do 
                        {
                            Console.WriteLine($"is your number {middle}? yes or no answers pls)");
                            answer = Console.ReadLine();
                        }
                        while (answer != "yes" && answer != "no");

                        
                        this.Attempts --;

                        // right guess flow
                        if (answer == "yes")
                        {
                        Console.WriteLine($"great, the number is guessed. thanks for the game");
                        break;
                        }

                        // wrong guess flow
                        string? moreOrLess = "";
                        // requiring additional info (is number more or less)
                        do 
                        {
                            Console.WriteLine("type '-'(minus), if your number is less than the guess. or '+'(plus) if your number is more");
                            moreOrLess = Console.ReadLine();
                            if (moreOrLess =="-")
                            {
                                this.Last = middle;
                            }
                            else if (moreOrLess == "+")
                            {
                                this.First = middle;
                            }
                        }
                        while (moreOrLess != "-" && moreOrLess != "+");
                        

                    }
                    
                    while (this.Attempts > 0);

                }
                else
                {
                    Random rnd = new Random();
                    int num = rnd.Next(this.First, this.Last);
                    int guess;
                        do 
                        {
                            // making sure the input is a number from range
                            bool isInputIncorrect;
                            do 
                            {
                                Console.WriteLine($"type in your guess. it should be the number from {this.First} to {this.Last}");
                                var inpt = Console.ReadLine();

                                if (int.TryParse(inpt, out guess) && int.Parse(inpt)<= this.Last && int.Parse(inpt) >= this.First)
                                {
                                    guess = int.Parse(inpt);
                                    isInputIncorrect = false; 
                                }
                                else if (int.TryParse(inpt, out guess) && (int.Parse(inpt) >  this.Last || int.Parse(inpt) < this.First))
                                {
                                    Console.WriteLine($"from {this.First} to {this.Last} :)");
                                    isInputIncorrect = true;
                                }
                                else
                                {
                                    Console.WriteLine("a NUMBER is needed");
                                    isInputIncorrect = true;
                                }

                            }
                            while (isInputIncorrect);

                            this.Attempts --;

                            // right guess flow just in case
                            if (guess == num)
                            {
                            Console.WriteLine("great, the number is guessed. thanks for the game");
                            break;
                            }
                            
                            // wrong guess scenario
                            Console.WriteLine($"sorry, {guess} is a wrong guess");
                        }

                        // keep asking until the number is guessed and there are attempts left
                        while (guess != num && this.Attempts > 0);
                }
                // letting know the attempts are over
                Console.WriteLine($"there are no more attempts");
           
            }      
        }