namespace Tabs
{
    public interface ITab
    {
        UnityEngine.Sprite TabIcon { get; }
        string TabName { get; }
    }
}