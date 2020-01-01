using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生成杨辉三角的前n行
public class Generate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Generate3(4);
		Debug.LogError("Generate3");
		Generate3(5);
	}
	
	public IList<IList<int>> Generate1(int numRows) {
		IList<IList<int>> res = new List<IList<int>>();
		if(numRows == 0){
			return res;
		}
			
		int row = 0;
		while(row < numRows){
			IList<int> list = new List<int>();
			if(row == 0){
				list.Add(1);
			}else if(row == 1){
				list.Add(1);
				list.Add(1);
			}else{
				IList<int> prelist = res[row - 1];
				list.Add(1);
				int num = 0;
				for(var i = 1; i < row; i++){
					num = prelist[i-1] + prelist[i];
					list.Add(num);
				}
				list.Add(1);
			}
			res.Add(list);
			row++;
		}
		return res;
    }

    public IList<IList<int>> Generate2(int numRows) {
       if(numRows == 0)
        {
            return new List<IList<int>>();
        }

        var yangHuiList = new List<IList<int>>();
        for(int i = 0; i < numRows; i++)
        {
            yangHuiList.Add(new List<int>());
            for(int j = 0; j <= i; j++)
            {
                if(j == 0 || j == i)
                {
                    yangHuiList[i].Add(1);
                }
                else
                {
                    yangHuiList[i].Add((yangHuiList[i - 1][j - 1] + yangHuiList[i - 1][j]));
                }
            }
        }

        return yangHuiList;
    }

	public IList<int> Generate3(int rowIndex) {
		var trangle = new List<int>();
		if(rowIndex == 0)
			return trangle;
		for(int i = 0; i <= rowIndex; i++){
			trangle.Add(1);
			for(int j = i - 1; j > 0; j--){
				trangle[j] += trangle[j-1];
			}
		}
		for(int i = 0; i <= rowIndex; i++){
			Debug.LogErrorFormat("trangle i{0} {1}", i, trangle[i]);
		}
		return trangle;
	}
}
