﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#5 最长回文子串
public class LongestPalindrome : MonoBehaviour {
	
	public string longestPalindrome(string s) {
		if(s.Length < 2) return s;
		int len = s.Length;
		string res = "", s1 = "", s2 = "";
		for(int i = 0; i < len; i++){
			s1 = Palindrome(s, i, i);
			s2 = Palindrome(s, i, i+1);
			res = res.Length > s1.Length ? res : s1;
			res = res.Length > s2.Length ? res : s2; 
		}
		return res;
	}

	//从中间向两侧查找
	string Palindrome(string s, int l, int r){
		while(l >= 0 && r < s.Length && s.Substring(l,1) == s.Substring(r,1)){
			l--;
			r++;
		}
		return s.Substring(l+1, r - l -1);
	}
}
