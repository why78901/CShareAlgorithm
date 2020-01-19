using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//283.移动数组中的零到末位
public class MoveZeroes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void moveZeroes(int[] nums) {
        if(nums.Length == 0)
            return;
        int moved = 0;
        int len = nums.Length;
        for(int i = 0; i < len; i++){
            if(nums[i] == 0){
                moved++;
            }else{
                if(moved > 0){
                    nums[i-moved] = nums[i];
                }
            }
        }
        for(int i = len - moved; i < len; i++){
            nums[i] = 0;
        }
    }

	//双指针法
	public void moveZeroes2(int[] nums)
	{
		int slow = 0;
		
		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[i] != 0)
			{
				nums[slow++] = nums[i];
			}
		}

		for (int i = slow; i < nums.Length; i++)
		{
			nums[i] = 0;
		}

	}
}
