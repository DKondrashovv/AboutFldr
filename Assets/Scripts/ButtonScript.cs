using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private string sex;
    public static Action<string> OnChooseButton;

    public void SendSex()
    {
        OnChooseButton?.Invoke(sex);
    }
    
    
}
