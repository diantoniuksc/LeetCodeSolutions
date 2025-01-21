using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOf2LinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*ListNode node1_1 = new ListNode(3);
            ListNode node2_1 = new ListNode(6);
            ListNode node2_2 = new ListNode(4);*/
            ListNode node2 = new ListNode(7);
            /*ListNode node3 = new ListNode(0);
            ListNode node4 = new ListNode(-4);
            node1_1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = null;
            node2_1.next = node2_2;
            node2_2.next = node2;*/


            Console.WriteLine(GetIntersectionNode(node2, node2).val.ToString());
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
        /// https://leetcode.com/problems/intersection-of-two-linked-lists/
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) 
                return null;

            for(;; )
            {
                ListNode nodeToCompare = headB;
                for(; ; )
                {
                    if (headA == nodeToCompare) 
                        return headA;

                    if (nodeToCompare.next != null)
                        nodeToCompare = nodeToCompare.next;
                    else
                        break;
                }
                if (headA.next != null)
                    headA = headA.next;
                else
                    break;
            }
            return null;
        }
    }
}
