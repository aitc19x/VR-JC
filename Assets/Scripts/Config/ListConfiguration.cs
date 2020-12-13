using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Config
{
    public class ListConfiguration<T> : MonoBehaviour
    {
        private List<T> m_Json;
        private readonly string m_Name;

        public ListConfiguration(string name)
        {
            m_Name = name;
        }

        protected void Awake()
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Config/");
            if (!File.Exists(Application.persistentDataPath + "/Config/" + m_Name + ".json")) {
                if (File.Exists(Application.streamingAssetsPath + "/Config/" + m_Name + ".json"))
                {
                    File.Copy(Application.streamingAssetsPath + "/Config/" + m_Name + ".json", Application.persistentDataPath + "/Config/" + m_Name + ".json");
                }
                else
                {
                    File.Create(Application.persistentDataPath + "/Config/" + m_Name + ".json").Dispose();
                    m_Json = new List<T>();
                    Save();
                }
            }
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/Config/" + m_Name + ".json");
            m_Json = JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        public T Get(int key)
        {
            return key < m_Json.Count ? m_Json[key] : default;
        }

        public List<T> Get()
        {
            return m_Json;
        }

        public void Set(int key, T value)
        {
            if (key < m_Json.Count)
                m_Json[key] = value;
            else
                m_Json.Add(value);
            Save();
        }

        public void Remove(int key) {
            m_Json.RemoveAt(key);
            Save();
        }

        public void Remove(T value)
        {
            m_Json.Remove(value);
            Save();
        }

        private void Save()
        {
            File.WriteAllText(Application.persistentDataPath + "/Config/" + m_Name + ".json", JsonConvert.SerializeObject(m_Json, Formatting.Indented));
        }
    }
}