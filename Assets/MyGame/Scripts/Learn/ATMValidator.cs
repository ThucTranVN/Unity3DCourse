using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMValidator : MonoBehaviour
{
    //In this coding test, you need to validate a given ATM PIN. An ATM PIN is valid if:
    //1. The length of the ATM PIN is either 4 or 6.
    //2. The ATM PIN consists of digits.
    //3. The digits are unique.
    //Assume the skeleton class ATMValidator is given.
    //Your job is to implement the function ValidatePIN(ATMPIN).
    //This function parses the given input string (ATM PIN) and validates the ATM PIN based on the three conditions given above.
    //If the ATM PIN is valid, the function returns the message "The ATM PIN is valid."
    //If not, the function returns the message "The ATM PIN is invalid." 
    //The ATMValidator class takes a string (ATM PIN) and calls the ValidatePIN function to validate the ATM PIN.
    //Two examples: 
    //Input: ATMPIN = 1234 Output: The ATM PIN is valid.
    //Input: ATMPIN = a112233 Output: The ATM PIN is invalid.
    public string ATMPIN;

    void Start()
    {
        Debug.Log(ValidatePin(ATMPIN));
    }

    private string ValidatePin(string ATMPIN)
    {
        //Tạo list để kiểm tra phần tử bị trùng
        List<char> checkDuplicateChar = new List<char>();

        //Kiếm tra độ dài của mã pin nhập vào
        if(ATMPIN.Length == 4 || ATMPIN.Length == 6)
        {
            //Kiểm tra mã pin có phải toàn là số hay không
            bool isNumber = int.TryParse(ATMPIN, out int number);
            if (isNumber)
            {
                //Lặp qua từng phần tử trong mã pin
                foreach (char c in ATMPIN)
                {
                    //Nếu trong list chưa có phần tử này thì add vào
                    if (!checkDuplicateChar.Contains(c))
                    {
                        checkDuplicateChar.Add(c);
                    }
                    //Nếu có ký tự nào trong mã pin giống nhau thì dừng vòng lặp 
                    else
                    {
                        return "The ATM PIN is invalid.";
                    }
                }
                //Không có ký tự nào trong mã pin giống nhau
                return "The ATM PIN is valid.";
            }
            else
            {
                //Mã pin nhập vào không hoàn toàn là số
                return "The ATM PIN is invalid.";
            }
        }
        else
        {
            //Mã pin có độ dài không phải là 4 hoặc 6 ký tự
            return "The ATM PIN is invalid.";
        }
    }
}
