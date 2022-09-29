using System;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public event Action<TabItem> ItemClicked;

    [SerializeField] private TabItem[] items;

    private TabItem _selectedItem;

    private void Awake() {
        foreach(TabItem item in items){
            item.Clicked += OnItemClicked;
        }
    }

    private void OnItemClicked(TabItem clickedItem){     
        foreach(TabItem item in items){
            if(item != clickedItem)
                item.DeactivateHighlight();
        }

        ItemClicked?.Invoke(clickedItem);
    }
}
