using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizView : MonoBehaviour
{
    public Packs.Level[] levels;

    private int currentLevelIndex;

    [SerializeField]
    TextMeshProUGUI questionText;

    private void Awake()
    {
        levels = Database.instance.levels;
        currentLevelIndex = Database.instance.currentLevelIndex;
    }

    private void Start()
    {
        string question = levels[currentLevelIndex].question;
        questionText.text = question.ToString();
    }
}
