using System;
using UnityEngine;

namespace Tabs
{
    public class TabGroup<T> : MonoBehaviour
    {
        public event Action<ITabItem<T>> ItemClicked;
    
        [SerializeField] private TabItem<T>[] items;
    
        private TabItem<T> _selectedItem;
    
        private void Awake() {
            if(items.Length == 0)
                return;
    
            foreach(TabItem<T> item in items){
                item.DeactivateHighlight();
                item.Clicked += OnItemClicked;
            }
            
            _selectedItem = items[0];
            _selectedItem.ActivateHighlight();
            ItemClicked?.Invoke(_selectedItem);
        }
    
        private void OnItemClicked(TabItem<T> clickedItem){     
            _selectedItem.DeactivateHighlight();
            _selectedItem = clickedItem;
    
            ItemClicked?.Invoke(clickedItem);
        }

        public void Activate(){
            gameObject.SetActive(true);
            ItemClicked?.Invoke(_selectedItem);
        }

        public void Deactivate(){
            gameObject.SetActive(false);
        }
    }
}