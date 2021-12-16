using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WindowManager : MonoBehaviour
{
    public Dropdown shapeSelecion; 
    public void GenerateWindow()
    {

      clear("Frame");
        print("Windows/" + shapeSelecion.options[shapeSelecion.value].text); 
        GameObject frame =   GameObject.Instantiate(Resources.Load<GameObject>("Windows/" + shapeSelecion.options[shapeSelecion.value].text));
      
      frame.tag = "Frame";
      frame.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);  
      

    }
    
    void clear(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag); 
        foreach (GameObject _object in objects)
        {
            Destroy(_object);
        }
    }
}
