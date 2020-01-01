using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegerSort : MonoBehaviour {
	//最大连续数组
 	public int MaxSubArray(int[] nums) {
        int sum = 0;
        int res = nums[0];
        for(int i = 0; i < nums.Length; i++){
            if(sum > 0){
                sum += nums[i];
            }else{
                sum = nums[i];
            }
            res = Mathf.Max(sum, res);
        }
		return res;
    }
}
