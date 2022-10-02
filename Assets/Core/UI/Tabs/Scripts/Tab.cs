using UnityEngine;

public abstract class Tab : MonoBehaviour, IInitializable
{
    public Sprite TabIcon { get; private set; }
    public string TabName { get; private set; }

    public abstract void Initialize();

    public abstract void Activate();
    public abstract void Deactivate();

    public abstract void SelectItemByIndex(int index);

    public void SetName(string name){
        if(string.IsNullOrEmpty(name))
            throw new System.ArgumentNullException("Tab name can't be null or empty");

        TabName = name;
    }
    
    public void SetIcon(Sprite icon) => TabIcon = icon;
}
