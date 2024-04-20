using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class ListNode
{
    public ListNode next;

    public int val;

    public ListNode( int val, ListNode next)
    {
        this.next = next;
        this.val = val;
    }

    public ListNode( ListNode next, int val)
    {
        this.next = next;
        this.val = val;
    }

    public ListNode(int val)
    {
        this.next = null;
        this.val = val;
    }
}

