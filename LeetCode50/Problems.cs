using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics.Tracing;
using System.IO.Pipes;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

internal class Problems
{
    bool foo1115 = false;
    int n1115 = 5;
    public void currentProblem()
    {
        string input = "(10+5)";

        Console.WriteLine(calculate(input));

    }

    //224. Basic Calculator
    public int calculate(String s)
    {
        s = s.Replace(" ", "");
        int ans = 0;
        int currNum = 0;
        int sign = 1;
        Stack<int> stack = new Stack<int>();

        foreach(char c in s)
        {
            Console.WriteLine(ans);
            if(Char.IsDigit(c))
            {
                currNum *= 10;
                currNum += c - '0';
            }
            else if(c == '+')
            {
                ans += sign * currNum;
                currNum = 0;
                sign = 1;
            }
            else if(c == '-')
            {
                ans += sign * currNum;
                currNum = 0;
                sign = -1;
            }
            else if(c == '(')
            {
                stack.Push(ans);
                stack.Push(sign);

                ans = 0;
                sign = 1;
            }
            else if(c == ')')
            {
                ans += sign * currNum;
                currNum = 0;

                int stackSign = stack.Pop();
                int stackAns = stack.Pop();

                ans += stackSign * stackAns;


            }
        }

        if(currNum != 0)
        {
            ans += sign * currNum;
        }

        return ans;
    }


    //141. Linked List Cycle
    public bool HasCycle(ListNode head)
    {
        if(head == null || head.next == null)
        {
            return false;
        }
        ListNode slow = head;

        ListNode fast = head.next;

        while(slow != null && fast != null)
        {
            if (slow.GetHashCode() == fast.GetHashCode())
            {
                return true;
            }

            if(fast.next == null || slow.next == null || fast.next.next == null)
            {
                return false;
            }

            fast = fast.next.next;
            slow = slow.next;


        }


        return false;


    }



    //507. Perfect Number
    public bool CheckPerfectNumber(int num)
    {
        double sqrt = Math.Sqrt(num);

        int sum = 1;


        for(int i = 2; i <= sqrt; i++)
        {
            if(num % i == 0)
            {
                sum += i;


                int complement = num / i;
                if(complement != i)
                {
                    sum += complement;
                }

            }


        }

        return sum == num;

    }


    //504. Base 7
    public string ConvertToBase7(int num)
    {
        bool isNeg = num < 0;

        string output = "";
        if (num == 0)
            return "0";

        while(num != 0)
        {
            int remainder = num % 7;
            remainder = Math.Abs(remainder);
            num = num / 7;
            output = output.Insert(0, remainder.ToString());
        }

        if(isNeg)
        {
            output = output.Insert(0, "-");
        }
        return output;


    }


    //217. Contains Duplicate
    public bool ContainsDuplicate(int[] nums)
    {

        HashSet<int> set = new HashSet<int>();

        foreach(int i in nums)
        {
            if(set.Contains(i))
            {
                return true;
            }
            else
            {
                set.Add(i);
            }
        }


        return false;



    }


    //268. Missing Number
    public int MissingNumber(int[] nums)
    {
        bool[] foundNums = new bool[nums.Length +  1];
        foreach(int i in nums)
        {
            foundNums[i] = true;
        }

        for(int i = 0; i < foundNums.Length;  i++)
        {
            if (!foundNums[i])
                return i;
        }

        return -1;

    }

    //263. Ugly Number
    public bool IsUgly(int n)
    {
        if (n <= 0)
            return false;
        if (n == 1)
            return true;


        while(n >= 1)
        {

            if(n == 1)
            {
                return true;
            }
            else if(n % 2 == 0)
            {
                n = n / 2;
            }
            else if(n % 3 == 0)
            {
                n = n / 3;
            }
            else if(n % 5 == 0)
            {
                n = n / 5;
            }
            else
            {
                return false;
            }
        }

        return false;
       


    }

    //1089. Duplicate Zeros
    public void DuplicateZeros(int[] arr)
    {

        foreach (int k in arr)
        {
            Console.Write(k + ", ");
        }
        Console.WriteLine();
        Console.WriteLine();


        for (int i = 0; i < arr.Length; i++)
        {
            int curr = arr[i];

            if (curr == 0)
            {


                for (int j = arr.Length - 1; j > i; j--)
                {
                    arr[j] = arr[j-1];
                }

                i += 1;
            }

            foreach (int k in arr)
            {
                Console.Write(k + ", ");
            }
            Console.WriteLine();

        }


        Console.WriteLine();
        foreach (int k in arr)
        {
            Console.Write(k + ", ");
        }
        Console.WriteLine();


    }


    //495. Teemo Attacking
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {


        int total = 0;
        int currentPoisonedUntil = timeSeries[timeSeries.Length - 1] + duration;
        for (int i = timeSeries.Length - 1; i >= 0; i--)
        {

            int curr = timeSeries[i];

            if (currentPoisonedUntil > curr)
            {
                total += Math.Min(duration, currentPoisonedUntil - curr);
            }


            currentPoisonedUntil = curr;
        }


        return total;

    }





        //917. Reverse Only Letters
        public string ReverseOnlyLetters(string s)
    {
        Stack<char> stack = new Stack<char>();


        for(int i = 0; i < s.Length; i++)
        {
            char current = s[i];

            if (char.IsLetter(current))
            {
                stack.Push(current);
            }

        }

        String output = "";

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];

