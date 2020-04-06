using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//买股票的最佳时机
public class MaxProfit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[] prices = {7,1,5,3,6,4};
		int result = MaxProfit11(prices);
		Debug.LogError("MaxProfit11"+result);
	}

	//只有一次交易
	private int MaxProfit1(int[] prices){
		if(prices.Length == 0)
            return 0;
        int min = prices[0];
        int profit = 0;
        for(int i=1; i<prices.Length; i++){
            if(prices[i] > min){
                profit = Math.Max(prices[i] - min,profit);
            }else{
                min = prices[i];
            }
        }
        return profit;
	}	

	private int MaxProfit11(int[] prices){
		int n = prices.Length;
		Dictionary<int,List<int>> dp = new Dictionary<int,List<int>>();
		for(int i = 0; i < n; i++){
			dp.Add(i,new List<int>{0,0});
		}
		for(int i = 1; i < n; i++){
			dp[i][0] = Math.Max(dp[i-1][0], dp[i-1][1] + prices[i]);
			dp[i][1] = Math.Max(dp[i-1][1], -prices[i]);
		}
		return dp[n-1][0];
	}


	//多次交易
	private int MaxProfit2(int[] prices) {
        return calculate2(prices, 0);
    }

	//force func
	private int calculate2(int[] prices, int s){
		if(s >= prices.Length)
			return 0;
		int max = 0;
		for(int start=s; start < prices.Length; start++){
			int maxProfit = 0;
			for(int i = start + 1; i < prices.Length; i++){
				if(prices[start] < prices[i]){
					//记录当前位置i的最优解，获取后面数组的最优解(依次递归)
					int profit = calculate2(prices, i + 1) + (prices[i] - prices[start]);
					if(profit > maxProfit){
						maxProfit = profit;
					}
				}
			}
			if(maxProfit > max){
				max = maxProfit;
			}
		}
		return max;
	}

	//多次交易 波峰波谷法
	private int MaxProfit3(int[] prices) {
		if(prices.Length == 0)
			return 0;
		int i = 0;
        int peak = prices[0];
		int valley = prices[0];
		int maxProfit = 0;
		while(i < prices.Length - 1){
			while(i < prices.Length - 1 && prices[i] >= prices[i+1]){
				i++;
			}
			valley = prices[i];
			while(i < prices.Length - 1 && prices[i] <= prices[i+1]){
				i++;
			}
			peak = prices[i];
			maxProfit += peak - valley;
		}
		return maxProfit;
    }


	private int MaxProfit4(int[] prices){
		if(prices.Length == 0)
			return 0;
		int profit = 0;
		for(int i = 1; i < prices.Length; i++){
			if(prices[i] > prices[i-1]){
				profit += prices[i] - prices[i-1];
			}
		}
		return profit;
	}
	
	

	#region #JAVA# 动态规划解法
	//https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii/solution/yi-ge-tong-yong-fang-fa-tuan-mie-6-dao-gu-piao-wen/
	//只能买卖一次
	// private int MaxProfit1111(int[] prices){
	// 	if(prices.length == 0)
    //         return 0;
    //     int n = prices.length;
    //     int[][] dp = new int[n][2];
    //     for (int i = 0; i < n; i++) {
    //         if(i == 0){
    //             dp[i][0] = 0;
    //             dp[i][1] = -prices[i];
    //             continue;
    //         }
    //         dp[i][0] = Math.max(dp[i-1][0], dp[i-1][1] + prices[i]);
    //         dp[i][1] = Math.max(dp[i-1][1], -prices[i]);
    //     }
    //     return dp[n - 1][0];
	// }

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


	int maxProfit_k_inf(int[] prices){
		int n = prices.Length;
		int dp_i_0 = 0, dp_i_1 = int.MinValue;
		for(int i = 0; i < n; i++){
			int temp = dp_i_0;
			dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
			dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
		}
		return dp_i_0;
	}

	// 只能买卖两次
	// dp[i][2][0] = max(dp[i-1][2][0], dp[i-1][2][1] + prices[i])
	// dp[i][2][1] = max(dp[i-1][2][1], dp[i-1][1][0] - prices[i])
	// dp[i][1][0] = max(dp[i-1][1][0], dp[i-1][1][1] + prices[i])
	// dp[i][1][1] = max(dp[i-1][1][1], -prices[i])
	//  public int maxProfit(int[] prices) {
    //     int dp_i10 = 0, dp_i11 = Integer.MIN_VALUE;
    //     int dp_i20 = 0, dp_i21 = Integer.MIN_VALUE;
    //     for (int price : prices) {
    //         dp_i20 = Math.max(dp_i20, dp_i21 + price);
    //         dp_i21 = Math.max(dp_i21, dp_i10 - price);
    //         dp_i10 = Math.max(dp_i10, dp_i11 + price);
    //         dp_i11 = Math.max(dp_i11, -price);
    //     }
    //     return dp_i20;
    // }
	public int maxProfit_k_2(int[] prices){
		int dp_i10 = 0, dp_i11 = int.MinValue;
		int dp_i20 = 0, dp_i21 = int.MinValue;
		for(int i = 0; i < prices.Length; i++){
			int price = prices[i];
			dp_i20 = Math.Max(dp_i20, dp_i21 + price);
			dp_i21 = Math.Max(dp_i21, dp_i10 - price);
			dp_i10 = Math.Max(dp_i10, dp_i11 + price);
			dp_i11 = Math.Max(dp_i11, -price);
		}
		return dp_i20;
	}

	//买卖K次
	// int maxProfit_k_any(int max_k, int[] prices) {
	// 	int n = prices.length;
	// 	if (max_k > n / 2) 
	// 		return maxProfit_k_inf(prices);
	// 
	// 	int[][][] dp = new int[n][max_k + 1][2];
	// 	for (int i = 0; i < n; i++) 
	// 		for (int k = max_k; k >= 1; k--) {
	// 			if (i - 1 == -1) { 
	// 				/* 处理 base case */ 
	// 				dp[i][k][0] = 0;
	// 				dp[i][k][1] = -prices[i];
	// 				continue;
	// 			}
	// 			dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i]);
	// 			dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i]);     
	// 		}
	// 	return dp[n - 1][max_k][0];
	// }

	#endregion
}
