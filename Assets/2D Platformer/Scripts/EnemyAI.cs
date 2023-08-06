using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f; 
        public LayerMask Ground;
        public LayerMask Wall;
        public GameObject DeathEnemyPrefab;

        private Rigidbody2D rigidbody; 
        public Collider2D TriggerCollider;
        
        public void Death()
        {
            Instantiate(DeathEnemyPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }

        void FixedUpdate()
        {
            if(!TriggerCollider.IsTouchingLayers(Ground) || TriggerCollider.IsTouchingLayers(Wall))
            {
                Flip();
            }
        }
        
        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
    }
}
