using System;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class SingleBulletEmitor : IBulletEmitor
    {
        public Action<Vector2> BulletCreateMethod { get; set; }

        public void StartEmit(MonoBehaviour context, Vector2 direction)
        {
            BulletCreateMethod?.Invoke(direction);
        }

        public void CancelEmit()
        {
            
        }
    }
}