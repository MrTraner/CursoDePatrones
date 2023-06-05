using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Ships.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _fireRateInSeconds;
        [SerializeField] private Projectile[] _projectilePrefabs;
        [SerializeField] private Transform _projectileSpawnPosition;

        private IShip _ship;
        private float _remainingSecondsToBeAbleToShoot;
        private string _activeProjectileId;

        public void Configure(IShip ship)
        {
            _ship = ship;
            _activeProjectileId = "Projectile1";
        }

        public void TryShoot()
        {
            _remainingSecondsToBeAbleToShoot -= Time.deltaTime;
            if (_remainingSecondsToBeAbleToShoot > 0)
                return;

            Shoot();
        }

        private void Shoot()
        {
            var prefab = _projectilePrefabs.First(projectile => projectile.ID.Equals(_activeProjectileId));
            _remainingSecondsToBeAbleToShoot = _fireRateInSeconds;
            Instantiate(prefab, _projectileSpawnPosition.position, _projectileSpawnPosition.rotation);
        }
    }
}