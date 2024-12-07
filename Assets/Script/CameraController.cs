using UnityEngine;

namespace Assets.Script
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = new Vector3(0,0,-1);
        [SerializeField] private float damping = 0.25f;

        public Transform target;

        private Vector3 vel = Vector3.zero;

        private void FixedUpdate()
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);
        }
    }
}
