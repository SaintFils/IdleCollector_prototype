using System.Collections.Generic;
using UnityEngine;

namespace Client.Scripts.Infrustructure
{
    public class EffectManager : MonoBehaviour
    {
        public static EffectManager Instance { get; private set; }

        public List<EffectPool> effectPools;

        private Dictionary<EffectName, Queue<ParticleSystem>> poolDictionary;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializePools();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializePools()
        {
            poolDictionary = new Dictionary<EffectName, Queue<ParticleSystem>>();

            foreach (var effectPool in effectPools)
            {
                Queue<ParticleSystem> objectPool = new Queue<ParticleSystem>();

                for (int i = 0; i < effectPool.poolSize; i++)
                {
                    GameObject obj = Instantiate(effectPool.effectPrefab, transform);
                    obj.SetActive(false);
                    ParticleSystem particleSystem = obj.GetComponent<ParticleSystem>();
                    objectPool.Enqueue(particleSystem);
                }

                poolDictionary.Add(effectPool.effectName, objectPool);
            }
        }

        public void PlayEffect(EffectName effectName, Vector3 position)
        {
            if (!poolDictionary.ContainsKey(effectName))
            {
                Debug.LogWarning($"Effect pool for {effectName} doesn't exist.");
                return;
            }

            Queue<ParticleSystem> effectPool = poolDictionary[effectName];

            if (effectPool.Count == 0)
            {
                Debug.LogWarning($"Effect pool for {effectName} is empty. Consider increasing pool size.");
                return;
            }

            ParticleSystem effect = effectPool.Dequeue();
            effect.transform.position = position;
            effect.gameObject.SetActive(true);
            effect.Play();

            StartCoroutine(ReturnToPool(effect, effectName));
        }

        private System.Collections.IEnumerator ReturnToPool(ParticleSystem effect, EffectName effectName)
        {
            yield return new WaitForSeconds(effect.main.duration);
            effect.Stop();
            effect.gameObject.SetActive(false);
            poolDictionary[effectName].Enqueue(effect);
        }
        
        [System.Serializable]
        public class EffectPool
        {
            public EffectName effectName;
            public GameObject effectPrefab;
            public int poolSize = 20;
        }
    }
}