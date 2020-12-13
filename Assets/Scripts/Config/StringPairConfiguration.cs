using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Config
{
    public class StringPairConfiguration : MonoBehaviour
    {
        private Dictionary<string, string> m_Json;
        private readonly string m_Name;

        protected StringPairConfiguration(string name)
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
                    m_Json = new Dictionary<string, string>();
                    Save();
                }
            }
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/Config/" + m_Name + ".json");
            m_Json = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        public string Get(string key) {
            return m_Json.ContainsKey(key) ? m_Json[key] : null;
        }

        public void Set(string key, string value)
        {
            if (m_Json.ContainsKey(key))
                m_Json[key] = value;
            else
                m_Json.Add(key, value);
            Save();
        }

        public void Remove(string key) {
            m_Json.Remove(key);
            Save();
        }

        private void Save()
        {
            File.WriteAllText(Application.persistentDataPath + "/Config/" + m_Name + ".json", JsonConvert.SerializeObject(m_Json, Formatting.Indented));
        }
    }
}
