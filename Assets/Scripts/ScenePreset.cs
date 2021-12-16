using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenePreset", menuName = "Custom/ScenePreset")]
public class ScenePreset : ScriptableObject
{
    public string name; 

    [Header("Elements")]
    public GameObject frameObject;
    public GameObject foregroundElement;
    public GameObject middleground;
    public GameObject background; 

    //[Header("Audio")]

    [Header("Time")]
    [Range(0, 24)]
    public int dayTime;

    [Header("Weather")]
    public bool wind;
    [Range(0, 100)]
    public float windStrengh; 
    
}
