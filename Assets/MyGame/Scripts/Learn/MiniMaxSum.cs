using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMaxSum : MonoBehaviour
{
    //Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers.
    //Then print the respective minimum and maximum values as a single line of two space-separated long integers.
    //Output Format
    //Print two space-separated long integers denoting the respective minimum and maximum values that can be calculated by summing exactly
    //four of the five integers. (The output can be greater than a 32 bit integer.)
    //Sample Input
    //1 2 3 4 5
    //Sample oputut
    //10 14
    public List<int> arr;

    void Start()
    {
        Sum(arr);
    }

    void Sum(List<int> arr)
    {

        long sum = 0;
        long max = arr[0];
        long min = arr[0];
        for (int i = 0; i < arr.Count; i++)
        {
            Debug.Log(arr[i]);
            sum += arr[i];
            if(arr[i] < min)
            {
                min = arr[i];
            }
            if(arr[i] > max)
            {
                max = arr[i];
            }
        }

        long maxSum = sum - min;
        long minSum = sum - max;
        Debug.Log(minSum);
        Debug.Log(maxSum);
    }
}
