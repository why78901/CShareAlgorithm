using System;
using UnityEngine;
using System.Collections.Generic;

 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
 }
//#剑指 Offer 24.反转链表
public class ReversList : MonoBehaviour
{
    private void Start(){
        int[] arr = {1, 2, 3, 4, 5};
        List<ListNode> lst = new List<ListNode>();
        foreach (var item in arr){
            var node = new ListNode(item);
            if (lst.Count > 0){
                lst[lst.Count - 1].next = node;
            }
            lst.Add(node);
        }

        lst[lst.Count - 1].next = null;
        var head = lst[0];
        head = ReverseList(head);
        while (head != null){
            print(head.val);
            head = head.next;
        }
    }

    public ListNode ReverseList(ListNode head){
        if (head == null){
            return null;
        }
        var result = new ListNode(head.val);
        while (head.next != null){
            head = head.next;
            var temp = new ListNode(head.val);
            temp.next = result;
            result = temp;
        }
        return result;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}