using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelsLoader : MonoBehaviour
{
    public Packs.Level[] levels;

    [SerializeField]
    private GameObject LevelButtonPrefab;

    [SerializeField]
    private Transform parentContainer;

    [SerializeField]
    private Packs[] packs;

    private int currentPackIndex;

    private void Awake()
    {
        currentPackIndex = Database.instance.currentPackIndex;
    }

    private void Start()
    {
        LoadPacksList();

        LoadLevel();
    }

    void LoadLevel()
    {
        levels = packs[currentPackIndex].levels;

        for (int i = 0; i < levels.Length; i++)
        {
            Button button = Instantiate(LevelButtonPrefab, parentContainer).GetComponent<Button>();
            button.onClick.AddListener(Clicked);

            Transform isAnsweredImage = button.transform.GetChild(1);
            Transform levelNameText = button.transform.GetChild(0);

            levelNameText.GetComponent<TextMeshProUGUI>().text = "Level " + packs[currentPackIndex].packName + "-" + levels[i].levelID.ToString();

            if (levels[i].isAnswered)
            {
                isAnsweredImage.gameObject.SetActive(true);
            }
            else
            {
                isAnsweredImage.gameObject.SetActive(false);
            }

        }

    }

    private void LoadPacksList()
    {
        packs = Resources.LoadAll<Packs>("Packs");
    }

    void Clicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
