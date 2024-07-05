using Client.Scripts.Infrustructure;
using UnityEngine;

namespace Client.Scripts.Coins
{
    public class PlayerCoins : MonoBehaviour
    {
        [SerializeField] public int maxCoins = 100;
        
        public void AddCoins(int amount)
        {
            int coinsToAdd = Mathf.Min(amount, maxCoins - Statistic.Instance.CurrentCoins);
            Statistic.Instance.AddCurrentCoins(coinsToAdd);
        }

        public void RemoveCoins(int amount) => Statistic.Instance.RemoveCurrentCoins(amount);
    }
}