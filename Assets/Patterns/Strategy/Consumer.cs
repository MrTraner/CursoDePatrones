using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns.Adapter;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private readonly IDataStore _dataStore;

        public Consumer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            var data = new Data("Hola", 4545);
            _dataStore.SetData(data, "data2");
        }

        public void Load()
        {
            var data = _dataStore.GetData<Data>("data2");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}