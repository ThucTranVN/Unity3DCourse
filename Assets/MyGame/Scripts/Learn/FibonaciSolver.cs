using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FibonaciSolver : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> digits;
    public List<int> result;
    public int[,] board;
    void Start()
    {
        //Debug.Log(fibonacci(5));
        //result = plusOne(digits);
    }

    private int fibonacci(int n)
    {
        int a = 0, b = 1, c = 0;

        if (n == 0) return a;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return b;
    }

    public List<int> plusOne(List<int> digits)
    {
        result = new List<int>();
        int index = digits.Count - 1;

        while(index >= 0 && digits[index] == 9)
        {
            digits[index--] = 0;
            result.Add(digits[index]);
        }

        if(index < 0)
        {
            result.Add(1);
        }
        else
        {
            digits[index]++;
            result.Add(digits[index]);
        }
        return result;
    }
}
