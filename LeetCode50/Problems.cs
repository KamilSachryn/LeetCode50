internal class Problems
{
    public void currentProblem()
    {
        ListNode l1 = new ListNode(2, null);
        l1.next = new ListNode(null, 4);
        l1.next.next = new ListNode(null, 3);
        
        ListNode l2 = new ListNode(null, 5);
        l2.next = new ListNode(null, 6);
        l2.next.next = new ListNode(null, 4);

        AddTwoNumbers(l1, l2);
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
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {

        Stack<int> l1Stack = new Stack<int>();
        Stack<int> l2Stack = new Stack<int>();
        ListNode current = l1;

        

        
        return new ListNode(null, 0);
    }
}