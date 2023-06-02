using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace Patterns.Adapter
{
    public class FileDataStoreAdapter : IDataStore
    {
        public void SetData<T>(T data, string name)
        {
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine($"{Application.dataPath}/TestData/", $"{name}.txt");

            File.WriteAllText(path, json);
        }

        public T GetData<T>(string name)
        {
            var path = Path.Combine($"{Application.dataPath}/TestData/", $"{name}.txt");
            var json = File.ReadAllText(path);

            return JsonUtility.FromJson<T>(json);
        }
    }
}