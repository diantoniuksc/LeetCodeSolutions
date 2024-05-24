using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCycle2
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(3);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(0);
            ListNode node4 = new ListNode(-4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node2;

            Console.WriteLine(DetectCycle(node1).val.ToString());
            Console.ReadLine();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/linked-list-cycle-ii/description/
        /// </summary>
        /// <param name="args"></param>
        public static ListNode DetectCycle(ListNode baseNode)
        {       
            if (baseNode == null) 
                return null;

            int i = 0;
            for (ListNode toCheck = baseNode; toCheck != null; i++, toCheck = toCheck.next)
            {
                int j = 0;
                ListNode forCheck = baseNode;
                for (; toCheck != forCheck; j++, forCheck = forCheck.next)
                {

                }
                if (toCheck == forCheck)
                    if (i != j)
                        return toCheck;
            }
            return null;
        }
    }
}
