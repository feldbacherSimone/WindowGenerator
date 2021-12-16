using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class QuizManager : MonoBehaviour
{
   public Emotion[] emotions = new Emotion[7];

  public void IncreaseStat(int value, Emotion emotion)
    {
        for (int i = 0; i < emotions.Length; i++)
        {
            if (emotion.emotions == emotions[i].emotions)
                emotions[i].strength += value; 
        }
    }

    public void SortEmotions()
    {
        Emotion strongestEmotion = emotions[0]; 
        for (int i = 1; i < emotions.Length; i++)
        {
            if (emotions[i].strength > strongestEmotion.strength)
                strongestEmotion = emotions[i]; 
        }
        print("Strongest Emotion: "+ strongestEmotion.emotions + "=" + strongestEmotion.strength );
        PlayerPrefs.SetString("Emotion", strongestEmotion.emotions.ToString());
        print(strongestEmotion);
    }
    
}
