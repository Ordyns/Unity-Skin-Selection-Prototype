using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public event System.Action<TabButton, TabView.Tab> Selected;

    public bool IsSelected { get; private set; }

    private const float SelectedAlpha = 1f;
    private const float UnselectedAlpha = 0.3f;

    private CanvasGroup _canvasGroup;

    private TabView.Tab _targetTab;

    public void Initialize(TabView.Tab tab){
        _targetTab = tab;

        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerClick(PointerEventData eventData){
        if(IsSelected)
            return;

        Select();
        Selected?.Invoke(this, _targetTab);
    }

    public void Select() => SetSelectionState(true);

    public void Unselect() => SetSelectionState(false);

    private void SetSelectionState(bool selected){
        _canvasGroup.alpha = selected ? SelectedAlpha : UnselectedAlpha;
        IsSelected = selected;
    }
}
