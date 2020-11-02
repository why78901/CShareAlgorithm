using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        int[] arr = new[]{1, 7, 3, 5, 2, 4};
        quickSort(arr,0, arr.Length - 1);
        Debug.Log("list end: " + util.ToString(arr));
    }

    // Update is called once per frame
    void quickSort(int[] arr, int l, int r){
        if (l < r){
            int i = partition(arr, l, r);
            quickSort(arr, l,i-1);
            quickSort(arr, i + 1, r);
        }
    }
    
    int partition(int[] arr, int l, int r){
        int temp = arr[l];
        while (l < r){
            while (l < r && arr[r] > temp){//从右边找一个小的
                r--;
            }

            if (l < r){
                arr[l] = arr[r];
                l++;
            }

            while (l < r && arr[l] < temp){//从左边找一个大的
                l++;
            }

            if (l < r){
                arr[r] = arr[l];
            }
        }

        arr[l] = temp;
        return l;
    }
    
    
}
