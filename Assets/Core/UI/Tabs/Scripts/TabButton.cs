using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabs
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TabButton : MonoBehaviour, IInitializable<Tab>, IPointerClickHandler
    {
        public event System.Action<TabButton, Tab> Selected;

        public bool IsSelected { get; private set; }

        [SerializeField] private UnityEngine.UI.Image icon;

        private const float SelectedAlpha = 1f;
        private const float UnselectedAlpha = 0.3f;

        private CanvasGroup _canvasGroup;

        private Tab _targetTab;

        public void Initialize(Tab tab){
            _targetTab = tab;

            icon.sprite = tab.TabIcon;

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
}
