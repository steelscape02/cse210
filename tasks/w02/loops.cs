void playGame(){
    Random randomGenerator = new Random();
    int guess_count = 0;
    Console.Write("Please enter the maximum number you want: ");
    int range = Convert.ToInt32(Console.ReadLine());
    int actual = randomGenerator.Next(1, range);
    int guess = 0;
    while(guess != actual){
        guess_count += 1;
        Console.Write("Please enter guess: ");
        guess = Convert.ToInt32(Console.ReadLine());
        if(guess == actual){
            Console.WriteLine($"Guess Correct!\nIt took you {guess_count} guesses to guess the mystery number.");
        }else if(guess > actual){
            Console.WriteLine("Lower");
        }else if(guess < actual){
            Console.WriteLine("Higher");
        }
    }
}

Console.WriteLine("Welcome to the number guesser!");
playGame();
Console.WriteLine("Thank you for playing!\n");
Console.Write("Would you like to play again?: ");
string play = Console.ReadLine();
Console.WriteLine("\n");
if (play == "yes"){
    Console.WriteLine("Here we go!");
    playGame();
}else{
    Console.WriteLine("Thank you!");
}