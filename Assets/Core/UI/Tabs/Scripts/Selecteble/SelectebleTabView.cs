using UnityEngine;

namespace Tabs
{
    public class SelectebleTabView<T> : TabView where T : IItem
    {
        public event System.Action<ISelectebleTabItem<T>> ItemClicked;

        [Space]
        [SerializeField] private bool selectFirstItemsInTabsOnStart = false;
        [Space]
        [SerializeField] private SelectebleTab<T> TabPrefab;
        [SerializeField] private Transform content;
        [Space]
        [SerializeField] private TabContent[] tabs;

        private SelectebleTab<T>[] _createdTabs;

        private void Awake() {
            _createdTabs = new SelectebleTab<T>[tabs.Length];

            for(int i = 0; i < tabs.Length; i++){
                SelectebleTab<T> Tab = Instantiate(TabPrefab, content);
                Tab.SetItems(tabs[i].Items);
                Tab.SetName(tabs[i].Name);
                Tab.SetIcon(tabs[i].Icon);

                if(selectFirstItemsInTabsOnStart)
                    Tab.SelectFirstItem();

                _createdTabs[i] = Tab;
            }

            AddTabs(_createdTabs);

            foreach(var tab in _createdTabs)
                tab.ItemClicked += (item) => ItemClicked?.Invoke(item);
        }

        public void SelectItem(IItem item){
            foreach (var tab in _createdTabs){
                if(tab.TrySelectItem(item))
                    return;
            }

            throw new System.ArgumentException($"Can't find item with {item.ID} ID");
        }

        public void SelectItemByIndex(int tabIndex, int itemIndex){
            _createdTabs[tabIndex].SelectItemByIndex(itemIndex);
        }

        [System.Serializable]
        public struct TabContent
        {
            public string Name;
            public Sprite Icon;
            public T[] Items;
        }
    }
}
