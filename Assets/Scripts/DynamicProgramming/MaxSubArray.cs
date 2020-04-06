using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//#53 最大子序和
public class MaxSubArray : MonoBehaviour {

	public int maxSubArray(int[] nums) {
		int sum = nums[0];
		int[] dp = new int[nums.Length];
		dp[0] = nums[0];
		for(int i = 1; i < nums.Length; i++){
			if(dp[i-1] > 0){
				dp[i] = dp[i-1] + nums[i];
			}else{
				dp[i] = nums[i];
			}
			sum = Math.Max(sum, dp[i]);
		}
		return sum;
	}
}
