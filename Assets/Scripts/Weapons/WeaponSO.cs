using Projectiles;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Game/Weapon")]
    public class WeaponSO : ScriptableObject
    {
        public enum InvokeType
        {
            OnPointerUp,
            OnPointerDown
        }

        [SerializeField] private InvokeType _invokeType;

        [SerializeField] private int _primaryClipSize, _maxAmmoCount;
        
        [SR] [SerializeReference] private IShotType[] _shotingsModes;

        [SR] [SerializeReference] private IBulletEmitor _bulletEmitor;

        [SerializeField] private Bullet _projectile;
        
        public InvokeType InvokingType => _invokeType;
        
        public int PrimaryClipSize => _primaryClipSize;

        public int MAXAmmoCount => _maxAmmoCount;

        public IShotType[] ShotingsModes => _shotingsModes;

        public Bullet Projectile => _projectile;

        public IBulletEmitor BulletEmitor => _bulletEmitor;
    }
}
