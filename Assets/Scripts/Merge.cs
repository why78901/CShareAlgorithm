using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//88.合并两个有序数组
public class Merge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void Merge2(int[] nums1, int m, int[] nums2, int n) {
        int len = m+n;
        int i=m-1, j=n-1, k=len-1;
        while(i>=0 && j>=0){
			if(nums1[i] > nums2[j]){
				nums1[k--] = nums1[i--];
			}else{
				nums1[k--] = nums2[j--];
			}
		}
		for(;i >= 0;i--){
			nums1[k--] = nums1[i];
		}

		for(;j >= 0;j--){
			nums1[k--] = nums2[j];
		}
    }

	public void Merge1(int[] nums1, int m, int[] nums2, int n) {
        int len = m+n;
        int[] arr = new int[len];
        int i=0, j=0, k=0;
        while(i<m && j<n){
            if(nums1[i] < nums2[j]){
                arr[k++] = nums1[i++];
            }else{
                arr[k++] = nums2[j++];
            }
        }
        for(;i < m; i++){
            arr[k++] = nums1[i];
        }

        for(;j < n; j++){
            arr[k++] = nums2[j];
        }
        for(int v = 0; v < len; v++){
            nums1[v] = arr[v]; 
        }
    }
}
