using UnityEngine;

namespace Client.Scripts.Coins
{
    public abstract class CoinTriggerBase : MonoBehaviour
    {
        [SerializeField] protected int coinsPerSecond = 1;

        protected PlayerCoins playerCoins;
        private bool playerInTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerCoins = other.GetComponent<PlayerCoins>();
                playerInTrigger = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInTrigger = false;
            }
        }

        protected virtual void Update()
        {
            if (playerInTrigger)
            {
                ProcessCoins();
            }
        }

        protected abstract void ProcessCoins();
    }
}