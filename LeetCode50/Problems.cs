using System.Collections;
using static System.Net.Mime.MediaTypeNames;

internal class Problems
{
    public void currentProblem()
    {
        int[] nums1 = { 1, 2 };
        int[] nums2 = { 3, 4 };
        
        Console.WriteLine(Reverse(123));
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
        int len = x.ToString().Length;
        bool neg = x < 0 ? true : false;
        int i = 10^ len;

        int output = 0;
        Console.WriteLine("Input: " + x);
        while (x > 0)
        {
            int last = x % 10;
            x = x / 10;
            output += last * i;
            i /= 10;
            Console.Write(last);
        }
        Console.WriteLine();


        return output * (neg ? -1 : 1);
    }
}