using static System.Net.Mime.MediaTypeNames;

internal class Problems
{
    public void currentProblem()
    {
        string s = "qrsvbspk";
        Console.WriteLine(LengthOfLongestSubstring(s));
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
}