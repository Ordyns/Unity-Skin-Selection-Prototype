namespace Tabs    
{
    [System.Serializable]
    public struct Tab<T> : ITab
    {
        public TabGroup<T> Group;
        public UnityEngine.Sprite TabIcon { get; private set; }
        public string TabName { get; private set; }
    }
}