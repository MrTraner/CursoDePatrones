using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        //private FileDataStoreAdapter fileStore;
        private PlayerPrefsDataStoreAdapter fileStore;

        private void Awake()
        {
            //fileStore = new FileDataStoreAdapter();
            fileStore = new PlayerPrefsDataStoreAdapter();
            var data = new Data("Dato1", 1234);
            fileStore.SetData(data, "Data1");
        }

        private void Start()
        {
            var data = fileStore.GetData<Data>("Data1");
            Debug.Log(data.Dato1);
            Debug.Log(data.Dato2);
        }
    }
}