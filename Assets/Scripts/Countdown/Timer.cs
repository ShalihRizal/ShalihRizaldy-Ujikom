using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Paintastic.Timer
{
    public class Timer : MonoBehaviour
    {
        public Action OnTimesUp;

        [SerializeField]
        float remaining = 30;

        [SerializeField]
        private TextMeshProUGUI timerText;

        [SerializeField]
        private Slider timerBar;

        private void Awake()
        {
            OnTimesUp += Test;
        }


        private void Update()
        {
            if (remaining > 0)
            {
                remaining -= Time.deltaTime;
                timerBar.value = remaining;
            }
            else
            {
                remaining = 0;
                OnTimesUp?.Invoke();
            }

            DisplayTime(remaining);
        }

        void DisplayTime(float amountToDisplay)
        {
            if (amountToDisplay < 0)
            {
                amountToDisplay = 0;
            }

            float seconds = Mathf.FloorToInt(amountToDisplay % 60);

            timerText.text = string.Format("{0:00}", seconds);
        }

        void Test()
        {
            Debug.Log("Time's Up");
        }
    }
}