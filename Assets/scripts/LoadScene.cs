using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadA("Menu");
        }
    }
    public void LoadA(string scene)
    {
        print("hello");
        SceneManager.LoadScene(scene);
    }    
}
