using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemManager : MonoBehaviour
{
    public int problemsSolved = 0;
    public TMP_Text displayProblem;
    public TMP_Text displayPoints;
    public TMP_InputField answer;

    public int num1;
    public int num2;

    // Start is called before the first frame update
    void Start()
    {
        GenerateProblem();
    }

    // Update is called once per frame
    void Update()
    {
        displayPoints.text = $"Problems solved: {problemsSolved}";
    }

    public void GenerateProblem()
    {
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
    }

    public void EnterAnswer()
    {
        if(problemsSolved <= 5)
        {
            if (int.Parse(answer.text) == (num1 + num2))
            {
                problemsSolved++;
                GenerateProblem();
                answer.text = "";
            }
        }
        if (problemsSolved <= 10)
        {
            if (int.Parse(answer.text) == (num1 - num2))
            {
                problemsSolved++;
                GenerateProblem();
                answer.text = "";
            }
        }
    }
}
