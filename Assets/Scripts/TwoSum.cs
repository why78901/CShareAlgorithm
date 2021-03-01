using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#1.两数之和
public class TwoSum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public int[] TwoSum1(int[] numbers, int target) {
		int[] arr = new int[2];
		Dictionary<int,int> dic = new Dictionary<int, int>();
		for(int i = 0; i < numbers.Length; i++){
			int value = target - numbers[i];
			if(dic.ContainsKey(value)){
				arr[0] = dic[value] + 1;
				arr[1] = i + 1;
				break;
			}
			if(!dic.ContainsKey(numbers[i])){
                dic.Add(numbers[i],i);
            }
		}
		return arr;
	}

	public int[] TwoSum2(int[] numbers, int target) {
		int[] arr = new int[2];
		int head = 0;
		int tail = numbers.Length - 1;
		while(head < tail){
			int sum = numbers[head] + numbers[tail];
			if(sum == target)
				break;
			if(sum > target){
				tail--;
			}else{
				head++;
			}
		}
		arr[0] = head + 1;
		arr[1] = tail + 1;
		return arr;
	}
}

//两数之和lua版
// function TwoSum(numbers, target)
//     local head = 1
//     local tail = #numbers
//     while head < tail do
//       local sum = numbers[head] + numbers[tail]
//       if sum == target then
//         break
//       end
//       if sum > target then
//         tail = tail - 1
//       end
//       if sum < target then
//         head = head +1
//       end
//     end
//     return head,tail
// end
       
// print(TwoSum({5,8,10,12,23},20))