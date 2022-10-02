using UnityEngine;

public class Skin : ScriptableObject, IItem
{
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public string ID { get; private set; }
    [field:SerializeField] public Sprite Icon { get; private set; }
    [field:Space]
    [field:SerializeField] public bool IsLocked { get; private set; }
}
