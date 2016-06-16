namespace Problem05.LongestIncreasingSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSequence
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> longestInputSeq = new List<int>();
            List<List<int>> longestInputDB = new List<List<int>>();

            for (int i = 1; i < input.Length; i++)
            {
                int currentNumber = input[i];
                int prevNumber = input[i - 1];

                if (prevNumber < currentNumber) //if the sequence is increasing, add the number
                {
                    longestInputSeq.Add(prevNumber);
                }
                else
                {
                    longestInputSeq.Add(prevNumber); //when the current number is the last of the subsequence, add it
                    longestInputDB.Add(new List<int>(longestInputSeq.GetRange(0, longestInputSeq.Count))); //add the sequence list to the db
                    longestInputSeq.Clear(); //clear the iterator list
                }
            }
            if (longestInputSeq.Count >= 0) //add the last number from the sequence.
            {
                longestInputSeq.Add(input[input.Length - 1]);
            }

            longestInputDB.Add(new List<int>(longestInputSeq.GetRange(0, longestInputSeq.Count))); //add the last iterator list

            foreach (var candidateLIS in longestInputDB)
            {
                Console.WriteLine(string.Join(" ", candidateLIS)); //output the sub sequences
            }

            List<int> longestSeqInDB = new List<int>(longestInputDB[0]); //list for the longest sub sequence fetched from the db

            for (int i = 1; i < longestInputDB.Count; i++)
            {
                if (longestSeqInDB.Count < longestInputDB[i].Count) //if the number of elements from the candidate list is smaller than the next subsequence count
                {
                    longestSeqInDB.Clear(); //clear the candidate list
                    longestSeqInDB.AddRange(longestInputDB[i]); //fill the candidate list with the larger subsequence
                }
            }

            Console.WriteLine("Longest : {0}", string.Join(" ", longestSeqInDB)); //output the largest subsequence
        }
    }
}
