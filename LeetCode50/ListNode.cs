using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class ListNode
{
    
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }


    public static ListNode generateLinkedList(List<int> arr)
    {
        ListNode result = new ListNode();
        ListNode resultHead = result;

        foreach (int i in arr)
        {
            result.next = new ListNode(i);
            result = result.next;
        }

        return resultHead.next;
    }

    public static List<int> linkedListToList(ListNode head)
    {
        List<int> output = new List<int>();

        while (head != null)
        {
            output.Add(head.val);
            head = head.next;
        }

        return output;

    }

}

