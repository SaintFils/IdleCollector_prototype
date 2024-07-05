using System;
using UnityEngine;

namespace Client.Scripts.Infrustructure
{
    public class Statistic : MonoBehaviour
    {
        public static Statistic Instance { get; private set; }

        public int TotalCollectedCoins { get; private set; }
        public int CurrentCoins { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddTotalCoins(int amount) => TotalCollectedCoins += amount;

        public void AddCurrentCoins(int amount) => CurrentCoins += amount;
        public void RemoveCurrentCoins(int amount) => CurrentCoins = Math.Max(0, CurrentCoins - amount);

        /*public void ResetCoins()
        {
            TotalCollectedCoins = 0;
            CurrentCoins = 0;
        }*/
    }
}