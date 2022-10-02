using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tabs
{
    public class SelectebleTab<T> : Tab where T : IItem
    {
        public event Action<ISelectebleTabItem<T>> ItemClicked;
    
        [SerializeField] private GridLayoutGroup contentGridLayoutGroup;
        [SerializeField] private ContentSizeFitter contentSizeFilter;
        [Space]
        [SerializeField] private SelectebleTabItem<T> itemPrefab;

        private T[] _items;

        private SelectebleTabItem<T>[] _tabItems;
        private Dictionary<string, SelectebleTabItem<T>> _itemsDictionary = new Dictionary<string, SelectebleTabItem<T>>();

        private SelectebleTabItem<T> _clickedItem;
        private SelectebleTabItem<T> _selectedItem;

        public void SetItems(T[] items){
            _items = items;
        }
    
        public override void Initialize() {
            if(_items.Length == 0)
                return;

            _tabItems = new SelectebleTabItem<T>[_items.Length];
        
            for(int i = 0; i < _items.Length; i++){
                var tabItem = Instantiate(itemPrefab, contentGridLayoutGroup.transform);
                tabItem.Initialize(_items[i]);
                tabItem.Clicked += OnItemClicked;
                tabItem.Selected += OnItemSelected;

                _tabItems[i] = tabItem;

                if(_itemsDictionary.ContainsKey(_items[i].ID)){
                    string message = $"Item must have a unique ID. Identifier \"{_items[i].ID}\" is used in several items or some tab items use the same IItem";
                    throw new System.NotSupportedException(message);
                }
            
                _itemsDictionary.Add(_items[i].ID, tabItem); 
            }
        }

        private void Start() {
            contentGridLayoutGroup.ForceUpdate();
            contentSizeFilter.ForceUpdate();

            contentSizeFilter.enabled = false;
            contentGridLayoutGroup.enabled = false;
        }

        public void SelectFirstItem(){
            _clickedItem = _tabItems[0];
            _clickedItem.ActivateHighlight();
            ItemClicked?.Invoke(_tabItems[0]);
        }
    
        private void OnItemClicked(SelectebleTabItem<T> clickedItem){
            _clickedItem?.DeactivateHighlight();
            
            _clickedItem = clickedItem;
    
            InvokeItemClickedEvent();
        }

        private void OnItemSelected(SelectebleTabItem<T> selectedItem){  
            _selectedItem?.Unselect();

            _clickedItem = selectedItem;
            _selectedItem = selectedItem;
            _selectedItem.ActivateHighlight();

            InvokeItemClickedEvent();
        }

        public override void Activate(){
            gameObject.SetActive(true);

            InvokeItemClickedEvent();
        }

        public override void Deactivate(){
            gameObject.SetActive(false);
        }

        private void InvokeItemClickedEvent(){
            if(_clickedItem != null)
                ItemClicked?.Invoke(_clickedItem);
        } 

        public override void SelectItemByIndex(int index){
            _tabItems[index].Select();
        }

        public bool ContainsItem(IItem item) => _itemsDictionary.ContainsKey(item.ID);

        public void SelectItem(IItem item){
            if(ContainsItem(item) == false)
                throw new System.ArgumentException($"Can't find IItem with \"{item.ID}\" ID");

            _itemsDictionary[item.ID].Select();
        }

        public bool TrySelectItem(IItem item){
            if(ContainsItem(item)){
                SelectItem(item);
                return true;
            }

            return false;
        }
    }
}