using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinus : MonoBehaviour
{
    //Given an array of integers, calculate the ratios of its elements that are positive, negative, and zero.
    //Print the decimal value of each fraction on a new line withplaces after the decimal.
    //Note: This challenge introduces precision problems.The test cases are scaled to six decimal places,
    //though answers with absolute error of up to are acceptable.
    //Example
    //arr = [1,1,0,-1,-1]
    //There are elements, two positive, two negative and one zero.Their ratios are 2/5, 2/5 and 1/5. Results are printed as:

    //0.400000
    //0.400000
    //0.200000

    public List<int> arr;

    void Start()
    {
        PlusMinusSolution(arr);
    }

    private void PlusMinusSolution(List<int> arr)
    {
        int pos = 0;
        int nev = 0;
        int zero = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == 0)
            {
                zero++;
            }
            else if (arr[i] > 0) 
            {
                pos++;
            } else if (arr[i] < 0)
            {
                nev++;
            }
        }

        float zeroResult = zero / (arr.Count * 1.0f);
        float posResult = pos / (arr.Count * 1.0f);
        float nevResult = nev / (arr.Count * 1.0f);
        Debug.Log("Pos: " + string.Format("{0:N6}", (decimal)posResult));
        Debug.Log("Nev: " + string.Format("{0:N6}", (decimal)nevResult));
        Debug.Log("Zero: " + string.Format("{0:N6}", (decimal)zeroResult));
    }
}
