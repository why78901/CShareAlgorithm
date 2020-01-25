using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrStr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		strStr("mississippi","issip");
	}

	public int strStr(string haystack, string needle) {
        int n = haystack.Length;
        int m = needle.Length;
        for(int i = 0; i < n - m + 1; i++){
            int j = 0;
            for(; j < m; j++){
                if(haystack[i+j] != needle[j]){
                    break;
                }
            }
            if(j == m){
                return i;
            }
        }
        return -1;
    }


	public int StrStr2(string haystack, string needle) {
        if (needle == "")
            return 0;
        if (haystack == "")
            return -1;

        if (needle.Length > haystack.Length)
            return -1;

        int i, j;

        if (needle.Length == 1){
            for (i = 0; i < haystack.Length; i++)
                if (haystack[i] == needle[0])
                    return i;
                return -1;
        }

        int[] next = GetNext(needle);

        i = 0;
        j = 0;

        while (i < haystack.Length && j < needle.Length){
            if (haystack[i] == needle[j]){
                i++;
                j++;
            }else{
                j = next[j];
            }
            if (j == -1){
                i++;
                j = 0;
            }
        }

        if (j == needle.Length)
            return i - needle.Length;
        return -1;

    }
    public int[] GetNext(string p)
	{
		int[] next = new int[p.Length];
		next[0] = -1;
		next[1] = 0;
		int k = 0;
		for(int j = 1; j < p.Length-1; j++)
		{

			if (p[j] == p[k]) next[j + 1] = ++k;
			else if (next[k] == -1) next[j + 1] = 0;
			else if (p[j] == p[next[k]])
			{
				next[j + 1] = next[k] + 1;
				k = next[k] + 1;
			}
			else
			{
				next[j + 1] = 0;
				k = 0;
			}

		}
		return next;
	}
	
}
