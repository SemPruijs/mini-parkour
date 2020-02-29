using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{
    public static float FinishTime = 0.0f;
    void Update()
    {
        FinishTime += Time.deltaTime;
        print(FinishTime);
    }
}
