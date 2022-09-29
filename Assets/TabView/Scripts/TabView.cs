using UnityEngine;
using TMPro;

public class TabView : MonoBehaviour
{
    [SerializeField] private Tab[] tabs;
    [Space]
    [SerializeField] private TabbedControl tabbedControl;
    [Space]
    [SerializeField] private TextMeshProUGUI headline;

    private Tab _selectedTab;

    private void Awake() {
        tabbedControl.Initialize(tabs);

        foreach (Tab tab in tabs){
            tab.Group.gameObject.SetActive(false);
        }

        _selectedTab = tabs[0];
        ChangeTab(_selectedTab);

        tabbedControl.TabChanged += ChangeTab;
    }

    private void ChangeTab(Tab tab){
        _selectedTab.Group.gameObject.SetActive(false);
        tab.Group.gameObject.SetActive(true);

        headline.text = tab.TabName;

        _selectedTab = tab;
    }

    [System.Serializable]
    public struct Tab
    {
        public TabGroup Group;
        public Sprite TabIcon;
        public string TabName;
    }
}
