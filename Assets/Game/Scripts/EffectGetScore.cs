using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectGetScore : MonoBehaviour
{
    [Header("UI reference")]
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform destination;

    [Space]
    [Header("Available coins: (coin to pool)")]
    [SerializeField] int maxCoin;
    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Space]
    [Header("Animation setting")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
    [SerializeField] [Range(0.9f, 2.0f)] float maxAnimDuration;
    [SerializeField] Ease easeType;
    [SerializeField] float spread;

    private void Awake()
    {
        PrepareCoins();
    }
    private void OnEnable()
    {
        EventManager.EffectGetCoin += Animate;
    }
    private void OnDisable()
    {
        EventManager.EffectGetCoin -= Animate;
    }
    void PrepareCoins()
    {
        for (int i = 0; i < maxCoin; i++)
        {
            GameObject coin;
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
    }
    void Animate(Vector3 collectedCoinPosition, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            // check if there's coin from the pool
            if (coinsQueue.Count > 0)
            {
                // extract a coin from pool
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);

                // move coin to the collected coin position
                coin.transform.position = collectedCoinPosition + new Vector3(Random.Range(-spread, spread), 0, Random.Range(-spread, spread));

                // animate coin to target position
                float duration = Random.Range(minAnimDuration, maxAnimDuration);
                coin.transform.DOMove(destination.transform.position, duration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // excutes whenever coin reach target position
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);
                        EventManager.GetScore?.Invoke(1);
                    });
            }
        }
    }
}
