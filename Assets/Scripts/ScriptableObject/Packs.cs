using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute]
public class Packs : ScriptableObject
{
    [SerializeField]
    private string packID;

    [SerializeField]
    public string packName;

    [SerializeField]
    public bool isCompleted;

    [SerializeField]
    public bool isUnlocked;

    [SerializeField]
    public Level[] levels;

    [SerializeField]
    public int unlockCost { get; private set; } = 100;

    [SerializeField]
    public int ID { get; private set; }

    [System.Serializable]
    public class Level
    {
        [SerializeField]
        public int levelID;

        [SerializeField]
        public string question;

        [SerializeField]
        public string[] wrongAnswers;

        [SerializeField]
        public string correctAnswer;

        [SerializeField]
        public Sprite hintImage;

        [SerializeField]
        public bool isAnswered;
    }
}