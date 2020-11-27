using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace CAT
{
    class Program
    {

        static int[] playerPointArr = new int[10]; // array of all the players points
        static int[] dealerPointArr = new int[10]; // array of all the Dealer points
        static int[] TwistPointCount = new int[2]; // TwistPointCount[0] counts up for playerPointArr & dealerPointArr
        static int PlayerTwistcount = 2; // if the Player twists it will start the count at 2 and go up ever time they twist
        static int DealerTwistcount = 2; // if the Dealer twists it will start the count at 2 and go up ever time they twist
        static int[] countWLD = new int[4]; //count win lose draw and number of games
        static int[] totalPoints = new int[2];// totalPoints[0] is sum of playerPointArr & totalPoints[1]  is sum of dealerPointArr
        static List<card> deck = CreateCards();

        static void Main(string[] args)
        {
            
            FirstCards(); //calls the first 2 cards

        }
        public static void FirstCards()
        {
            Shuffle(deck);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("You delt {0}", deck[i]); // prints the fist 2 cards


                if (deck[i].Rank == "Ace")//if get ace has to input value
                {
                    Console.WriteLine("would you like ace to equal 1 or 11");
                    String aceValue = Console.ReadLine();
                    if (aceValue == "1")
                    {
                        deck[i].ACE = 1;
                    }
                    else if (aceValue == "11")
                    {
                        deck[i].ACE = 11;
                    }
                }
                
            }

            playerPointArr[0] = deck[0].points + deck[1].points; // add the points for both cards
            Console.WriteLine("Points this turn:{0}", playerPointArr[0]); // print out sum of points

            question();

        }

        public static void question()
        {
            Console.WriteLine("Stick or twist s/t:");
            String input = Console.ReadLine();

            if (input == "t")
            {
                PlayerTwistcount++; // counts the number of twists from 2 to print out card 
                TwistPointCount[0]++; // counts the number of twists from 0 to be used in the array of points collected each turn
                twist();

            }
            else
            {
                Dealer(); // dealer play
            }


        }
        public static void twist()
        {
            Console.WriteLine("You delt {0}",deck[PlayerTwistcount]); // will print out player 
            

            if (deck[PlayerTwistcount].Rank == "Ace") //if get ace has to input value
            {
                Console.WriteLine("would you like ace to equal 1 or 11");
                String aceValue = Console.ReadLine();
                if (aceValue == "1")
                {
                    deck[PlayerTwistcount].ACE = 1;
                   
                }
                else if (aceValue == "11")
                {
                    deck[PlayerTwistcount].ACE = 11;
                    
                }
            }

            playerPointArr[TwistPointCount[0]] = deck[PlayerTwistcount].points;//adds the points of this twist to point array
            totalPoints[0] = playerPointArr.Sum(); //add all the points collected in playerPointArr
            Console.WriteLine("total points:{0}", totalPoints[0]); // prints it out

            if (totalPoints[0] < 21) // if less than then it will as to s/t again
            {
                question();
            }
            else // if more than 21 it will be a bust
            { 
                countWLD[0]++; // counts lose
                Console.WriteLine("YOU WENT BUST");

                Menu(); 
            }

        }
        public static void Dealer()
        {
   

            Console.WriteLine("--------------Dealers Turns--------------");
            Shuffle(deck);
            for (int x = 0; x < 2; x++)
            {
                Console.WriteLine("dealer delt {0}", deck[x]); // print the first 2 card of of dealer
              //  Console.WriteLine("dealer delt{0}", deck[randDealer[x]]);

               
                if (deck[x].Rank == "Ace") //if get ace has to input value
                {

                    Random rnd = new Random();

                    if ((rnd.Next() & 1) == 0) // equal chance of get 1 or 11 at random
                    {
                        deck[x].ACE = 1;
                        Console.WriteLine("Ace equals 1");
                    }
                    else
                    {
                        deck[x].ACE = 11;
                        Console.WriteLine("Ace equals 11");
                    }

                }

            }

            dealerPointArr[0] = deck[0].points + deck[1].points; //add points of 2 cards into dealerPointArr
            Console.WriteLine("dealer Total is:{0}", dealerPointArr[0]);
            
            if (dealerPointArr[0] < 17) //if less than 17 than dealer will twist
            {
                DealerTwist();
            }
            else
            {
                totalPoints[1] = dealerPointArr.Sum();
                winner();
            }

        }

        public static void DealerTwist()
        {
            Shuffle(deck);
            DealerTwistcount++; //counts the number of dealer twist from 2
            TwistPointCount[1]++; //counts from 0 to be used in dealerPointArr

            Console.WriteLine("--------------The Dealer twisted--------------");
        //    Console.WriteLine("dealer delt {0}", deck[randDealer[DealerTwistcount]]);
            Console.WriteLine("dealer delt {0}", deck[DealerTwistcount]);

            if (deck[DealerTwistcount].Rank == "Ace") // if get ace has to input the value
            {
                Random rnd = new Random();

                if ((rnd.Next() & 1) == 0) // equal chance of get 1 or 11 at random
                {
                    deck[DealerTwistcount].ACE = 1;
                    Console.WriteLine("Ace equals 1");
                }
                else
                {
                    deck[DealerTwistcount].ACE = 11;
                    Console.WriteLine("Ace equals 11");
                }

                
            }


            dealerPointArr[TwistPointCount[1]] = deck[DealerTwistcount].points; //add points of card from each twist
            totalPoints[1] = dealerPointArr.Sum(); //adds all the points collected in array dealerPointArr[TwistPointCount[1]]
            Console.WriteLine("Dealer Points total:{0}", totalPoints[1]);

            if ((totalPoints[1] > 17) && (totalPoints[1] < 21)) // between 17-21 will go to compare stage
            {
               
                winner();
            }
            else if (totalPoints[1] < 17) // if less than 17 will do another twist
            {
                DealerTwist();
            }
            else if (totalPoints[1] > 21) // if more than 21 the dealer has gone bust
            {

                countWLD[1]++; //counts player win
                Console.WriteLine("DEALER WENT BUST!");
                Console.WriteLine("YOU WIN!");
                Menu();

            }

        }
        public static void winner()
        {
            Console.WriteLine("-----------------Results-----------------");
            if (totalPoints[0] < totalPoints[1])
            {
                Console.WriteLine("DEALER WINS");
               
                countWLD[0]++; // counts Player losses
            }
            else if (totalPoints[0] > totalPoints[1])
            {
                Console.WriteLine("YOU WIN");
                
                countWLD[1]++; //counts player wins
            }
            else if (totalPoints[0] == totalPoints[1])
            {
                Console.WriteLine("YOU DREW WITH DEALER");
              
                countWLD[2]++; //counts player draws
            }

            Menu();
        }
        public static void Menu()
        {
           
            countWLD[3]++;
            Console.WriteLine("------------------Menu------------------");
            Console.WriteLine("Input the number of the option you would like to pick:");
            Console.WriteLine("1)Play another game");
            Console.WriteLine("2)See your Win, Lose and Draw  record");
            Console.WriteLine("3)End");
            switch (Console.ReadLine())
            {
                case "1":
                    //resets so points for next game
                    TwistPointCount[0] = 0;
                    TwistPointCount[1] = 0;
                    PlayerTwistcount = 2;
                    DealerTwistcount = 2;
                    totalPoints[0] = 0;
                    totalPoints[1] = 0;
                    FirstCards();
                    break;
                case "2":
                    PlayerRecord(); 
                    break;
                case "3":
                    Console.WriteLine("Thank you for playing!");
                    break;
            }
        
        }
        public static void PlayerRecord() //additional feature
        {
            Console.WriteLine("------Win, Lose and Draw  record------");
            Console.WriteLine("{0,15}{1,10}","Win:", countWLD[1]);
            Console.WriteLine("{0,15}{1,10}","Lose:", countWLD[0]);
            Console.WriteLine("{0,15}{1,10}","Draw:", countWLD[2]);
            Console.WriteLine("{0,15}{1,10}","Total games:", countWLD[3]);
            Menu();

        }
       
        private static List<card> CreateCards() //creats deck
        {
            string[] suits = { "Diomands", "Spades", "Clubs", "Hearts" };
            string[] ranks = { "Ace" , "2",  "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "king"};

            List<card> deck = new List<card>();

            for (int i = 0; i < suits.Length; i++)      
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    card c = new card();
                    c.Suit = suits[i];
                    c.Rank = ranks[j];
                    deck.Add(c);
                }
            }
            return deck;

        }
        private static void Shuffle(List<card> deck) //shuffle deck
        {
            Random rand = new Random();
            card temp = new card();
            int cardNumber;
            for (int i = 0; i < deck.Count; i++)
            {
                cardNumber = rand.Next(deck.Count);
                temp = deck.ElementAt(i);
                deck[i] = deck.ElementAt(cardNumber);
                deck[cardNumber] = temp;
            }
        }

    }
 }
    

            
   