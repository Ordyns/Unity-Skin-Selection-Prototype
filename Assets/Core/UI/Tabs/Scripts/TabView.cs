using UnityEngine;
using TMPro;

namespace Tabs
{
    public class TabView : MonoBehaviour
    {
        public int TabsCount { get; private set; }

        [SerializeField] private TabbedControl tabbedControl;
        [SerializeField] private TextMeshProUGUI headline;

        private Tab _selectedTab;

        protected virtual void AddTabs(params Tab[] tabs) {
            tabbedControl.Initialize(tabs);
    
            foreach (Tab tab in tabs){
                tab.Initialize();
                tab.Deactivate();
            }
    
            _selectedTab = tabs[0];
            ChangeTab(_selectedTab);
    
            TabsCount = tabs.Length;
            tabbedControl.TabChanged += ChangeTab;
        }

        private void ChangeTab(Tab tab){
            _selectedTab.Deactivate();
            tab.Activate();
    
            headline.text = tab.TabName;
    
            _selectedTab = tab;
        } 
    }
}
