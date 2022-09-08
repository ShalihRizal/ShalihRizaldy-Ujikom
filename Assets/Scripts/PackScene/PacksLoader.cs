using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Currency.Coin;
using UnityEngine.UI;
using TMPro;
using PackUnlock.Unlocker;
using System;
using Data;
using UnityEngine.SceneManagement;

namespace PackScene.PackLoader
{

    public class PacksLoader : MonoBehaviour
    {
        [SerializeField]
        private Packs[] packs;

        [SerializeField]
        private GameObject PackButtonPrefab;

        [SerializeField]
        private Transform parentContainer;

        public Action<int> OnClicked;

        [SerializeField]
        Coin coin;

        private int selectedPackIndex;

        private void Awake()
        {
            LoadPacksList();
        }

        private void Start()
        {
            LoadPacks();
        }

        void LoadPacks()
        {
            for (int i = 0; i < packs.Length; i++)
            {
                Button button = Instantiate(PackButtonPrefab, parentContainer).GetComponent<Button>();

                Transform unlockImage = button.transform.GetChild(0);
                Transform unlockButton = button.transform.GetChild(2);
                TextMeshProUGUI packText = button.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

                packText.text = "Level Pack " + packs[i].packName.ToString();

                if (packs[i].isUnlocked)
                {
                    button.onClick.AddListener(SelectPack);
                    unlockImage.gameObject.SetActive(false);
                    unlockButton.gameObject.SetActive(false);
                    selectedPackIndex = i;
                }
                else
                {
                    button.onClick.AddListener(() => { CheckPrice(); });
                }
            }
        }

        void SelectPack()
        {
            Database.instance.currentPackIndex = selectedPackIndex;
            SceneManager.LoadScene("Level");
        }

        Packs[] GetPackList()
        {
            return packs;
        }


        private void LoadPacksList()
        {
            packs = Database.instance.packs;
        }

        void CheckPrice()
        {
            coin.SpendCoin(100);
        }
    }
}
