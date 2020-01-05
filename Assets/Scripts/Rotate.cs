using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//189旋转数组
public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	//force
	public void Rotate1(int[] nums, int k) {
		k = k % nums.Length;
		int max;
		int len = nums.Length;
        while(k > 0){
			max = nums[len - 1];
			for(int i = len-1; i > 0; i--){
				nums[i] = nums[i - 1];
			}
			nums[0] = max;
			k--;
		}
    }

	//数组法
	public void rotate(int[] nums, int k) {
        int[] a = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            a[(i + k) % nums.Length] = nums[i];
        }
        for (int i = 0; i < nums.Length; i++) {
            nums[i] = a[i];
        }
    }

	//反转法
	public void rotate1(int[] nums, int k) {
        k %= nums.Length;
        reverse(nums, 0, nums.Length - 1);
        reverse(nums, 0, k - 1);
        reverse(nums, k, nums.Length - 1);
    }
    public void reverse(int[] nums, int start, int end) {
        while (start < end) {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }

}
