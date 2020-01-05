using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ContainsDuplicate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] arr = {1,2,3,1,2,3};
		var result = containsDuplicate2(arr,2);
		Debug.LogError("result:"+ result.ToString());
	}
	
	public bool containsDuplicate(int[] nums) {
		for(int i = 0; i < nums.Length; i++){
			for(int j = i + 1; j < nums.Length; j++){
				if(nums[i] == nums[j]){
					return true;
				}
			}
		}
        return false;
    }

	public bool containsDuplicate1(int[] nums) {
		Array.Sort(nums);
		for(int i = 0; i < nums.Length -1; i++){
			if(nums[i] == nums[i + 1]) return true;
		}
        return false;
    }

	public bool containsDuplicate2(int[] nums, int k) {
		HashSet<int> set = new HashSet<int>();
		for(int i = 0; i < nums.Length; i++){
			if(set.Contains(nums[i])) return true;
			set.Add(nums[i]);
			if(set.Count > k){
				set.Remove(nums[i - k]);
			}	
		}
		return false;
    }

}
