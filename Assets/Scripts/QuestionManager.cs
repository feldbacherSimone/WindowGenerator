using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Question[] questionClasses;

    private Object[] questions;

    private List<int> numbers = new List<int>();

    public GameObject template;
    public int questionAmmount = 4;
    public int distance = 800;

    private void Start()
    {
        int margine = 0;
        for (int e = 0; e < questionAmmount; e++)
        {
            GameObject question = Instantiate(template, transform);
            question.transform.position = new Vector3(margine, transform.position.y, transform.position.z);
            question.name = "Question " + e + 1;
            question.GetComponent<Question>().slider.value = setPercentage(questionAmmount, e+1);
            margine += 800;
        }

        questions = Resources.LoadAll("Questions");
        questionClasses = new Question[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            questionClasses[i] = child.GetComponent<Question>();
            i++;
        }
        pickNumbers();
        i = 0;

        foreach (Question question in questionClasses)
        {
            question.preset = (QuestionsPreset)questions[numbers[i]];
            i++;
            if (i == transform.childCount )
                question.lastQuestion = true; 
            question.initialize();
        }
    }

    void pickNumbers()
    {
        List<int> possibleNumbers = new List<int>();

        int range = questions.Length;

        for (int i = 0; i < range; i++)
        {
            possibleNumbers.Add(i);
            print(possibleNumbers[i]);
        }

        print(questionClasses.Length);

        for (int i = 0; i < questionClasses.Length; i++)
        {
            range = possibleNumbers.Count;
            int index = Random.Range(0, range);
            numbers.Add(possibleNumbers[index]);
            possibleNumbers.RemoveAt(index);

        }
        for (int i = 0; i < numbers.Count; i++)
        {
            print("Number = " + numbers[i]);
        }
    }

    float setPercentage(int totalNumber, int questionNumber)
    {
        float percentage = (float)questionNumber / (float)totalNumber;
        return percentage; 
    }
    
}
