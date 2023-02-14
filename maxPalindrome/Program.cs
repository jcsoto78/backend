using System;

namespace maxPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            // string S = "bbaaabb";
            // string S = "for1geeksskeeg1for";
            string S = "babababab";

            string maxPalindrome = string.Empty;

            for (int i = 0; i < S.Length; i++)
            {
                string nextCharacter = string.Empty;
                string previousCharacter = string.Empty;
                int left = i;
                int right = i;
                string localPalindrome = string.Empty;
                // string currentCharacter = S.Substring(i, 1);

                // search core
                while (canTakeRight(S, right))
                { 
                    nextCharacter = S.Substring(right++, 1); 
                    if( S.Substring(i, 1) == nextCharacter)
                        localPalindrome = $"{localPalindrome}{nextCharacter}";
                    else
                        break;
                }

                //search for extension of the palindrome
                // to the left at i-1 an to right at right-1
                left = i;
                right = i+localPalindrome.Length-1;

                while(canTakeLeft(S, left) && canTakeRight(S, right))
                {
                    nextCharacter = S.Substring(++right, 1);
                    previousCharacter = S.Substring(--left, 1);

                    if(nextCharacter == previousCharacter)
                        localPalindrome = $"{previousCharacter}{localPalindrome}{nextCharacter}";
                    else    
                        break;
                }

                maxPalindrome = (maxPalindrome.Length <= localPalindrome.Length) ? localPalindrome : maxPalindrome;
            }

            bool canTakeLeft(string S, int index)
            {
                return (index - 1 >= 0);
            }

            bool canTakeRight(string S, int index)
            {
                return (index + 1 < S.Length);
            }

            Console.WriteLine(maxPalindrome);
        }
    }
}
