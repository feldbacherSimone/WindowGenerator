using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Question : MonoBehaviour
{
    public bool lastQuestion; 

    public Toggle[] toggles;
    public Text questionText; 

    public QuestionsPreset preset; 

    public Emotion negEmotion;
    public Emotion posEmotion;

    public Button skipB;
    public Button sortB;

    public Slider slider; 

    bool changeValues = true; 
    
    public void initialize()
    {
        questionText.text = preset.questionText;
        posEmotion = preset.posEmotion;
        negEmotion = preset.NegEmotion;


        toggles = new Toggle[transform.GetChild(0).childCount];
        int i = 0; 
        foreach (Transform child in transform.GetChild(0))
        {
          toggles[i] = child.GetComponent<Toggle>();
            i++;
        }

        AssignButtonListeners(skipB, sortB); 
        
    }
    private void Update()
    {
        if(changeValues)
        editEmotions(); 
    }
    void editEmotions()
    {     
            posEmotion.strength = 0;
            negEmotion.strength = 0;

            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                {
                    if (i > 2)
                        posEmotion.strength += i - 2;
                    if (i < 2)
                        negEmotion.strength += (i - 2) * -1;
                }  
            }      
    }

    public void SubmitAnswer()
    {
        changeValues = false; 
        QuizManager quizManager;
        quizManager = GameObject.FindGameObjectWithTag("QuizManager").GetComponent<QuizManager>();

            quizManager.IncreaseStat(posEmotion.strength, posEmotion);
            quizManager.IncreaseStat(negEmotion.strength, negEmotion);
    }

    

    void AssignButtonListeners(Button skip, Button sort)
    {
        QuizManager quizManager = GameObject.FindGameObjectWithTag("QuizManager").GetComponent<QuizManager>();
        CamController camController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamController>();
        if (lastQuestion)
            skipB.gameObject.SetActive(false); 

        skip.onClick.AddListener(() =>
        {
            Debug.Log("Clicked !");
            SubmitAnswer();
            if(!lastQuestion)
            camController.UpdateDestination();
           
            
        });

        sort.onClick.AddListener(() =>
        {
            if (lastQuestion)
            {
                SubmitAnswer();
                SceneManager.LoadScene(1);
            }
            quizManager.SortEmotions();
        });
    }
}
