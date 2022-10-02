namespace Tabs
{
    public interface ISelectebleTabItem<T>
    {
        T Value { get; }
        
        bool IsSelected { get; }
        bool IsLocked { get; }
    }
}