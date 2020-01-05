using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//169 多数元素
public class MajorityElement : MonoBehaviour {

	// Use this for initialization
	//
	//
	void Start () {
		
	}
	
	public int MajorityElement1(int[] nums) {
		int[] arr = new int[2];
		arr[0] = nums[0];
		arr[1] = 1;
		for(int i = 1; i < nums.Length; i++){
			if(arr[0] == nums[i]){
				arr[1] += 1;
			}else{
				arr[1] -= 1;
				if(arr[1] == 0){
					arr[0] = nums[i];
					arr[1] = 1;
				}
			}
		}
		return arr[0];
    }
}
