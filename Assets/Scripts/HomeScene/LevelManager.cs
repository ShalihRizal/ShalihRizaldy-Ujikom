using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(LoadPackScene);
    }

    void LoadPackScene()
    {
        SceneManager.LoadScene("Pack");
    }
}