            if (char.IsLetter(current))
            {
                output += stack.Pop();
            }
            else
            {
                output += s[i];
            }

        }

        return output;




    }

    //1221. Split a String in Balanced Strings
    public int BalancedStringSplit(string s)
    {
        int lCount = 0;
        int rCOunt = 0;
        int output = 0;


        for(int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if(c == 'R')
            {

                rCOunt++;

            }
            else //c == L
            {
                lCount++;
            }

            if(lCount > 0 && rCOunt > 0 && lCount == rCOunt)
            {
                output++;
                lCount = 0;
                rCOunt = 0;
            }


        }

        return output;



    }


    //2652. Sum Multiples
    public int SumOfMultiples(int n)
    {
        bool[] sieve = new bool[n + 1];

        for(int i = 3; i <= n; i+=3)
        {
            sieve[i] = true;
        }        
        for(int i = 5; i <= n; i+=5)
        {
            sieve[i] = true;
        }        
        for(int i = 7; i <= n; i+=7)
        {
            sieve[i] = true;
        }

        int sum = 0;
        for(int i = 1; i <= n; i++)
        {
            if (sieve[i])
            {
                sum += i;
            }
        }

        return sum;


    }

    //136. Single Number
    public int SingleNumber(int[] nums)
    {
        HashSet<int> result = new HashSet<int>();

        foreach(int num in nums)
        {
            if (result.Contains(num))
                result.Remove(num);
            else
                result.Add(num);
        }


        return result.ToArray()[0];


    }


    //171. Excel Sheet Column Number
    public int TitleToNumber(string columnTitle)
    {
        if (columnTitle.Length == 0)
            return 0;

        int total = 0;

        int revIndex = columnTitle.Length - 1;

        for(int i = 0; i < columnTitle.Length; i++)
        {
            char c = columnTitle[i];
            int val = c - 'A' + 1;

            total += val * (int)(Math.Pow(26, revIndex--));
            // X_baseN = X[0]*10^(len-1) + x[1]*10^(len-2) + ... + x[len-1]+10^(0)
       

        }
        

        return total;

    }

    //2418. Sort the People
    public string[] SortPeople(string[] names, int[] heights)
    {
        string[] output = new string[names.Length];
        Dictionary<int, String> dict = new Dictionary<int, string>();

        for(int i = 0; i < names.Length; i++)
        {
            dict[heights[i]] = names[i];
        }

        int j =0;

        Array.Sort(heights);
        Array.Reverse(heights);

        foreach(int k in heights)
        {
            output[j++] = dict[k];
        }

      

        return output;

    }


    //55. Jump Game
    public bool CanJump(int[] nums)
    {
        //[2][3][1][1][4]

        if (nums.Length <= 1)
            return true;
        int highestReachable = nums[0];

        for (int i = 1; i <= highestReachable; i++)
        {
            if (nums[i] + i > highestReachable)
            {
                highestReachable = nums[i] + i;
            }

            if (highestReachable >= nums.Length)
                return true;

        }

        return false;



    }


    //2864. Maximum Odd Binary Number
    public string MaximumOddBinaryNumber(string s)
    {
        string output = "1";

        bool first1 = true;
        int insertIndex = 0;

        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '1')
            {
                if(first1)
                {
                    first1 = false;
                }
                else
                {
                    output = output.Insert(0, "1");
                    insertIndex++;
                }
                

            }
            else //s[i] == 0
            {
                output = output.Insert(insertIndex, "0");

            }


        }



        return output;


    }



    //728. Self Dividing Numbers
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        List<int> list = new List<int>();

        for (int i = left; i <= right; i++)
        {
            bool bad = false;
            string num = i.ToString();
            if(num.Contains('0'))
            {
                continue;
            }
            foreach(char c in num)
            {
                if(i % (c - '0') != 0)
                {
                    bad = true;
                    break;
                }
            }

            if (!bad)
                list.Add(i);



        }



        return list;
    }

    //1137. N-th Tribonacci Number
    public int Tribonacci(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        if (n == 2)
            return 1;


        int three = 0;
        int two = 1;
        int one = 1;
        int zero = three + two + one;
        for(int i = 3; i <= n; i++)
        {
            zero = three + two + one;
            three = two;
            two = one;
            one = zero;
        }

        return zero;


    }


    // 392. Is Subsequence
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
            return true;

        int j = 0;
        for(int i = 0; i < t.Length; i++)
        {
            //if have match
            if (t[i] == s[j])
            {
                j++;
            }

            if (j == s.Length)
                return true;

        }
        return false;


    }

    //509. Fibonacci Number
    public int Fib(int n)
    {

        if (n == 0)
            return 0;



        int[] arr = new int[n];

        arr[0] = 1;
        arr[1] = 1;

        for(int i = 2; i < n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }

        return arr[n - 1];


    }

    // 49. Group Anagrams
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };

        Dictionary<BigInteger, List<String>> dict = new Dictionary<BigInteger, List<String>>();

        foreach(string str in strs)
        {
            
            BigInteger currNum = 1;

            foreach(char c in str)
            {
                int i = c - 'a';

                currNum *= primes[i];
            }

            if(dict.ContainsKey(currNum))
            {
                dict[currNum].Add(str);
            }
            else
            {
                dict[currNum] = new List<string>() { str};
            }           
        }

        IList<IList<String>> output = new List<IList<string>>();
        foreach(List<String> i in dict.Values)
        {
            output.Add(i);
        }


        return output;


    }


    //242. Valid Anagram
    public bool IsAnagram(string s, string t)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();



        foreach(char c in s)
        {
            dict.TryGetValue(c, out int n);
            dict[c] = n + 1;
        }


        foreach (char c in t)
        {
            dict.TryGetValue(c, out int n);
            dict[c] = n - 1;
        }


        foreach(char c in dict.Keys)
        {
            if (dict[c] != 0)
                return false;
        }

        return true;



    }


    //290. Word Pattern
    public bool WordPattern(string pattern, string s)
    {
        //O(1)
        Dictionary<char, string> dict = new Dictionary<char, string>();

        //O(n)
        List<String> splitString = s.Split(' ').ToList();

        //O(1)
        if (pattern.Length != splitString.Count)
            return false;

        //O(n)
        for(int i = 0; i < pattern.Length; i++)
        {
            char currChar = pattern[i];
            string currString = splitString[i];

            if (dict.ContainsKey(currChar))
            {
                if (dict[currChar] != currString)
                    return false;
            }
            else
            {
                dict[currChar] = currString;
            }


        }


        //O(n)
        if(dict.Values.Count != (new HashSet<String>(dict.Values).Count))
        {
            return false;
        }


        return true;




    }


    //205. Isomorphic Strings
    public bool IsIsomorphic(string s, string t)
    {

        Dictionary<char, char> mapStoT = new Dictionary<char, char>();
        Dictionary<char, char> mapTtoS = new Dictionary<char, char>();


        for(int i = 0; i < s.Length; i++)
        {
            char a = s[i];
            char b = t[i];

            if(mapStoT.ContainsKey(a))
            {
                if (mapStoT[a] != b)
                    return false;

            }
            else
            {
                mapStoT.Add(a, b);
            }

            if(mapTtoS.ContainsKey(b))
            {
                if (mapTtoS[b] != a)
                    return false;
            }
            else
            {
                mapTtoS.Add(b, a);
            }




        }

        return true;

    }

    //383. Ransom Note
    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();

        
        foreach(char c in magazine)
        {

           // int dictVal = 0;
            dict.TryGetValue(c, out int dictVal);
            dict[c] = dictVal + 1;



        }

        foreach(char c in ransomNote)
        {
            if(!dict.ContainsKey(c) || dict[c]-- == 0)
            {
                return false;
            }
        }

        return true;


    }

    //139. Word Break
    public bool WordBreak(string s, IList<string> wordDict)
    {
        bool[] table = new bool[s.Length + 1];
        table[0] = true;


        for(int i = 1; i <= s.Length; i++)
        {
            for(int j = 0; j < i; j++)

            {
                string sub = s.Substring(j, i - j);
                Console.WriteLine(sub);


                if (table[j] == true && wordDict.Contains(sub))
                {
                    table[i] = true;
                    break;
                }


            }


        }

        return table[s.Length];


    }


    public string MySubString(string s, int start, int end)
    {
        return s.Substring(start, end - start);
    }








    //56. Merge Intervals
    public int[][] Merge(int[][] intervals)
    {
        //[[1,3],[2,6],[8,10],[15,18]]
        Array.Sort(intervals, (x, y) => { return x[0] - y[0]; });

        List<int[]> output = new List<int[]>();

        int[] previous = intervals[0];

        bool prevNotInStack = true;

        for (int i = 1; i < intervals.Length; i++)
        {
            int[] current = intervals[i];
            //prev[0] is always smaller than current[0]

            //check if current[0] is < prev[1]
            if (current[0] <= previous[1])
            {
                //new prev[1] is max of current[1] and prev[1]
                previous[1] = Math.Max(current[1], previous[1]);
                prevNotInStack = true;
                //move on
                //MAKE SURE TO CHECK IF PREV IS ACTIVE AFTER LOOP
            }
            else
            {
                //else current[0]  is not within range is previous
                //so add prev to stack
                output.Add(previous);
                prevNotInStack = false;
                //make current be new prev
                previous = current;
            }


        }

        output.Add(previous);



        return output.ToArray();
    }

    //61. Rotate List
    public ListNode RotateRight(ListNode head, int k)
    {

        if (head == null)
            return null;
        if (head.next == null)
            return head;


        int headLen = 1;

        ListNode tmpHead = head;
        while (tmpHead.next != null)
        {
            headLen++;
            tmpHead = tmpHead.next;
        }
        Console.WriteLine(headLen);


        for (k = k % headLen; k > 0; k--)
            head = RotateRight(head);



        return head;




    }
    public ListNode RotateRight(ListNode head)
    {
        if (head.next == null)
            return head;

        //1 -> 2 -> 3 -> 4 -> 5


        ListNode newHead = new ListNode(0, head);
        //0 -> 1 -> 2 -> 3 -> 4 -> 5

        ListNode tailVal = new ListNode(0);

        ListNode tmpList = head;
        while (tmpList != null)
        {
            tailVal = tmpList;
            tmpList = tmpList.next;
        }



        newHead.val = tailVal.val;




        newHead = removeTail(newHead);






        return newHead;





    }


    ListNode removeTail(ListNode head)
    {
        if (head == null)
            return null;
        if (head.next == null)
            return null;


        ListNode secondLast = head;
        while (secondLast.next.next != null)
        {
            secondLast = secondLast.next;
        }
        secondLast.next = null;

        return head;



    }

    //58. Length of Last Word

    public int LengthOfLastWord(string s)
    {
        s = s.TrimEnd();
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ')
            {
                return s.Length - i - 1;
            }
        }

        return s.Length;

    }


    //228. Summary Ranges
    public IList<string> SummaryRanges(int[] nums)
    {
        List<string> output = new List<string>();
        output.EnsureCapacity(nums.Length);


        if (nums.Length == 0)
            return output;

        int rangeStart = nums[0];
        int prev = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int curr = nums[i];

            if (curr - 1 != prev)
            {

                if (rangeStart == prev)
                {
                    output.Add(prev.ToString());
                }
                else
                {
                    output.Add(rangeStart.ToString() + "->" + prev.ToString());
                }
                rangeStart = curr;


            }

            prev = curr;



        }

        if (rangeStart == nums[nums.Length - 1])
        {
            output.Add(rangeStart.ToString());
        }
        else
        {
            output.Add(rangeStart.ToString() + "->" + nums[nums.Length - 1].ToString());
        }



        return output;
    }


    //274. H-Index
    public int HIndex(int[] citations)
    {
        int h = 0;

        // Key: Number of citations  Value: Number of papers with atleast <key> citations
        Dictionary<int, int> citationDb = new Dictionary<int, int>();


        //The h-index is defined as the maximum value of h such that the given researcher has published at least h papers that have each been cited at least h times.
        //so, make a database of how many papers have been cited atleast n times?

        foreach (int i in citations)
        {
            if (!citationDb.ContainsKey(i))
            {
                citationDb.Add(i, 0);
            }
        }

        foreach (int i in citations)
        {
            foreach (int key in citationDb.Keys)
            {
                if (key <= i)
                    citationDb[key]++;
            }
        }


        int maxPapers = 0;
        int maxCitations = 0;

        foreach (int key in citationDb.Keys)
        {
            //      Console.WriteLine(key + " : " + citationDb[key]);

            //so we have a db of citations with # of papers
            //we want..the biggest number of papers with atleast papers citations?
            //no
            //we want the biggest number of citations where papers is aleast equal to citations

            int numPapers = citationDb[key];

            if (numPapers >= key)
            {
                if (maxCitations < key)
                {
                    maxCitations = key;
                }
            }

            if (key >= numPapers)
            {
                if (maxPapers < numPapers)
                {
                    maxPapers = numPapers;
                }
            }

        }


        return Math.Max(maxCitations, maxPapers);
    }

    //151. Reverse Words in a String
    public string ReverseWords(string s)
    {
        s = s.Trim();
        s = System.Text.RegularExpressions.Regex.Replace(s, "  *", " ");

        List<String> list = s.Split(' ').ToList();

        s = "";

        for (int i = list.Count - 1; i >= 0; i--)
        {
            s += list[i] + ' ';
        }

        return s.Trim();

    }



    public char[][] convertLeetCode2dArrString(String leet)
    {
        //[[1,3],[2,6],[8,10],[15,18]]


        leet = leet.Remove(0, 1);
        leet = leet.Remove(leet.Length - 1, 1);
        leet = leet.Replace("\"", "");
        leet = leet.Replace(",", "");

        int rows = 0;
        int columns = leet.IndexOf(']') - 1;
        foreach (char c in leet)
        {
            if (c == '[')
            {
                rows++;
            }
        }

        char[][] output = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            output[i] = new char[columns];
        }




        foreach (char[] arr in output)
        {

            int index = 0;
            for (int i = 1; i < leet.IndexOf(']'); i++)
            {
                char currIndex = leet[i];
                arr[index] = currIndex;
                index++;

            }
            leet = leet.Remove(0, leet.IndexOf(']') + 1);
        }

        return output;


    }

    public int[][] convertLeetCode2dIntArrString(String leet)
    {
        String[] split = Regex.Split(leet, "],\\[");

        for (int i = 0; i < split.Length; i++)
        {
            split[i] = Regex.Replace(split[i], "(\\[|\\])", "");
        }



        int[][] output = new int[split.Length][];
        int index = 0;
        foreach (string s in split)
        {
            int[] newSubarray = new int[Regex.Matches(s, "[0-9]+").Count];
            int subindex = 0;
            foreach (string sub in Regex.Split(s, ","))
            {
                newSubarray[subindex++] = int.Parse(sub);
            }
            output[index++] = newSubarray;
        }

        return output;






    }


    public double get1BasedQuotient(double num)
    {
        double numerator = 0.00;
        double count = 1;

        while (num % 1 != 0)
        {
            count *= 10;
            num *= 10;
        }

        numerator = num;
        double denominator = count;


        return denominator / numerator;


    }


    //43. Multiply Strings
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
            return "0";

        string output = "0";


        int left = num1.Length - 1;
        int right = num2.Length - 1;

        List<string> numsToAdd = new List<string>();


        for (int i = num1.Length - 1; i >= 0; i--)
        {

            string top = num1[i].ToString();
            //   Console.WriteLine("TOP: " + top);
            string numToAdd = "";
            string hold = "";

            for (int j = num2.Length - 1; j >= 0; j--)
            {

                string bottom = num2[j].ToString();
                //       Console.WriteLine("BOTTOM: " + bottom);

                string n = (int.Parse(bottom) * int.Parse(top) + (hold != "" ? int.Parse(hold) : 0)).ToString();
                if (n.Length > 1)
                {
                    hold = n.Substring(0, 1);
                    n = n.Substring(1, 1);
                }
                else
                {
                    hold = "";
                }

                numToAdd = numToAdd.Insert(0, n);


                //     Console.WriteLine(String.Format("num to add jloop {0} = {1} * {2}, hold = {3}", numToAdd, int.Parse(bottom), int.Parse(top), hold));




            }
            //    Console.WriteLine(String.Format("num to add before hold change {0}, hold {1}", numToAdd, hold));
            if (hold != "")
            {
                numToAdd = numToAdd.Insert(0, hold);
                hold = "";
            }

            for (int k = 0; k < numsToAdd.Count; k++)
            {
                numToAdd += "0";
            }

            //     Console.WriteLine(String.Format("num to add after hold change {0}, hold {1}", numToAdd, hold));
            numsToAdd.Add(numToAdd);


        }
        //   Console.WriteLine("-- adding --");

        foreach (string a in numsToAdd)
        {
            //       Console.WriteLine(output + ", " + a);
            // output = (int.Parse(output) + int.Parse(a)).ToString();
            output = AddStrings(output, a);
            //        Console.WriteLine(a);
        }


        return output;

    }
    public string AddStrings(string num1, string num2)
    {

        string output = "";

        int leftHead = num1.Length - 1;
        int rightHead = num2.Length - 1;

        string hold = "0";

        while (leftHead >= 0 || rightHead >= 0 || hold != "0")
        {
            if (leftHead >= 0 && rightHead >= 0)
            {
                string left = num1.Substring(leftHead, 1);
                string right = num2.Substring(rightHead, 1);

                int leftDigit = int.Parse(left);
                int rightDigit = int.Parse(right);
                int holdDigit = int.Parse(hold);

                int sum = leftDigit + rightDigit + holdDigit;

                if (sum >= 10)
                {
                    sum -= 10;
                    holdDigit = 1;
                }
                else
                {
                    holdDigit = 0;
                }

                hold = holdDigit.ToString();
                output = output.Insert(0, sum.ToString());

                leftHead--;
                rightHead--;


            }
            else if (leftHead >= 0)
            {
                string left = num1.Substring(leftHead, 1);
                int leftDigit = int.Parse(left);
                int holdDigit = int.Parse(hold);

                int sum = leftDigit + holdDigit;

                if (sum >= 10)
                {
                    sum -= 10;
                    holdDigit = 1;
                }
                else
                {
                    holdDigit = 0;
                }
                hold = holdDigit.ToString();
                output = output.Insert(0, sum.ToString());
                leftHead--;
            }
            else if (rightHead >= 0)
            {
                string right = num2.Substring(rightHead, 1);
                int rightDigit = int.Parse(right);
                int holdDigit = int.Parse(hold);

                int sum = rightDigit + holdDigit;

                if (sum >= 10)
                {
                    sum -= 10;
                    holdDigit = 1;
                }
                else
                {
                    holdDigit = 0;
                }
                hold = holdDigit.ToString();
                output = output.Insert(0, sum.ToString());
                rightHead--;
            }
            else
            {
                output = output.Insert(0, hold);
                hold = "0";
            }




        }




        return output;


    }

    //75. Sort Colors
    public void SortColors(int[] nums)
    {
        if (nums.Length <= 1)
            return;

        int red = 0;
        int white = 0;
        int blue = 0;

        foreach (int i in nums)
        {
            if (i == 0)
                red++;
            else if (i == 1)
                white++;
            else
                blue++;


        }

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = red-- > 0 ? 0 : (white-- > 0 ? 1 : 2);
        }
    }

    //1019. Next Greater Node In Linked List
    public int[] NextLargerNodes(ListNode head)
    {
        //       index        index of bigger,  value of original  val of bigger
        Dictionary<int, Tuple<int, int, int>> dict = new Dictionary<int, Tuple<int, int, int>>();
        int i = 0;
        List<int> list = new List<int>();
        int[] output = new int[i];

        while (head != null)
        {
            dict.Add(i, new Tuple<int, int, int>(0, head.val, 0));
            list.Add(i);
            foreach (int key in dict.Keys)
            {
                Tuple<int, int, int> value = dict[key];
                if (value.Item1 == 0)
                {
                    if (value.Item2 < head.val)
                    {
                        list[i] = value.Item3;
                        // dict[key] = new Tuple<int, int, int>(i, value.Item2, head.val);
                        dict.Remove(key);

                    }
                }
            }

            i++;
            head = head.next;

        }




        return list.ToArray();


    }


    //447. Number of Boomerangs
    public int NumberOfBoomerangs(int[][] points)
    {
        int count = 0;
        if (points.Length < 3)
            return 0;


        Dictionary<double, int> dict = new Dictionary<double, int>();


        for (int i = 0; i < points.Length; i++)
        {
            for (int j = 0; j < points.Length; j++)
            {


                int x1 = points[i][0];
                int y1 = points[i][1];
                int x2 = points[j][0];
                int y2 = points[j][1];

                if (x1 == x2 && y1 == y2)
                    continue;

                double dist = distanceBetweenTwoPoints(x1, y1, x2, y2);

                if (dict.ContainsKey(dist))
                {
                    dict[dist]++;
                }
                else
                {
                    dict.Add(dist, 1);
                }
                Console.WriteLine(String.Format("({0}, {1}), ({2}, {3}) : {4}", x1, y1, x2, y2, dist));

            }

            foreach (double key in dict.Keys)
            {
                /*
                Console.WriteLine(String.Format("{0} : {1}", key, dict[key]));
                if (dict[key] >= 1)
                {
                    count += dict[key];
                }
                */

                count += dict[key] * (dict[key] - 1);


            }

            dict.Clear();

        }
        return count;


    }
    //447. Number of Boomerangs
    public int NumberOfBoomerangsNaive(int[][] points)
    {
        int count = 0;

        for (int i = 0; i < points.Length; i++)
        {
            int x1 = points[i][0];
            int y1 = points[i][1];

            for (int j = 0; j < points.Length; j++)
            {
                int x2 = points[j][0];
                int y2 = points[j][1];

                if (x1 != x2 || y1 != y2)
                {

                    for (int k = 0; k < points.Length; k++)
                    {
                        int x3 = points[k][0];
                        int y3 = points[k][1];

                        if ((x1 != x3 || y1 != y3) && (x2 != x3 || y2 != y3))
                        {
                            double distBetweenFirstTwo = distanceBetweenTwoPoints(x1, y1, x2, y2);
                            double distBetweenSecondTwo = distanceBetweenTwoPoints(x1, y1, x3, y3);
                            // Console.WriteLine(String.Format("({0}, {1}), ({2}, {3}), ({4}, {5}), 1st dist: {6}, 2nd dist: {7}", x1, y1, x2, y2, x3, y3, distBetweenFirstTwo, distBetweenSecondTwo));

                            if (distBetweenFirstTwo == distBetweenSecondTwo)
                            {
                                //Console.WriteLine("count++");
                                count++;
                            }


                        }


                    }
                }

            }


        }


        return count;




    }






    double distanceBetweenTwoPoints(int x1, int y1, int x2, int y2)
    {
        //d=√((x2 – x1)² + (y2 – y1)²).
        return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
    }


    //2487. Remove Nodes From Linked List
    public ListNode RemoveNodes(ListNode head)
    {
        if (head == null || head.next == null)
            return head;



        ListNode revHead = reverseListNode(head);

        int largest = revHead.val;

        ListNode outputHead = new ListNode(0);
        ListNode output = new ListNode(revHead.val);
        outputHead.next = output;
        revHead = revHead.next;
        while (revHead != null)
        {

            if (revHead.val >= largest)
            {
                Console.WriteLine(largest + " >= " + revHead.val);
                output.next = new ListNode(revHead.val);
                output = output.next;
                largest = revHead.val;

            }
            revHead = revHead.next;
        }


        return reverseListNode(outputHead.next);

    }




    public ListNode reverseListNode(ListNode n)
    {
        //1 -> 2 -> 3 -> null
        //smallest case: 3 -> null
        //so build up from 3
        if (n == null)
        {
            return n;
        }


        ListNode tmp = n;
        if (n.next != null)
        {
            tmp = reverseListNode(n.next);
            n.next.next = n;
        }
        n.next = null;

        return tmp;





    }

    //1115. Print FooBar Alternately
    public void Foo1115(Action printFoo)
    {

        for (int i = 0; i < n1115; i++)
        {
            if (!foo1115)
            {
                while (true)
                {
                    if (foo1115 == true)
                        break;
                }
            }
            // printFoo() outputs "foo". Do not change or remove this line.
            printFoo();
            foo1115 = false;
        }
    }

    public void Bar1115(Action printBar)
    {

        for (int i = 0; i < n1115; i++)
        {

            if (foo1115)
            {
                while (true)
                {
                    if (foo1115 == false)
                    {
                        break;
                    }
                }
            }
            // printBar() outputs "bar". Do not change or remove this line.
            printBar();
            foo1115 = true;
        }
    }

    //1047. Remove All Adjacent Duplicates In String
    public string RemoveDuplicates(string s)
    {
        int len = s.Length;
        int i = 0;
        while (i < len - 1)
        {
            bool dec = true;
            if (s[i] == s[i + 1])
            {
                s = s.Remove(i, 2);
                dec = false;
                len = s.Length;
            }
            if (dec)
                i++;
            else
                i--;
            if (i < 0)
                i = 0;
        }

        return s;

    }


    // 486. Predict the Winner
    public bool PredictTheWinner(int[] nums)
    {
        return PredictTheWinner(nums, 0, 0, true);




    }

    public bool PredictTheWinner(int[] nums, int p1Score, int p2Score, bool p1Turn)
    {

        Console.Write("Nums: ");
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write(nums[i] + ", ");
        }
        Console.WriteLine();

        if (nums.Length == 0)
        {
            if (p1Score > p2Score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        bool output = false;
        int[] leftNums = new int[nums.Length - 1];
        for (int i = 1; i < nums.Length; i++)
        {
            leftNums[i - 1] = nums[i];
        }

        int[] rightNums = new int[nums.Length - 1];
        for (int i = 0; i < nums.Length - 1; i++)
        {
            rightNums[i] = nums[i + 1];
        }

        if (p1Turn)
        {
            output = PredictTheWinner(leftNums, p1Score + nums[0], p2Score, false);
            if (output != true)
            {
                output = PredictTheWinner(rightNums, p1Score + nums[nums.Length - 1], p2Score, false);
            }
        }
        else
        {
            output = PredictTheWinner(leftNums, p1Score, p2Score + nums[0], true);
            if (output != true)
            {
                output = PredictTheWinner(rightNums, p1Score, p2Score + nums[nums.Length - 1], true);
            }
        }

        return output;


    }

    //48. Rotate Image
    public void Rotate(int[][] matrix, bool inplace)
    {


        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int hold = matrix[i][j];
                int hold2 = matrix[j][i];
                matrix[j][i] = hold;
                matrix[i][j] = hold2;
            }
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix.Length / 2; j++)
            {
                int hold1 = matrix[i][j];
                int hold2 = matrix[i][matrix.Length - 1 - j];
                matrix[i][j] = hold2;
                matrix[i][matrix.Length - 1 - j] = hold1;


            }
        }

    }

    public void Rotate(int[][] matrix)
    {
        Console.WriteLine("Starting arr:");
        printArrofArrs(matrix);
        Console.WriteLine("End starting arr arr:");


        int[][] output = new int[matrix.Length][];
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = new int[matrix[0].Length];
        }

        if (matrix.Length == 0)
        {
            Console.WriteLine("width 0");
            return;
        }
        if (matrix[0].Length == 0)
        {
            Console.WriteLine("height 0");
            return;
        }


        int width = matrix.Length;
        int height = matrix[0].Length;


        for (int i = 0; i < matrix.Length; i++)
        {

            for (int j = 0; j < matrix.Length; j++)
            {
                output[j][height - i - 1] = matrix[i][j];


            }
        }

        Console.WriteLine("Ending arr:");
        printArrofArrs(output);
        Console.WriteLine("End ending arr arr:");
    }

    void printArrofArrs(int[][] matrix)
    {


        foreach (int[] arr in matrix)
        {
            foreach (int i in arr)
            {
                Console.Write("[" + i + "]");
            }
            Console.WriteLine();
        }


    }
    void printArrofArrs(char[][] matrix)
    {


        foreach (char[] arr in matrix)
        {
            foreach (char i in arr)
            {
                Console.Write("[" + i + "]");
            }
            Console.WriteLine();
        }


    }

    void printArrofArrs(string[][] matrix)
    {


        foreach (string[] arr in matrix)
        {
            foreach (string i in arr)
            {
                Console.Write("[" + i + "]");
            }
            Console.WriteLine();
        }


    }

    // 204. Count Primes
    public int CountPrimes(int n)
    {
        bool[] sieve = new bool[n];
        int output = 0;
        if (n <= 2)
            return 0;
        for (int i = 4; i < sieve.Length; i += 2)
        {
            sieve[i] = true;
        }

        for (int i = 3; i < sieve.Length; i++)
        {
            if (!sieve[i])
            {
                for (int j = i + i; j < sieve.Length; j += i)
                {
                    sieve[j] = true;
                }
            }
        }

        for (int i = 2; i < sieve.Length; i++)
        {

            // Console.WriteLine(i + " is " + (sieve[i] ? "not prime" : "prime"));
            output += sieve[i] ? 0 : 1;
        }

        return output;

    }


    //125. Valid Palindrome
    public bool IsPalindrome(string s)
    {
        s = s.ToLower();

        string pattern = "[^a-zA-Z0-9]";

        s = Regex.Replace(s, pattern, "");

        Console.WriteLine(s);
        int left = 0;
        int right = s.Length - 1;

        while (left <= right)
        {
            if (s[left++] != s[right--])
                return false;
        }

        return true;

    }


    public bool IsPowerOfN(int b, int a)
    {
        //log_a(b) = c -> a^c = b


        //log_a(b) = log_10(b) / log_10(a)
        double log = Math.Log10(b) / Math.Log10(a);
        //Console.WriteLine(log);

        return log - (int)log == 0;

    }

    //326. Power of Three
    public bool IsPowerOfThree(int n)
    {

        return IsPowerOfN(n, 3);


    }

    //191. Number of 1 Bits
    public int HammingWeight(int n)
    {
        int count = 0;
        while (n >= 1)
        {
            count += n % 2;
            n /= 2;
        }

        return count;

    }



    //169. Majority Element
    public int MajorityElement(int[] nums)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (int i in nums)
        {
            if (!dict.ContainsKey(i))
            {
                dict.Add(i, 1);
            }
            else
            {
                dict[i] = dict[i] + 1;
            }


        }

        int maxNum = -1;
        int maxKey = -1;
        foreach (int i in dict.Keys)
        {
            if (dict[i] > maxNum)
            {
                maxNum = dict[i];
                maxKey = i;
            }
        }

        return maxKey;



    }


    //283. Move Zeroes
    public void MoveZeroes(int[] nums)
    {

        int movingPointer = 0;
        List<int> freeSpaces = new List<int>(nums.Length);
        int ignoreIndex = 0;


        while (movingPointer != nums.Length)
        {
            int curr = nums[movingPointer];
            if (curr == 0)
            {
                freeSpaces.Add(movingPointer);

            }
            else
            {
                if (freeSpaces.Count > 0)
                {
                    nums[freeSpaces[ignoreIndex]] = curr;
                    ignoreIndex++;
                    nums[movingPointer] = 0;
                    freeSpaces.Add(movingPointer);
                }
            }

            movingPointer++;
        }

        foreach (int i in nums)
        {
            Console.Write(i + ", ");
        }

    }

    //1450. Number of Students Doing Homework at a Given Time
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
    {
        int output = 0;

        for (int i = 0; i < startTime.Length; i++)
        {
            if (startTime[i] <= queryTime && endTime[i] >= queryTime)
                output++;
        }

        return output;
    }


    //1859. Sorting the Sentence
    public string SortSentence(string s)
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();
        string build = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i])) //is a number
            {
                dict.Add(s[i] - '0', build);
                build = "";
            }
            else if (s[i] == ' ') //is a blank space
            {
                //do nothing
            }
            else //is a letter
            {
                build += s[i];
            }
        }

        string output = "";
        for (int i = 1; i <= dict.Count; i++)
        {
            output += dict[i];
            output += ' ';
        }

        return output.Trim();





    }

    //88. Merge Sorted Array
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int left = m - 1;
        int right = n - 1;
        int i = m + n - 1;


        while (right >= 0)
        {
            if (left >= 0 && nums1[left] > nums2[right])
            {

                nums1[i] = nums1[left];
                i--;
                left--;
            }
            else
            {
                nums1[i] = nums2[right];
                i--;
                right--;
            }
        }

    }

    //121. Best Time to Buy and Sell Stock
    public int MaxProfit(int[] prices)
    {

        int left = 0;
        int right = 1;
        int diff = 0;

        while (right != prices.Length)
        {
            int currDiff = prices[right] - prices[left];
            if (prices[left] < prices[right])
            {
                if (diff < currDiff)
                    diff = currDiff;

            }
            else
            {
                left = right;
            }
            right++;

        }

        return diff;

    }


    //83. Remove Duplicates from Sorted List
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
            return null;
        if (head.next == null)
            return head;

        ListNode prev = head;
        ListNode newHead = head;
        head = head.next;
        while (head != null)
        {
            if (head.val == prev.val)
            {
                ListNode tmp = head.next;
                prev.next = tmp;
                head = tmp;
            }
            else
            {
                prev = head;
                head = head.next;

            }


        }

        return newHead;

    }



    /*
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> output = new List<string>();


        genParen("", n, n, output, 0);


        return output;
    }

    void genParen(string str, int left, int right, List<string> list, int validClose)
    {
        
        if (left == 0 && right == 0)
        {
            list.Add(str);
            return;
        }

        if (left > 0)
        {
            genParen(str + "(", left - 1, right, list, validClose + 1);
        }
        if (validClose > 0)
        {
            genParen(str + ")", left, right - 1, list, validClose - 1);
        }




    }

     */

    //70. Climbing Stairs
    public int ClimbStairs(int n)
    {

        Dictionary<int, int> dict = new Dictionary<int, int>();
        return ClimbStairs(n, dict);





    }

    public int ClimbStairs(int n, Dictionary<int, int> dict)
    {

        if (n == 0)
            return 1;
        if (n == 1)
            return 1;

        if (!dict.ContainsKey(n))
        {
            dict.Add(n, ClimbStairs(n - 1, dict) + ClimbStairs(n - 2, dict));
        }

        return dict[n];


    }

    //69. Sqrt(x)
    public int MySqrt(int x)
    {
        if (x == 0)
            return 0;
        int left = 0;
        int right = x / 2;
        int best = 1;
        while (left != right)
        {
            Console.WriteLine("Left: " + left + ", Right: " + right);
            int lPow = (int)Math.Pow(left, 2);
            int rPow = (int)Math.Pow(right, 2);
            if (lPow == x)
                return left;
            else if (rPow == x)
                return right;

            if (lPow > x)
                left /= 2;
            if (rPow < x)
                right *= 2;
            best = left;


        }

        return best;
    }

    //67. Add Binary
    public string AddBinary(string a, string b)
    {
        int ptrA = a.Length - 1;
        int ptrB = b.Length - 1;
        string output = "";
        int carry = 0;


        while (ptrA >= 0 || ptrB >= 0)
        {
            if (ptrA >= 0 && ptrB >= 0)
            {
                int aa = a[ptrA] == '1' ? 1 : 0;
                int bb = b[ptrB] == '1' ? 1 : 0;

                int sum = aa + bb + carry;
                if (sum == 2)
                {

                    output = output.Insert(0, "0");
                    carry = 1;
                }
                else if (sum == 3)
                {

                    output = output.Insert(0, "1");
                    carry = 1;
                }
                else
                {
                    carry = 0;
                    output = output.Insert(0, sum.ToString());
                }
                ptrA--;
                ptrB--;
            }
            else if (ptrA >= 0)
            {
                int aa = a[ptrA] == '1' ? 1 : 0;
                int sum = aa + carry;
                if (sum == 2)
                {
                    output = output.Insert(0, "0");
                    carry = 1;
                }
                else
                {
                    carry = 0;
                    output = output.Insert(0, sum.ToString());
                }
                ptrA--;
            }
            else if (ptrB >= 0)
            {
                int bb = b[ptrB] == '1' ? 1 : 0;
                int sum = bb + carry;
                if (sum == 2)
                {
                    output = output.Insert(0, "0");
                    carry = 1;
                }
                else
                {
                    carry = 0;
                    output = output.Insert(0, sum.ToString());
                }
                ptrB--;
            }
        }
        if (carry == 1)
            output = output.Insert(0, "1");

        output = output.TrimStart('0');

        if (output.Length == 0)
            output = "0";

        return output;


    }

    //66. Plus One
    public int[] PlusOne(int[] digits)
    {
        int remainder = 1;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i] += 1;
                return digits;
            }
            digits[i] = 0;

        }


        digits = new int[digits.Length + 1];
        digits[0] = 1;
        return digits;



    }



    //35. Search Insert Position
    public int SearchInsert(int[] nums, int target)
    {
        if (nums.Length == 0)
            return 0;

        int left = 0;
        int right = nums.Length;
        if (target > nums[right - 1])
            return right;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] <= target)
            {
                left = mid + 1;
            }
            else

            {
                right = mid - 1;
            }
        }

        return left;


    }



    //206. Reverse Linked List
    public ListNode ReverseList(ListNode head)
    {
        return rev(head, null);

    }

    ListNode rev(ListNode node, ListNode prev)
    {
        {
            Console.Write("Start: Node: [");
            foreach (int i in ListNode.linkedListToList(node))
            {
                Console.Write(i + ", ");
            }
            Console.Write("] prev: [");
            foreach (int i in ListNode.linkedListToList(prev))
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine("]\n");
        }
        if (node == null)
        {
            return prev;
        }


        ListNode tmp = node.next;
        node.next = prev;

        {
            Console.Write("End: Node: [");
            foreach (int i in ListNode.linkedListToList(tmp))
            {
                Console.Write(i + ", ");
            }
            Console.Write("] prev: [");
            foreach (int i in ListNode.linkedListToList(node))
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine("]\n");
        }
        return rev(tmp, node);
    }

    /*
    node: [1,2,3,4,5]
    prev: [null]
    
    node: [2,3,4,5]
    prev: [1]
    
    node: [1,2,3,4,5]
    prev: [null]
    
    node: [1,2,3,4,5]
    prev: [null]
    
    node: [1,2,3,4,5]
    prev: [null]
    
    node: [1,2,3,4,5]
    prev: [null]
    
    node: [1,2,3,4,5]
    prev: [null]





    */






    //24. Swap Nodes in Pairs
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null)
        {
            return null;
        }
        if (head.next == null)
        {
            return head;
        }

        ListNode headPtr = head;
        ListNode left = head;
        ListNode right = head.next;
        ListNode nextNode = head.next.next;
        ListNode tmp = left;
        left = right;
        right = tmp;
        left.next = right;
        right.next = nextNode;
        headPtr = left;
        ListNode prevNode = right;

        while (right != null && nextNode != null)
        {
            left = nextNode;
            right = left.next;
            if (right != null)
            {
                nextNode = right.next;
                tmp = left;
                left = right;
                right = tmp;
                left.next = right;
                right.next = nextNode;
                prevNode.next = left;
                prevNode = right;
            }
        }
        return headPtr;
    }

    //23. Merge k Sorted Lists
    public ListNode MergeKLists(ListNode[] lists)
    {


        List<ListNode> temp = new List<ListNode>();

        foreach (ListNode l in lists)
        {
            if (l != null)
                temp.Add(l);
        }

        lists = temp.ToArray();

        if (lists.Length == 0)
        {
            return null;
        }


        ListNode output = new ListNode();
        ListNode outputHead = output;
        Boolean finished = false;


        int currentLowest = lists[0].val;
        int lowestID = 0;
        while (!finished)
        {
            finished = true;
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode currentHead = lists[i];
                if (currentHead != null)
                {
                    finished = false;
                    if (currentHead.val < currentLowest)
                    {
                        currentLowest = currentHead.val;
                        lowestID = i;

                    }
                }

            }
            if (finished) break;

            output.next = new ListNode(currentLowest);
            output = output.next;
            Console.WriteLine("Lowest val was " + currentLowest + " on listid " + lowestID);
            lists[lowestID] = lists[lowestID].next;
            currentLowest = int.MaxValue;
        }

        return outputHead.next;
    }



    //22. Generate Parentheses
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> output = new List<string>();


        genParen("", n, n, output, 0);


        return output;
    }

    void genParen(string str, int left, int right, List<string> list, int validClose)
    {

        if (left == 0 && right == 0)
        {
            list.Add(str);
            return;
        }

        if (left > 0)
        {
            genParen(str + "(", left - 1, right, list, validClose + 1);
        }
        if (validClose > 0)
        {
            genParen(str + ")", left, right - 1, list, validClose - 1);
        }




    }


    //#1. Two Sum
    public int[] TwoSum(int[] nums, int target)
    {

        /*
         * [2,   7, 11,15]
         * [-7, -2, 3, 6]
         
        */
        Dictionary<int, int> dict = new Dictionary<int, int>();

        Dictionary<int, int> dict2 = new Dictionary<int, int>();


        for (int i = 0; i < nums.Length; i++)
        {
            dict[nums[i]] = i;
        }




        for (int i = 0; i < nums.Length; i++)
        {
            int current = nums[i];


            if (dict.TryGetValue(target - current, out current) && current != i)
            {
                return new int[] { i, current };
            }

        }

        return new int[] { -1, -1 };
    }

    //#2. Add two problems
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {


        ListNode l3 = new ListNode(0);
        ListNode current = l3;

        int carry = 0;

        while (l1 != null || l2 != null)
        {
            int val = 0;



            if (l1 != null && l2 != null)
            {
                Console.WriteLine("L1: " + l1.val + ", L2: " + l2.val + ", l3: " + (l1.val + l2.val));
                val = l1.val + l2.val;
                l1 = l1.next;
                l2 = l2.next;
            }
            else if (l1 == null)
            {
                Console.WriteLine(" L2: " + l2.val);
                val = l2.val;
                l2 = l2.next;
            }
            else if (l2 == null)
            {
                Console.WriteLine("L1: " + l1.val);
                val = l1.val;
                l1 = l1.next;
            }

            current.next = new ListNode((val + carry) % 10);
            current = current.next;

            carry = (val + carry) / 10;
            Console.WriteLine("carry: " + carry);
        }
        if (carry != 0)
        {
            current.next = new ListNode(carry);
        }


        return l3.next;
    }

    //#3. Longest Substring Without Repeating Characters
    public int LengthOfLongestSubstring(string s)
    {
        //Probably better to use a hashset
        Dictionary<char, int> dict = new Dictionary<char, int>();

        //longest sequence
        int best = 0;

        //read heads
        int i = 0;
        int j = 0;
        //while both readheads can read
        while (i < s.Length && j < s.Length)
        {
            //current forward read head value
            char c = s[j];

            //if forward key is unique
            if (!dict.ContainsKey(c))
            {
                //add to dict and advance forward read head
                dict[c] = 1;
                j++;

            }
            //if a dupe key is encoutered with forward read head
            else
            {
                //check if new length record
                int count = dict.Count;
                if (count > best)
                {
                    best = count;
                }

                //remove back read head's value
                dict.Remove(s[i]);
                //advance back read head
                i++;

            }
        }

        //if the last forward value was unique it wont have been counted since we only check on dupe
        if (dict.Count > best)
        {
            best = dict.Count;
        }


        return best;

    }

    //#4. Median of Two Sorted Arrays
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        //read heads
        int i = 0;
        int j = 0;
        int k = 0;

        int[] nums3 = new int[nums1.Length + nums2.Length];


        //loop read heads
        while (i < nums1.Length || j < nums2.Length)
        {
            //if both read heads are reading a value
            if (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    nums3[k++] = nums1[i++];
                }
                else
                {
                    nums3[k++] = nums2[j++];
                }
            }
            else if (i >= nums1.Length)
            {
                nums3[k++] = nums2[j++];
            }
            else if (j >= nums2.Length)
            {
                nums3[k++] = nums1[i++];
            }
        }

        double sum = 0;
        if (nums3.Length % 2 == 0)
        {
            int x = nums3[(nums3.Length - 1) / 2];
            int y = nums3[(nums3.Length - 1) / 2 + 1];
            sum = x + y;
            sum /= 2;
        }
        else
        {
            sum = nums3[nums3.Length / 2];
        }



        return sum;
    }

    //#5. Longest Palindromic Substring
    public string LongestPalindrome(string s)
    {
        int i = 0;
        int j = 1;
        string longest = "";

        while (i < s.Length)
        {
            string curr = s.Substring(i, j);
            Console.WriteLine("looking at : " + curr);

            bool pal = isPalindrome(curr);
            if (pal)
            {
                if (curr.Length > longest.Length)
                {
                    longest = curr;
                }
            }

            j++;
            if (j + i > s.Length)
            {
                j = 1;
                i++;
            }

        }

        return longest;
    }
    bool isPalindrome(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        while (j >= i)
        {
            if (s[j--] != s[i++])
            {
                return false;
            }
        }

        return true;
    }
    //#6. Zigzag Conversion
    public string Convert(string s, int numRows)
    {
        char[,] chars = new char[s.Length * numRows, numRows];

        int i = 0;
        bool dirDown = true;


        i = 0;


        int x = 0;
        int y = 0;
        string output = s;
        while (i < s.Length)
        {

            y = Math.Min(numRows - 1, y);
            y = Math.Max(0, y);

            if (y == 0)
            {
                dirDown = true;
            }
            else if (y == numRows - 1)
            {
                dirDown = false;
            }

            int mod = i % numRows;

            Console.WriteLine(String.Format("X: {0},\t Y: {1},\t dirDown:{2},\t i: {3},\tmod: {5},\t currChar: {4}", x, y, dirDown ? "down" : "up", i, s[i], mod));



            chars[x, y] = s[i];



            if (dirDown && y != numRows - 1)
            {
                y++;
            }
            else if (dirDown && y == numRows - 1)
            {
                y--;
                x++;
            }
            else if (!dirDown && y == 0)
            {
                y++;
                x++;
            }
            else if (!dirDown && y != 0)
            {
                y--;
                x++;

            }





            i++;

        }



        Print2DCharArray(chars);
        for (int ii = 0; ii < chars.GetLength(1); ii++)
        {
            for (int jj = 0; jj < chars.GetLength(0); jj++)
            {
                char c = chars[jj, ii];
                if (c != '\0')
                {
                    output += c;
                }

            }
        }



        return output;
    }

    public void Print2DCharArray(char[,] arr)
    {
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                char c = arr[j, i];
                if (c == '\0')
                {
                    c = '_';
                }

                Console.Write(c);

            }
            Console.WriteLine();
        }
    }
    public void Print2DIList(IList<IList<int>> list)
    {



        for (int i = 0; i < list.Count; i++)
        {
            IList<int> subList = list[i];
            for (int j = 0; j < subList.Count; j++)
            {
                object obj = subList[j];

                Console.Write(obj);

            }
            Console.WriteLine();
        }
    }


    //#7. Reverse Integer
    public int Reverse(int x)
    {
        //bool neg = x < 0 ? true : false;
        int output = 0;

        while (x != 0)
        {
            int last = x % 10;
            int prevOutput = output;


            output = output * 10 + last;

            if ((output - last) / 10 != prevOutput)
            {
                return 0;
            }

            x /= 10;
        }

        return output;// * (neg ? -1 : 1);
    }

    //#8. String to Integer (atoi)
    public int MyAtoi(string s)
    {
        Console.WriteLine("Start string: " + s);
        int output = 0;
        s = s.Trim();
        if (s.Length == 0)
        {
            return 0;
        }
        bool neg = s[0] == '-' ? true : false;
        Console.WriteLine("neg: " + neg);

        if (neg || s[0] == '+')
        {
            s = s.Substring(1, s.Length - 1);
        }
        string temp = "";

        Console.WriteLine("trimmed string: " + s);
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                temp += s[i];
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("numbers only string: " + temp);


        foreach (char c in temp)
        {
            Console.WriteLine("output: " + output);
            int curr = (c - '0');
            int prevOutput = output;
            output = output * 10 + curr;
            Console.WriteLine("newOutput: " + output + " newOutputDiv: " + (output - curr) / 10 + ", prevOutput: " + prevOutput);
            if ((output - curr) / 10 != prevOutput || output < 0)
            {
                Console.WriteLine("overflow");
                if (neg)
                {
                    return Int32.MinValue;
                }
                else
                {
                    return Int32.MaxValue;
                }
            }
        }

        return output * (neg ? -1 : 1);

    }



    //118. Pascal's Triangle
    public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> triangle = new List<IList<int>>();
        if (numRows == 0)
        {
            return triangle;
        }

        triangle.Add(new List<int>() { 1 });

        for (int i = 1; i < numRows; i++)
        {
            IList<int> previousList = triangle[i - 1];
            List<int> newList = new List<int>() { 1 };

            for (int j = 1; j < i; j++)
            {
                newList.Add(previousList[j - 1] + previousList[j]);

            }

            newList.Add(1);
            triangle.Add(newList);

        }

        return triangle;
    }

    //11. Container With Most Water
    public int MaxArea(int[] height)
    {
        int output = 0;

        int backHead = 0;
        int forwardHead = height.Length - 1;

        while (backHead < forwardHead)
        {

            int i = height[backHead];
            int j = height[forwardHead];
            int dist = forwardHead - backHead;
            int area = dist * Math.Min(i, j);

            Console.WriteLine(String.Format("back: {0}, forward: {1}, i: {2}, j: {3}, dist: {4}, area: {5}", backHead, forwardHead, i, j, dist, area));
            if (area > output)
            {
                output = area;
            }

            if (i < j)
                backHead++;
            else
                forwardHead--;


        }




        return output;
    }

    //12. Integer to Roman
    public string IntToRoman(int num)
    {
        String output = "";

        int[] integer = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        String[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        int i = 0;
        while (num > 0)
        {
            while (integer[i] <= num)
            {
                num -= integer[i];
                output += roman[i];
            }
            i++;
        }


        return output;

        /*
        Dictionary<char, int> romanValues = new Dictionary<char, int>();
        romanValues.Add('I', 1);
        romanValues.Add('V', 5);
        romanValues.Add('X', 10);
        romanValues.Add('L', 50);
        romanValues.Add('C', 100);
        romanValues.Add('D', 500);
        romanValues.Add('M', 1000);

        Dictionary<int, char> intValues = new Dictionary<int, char>();
        intValues.Add(1, 'I');
        intValues.Add(5, 'V');
        intValues.Add(10, 'X');
        intValues.Add(50, 'L');
        intValues.Add(100, 'C');
        intValues.Add(500, 'D');
        intValues.Add(1000, 'M');
        */

    }

    //13. Roman to Integer
    public int RomanToInt(string s)
    {
        int output = 0;

        Dictionary<char, int> romanValues = new Dictionary<char, int>();
        romanValues.Add('I', 1);
        romanValues.Add('V', 5);
        romanValues.Add('X', 10);
        romanValues.Add('L', 50);
        romanValues.Add('C', 100);
        romanValues.Add('D', 500);
        romanValues.Add('M', 1000);


        int prev = 0;
        while (s.Length > 0)
        {
            //  Console.WriteLine(String.Format("S: {0}, output: {1}",s, output));
            int current = romanValues[s[s.Length - 1]];
            //  Console.WriteLine(String.Format("prev: {0}, Current: {1}",prev, current));
            if (prev > current)
            {
                output -= current;
                //      Console.WriteLine(String.Format("Prev was smaller than curr, new output: {0}",output));
            }
            else
            {
                output += current;
                //      Console.WriteLine(String.Format("Prev was bigger than curr, new output: {0}", output));
            }
            prev = current;

            s = s.Substring(0, s.Length - 1);
            // Console.WriteLine(String.Format("new Prev: {0}, newOutput: {1}, new s: {2}",prev, output, s));
        }

        return output;
    }

    //15. 3Sum
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        List<IList<int>> output = new List<IList<int>>();

        for (int left = 0; left < nums.Length - 2; left++)
        {
            if (left > 0 && nums[left] == nums[left - 1])
            {
                continue;
            }
            int mid = left + 1;
            int right = nums.Length - 1;

            while (mid < right)
            {
                int sum = nums[left] + nums[mid] + nums[right];
                if (sum == 0)
                {
                    output.Add(new int[] { nums[left], nums[mid], nums[right] });

                    while (mid < right && nums[mid] == nums[mid + 1])
                    {
                        mid++;
                    }

                    while (mid < right && nums[right] == nums[right - 1])
                    {
                        right--;
                    }
                    mid++;
                    right--;

                }
                else if (sum < 0)
                {
                    mid++;
                }
                else if (sum > 0)
                {
                    right--;
                }



            }
        }

        return output;

    }

    //16. 3Sum Closest
    public int ThreeSumClosest(int[] nums, int target)
    {
        int output = 0;
        int bestDiff = int.MaxValue;
        Array.Sort(nums);

        for (int left = 0; left < nums.Length - 2; left++)
        {

            int mid = left + 1;
            int right = nums.Length - 1;

            while (mid < right)
            {
                int sum = nums[left] + nums[mid] + nums[right];

                if (sum == target)
                {
                    return sum;
                }

                int diff = Math.Abs(target - sum);


                if (diff < bestDiff)
                {
                    bestDiff = diff;
                    output = sum;
                }

                if (sum < target)
                {
                    mid++;
                }
                else if (sum > target)
                {
                    right--;
                }
            }
        }
        return output;

    }

    //17. Letter Combinations of a Phone Number
    public IList<string> LetterCombinations(string digits)
    {

        List<string> output = new List<string>();
        if (digits.Length == 0)
        {
            return output;
        }
        output.Add("");

        Dictionary<int, string> phone = new Dictionary<int, string>();
        phone.Add('2', "abc");
        phone.Add('3', "def");
        phone.Add('4', "ghi");
        phone.Add('5', "jkl");
        phone.Add('6', "mno");
        phone.Add('7', "pqrs");
        phone.Add('8', "tuv");
        phone.Add('9', "wxyz");

        for (int i = 0; i < digits.Length; i++)
        {
            string currChars = phone[digits[i]];
            List<string> tmp = new List<string>();
            foreach (Char c in currChars)
            {
                foreach (string s in output)
                {
                    tmp.Add(s + c);
                }
            }
            output = tmp;
        }
        return output;
    }

    //19. Remove Nth Node From End of List
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head.next == null && n == 1)
        {
            return null;
        }

        ListNode outputHead = head;
        ListNode right = outputHead.next;
        ListNode left = head;
        int steps = 0;
        while (right != null)
        {
            if (steps != n - 1)
            {
                right = right.next;
                steps++;
            }
            else
            {
                //at last step
                if (right.next == null)
                {
                    left.next = left.next.next;
                    return outputHead;
                }
                else
                {
                    right = right.next;
                    left = left.next;
                }
            }

        }
        if (left == head)
        {
            return head.next;
        }
        return null;


    }

    //20. Valid Parentheses
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            switch (c)
            {
                case '{':
                case '(':
                case '[':
                    stack.Push(c);
                    break;
                case '}':
                case ']':
                case ')':
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    char top = stack.Pop();
                    if (top != oppositeParenthesis(c))
                    {
                        return false;
                    }
                    break;

            }
        }

        if (stack.Count == 0)
            return true;
        else
            return false;


    }

    char oppositeParenthesis(char c)
    {
        switch (c)
        {
            case '}':
                return '{';
            case ')':
                return '(';
            case ']':
                return '[';
            case '(':
                return ')';
            case '{':
                return '}';
            case '[':
                return ']';
        }

        return '\0';

    }

    //21. Merge Two Sorted Lists
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode sorted = new ListNode();
        ListNode sortedHead = sorted;

        while (list1 != null || list2 != null)
        {
            if (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {

                    sorted.next = new ListNode(list1.val);
                    sorted = sorted.next;
                    list1 = list1.next;

                }
                else
                {
                    sorted.next = new ListNode(list2.val);
                    sorted = sorted.next;
                    list2 = list2.next;
                }
            }
            else if (list1 != null)
            {
                sorted.next = new ListNode(list1.val);
                sorted = sorted.next;
                list1 = list1.next;
            }
            else
            {
                sorted.next = new ListNode(list2.val);
                sorted = sorted.next;
                list2 = list2.next;
            }
        }
        return sortedHead.next;
    }
}