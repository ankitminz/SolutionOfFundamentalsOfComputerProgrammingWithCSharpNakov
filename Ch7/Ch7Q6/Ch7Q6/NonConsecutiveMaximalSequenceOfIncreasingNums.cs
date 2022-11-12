// Write a program, which finds the maximal sequence of increasing 
// elements in an array arr[n]. It is not necessary the elements to be 
// consecutively placed. E.g.: { 9, 6, 2, 7, 4, 7, 6, 5, 8, 4} --> { 2, 4, 6, 8}.

namespace Ch7Q6
{
    public static class NonConsecutiveMaximalSequenceOfIncreasingNums
    {
        public static void Main()
        {
            int len;
            bool isInt;

            Console.WriteLine("Program to find the maximal sequence of increasing elements " +
                "in a given array. It is not necessary for the elements to be " +
                "consecutively placed.");
            do
            {
                Console.Write("Enter length of array = ");
                isInt = Int32.TryParse(Console.ReadLine(), out len);
                if(!isInt || len < 1)
                {
                    Console.WriteLine($"\nEnter a valid positive integer 'n' such that" +
                        $"\n0 < n <= {Int32.MaxValue}");
                }
            }
            while (!isInt || len < 1);

            int[] nums = new int[len];

            for(int i = 0; i < len; i++)
            {
                do
                {
                    Console.Write($"array[{i}] = ");
                    isInt = Int32.TryParse(Console.ReadLine(), out nums[i]);
                    if (!isInt || nums[i] == 0)
                    {
                        Console.WriteLine("\nEnter a non-zero integer 'n' such that" +
                            $"\n{Int32.MinValue} <= n <= {Int32.MaxValue}");
                    }
                }
                while (!isInt || nums[i] == 0);
            }

            Console.WriteLine();
            GetMaxSequenceOfIncreasingNums(nums);
        }


        private static void GetMaxSequenceOfIncreasingNums(int[] array)
        {
            // Method to find non-consecutive maximal sequence of increasing nums
            // from an array of non-zero integers

            int[] currentResult = new int[array.Length];
            int[] bestResult = new int[array.Length];
            int bestCount = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                InitArray(currentResult);
                currentResult[i] = array[i];
                int bestNum = array[i];
                int count = 1;
                int nextIndex = i + 1;

                while (nextIndex < array.Length)
                {
                    bool isNextNumFound = false;
                    int tempIndex = nextIndex;
                    int bestScore = Int32.MaxValue;

                    for (int j = nextIndex; j < array.Length; j++)
                    {
                        int score = array[j] + j;

                        if(array[j] > bestNum && score <= bestScore)
                        {
                            bestScore = score;
                            currentResult[j] = array[j];
                            UpdateCurrentResult(currentResult, j, bestNum);
                            tempIndex = j;

                            if (!isNextNumFound)
                            {
                                isNextNumFound = true;
                                count++;
                            }
                        }
                    }

                    if(!isNextNumFound)
                    {
                        break;
                    }

                    bestNum = array[tempIndex];
                    nextIndex = tempIndex++;
                }

                if(count > bestCount)
                {
                    bestCount = count;
                    SetBestResult(currentResult, bestResult);
                }
            }

            PrintMaxSequenceOfIncreasingNums(bestResult);
        }


        private static void InitArray(int[] array)
        {
            // Initialize all elements of array to 0

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }


        private static void SetBestResult(int[] current, int[] best)
        {
            // Method to set all elements of best array equal to current array

            for(int i = 0; i < current.Length; i++)
            {
                best[i] = current[i];
            }
        }


        private static void PrintMaxSequenceOfIncreasingNums(int[] array)
        {
            // Method to print maximal sequence of increasing nums

            int maxCount = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] > 0)
                {
                    maxCount++;
                }
            }

            for(int i = 0, count = 0; i < array.Length && count < maxCount; i++)
            {
                if(array[i] > 0)
                {
                    if (maxCount == 1)
                    {
                        Console.WriteLine($"{{{array[i]}}}");
                        break;
                    }

                    if (count == 0)
                    {
                        count++;
                        Console.Write($"{{{array[i]}, ");
                    }
                    else if(count > 0 && count < maxCount - 1)
                    {
                        count++;
                        Console.Write($"{array[i]}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{array[i]}}}");
                    }
                }
            }
        }


        private static void UpdateCurrentResult(int[] array, int currentIndex, int bestNum)
        {
            // Method to update current result array

            for(int i = currentIndex - 1; i >= 0; i--)
            {
                if(array[i] == bestNum)
                {
                    break;
                }
                else if(array[i] != 0 && array[i] + i >= array[currentIndex] + currentIndex && array[i] > array[currentIndex])
                {
                    array[i] = 0;
                }
            }
        }
    }
}