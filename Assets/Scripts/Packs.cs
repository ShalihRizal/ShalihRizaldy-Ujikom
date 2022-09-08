using UnityEditor;
using UnityEngine;

[CreateAssetMenuAttribute]
public class Packs : ScriptableObject
{
    [SerializeField]
    Level[] levels;

    [System.Serializable]
    class Level
    {
        [SerializeField]
        private string question;

        [SerializeField]
        private string[] answers;

        [SerializeField]
        private int correctAnswer;

        [SerializeField]
        bool isAnswered;
    }
}