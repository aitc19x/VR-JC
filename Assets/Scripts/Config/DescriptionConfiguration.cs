using Object;

namespace Config
{
    public class DescriptionConfiguration : ListConfiguration<Description>
    {
        public DescriptionConfiguration() : base("desc")
        {
        }

        public void ClearShowing() {
            foreach (Description desc in base.m_Json)
            {
                desc.Showing = false;
            }
            base.Save();
        }
    }
}
