using UnityEngine;

namespace Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(_rb.position + (Vector2)transform.up * (_speed * Time.fixedDeltaTime));
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.TryGetComponent(out IBulletCollider collider))
                return;
            
            collider.OnTakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}