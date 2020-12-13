using Newtonsoft.Json;
using UnityEngine;

namespace Object
{
    public class Description
    {
        public string Title;
        public string Content;
        public Vector3 SpherePosition;
        public Quaternion SphereRotation;
        public Vector3 SphereScale;
        public Vector3 PopUpPosition;
        public Quaternion PopUpRotation;
        public Vector3 PopUpScale;
        [JsonIgnore] public bool Showing = false;
    }
}
