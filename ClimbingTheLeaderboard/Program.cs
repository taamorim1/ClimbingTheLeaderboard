using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingTheLeaderboard
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the total number of scores");
            int cScores = EnterIntValue();

            int i = 0;
            int[] scores = new int[cScores];

            while(i < cScores)
            {
                Console.WriteLine("Enter the " + (i + 1) + "º score");
                scores[i] = EnterIntValue();

                i++;
            }
            Console.WriteLine("Enter the total number of Alice scores");

            var cAlice = EnterIntValue();
            int[] alice = new int[cAlice];

            int c = 0;

            while(c < cAlice)
            {
                Console.WriteLine("Enter the " + (i + 1) + "º Alice score");
                alice[c] = EnterIntValue();
                c++;
            }

            var AlicesPositions = climbingLeaderboard(scores, alice);

            Console.WriteLine(string.Join(" ", AlicesPositions));
            Console.ReadKey();
        }

        private static int EnterIntValue()
        {
            int c;

            while(!int.TryParse(Console.ReadLine(), out c))
            {
                Console.WriteLine("Please enter a number value");
            }
            return c;
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {

            var scoresWPositions = SetScoresPositions(scores);
            var sLen = scoresWPositions.Length - 1;
            var aLen = alice.Length;
            int[] result = new int[aLen];

            int lastIndex = sLen;

            for (int iA = 0; iA < aLen; iA++)
            {

                var aliceScore = alice[iA];
                int position = 1;

                for (int i = lastIndex; i >= 0; i--)
                {
                    var scoreVal = scoresWPositions[i][0];
                    var positionVal = scoresWPositions[i][1];


                    if (aliceScore < scoreVal)
                    {
                        position = positionVal + 1;
                        break;
                    }

                    lastIndex = i;
                }

                result[iA] = position;
            }

            return result;

        }

        public static int[][] SetScoresPositions(int[] scores)
        {
            Array.Sort(scores);
            Array.Reverse(scores);
            int lastS = int.MaxValue;
            int lastP = 0;
            int arrSize = scores.Length;

            int[][] result = new int[arrSize][];

            for (int i = 0; i < arrSize; i++)
            {
                var val = scores[i];

                if (val < lastS)
                    lastP += 1;

                lastS = val;
                result[i] = new int[] { val, lastP };

            }

            return result;
        }
    }
}
