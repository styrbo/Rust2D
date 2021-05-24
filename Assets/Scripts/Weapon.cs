using UnityEngine;
using Weapons;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponSO _weapon;
        [SerializeField] private Transform _bulletSpawnPoint;

        private int _index;

        public WeaponSO WeaponSO
        {
            get => _weapon;
            set
            {
                UpdateShotData(value);
                _weapon = value;
            }
        }

        private void Awake()
        {
            UpdateShotData(_weapon);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnPointerDown();
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnPointerUp();
            }
                
        }

        public void OnPointerDown()
        {
            if (WeaponSO.InvokingType != WeaponSO.InvokeType.OnPointerDown)
                return;
            
            Shot();
        }

        public void OnPointerUp()
        {
            if (WeaponSO.InvokingType != WeaponSO.InvokeType.OnPointerUp)
                return;
            
            Shot();
        }

        private void UpdateShotData(WeaponSO weapon)
        {
            foreach (var t in weapon.ShotingsModes)
            {
                t.EndCallback = NextElement;
                t.ShotMethod = EmitBullet;
            }

            weapon.BulletEmitor.BulletCreateMethod = CrateBullet;

            void NextElement()
            {
                weapon.ShotingsModes[_index].CancelShot();
                
                _index++;

                if (_index >= weapon.ShotingsModes.Length - 1)
                {
                    return;
                }
                
                weapon.ShotingsModes[_index].StartShot(this);
            }
        }

        private void Shot()
        {
            _index = 0;
            WeaponSO.ShotingsModes[0].StartShot(this);
        }

        private void EmitBullet()
        {
            _weapon.BulletEmitor.StartEmit(this, _bulletSpawnPoint.up);
        }
        
        private void CrateBullet(Vector2 direction)
        {
            var obj = Instantiate(_weapon.Projectile, _bulletSpawnPoint.position, Quaternion.identity);
            obj.transform.up = direction;
        }

        public void CancelShot()
        {
            WeaponSO.ShotingsModes[_index].CancelShot();
        }
    }
}