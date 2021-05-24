using System;
using UnityEngine;

namespace Weapons
{
    public class SingleShot : IShotType
    {
        public Action ShotMethod { get; set; }
        public Action EndCallback { get; set; }
        
        
        public void StartShot(MonoBehaviour context)
        {
            ShotMethod?.Invoke();
            EndCallback?.Invoke();
        }

        public void CancelShot()
        {
            
        }
    }
}