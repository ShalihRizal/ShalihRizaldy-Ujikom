using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionLoader : MonoBehaviour
{
    public Packs.Level[] levels;

    [SerializeField]
    private Transform parentContainer;

    private int currentLevelIndex;

    [SerializeField]
    private Packs[] packs;
    [SerializeField]
    private string choice;

    [SerializeField]
    private GameObject answerButtonPrefab;

    private void Awake()
    {
        levels = Database.instance.levels;
        currentLevelIndex = Database.instance.currentLevelIndex;
    }

    private void Start()
    {
        LoadAnswer();
    }

    void LoadAnswer()
    {
        for (int i = 0; i < levels[currentLevelIndex].wrongAnswers.Length; i++)
        {
            Button button = Instantiate(answerButtonPrefab, parentContainer).GetComponent<Button>();
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levels[currentLevelIndex].wrongAnswers[i].ToString() ;
            button.onClick.AddListener(delegate
            {
                Clicked(button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
            });
        }

        Button correctAnswerButton = Instantiate(answerButtonPrefab, parentContainer).GetComponent<Button>();
        correctAnswerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levels[currentLevelIndex].correctAnswer;
        correctAnswerButton.onClick.AddListener(delegate
        {
            Clicked(correctAnswerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
        });
    }

    private void Clicked(string name)
    {

        if (name == Database.instance.currentCorrectAnswer)
        {
            Database.instance.currentLevelIndex++;
            Debug.Log("Jawaban anda Benar");
            SceneManager.LoadScene("Gameplay");
        }
        else
        {
            Debug.Log("Jawaban anda Salah");
            SceneManager.LoadScene("Level");
        }
    }
}
