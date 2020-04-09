using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//归并排序
// 9,5,7,2
// 0,0,1 [5,9,7,2]
// 2,2,3 [5,9,2,7]
// 0,1,3 [2,5,7,9]
public class MergeSort : MonoBehaviour {
	private void Start(){
		int[] arr = {9, 5, 7, 2};
		mergeSort(arr, 0, arr.Length-1, new int[arr.Length]);
	}

	void mergeSort(int[] arr, int low, int high, int[] temp){
		if (low < high){
			int mid = (low + high) / 2;
			mergeSort(arr, low, mid, temp);
			mergeSort(arr, mid + 1, high, temp);
			merge(arr, low, mid, high, temp);	
		}
	}

	void merge(int[] arr, int low, int mid, int high, int[] temp){
		Debug.LogFormat("low:{0},mid:{1},high:{2}",low,mid,high);
		int i = low;//左序列指针
		int j = mid+1;//右序列指针
		int t = 0;//临时数组指针
		while (i<=mid && j<=high){
			if(arr[i]<=arr[j]){
				temp[t++] = arr[i++];
			}else {
				temp[t++] = arr[j++];
			}
		}
		while(i<=mid){//将左边剩余元素填充进temp中
			temp[t++] = arr[i++];
		}
		while(j<=high){//将右序列剩余元素填充进temp中
			temp[t++] = arr[j++];
		}
		t = 0;
		//将temp中的元素全部拷贝到原数组中
		while(low <= high){
			arr[low++] = temp[t++];
		}
		
		for (int z = 0; z <= high; z++){
			Debug.LogError(temp[z]);
		}

		for (int k = 0; k <= high; k++){
			Debug.LogWarning(arr[k]);
		}
	}
}
