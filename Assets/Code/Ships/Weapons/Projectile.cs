using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private float _destroyInSeconds;

        public string ID => _id;

        private void Start()
        {
            _rigidbody2D.velocity = transform.up * _speed;
            StartCoroutine(DestroyIn(_destroyInSeconds));
        }

        private IEnumerator DestroyIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }
    }
}