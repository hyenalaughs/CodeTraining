namespace Leetcode.Exercise
{
    internal class MergeTwoSortedList
    {
        public void Test()
        {
            var list1 = new ListNode(1);
            list1.next = new ListNode(2);
            list1.next.next = new ListNode(4);

            var list2 = new ListNode(1);
            list2.next = new ListNode(3);
            list2.next.next = new ListNode(4);

            var result = Execute(list1, list2);

            var currentNode = result;
            while (true)
            {
                Console.Write(currentNode.val.ToString() + ' ');
                
                if (currentNode.next is null)
                    break;

                currentNode = currentNode.next;
            } 
        }

        public static ListNode Execute(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            current.next = list1 ?? list2;

            return dummy.next; 
        }
    }

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
}
