using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabs
{
    public class TabItem<T> : MonoBehaviour, ITabItem<T>, IPointerClickHandler
    {
        public event System.Action<TabItem<T>> Clicked;
        
        [field:SerializeField] public T Value { get; private set; }
        [field:Space]
        [field:SerializeField] public bool IsHighlighted { get; private set; }
        [field:SerializeField] public bool IsSelected { get; private set; }
        [field:SerializeField] public bool IsLocked { get; private set; }
        [Space]
        [SerializeField] private Transform itemLockedIndicator;
        [SerializeField] private Transform itemSelectedIndicator;
        [Space]
        [SerializeField] private Transform highlight;

        private void Awake() {
            itemLockedIndicator.gameObject.SetActive(IsLocked);
            itemSelectedIndicator.gameObject.SetActive(IsSelected);
            highlight.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData){
            if(IsHighlighted)
                return;

            ActivateHighlight();
            Clicked?.Invoke(this);
        }

        public void ActivateHighlight() => SetHighlightState(true);
        public void DeactivateHighlight() => SetHighlightState(false);

        private void SetHighlightState(bool state){
            IsHighlighted = state;
            highlight.gameObject.SetActive(IsHighlighted);
        }

        public void Select() => SetSelectState(true);
        public void Unselect() => SetSelectState(false);

        private void SetSelectState(bool state){
            IsSelected = state;
            itemSelectedIndicator.gameObject.SetActive(IsSelected);
        }
    }
}
