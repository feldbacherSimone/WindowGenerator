using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Emotion
{
    
    public int strength = 2;
    public enum Emotions {fear, anger, happyness, sadness, trust, disgust, curiosity};
    public Emotions emotions; 

    public Emotion(Emotions emotions, int strength)
    {
        this.strength = strength;
        this.emotions = emotions; 
    }

}
