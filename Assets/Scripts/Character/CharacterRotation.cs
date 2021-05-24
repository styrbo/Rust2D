using System;
using UnityEngine;

namespace DefaultNamespace.Character
{
    public class CharacterRotation : MonoBehaviour
    {
        private void Update()
        {
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = targetPos - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}