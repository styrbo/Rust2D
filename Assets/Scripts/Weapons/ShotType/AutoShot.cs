using System;
using System.Collections;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class AutoShot : IShotType
    {
        [SerializeField] private float _delay;
        
        public Action ShotMethod { get; set; }
        public Action EndCallback { get; set; }

        private Coroutine _coroutine;
        private MonoBehaviour _context;

        public void StartShot(MonoBehaviour context)
        {
            _context = context;
            _coroutine = context.StartCoroutine(Shot());
        }

        private IEnumerator Shot()
        {
            while (true)
            {
                yield return new WaitForSeconds(_delay);
                ShotMethod?.Invoke();
            }
        }

        public void CancelShot()
        {
            if(_coroutine == null)
                return;
            
            _context.StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}