using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private bool isGold;
    //Method
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (isGold)
                {
                    player.CollectingCoin(2);
                }
                else
                {
                    player.CollectingCoin();
                }
                Destroy(gameObject);
            }
        }
    }
}
