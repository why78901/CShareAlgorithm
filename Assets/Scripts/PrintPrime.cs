using UnityEngine;
using System;
using System.Collections;

public class PrintPrime : MonoBehaviour
{
    private void Start(){
        bool isPrime = IsPrime(7);
        Debug.LogFormat("isPrime: " + isPrime);
    }

    //打印所有素数
    void printPrime(int n){
        bool isPrime;
        for (int i = 1; i <= n; i++) {
            isPrime = true;
            for (int j = 2; j < i; j++) {
                //若能除尽，则不为质数
                if (i % j == 0) {
                    isPrime = false;
                    break;
                }
            }
            //如果是质数，则打印
            if (isPrime) {
                Debug.Log(i);
            }
        }
    }
    
    //判断是否是素数
    public bool IsPrime(int candidate)
    {
        if (candidate % 2 != 0)
        {
            int limit = (int)Math.Sqrt(candidate);
            for (int divisor = 3; divisor <= limit; divisor += 2)
            {
                if (candidate % divisor == 0)
                    return false;
            }
            return true;
        }
        return candidate == 2; //能被2整除的不是素数
    }
}