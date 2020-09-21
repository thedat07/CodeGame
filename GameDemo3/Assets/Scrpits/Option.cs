using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Option : MonoBehaviour 
{
    // Start is called before the first frame update
    public TMP_Dropdown tmp_Resolution;
    public TMP_Dropdown tmp_Graphics;
    public int Resolution = 1;
    public int Graphics = 1;
    public string a;

    void Start()
    {
        a = Application.persistentDataPath;

    }
    public void Update()
    {
        Resolution = SaveManager.instance.activeSave.Resolution;
        Graphics = SaveManager.instance.activeSave.Graphics;
        tmp_Resolution.value = Resolution;
        tmp_Graphics.value = Graphics;
    }
    public void load()
    {

    }
    public void Save()
    {
        

    }
    public void OptionScreen(int Resolution)
    {
        if (Resolution == 0)
        {
            Screen.SetResolution(1024, 576, Screen.fullScreen);
            Debug.Log("val0");
        }
        if (Resolution == 1)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
            Debug.Log("val1");
        }
        if (Resolution == 2)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
            Debug.Log("val2");
        }
        SaveManager.instance.activeSave.Resolution = Resolution;
        SaveManager.instance.Save();
    }
    public void OptionGraphics(int Graphics)
    {
        if (Graphics == 0)
        {
            QualitySettings.SetQualityLevel(0);
            Debug.Log("val0");
        }
        if (Graphics == 1)
        {
            QualitySettings.SetQualityLevel(2);
            Debug.Log("val1");
        }
        if (Graphics == 2)
        {
            QualitySettings.SetQualityLevel(5);
            Debug.Log("val2");
        }
        SaveManager.instance.activeSave.Graphics = Graphics;
        SaveManager.instance.Save();
    }
}
