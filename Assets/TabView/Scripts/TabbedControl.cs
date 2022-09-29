using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class TabbedControl : MonoBehaviour, IInitializable<TabView.Tab[]>
{
    public event System.Action<TabView.Tab> TabChanged;

    [SerializeField] private TabButton tabButtonPrefab;

    private TabButton _selectedButton;
    private TabButton[] _buttons;

    private GridLayoutGroup _gridLayoutGroup;

    private void OnValidate() {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    public void Initialize(TabView.Tab[] tabs){
        _buttons = new TabButton[tabs.Length];

        for (int i = 0; i < tabs.Length; i++)
            _buttons[i] = CreateNewTabButton(tabs[i]);

        _selectedButton = _buttons[0];
        _selectedButton.Select();
    }

    private TabButton CreateNewTabButton(TabView.Tab tab){
        TabButton tabButton = Instantiate(tabButtonPrefab, transform);
        tabButton.Initialize(tab);
        tabButton.Selected += OnTabButtonSelected;
        tabButton.Unselect();
        return tabButton;
    }

    private void OnTabButtonSelected(TabButton button, TabView.Tab tab){
        _selectedButton?.Unselect();
        _selectedButton = button;

        TabChanged?.Invoke(tab);
    }
}
