using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{

    public static Database instance { get; private set; }

    public int currentPackIndex;

    public int currentLevelIndex;

    public string currentCorrectAnswer;

    [SerializeField]
    public Packs[] packs { get; private set; }

    [SerializeField]
    public Packs.Level[] levels { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        packs = Resources.LoadAll<Packs>("Packs");

        levels = packs[currentPackIndex].levels;

        currentCorrectAnswer = levels[currentLevelIndex].correctAnswer;

    }
}
