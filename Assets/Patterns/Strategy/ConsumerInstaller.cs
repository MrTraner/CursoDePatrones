using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Adapter;

namespace Patterns.Strategy
{
    public class ConsumerInstaller : MonoBehaviour
    {
        [SerializeField] private bool _usePlayerPrefs;

        private void Awake()
        {
            var consumer = new Consumer(GetDataStore());
            consumer.Save();
            consumer.Load();
        }

        private IDataStore GetDataStore()
        {
            if (_usePlayerPrefs)
                return new PlayerPrefsDataStoreAdapter();

            return new FileDataStoreAdapter();
        }
    }
}