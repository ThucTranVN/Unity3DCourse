using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomObject : MonoBehaviour
{
    //Cho 1 danh sách đầu vào List<object> listIn chứa n phần tử và 1 số nguyên int numObjToGet là số lượng phần tử muốn lấy ra
    //Viết thuật toán để lấy ra các phần tử từ danh sách đầu vào, các phần tử không được trùng nhau

    //Tạo danh sách object đầu vào
    public List<object> listIn = new List<object>();
    //Tạo danh sách object đầu ra
    public List<object> listOut = new List<object>();
    //Số lượng phần tử tối đa của danh sách đầu vào
    private int amount = 10;
    //Số lượng phần tử muốn lấy của danh sách object đầu ra
    public int numObjToGet;

    void Start()
    {
        CreateRandomListIn();
        GetRandomObjFromList(listIn, numObjToGet);
    }

    //Hàm tạo danh sách đầu vào
    private void CreateRandomListIn()
    {
        //Tạo danh sách đầu vào bằng cách lặp qua số lượng phần tử tối đa của danh sách đàu vào
        for (int i = 0; i < amount; i++)
        {
            //Tạo ngẫu nhiên số trong khoảng từ 0 - 10 và thêm vào danh sách đàu vào
            int randomNumber = Random.Range(0, 10);
            listIn.Add(randomNumber);
            Debug.Log("List in: " + randomNumber);
        }
    }

    //Hàm trả về danh sách đầu ra
    private List<object> GetRandomObjFromList(List<object> listIn, int numObjGet)
    {
        //Tạo danh sách checkList để xử lý, không làm ảnh hưởng đến danh sách listIn
        List<object> checkList = listIn;

        //Kiểm tra số lượng object cần lấy có lớn hơn tổng số lượng object của danh sách đầu vào hay không
        if (numObjGet > checkList.Count)
        {
            Debug.Log("The number of objects to get is greater than the total of the list");
            return listOut;
        }

        //Lặp theo số lượng object cần lấy
        while (listOut.Count < numObjGet)
        {
            //Lấy ngãu nhiên giá trị trong danh sách checkList
            int randomPickIndex = Random.Range(0, checkList.Count);
            object randomObjectToPick = checkList[randomPickIndex];

            //Kiểm tra trong danh sách listOut đã có phần tử này chưa
            if (!listOut.Contains(randomObjectToPick))
            {
                //Nếu chưa có, thêm phần tử ngẫu nhiên này vào trong danh sách listOut
                listOut.Add(randomObjectToPick);
                Debug.Log("List out: " + randomObjectToPick);
            }

            //Khi đã lấy thêm tử random vào listOut thì remove phần tử đó ra khỏi checkList và kiểm tra nếu trong checkList không còn phần tử nào nữa thì dừng vòng lặp
            checkList.RemoveAt(randomPickIndex);
            if (checkList.Count == 0) break;
        }
        //Trả về danh sách đã chứa các phần tử lấy ngẫu nhiên từ danh sách listIn
        return listOut;
    }
}
