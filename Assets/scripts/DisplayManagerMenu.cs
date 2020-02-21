using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManagerMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levels;

    public LoadScene SceneLoader;
    void Start()
    {
        SetMainMenu();
    }
    
    public void SetLevelSelect()
    {
        mainMenu.SetActive(false);
        levels.SetActive(true);
    }

    public void SetMainMenu()
    {
        mainMenu.SetActive(true);
        levels.SetActive(false);
    }
}
