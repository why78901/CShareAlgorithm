using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//#64.最小路径和
//给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
// 说明：每次只能向下或者向右移动一步。
public class MinPathSum : MonoBehaviour {

	public int minPathSum(int[][] grid) {
		if (grid.Length == 0)
			return 0;
		int row = grid.Length;
		int col = grid[0].Length;
		for(int i = 0; i < row; i++){
			for(int j = 0; j < col; j++){
				if(i == 0 && j == 0){
					continue;
				}
				else if(i == 0){
					grid[i][j] = grid[i][j - 1] + grid[i][j];
				}
				else if (j == 0){
					grid[i][j] = grid[i - 1][j] + grid[i][j];
				}
				else{
					grid[i][j] = Math.Min(grid[i-1][j],grid[i][j-1]) + grid[i][j];
				}
			}
		}
		return grid[row-1][col-1];
	}
}
