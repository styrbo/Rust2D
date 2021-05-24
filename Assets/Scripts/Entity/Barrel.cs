using Projectiles;
using UnityEngine;

namespace DefaultNamespace.Entity
{
    [RequireComponent(typeof(DamageTarget))]
    public class Barrel : MonoBehaviour
    {
        private DamageTarget _damageTarget;

        private void Awake()
        {
            _damageTarget = GetComponent<DamageTarget>();
        }

        private void OnEnable()
        {
            _damageTarget.OnDeath.AddListener(OnDeath);
        }
        
        private void OnDisable()
        {
            _damageTarget.OnDeath.RemoveListener(OnDeath);
        }

        private void OnDeath()
        {
            
        }
    }
}