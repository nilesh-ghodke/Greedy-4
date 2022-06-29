using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
    public class MinimumDominoRotaions
    {
        /*
         * T.C: O(N) 
         * S.C: O(1)
         */
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            if (tops == null || tops.Length == 0) return 0;

            int top = findMinRotation(tops, bottoms, tops[0]);

            if (top != -1)
            {
                return top;
            }

            return findMinRotation(tops, bottoms, bottoms[0]);
        }


        //Other way of doing it with no change in Time and Space Complexity
        public int MinDominoRotations1(int[] tops, int[] bottoms)
        {
            if (tops == null || tops.Length == 0) return 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            int target = 0;
            for (int i = 0; i < tops.Length; i++)
            {
                int top = tops[i];
                if (!map.ContainsKey(top))
                {
                    map.Add(top, 1);
                }
                else
                {
                    map[top]++;

                    if (map[top] == tops.Length)
                    {
                        target = top;
                        break;
                    }
                }

                int bottom = bottoms[i];
                if (!map.ContainsKey(bottom))
                {
                    map.Add(bottom, 1);
                }
                else
                {
                    map[bottom]++;

                    if (map[bottom] == bottoms.Length)
                    {
                        target = bottom;
                        break;
                    }
                }


            }

            return findMinRotation(tops, bottoms, target);
        }

        private int findMinRotation(int[] tops, int[] bottoms, int num)
        {
            int topRotation = 0;
            int bottomRotation = 0;
            int Rotation = 0;
            for (int i = 0; i < tops.Length; i++)
            {
                if (tops[i] != num && bottoms[i] != num)
                {
                    return -1;
                }
                else if (tops[i] != num)
                {
                    topRotation++;
                }
                else if (bottoms[i] != num)
                {
                    bottomRotation++;
                }
            }

            Rotation = Math.Min(topRotation, bottomRotation);
            return Rotation;
        }


    }
}
