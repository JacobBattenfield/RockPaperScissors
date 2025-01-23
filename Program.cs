using System.Formats.Asn1;
using System.Security.Cryptography;

class Program{
    static void Main(){
        Prompt([0,0]);
    }
    static void Prompt(int[] points){
        Console.WriteLine("Welcome To Rock Paper Scissors");
        Console.WriteLine("Please Input R for Rock, P for Paper or S for Scissors");
        string answer = Console.ReadLine()!.ToUpper();
        if(answer=="R"){
            Console.WriteLine("You Chose Rock!");
            GetBotMove("Rock",points);
        }else if(answer == "P"){
            Console.WriteLine("You Chose Paper");
            GetBotMove("Paper",points);
        }else if(answer == "S"){
            Console.WriteLine("You Chose Scissors");
            GetBotMove("Scissors",points);
        }else{
            Console.WriteLine("Your Input Was Incorrect. Restarting");
            Thread.Sleep(1000);
            Console.Clear();
            Prompt(points);
        }
    }
    static void GetBotMove(string answer, int[] points){
        Random random = new();
        Console.WriteLine("Waiting For Bot To Play Its Move");
        int choice = random.Next(3);
        string botAnswer = "";
        if(choice==0)botAnswer="Rock";
        else if(choice==1)botAnswer="Paper";
        else if(choice==2)botAnswer="Scissors";
        Thread.Sleep(2000);
        Console.WriteLine("-------");
        CompareBotAndHuman(answer,botAnswer,points);
    }
    static void CompareBotAndHuman(string answer,string botAnswer, int[] points){
        Console.WriteLine($"Bot Chose {botAnswer}");
        Console.WriteLine("-------");
        Thread.Sleep(2000);
        if(answer==botAnswer){
            Console.WriteLine("It Is A Tie, No Side Is Awarded A Point");
        }else if(answer=="Paper" && botAnswer=="Scissors"){
            Console.WriteLine("Computer Wins! One Point Awarded To The Bot");
            points[1]++;
        }else if(answer=="Paper" && botAnswer=="Rock"){
            Console.WriteLine("Player Wins! One Point Awarded To The Player");
            points[0]++;
        }else if(answer=="Rock" && botAnswer=="Paper"){
            Console.WriteLine("Computer Wins! One Point Awarded To The Bot");
            points[1]++;
        }else if(answer=="Rock" && botAnswer=="Scissors"){
            Console.WriteLine("Player Wins! One Point Awarded To The Player");
            points[0]++;
        }else if(answer=="Scissors" && botAnswer=="Rock"){
            Console.WriteLine("Computer Wins! One Point Awarded To The Bot");
            points[1]++;
        }else if(answer=="Scissors" && botAnswer=="Paper"){
            Console.WriteLine("Player Wins! One Point Awarded To The Player");
            points[0]++;
        }
        Console.WriteLine($"Current Points Are (Player: {points[0]}), (Bot: {points[1]})");
        Console.WriteLine();
        Console.WriteLine("Would You Like To Play Again? (Y/N)");
        string response = Console.ReadLine()!.ToUpper();
        if(response=="Y"){
            Console.Clear();
            Prompt(points);
        }else{
            Console.WriteLine("Quitting...");
            Thread.Sleep(2000);
            Console.Clear();
            return;
        }
    }
}