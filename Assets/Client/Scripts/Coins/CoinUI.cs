using Client.Scripts.Infrustructure;
using TMPro;
using UnityEngine;

namespace Client.Scripts.Coins
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentCoinsText;
        [SerializeField] private TMP_Text totalCollectedCoinsText;

        private void Update()
        {
            currentCoinsText.text = $"Current Coins: {Statistic.Instance.CurrentCoins}";
            totalCollectedCoinsText.text = $"Total Collected: {Statistic.Instance.TotalCollectedCoins}";
        }
    }
}