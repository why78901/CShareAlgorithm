using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] arr = {9,8,7,6,5,4,3,2,1,0};
		PlusOne1(arr);

	}
	
	public int[] PlusOne1(int[] digits) {
		for (int i = digits.Length - 1; i >= 0; i--) {
			digits[i]++;
			digits[i] = digits[i] % 10;
			if (digits[i] != 0) return digits;
        }
        digits = new int[digits.Length + 1];
        digits[0] = 1;
        return digits;
    }
}
