using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    private Controller m_Instance;
    public Controller Instance { get { return m_Instance; } }

    public static int clicks;
   

    public static string color = "red";

    public void addColor(UnityEngine.UI.Button button)
    {
        color = button.name;
    }
    /*
    public void addClick()
    {
        clicks += 1;
    }

    */

    public void sayClick()
    {
        //Debug.Log(clicks);
        Debug.Log(color);
    }

    void Awake()
    {
        m_Instance = this;

        string read = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "prevState.txt"));
        color = read;
        Debug.Log(read);
    }

    void OnDestroy()
    {
        m_Instance = null;

        string tempFile = Path.Combine(Environment.CurrentDirectory, "temp.txt");
        string realFile = Path.Combine(Environment.CurrentDirectory, "prevState.txt");

        System.IO.File.WriteAllText(tempFile, color);

        File.Delete(realFile);
        File.Move(tempFile, realFile);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
