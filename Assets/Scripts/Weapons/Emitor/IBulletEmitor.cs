using System;
using UnityEngine;

namespace Weapons
{
    public interface IBulletEmitor
    {
        Action<Vector2> BulletCreateMethod { set; }
        
        void StartEmit(MonoBehaviour context,Vector2 direction);
        void CancelEmit();
    }
}