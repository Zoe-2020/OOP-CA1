using System;
using System.Collections.Generic;
using System.Text;

namespace CAT
{
    class card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int point { get; set; }

        public int ACE { get; set; }

        private int one = 1;
        private int two = 2;
        private int three = 3;
        private int four = 4;
        private int five = 5;
        private int six = 6;
        private int seven = 7;
        private int eight = 8;
        private int nine = 9;
        private int ten = 10;
        



        public int points
        {
            get
            {
                if (Rank == "Ace")
                {
                    return ACE;
                } 
                else if (Rank == "2")
                {
                    return 2;
                }
                else if (Rank == "3")
                {
                    return 3;
                }
                else if (Rank == "4")
                {
                    return 4;
                }
                else if (Rank == "5")
                {
                    return 5;
                }
                else if (Rank == "6")
                {
                    return 6;
                }
                else if (Rank == "7")
                {
                    return 7;
                }
                else if (Rank == "8")
                {
                    return 8;
                }
                else if (Rank == "9")
                {
                    return 9;
                }
                else if (Rank == "10")
                {
                    return 10;
                }
                else if (Rank == "Jack")
                {
                    return 10;
                }
                else if (Rank == "Queen")
                {
                    return 10;
                }
                else
                {
                    return 10;
                }
            }
            set
            {

                if (Rank == "Ace")
                {
                    ACE= point;
                } 
                else if (Rank == "2")
                {
                    two = point;
                }
                else if (Rank == "3")
                {
                    three = point;
                }
                else if (Rank == "4")
                {
                    four = point;
                }
                else if (Rank == "5")
                {
                    five = point;
                }
                else if (Rank == "6")
                {
                    six = point;
                }
                else if (Rank == "7")
                {
                    seven = point;
                }
                else if (Rank == "8")
                {
                    eight = point;
                }
                else if (Rank == "9")
                {
                   nine = point;
                }
                else if (Rank == "10")
                {
                    ten = point;
                }
                else if (Rank == "Jack")
                {
                    ten= point;
                }
                else if (Rank == "Queen")
                {
                    ten = point;
                }
                else
                {
                    ten = point;
                }
                
            }
        }
        



        public card(string s,string r , int c)
        {
            Suit = s;
            points = c;
            Rank = r;
          
            
        }

        public card()
        {
        }

       

        public override string ToString()
        {
            return  Rank + " of " + Suit + " with value " + points  ;
        }
       

       


        




    }
}
