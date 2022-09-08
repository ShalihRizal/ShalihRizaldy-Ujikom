using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Currency.Coin;

public class QuestionLoader : MonoBehaviour
{
    public Packs.Level[] levels;

    [SerializeField]
    private Transform parentContainer;

    [SerializeField]
    private Image hintImage;

    [SerializeField]
    Coin coin;

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

        hintImage.sprite = levels[currentLevelIndex].hintImage;

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
            levels[currentLevelIndex].isAnswered = true;
            Database.instance.currentCorrectAnswer = levels[Database.instance.currentLevelIndex].correctAnswer;

            coin.AddCoin(20);

            if (Database.instance.currentLevelIndex >= 4)
            {
                Database.instance.packs[Database.instance.currentPackIndex].isCompleted = true;
                SceneManager.LoadScene("Pack");
            }

            SceneManager.LoadScene("Gameplay");
        }
        else
        {
            SceneManager.LoadScene("Level");
        }
    }
}
