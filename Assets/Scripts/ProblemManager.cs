using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemManager : MonoBehaviour
{
    public TimerManager timerManager;

    public int problemsSolved = 0;
    public TMP_Text displayProblem;
    public TMP_Text displayPoints;
    public TMP_InputField answer;
    public int answerInt;

    public int[] nums;
    public int curAnswer;

    // Start is called before the first frame update
    void Start()
    {
        GenerateProblem(2, 11, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        displayPoints.text = $"Problems solved: {problemsSolved}";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GenerateProblem(int numNum, int highRange, int lowRange, int symbol)
    {
        displayProblem.text = null;
        nums = new int[numNum];
        for (int i = 0; i < numNum; i++)
        {
            nums[i] = Random.Range(lowRange, highRange);
            if(i != numNum - 1)
            {
                if (symbol == 0)
                {
                    displayProblem.text += $"{nums[i]} + ";
                    curAnswer += nums[i];
                }
                if (symbol == 1)
                {
                    displayProblem.text += $"{nums[i]} - ";
                    if(i == 0)
                    {
                        curAnswer = nums[i];
                    }
                    else
                    {
                        curAnswer -= nums[i];
                    }
                }
            }
            else
            {
                displayProblem.text += $"{nums[i]} =";
                if(symbol == 0)
                {
                    curAnswer += nums[i];
                }
                else if(symbol == 1)
                {
                    curAnswer -= nums[i];
                }
            }
        }


        /*
        if(problemsSolved <= 5)
        {
            num1 = Random.Range(0, 11);
            num2 = Random.Range(0, 11 - num1);

            displayProblem.text = $"{num1} + {num2} =";
        }
        else if(problemsSolved <= 10)
        {
            num1 = Random.Range(0, 11);
            num2 = Random.Range(0, num1);

            displayProblem.text = $"{num1} - {num2}";
        }
        */
    }

    public void EnterAnswer()
    {
        if(answer.text != null && int.TryParse(answer.text, out answerInt))
        {
            if(answerInt == curAnswer)
            {
                if(timerManager.timerOn == true)
                {
                    timerManager.ResetTimer();
                }
                StartCoroutine(CorrectColorChange());
                problemsSolved += 1;
                answer.text = null;
                curAnswer = 0;
                if(problemsSolved <= 5)
                {
                    GenerateProblem(2, 11, 0, 0);
                }
                else if(problemsSolved <= 10)
                {
                    GenerateProblem(2, 11, 0, 1);
                }
                else
                {
                    int num1 = Random.Range(2, 4);
                    int num2 = Random.Range(0, 21);
                    int num3 = Random.Range(0, 2);
                    GenerateProblem(num1, num2, 0, num3);
                }
            }
            else
            {
                StartCoroutine(IncorrectColorChange());
            }
        }
    }

    public IEnumerator CorrectColorChange()
    {
        displayPoints.color = Color.yellow;
        yield return new WaitForSeconds(1);
        displayPoints.color = Color.white;
    }

    public IEnumerator IncorrectColorChange()
    {
        displayProblem.color = Color.red;
        yield return new WaitForSeconds(1);
        displayProblem.color = Color.white;
    }
}
