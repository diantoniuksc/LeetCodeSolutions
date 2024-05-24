using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCycle
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

            Console.WriteLine(HasCycle(node1).ToString());
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

        public static void PrintAllNodesInList(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/linked-list-cycle/description/
        /// </summary>
        /// <param name="nodeSlow"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode nodeSlow)
        {
            ListNode nodeFast = nodeSlow;
            while (nodeFast != null)
            {
                if (nodeFast.next != null)
                {
                    if (nodeFast.next.next != null)
                        nodeFast = nodeFast.next.next;
                    else
                        return false;
                }
                else
                    return false;

                nodeSlow = nodeSlow.next;

                if (nodeSlow == nodeFast)
                    return true;
            }
            return false;
        }    
    }
}
