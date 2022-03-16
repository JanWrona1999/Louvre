using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataKeeper : MonoBehaviour
{
    public static bool difficulty;
    public static string IP;
    public GameObject toggler;
    void Start()
    {
        
    }
    void Update()
    {
        difficulty = toggler.GetComponent<Toggle>().isOn;
    }
    
    public void ReadStringInput(string ip)
    {
        IP = ip;
    }
}