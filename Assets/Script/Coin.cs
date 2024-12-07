using UnityEngine;

namespace Assets.Script
{
    public class Coin : MonoBehaviour
    {
        //Attributes
        [SerializeField] private bool isGold;
        private float despawnTime = -10;
    
        //Method
        public void StartPhysics()
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            Vector2 randomDirection = Vector3.up + new Vector3(
                Random.Range(-1f, 1f),
                0
            );
            GetComponent<Rigidbody2D>().AddForce(randomDirection * 10, ForceMode2D.Impulse);
            despawnTime = 3f;
        }

        private void Update()
        {
            if (despawnTime > -10)
            {
                despawnTime -= Time.deltaTime;
                if (despawnTime < 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (despawnTime > 2.5) return;
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
}
