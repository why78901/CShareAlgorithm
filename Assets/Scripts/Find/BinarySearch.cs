using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#704.二分查找
//给定有序数组，查找给定值在数组中的位置
public class BinarySearch : MonoBehaviour {
	
	void Start (){
		int[] arr = new[]{2, 5, 6, 7, 9};
		int res = binarySearch(arr, arr.Length, 7);
		Debug.LogError("binarySearch:"+res);
	}

	int binarySearch(int[] arr, int n, int value){
		int left = 0;
		int right = n;
		while (left < right){
			int mid = (left + right) / 2;
			if (arr[mid] < value){
				left = mid + 1;
			}
			else if(arr[mid] > value){
				right = mid;
			}
			else{
				return mid;
			}
		}
		return -1;
	}
	
	public int Search(int[] nums, int target) {
		int left = 0;
		int right = nums.Length;
		while (left < right){
			int mid = (left + right) / 2;
			if (nums[mid] < target){
				left = mid + 1;
			}
			else if(nums[mid] > target){
				right = mid;
			}
			else{
				return mid;
			}
		}
		return -1;
	}

}
