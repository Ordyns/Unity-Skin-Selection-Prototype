public interface IItem
{
    string Name { get; }
    string ID { get; }
    UnityEngine.Sprite Icon { get; }

    bool IsLocked { get; }
}
