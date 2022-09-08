using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PackScene.PackLoader;
using Currency.Coin;
using System;

namespace PackUnlock.Unlocker
{
    public class Unlocker : MonoBehaviour
    {
        [SerializeField]
        PacksLoader loader;

        [SerializeField]
        Coin coin;

        public Action Unlock;

        private void OnEnable()
        {
            
        }
    }

}
