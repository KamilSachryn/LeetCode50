using System;
using System.Collections;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

internal class Problems
{
    public void currentProblem()
    {
        Console.WriteLine(RomanToInt("MCMXCIV"));

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
        while(i < s.Length && j < s.Length)
        {
            //current forward read head value
            char c = s[j];

            //if forward key is unique
            if(!dict.ContainsKey(c))
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
                if(count > best)
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
            if(i < nums1.Length && j < nums2.Length)
            {
                if(nums1[i] < nums2[j])
                {
                    nums3[k++] = nums1[i++];
                }
                else
                {
                    nums3[k++] = nums2[j++];
                }
            }
            else if(i >= nums1.Length)
            {
                nums3[k++] = nums2[j++];
            }
            else if(j >= nums2.Length)
            {
                nums3[k++] = nums1[i++];
            }
        }

        double sum = 0;
        if (nums3.Length % 2 == 0)
        {
            int x = nums3[(nums3.Length - 1)/ 2];
            int y = nums3[(nums3.Length - 1)/ 2 + 1];
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

        while(i < s.Length )
        {
            string curr = s.Substring(i, j);
            Console.WriteLine("looking at : " + curr);

            bool pal = isPalindrome(curr);
            if(pal)
            {
                if(curr.Length > longest.Length)
                {
                    longest = curr;
                }
            }

            j++;
            if(j + i > s.Length)
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
        char[,] chars = new char[s.Length * numRows,numRows];

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
            else if(y == numRows - 1)
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
            else if(dirDown && y == numRows - 1)
            {
                y--;
                x++;
            }
            else if(!dirDown && y == 0)
            {
                y++;
                x++;
            }
            else if(!dirDown && y != 0)
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
                if(c != '\0')
                {
                    output += c;
                }

            }
        }



        return output;
    }

    public void Print2DCharArray(char[,] arr)
    {
        for(int i = 0; i < arr.GetLength(1); i++)
        {
            for(int j = 0; j < arr.GetLength(0);j++)
            {
                char c = arr[j, i];
                if(c == '\0')
                {
                    c = '_';
                }

                Console.Write(c);
               
            }
            Console.WriteLine();
        }
    }

    //#7. Reverse Integer
    public int Reverse(int x)
    {
        //bool neg = x < 0 ? true : false;
        int output = 0;

        while(x != 0)
        {
            int last = x % 10;
            int prevOutput = output;


            output = output * 10 + last;

            if((output - last) / 10 != prevOutput)
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
        if(s.Length == 0)
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
                if(neg)
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

        for(int i = 1; i < numRows; i++)
        {
            IList<int> previousList = triangle[i - 1];
            List<int> newList = new List<int>() { 1 };

            for(int j = 1; j < i; j++)
            {
                newList.Add(previousList[j-1] + previousList[j]);

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

        while(backHead < forwardHead)
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
        while(num > 0)
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
        while(s.Length > 0)
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
}