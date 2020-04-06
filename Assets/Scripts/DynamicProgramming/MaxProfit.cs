using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//买股票的最佳时机
public class MaxProfit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] prices = {3,3,5,0,0,3,1,4};
		int result = MaxProfit11(prices);
		Debug.LogError("MaxProfit11 "+result);
	}

	//#121.只有一次交易
	private int MaxProfit11(int[] prices){
		int n = prices.Length;
		int[,] dp = new int[n,2];
		dp[1, 0] = 0;
		dp[1, 1] = -prices[0];
		for(int i = 1; i < n; i++){
			dp[i, 0] = Math.Max(dp[i-1, 0], dp[i-1, 1] + prices[i]);
			dp[i, 1] = Math.Max(dp[i-1, 1], -prices[i]);
		}
		return dp[n-1, 0];
	}
	
	//#123.交易两次
	private int MaxProfit111(int[] prices){
		if(prices == null || prices.Length < 2){
			return 0;
		}
		int n = prices.Length;
		int max_k = 2;
		int[,,] dp = new int[n,max_k + 1,2];
		dp[0, 1, 0] = 0;
		dp[0, 1, 1] = -prices[0];
		dp[0, 2, 0] = 0;
		dp[0, 2, 1] = -prices[0];
		for (int i = 1; i < n; i++) {
			for (int k = max_k; k >= 1; k--) {
				dp[i, k, 0] = Math.Max(dp[i-1, k, 0], dp[i-1, k, 1] + prices[i]);
				dp[i, k, 1] = Math.Max(dp[i-1, k, 1], dp[i-1, k-1, 0] - prices[i]);
			}
		}
		return dp[n - 1, max_k, 0];
	}
	
	//#122.不限次数
	private int MaxProfit1111(int[] prices){
		if(prices == null || prices.Length < 2){
			return 0;
		}
		int n = prices.Length;
		int[,] dp = new int[n,2];
		dp[0, 0] = 0;
		dp[0, 1] = -prices[0];
		for (int i = 1; i < n; i++) {
			dp[i, 0] = Math.Max(dp[i-1, 0], dp[i-1, 1] + prices[i]); 
			dp[i, 1] = Math.Max(dp[i-1, 1], dp[i-1, 0] - prices[i]);
		}
		return dp[n - 1, 0];
	}

	//#188.交易k次
	private int MaxProfit11111(int k, int[] prices){
		if(prices == null || prices.Length < 2){
			return 0;
		}
		int n = prices.Length;
		if (k > n / 2) 
			return MaxProfit1111(prices);
	
		int[,,] dp = new int[n, k + 1, 2];
		for (int i = 0; i < n; i++) 
			for (int j = k; j >= 1; j--) {
				if (i - 1 == -1) { 
					/* 处理 base case */ 
					dp[i,j,0] = 0;
					dp[i,j,1] = -prices[i];
					continue;
				}
				dp[i, j, 0] = Math.Max(dp[i-1, j, 0], dp[i-1, j, 1] + prices[i]);
				dp[i, j, 1] = Math.Max(dp[i-1, j, 1], dp[i-1, j-1, 0] - prices[i]);   
			}
		return dp[n - 1, k, 0];
	}
	
	// 不限次数
	// int maxProfit_k_inf(int[] prices) {
	// 	int n = prices.length;
	// 	int dp_i_0 = 0, dp_i_1 = Integer.MIN_VALUE;
	// 	for (int i = 0; i < n; i++) {
	// 		int temp = dp_i_0;
	// 		dp_i_0 = Math.max(dp_i_0, dp_i_1 + prices[i]);
	// 		dp_i_1 = Math.max(dp_i_1, temp - prices[i]);
	// 	}
	// 	return dp_i_0;
	// }
	
}
