using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayManager : MonoBehaviour
{
   public Text JumpLeftText;
   
    void Update()
    {
        JumpLeftText.text = Playermovement.JumpLeft.ToString();
    }
}
