using System;
using UnityEngine;

namespace Weapons
{
    public interface IShotType
    {
        Action ShotMethod { set; }
        Action EndCallback { set; }

        void StartShot(MonoBehaviour context);
        void CancelShot();
    }
}