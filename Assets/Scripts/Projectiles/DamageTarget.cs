using UnityEngine;
using UnityEngine.Events;

namespace Projectiles
{
    public class DamageTarget : MonoBehaviour, IBulletCollider
    {
        public UnityEvent OnDeath;
        
        [SerializeField] private float _hp;

        public float HP
        {
            get => _hp;
            set
            {
                if (value <= 0)
                {
                    OnDeath.Invoke();
                }
                
                _hp = value;
            }
        }


        public void OnTakeDamage(float amount)
        {
            HP -= amount;
        }
    }
}