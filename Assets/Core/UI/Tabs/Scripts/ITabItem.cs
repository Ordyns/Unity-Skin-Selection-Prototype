public interface ITabItem
{
    bool IsSelected { get; }
    bool IsLocked { get; }
}

public interface ITabItem<T>
{
    T Value { get; }
    
    bool IsSelected { get; }
    bool IsLocked { get; }
}