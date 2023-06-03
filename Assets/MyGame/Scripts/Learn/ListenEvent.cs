using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListenEvent : MonoBehaviour
{
    public TextMeshProUGUI countText;
    private int Count = 0;

    void Start()
    {
        if (ListenerManager.HasInstance)
        {
            //ListenerManager.Instance.Register(ListenType.UPDATE_COUNT_TEXT, OnListenUpdateCountTextEvent);
            ListenerManager.Instance.Register(ListenType.UPDATE_USER_INFO, OnListenUpdateUserInfoEvent);
        }
    }

    private void OnDestroy()
    {
        if (ListenerManager.HasInstance)
        {
            //ListenerManager.Instance.Unregister(ListenType.UPDATE_COUNT_TEXT, OnListenUpdateCountTextEvent);
            ListenerManager.Instance.Unregister(ListenType.UPDATE_USER_INFO, OnListenUpdateUserInfoEvent);
        }
    }

    private void OnListenUpdateUserInfoEvent(object value)
    {
        if (value != null)
        {
            if (value is UserInfo userInfo)
            {
                countText.text = "User Name: " + userInfo.userName;
            }
        }
    }

    private void OnListenUpdateCountTextEvent(object value)
    {
        if(value != null)
        {
            if(value is int countValue)
            {
                Count += countValue;
                countText.text = "Count: " + Count;
            }
        }
    }

}
