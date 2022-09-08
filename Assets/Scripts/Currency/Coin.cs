using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PackScene.PackLoader; 

namespace Currency.Coin
{
    public class Coin : MonoBehaviour
    {

        [SerializeField]
        PacksLoader loader;

        [SerializeField]
        private int coin;
        public int GetCoin()
        {
            return coin;
        }

        public void AddCoin(int amountToAdd)
        {
            coin += amountToAdd;
        }

        public void SpendCoin(int amountToSpend)
        {
            if (coin >= amountToSpend)
            {
                coin -= amountToSpend;
            }
            else
            {
                Debug.Log("Not Enough Coin");
            }
        }

        private void OnEnable()
        {
            loader.OnClicked += SpendCoin;
        }

    }
}

