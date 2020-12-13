using Object;

namespace Config
{
    public class DescriptionConfiguration : ListConfiguration<Description>
    {
        public DescriptionConfiguration() : base("desc")
        {
            /* TEST USE
            Description description = new Description
            {
                Title = "1",
                Content = "test content",
                SpherePosition = new Vector3(0, 0, 0),
                SphereRotation = new Quaternion(0, 0, 0, 0),
                SphereScale = new Vector3(1, 1, 1),
                PopUpPosition = new Vector3(0, 1, 0),
                PopUpRotation = new Quaternion(0, 0, 0, 0),
                PopUpScale = new Vector3(1, 1, 1)
            };
            Debug.Log(JsonConvert.SerializeObject(description, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
            */
        }
    }
}
