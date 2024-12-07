using TMPro;
using UnityEditor;
using UnityEngine;

namespace Assets.Script
{
    public class Player : MonoBehaviour, IDamageable
    {
        //Attributes
        private int coin;

        public int Coin
        {
            get { return coin;}
            set { coin = Mathf.Max(value,0); }
        }

        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private GameOverScreen gameOverScreen;
        [SerializeField] private GameObject silverCoin;


        //Method
        void Update()
        {
            coinText.text = $"coin: {Coin}";
        }

        public void CollectingCoin()
        {
            Coin += 1;
        }
        public void CollectingCoin(int coinCollected)
        {
            Coin += coinCollected;
        }

        public void TakeDamage()
        {
            if (Coin > 0)
            {
                //Drop Coin
                for (int i = 0; i < Coin; i++)
                {
                    GameObject spawnCoin = Instantiate(silverCoin, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    spawnCoin.GetComponent<Coin>().StartPhysics();
                }

                Coin = 0;

                //Add I Frame ? not sure
            }
            else
            {
                Time.timeScale = 0;
                gameOverScreen.StartGameOver();
            }
        }
    }
}
