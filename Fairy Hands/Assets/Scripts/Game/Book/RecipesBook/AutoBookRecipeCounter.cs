using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoBookRecipeCounter : MonoBehaviour
{
    
    public TextMeshProUGUI DoneText;
    public TextMeshProUGUI ToDoText;

    private int DoneValue;
    private int ToDoValue;


    void Awake()
    {
        DoneValue = 0;
        ToDoValue = 0;

        ToDoText.text = "+";
        DoneText.text = "+";

    }

    public void SetToDo(int value)
    {
        ToDoValue = value;
        ToDoText.text = ToDoValue.ToString();
    }

    public void AddDone()
    {
        DoneValue++;
        DoneText.text = DoneValue.ToString();
    }

    public void SetDone(int value)
    {
        DoneValue = value;
        DoneText.text = DoneValue.ToString();
    }

}
