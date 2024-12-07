using UnityEngine;

namespace Assets.Script
{
    public class JumpPad : MonoBehaviour
    {
        public float Bounce = 25f;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Bounce, ForceMode2D.Impulse);
            }
        }

    
    }
}
