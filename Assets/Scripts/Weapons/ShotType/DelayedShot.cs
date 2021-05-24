using System;
using System.Collections;
using UnityEngine;

namespace Weapons
{
    [Serializable]
    public class DelayedShot : IShotType
    {
        [SerializeField] private float _delay;

        public Action ShotMethod { get; set; }
        public Action EndCallback { get; set; }

        private Coroutine _coroutine;
        private MonoBehaviour _context;

        public void StartShot(MonoBehaviour context)
        {
            _context = context;
            context.StartCoroutine(OnShot());
        }

        public void CancelShot()
        {
            if(_coroutine == null)
                return;
            
            _context.StopCoroutine(_coroutine);
            _coroutine = null;
        }
        
        public IEnumerator OnShot()
        {
            yield return new WaitForSeconds(_delay);
            EndCallback?.Invoke();
        }
    }
}