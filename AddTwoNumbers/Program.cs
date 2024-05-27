using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(2);
            ListNode node2 = new ListNode(4);
            ListNode node3 = new ListNode(9);

            ListNode node4 = new ListNode(5);
            ListNode node5 = new ListNode(6);
            ListNode node6 = new ListNode(4);
            ListNode node7 = new ListNode(9);
            node1.next = node2;
            node2.next = node3;
            node3.next = null;

            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = null;
            /*ListNode node1 = new ListNode(0);
            ListNode node2 = new ListNode(0);

            node1.next = null;
            node2.next = null;*/

            PrintAllNodesInList(AddTwoNumbers(node1, node4));
            Console.ReadLine();
        }

        public static void PrintAllNodesInList(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }

        /*public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }*/

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/add-two-numbers/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            int prevExcess = 0, sum = 0;
            ListNode baseNode = null, currentNode = null;

            for (; l1 != null || l2 != null;)
            {
                if (l1 == null)
                {
                    sum = l2.val + prevExcess;
                }
                else
                {
                    if (l2 == null)
                    {
                        sum = l1.val + prevExcess;
                    }
                    else
                    {
                        sum = l1.val + l2.val + prevExcess;                      
                    }
                    l1 = l1.next;
                }
                if (l2 != null)
                    l2 = l2.next;

                if (baseNode == null)
                {
                    baseNode = new ListNode(sum % 10);
                    currentNode = baseNode;
                }
                else
                {
                    currentNode.next = new ListNode(sum % 10);
                    currentNode = currentNode.next;
                }
                prevExcess = sum / 10;
            }

            if (prevExcess == 1)
                currentNode.next = new ListNode(1);           

            return baseNode;
        }
    }
}
