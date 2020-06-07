using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayManager : MonoBehaviour
{
   public Text JumpLeftText;
   public Text time;
   
    void Update()
    {
        JumpLeftText.text = Playermovement.JumpLeft.ToString();
        time.text = Playermovement.Timer.ToString("F1");
    }
}
