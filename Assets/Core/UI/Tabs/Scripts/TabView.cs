using UnityEngine;
using TMPro;
using System.Linq;

namespace Tabs
{
    public class TabView<T> : MonoBehaviour
    {
        public event System.Action<ITabItem<T>> ItemClicked;

        [SerializeField] private Tab<T>[] tabs;
        [Space]
        [SerializeField] private TabbedControl tabbedControl;
        [Space]
        [SerializeField] private TextMeshProUGUI headline;
    
        private Tab<T> _selectedTab;
    
        private void Awake() {
            tabbedControl.Initialize(tabs.Cast<ITab>().ToArray());
    
            foreach (Tab<T> tab in tabs){
                tab.Group.ItemClicked += ItemClicked;
                tab.Group.Deactivate();
            }
    
            _selectedTab = tabs[0];
            ChangeTab(_selectedTab);
    
            tabbedControl.TabChanged += ChangeTab;
        }
    
        private void ChangeTab(ITab tab){
            Tab<T> castedTab = (Tab<T>) tab;

            _selectedTab.Group.Deactivate();
            castedTab.Group.Activate();
    
            headline.text = tab.TabName;
    
            _selectedTab = castedTab;
        } 
    }
}
