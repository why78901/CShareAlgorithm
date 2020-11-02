using System;
using System.Text;
using UnityEngine;

public class util
{
    public static string ToString(object obj){
        StringBuilder builder = new StringBuilder();
        if (obj is Array){
            Array arr = (Array)obj;
            foreach (var item in arr){
                builder.Append(item);
                builder.Append("_");
            }
        }
        return builder.ToString();
    }
}