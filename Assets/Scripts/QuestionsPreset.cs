using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Custom/Question")]
public class QuestionsPreset : ScriptableObject {

    public string questionText;
    public Emotion posEmotion;
    public Emotion NegEmotion;
  
    
}
