using Client.Scripts.Infrustructure;
using UnityEngine;

namespace Client.Scripts.Coins
{
    public abstract class CoinTriggerBase : MonoBehaviour
    {
        [SerializeField] protected int coinsPerSecond = 1;
        [SerializeField] protected float triggerCooldown = 1f;
        [SerializeField] protected Transform effectSpawnPoint;
        [SerializeField] protected EffectName effectName;

        protected PlayerCoins playerCoins;
        private bool playerInTrigger;
        private float timeSinceLastCoinOperation;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerCoins = other.GetComponent<PlayerCoins>();
                playerInTrigger = true;
                timeSinceLastCoinOperation = 0f;
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
                timeSinceLastCoinOperation += Time.deltaTime;
            
                if (timeSinceLastCoinOperation >= triggerCooldown)
                {
                    ProcessCoins();
                    //PlayEffect();
                    timeSinceLastCoinOperation = 0;
                }
            }
        }

        protected abstract void ProcessCoins();
        
        protected virtual void PlayEffect()
        {
            Vector3 effectPosition = effectSpawnPoint != null ? effectSpawnPoint.position : transform.position;
            EffectManager.Instance.PlayEffect(effectName, effectPosition);
        }
    }
}