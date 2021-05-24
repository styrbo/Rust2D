using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Weapons
{
    [Serializable]
    public class BurstBulletEmitor : IBulletEmitor
    {
        [SerializeField] private int _minBulletCount, _maxBulletCount;
        [SerializeField] private float _burstDelay = .1f;
        [SerializeField] private float _randomAngle;
        
        
        public Action<Vector2> BulletCreateMethod { get; set; }
        
        
        public void StartEmit(MonoBehaviour context, Vector2 direction)
        {
            context.StartCoroutine(EmitBullets(direction));
        }

        private IEnumerator EmitBullets(Vector2 direction)
        {
            var bulletCount = Random.Range(_minBulletCount, _maxBulletCount);
            var perpendicular = Vector2.Perpendicular(direction);
            
            for (var i = 0; i < bulletCount; i++)
            {
                yield return new WaitForSeconds(_burstDelay);
                
                var currentAngle = Random.Range(-_randomAngle, _randomAngle);
                var dir = Vector2.Lerp(direction, perpendicular * Mathf.Sign(currentAngle), Mathf.Abs(currentAngle) / 90f);
                BulletCreateMethod?.Invoke(dir);
            }
        }

        public void CancelEmit()
        {
            
        }
    }
}