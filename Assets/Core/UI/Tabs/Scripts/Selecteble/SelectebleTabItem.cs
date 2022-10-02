using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabs
{
    public class SelectebleTabItem<T> : MonoBehaviour, ISelectebleTabItem<T>, IInitializable<T>, IPointerClickHandler where T : IItem
    {
        public event System.Action<SelectebleTabItem<T>> Clicked;
        public event System.Action<SelectebleTabItem<T>> Selected;
        
        public T Value { get; private set; }
        [field:Space]
        [field:SerializeField] public bool IsHighlighted { get; private set; }
        [field:SerializeField] public bool IsSelected { get; private set; }
        [field:SerializeField] public bool IsLocked { get; private set; }
        
        [Header("Indicator")]
        [SerializeField] private UnityEngine.UI.Image itemStateIndicator;
        [Space]
        [SerializeField] private Sprite lockSrite;
        [SerializeField] private Sprite checmarkSrite;

        [Header("Highlight")]
        [SerializeField] private Transform highlight;

        [Header("Icon")]
        [SerializeField] private UnityEngine.UI.Image iconImage;
        [SerializeField] private GameObject blackOverlay;

        public void Initialize(T value) {
            Value = value;
            iconImage.sprite = value.Icon;
            IsLocked = value.IsLocked;

            blackOverlay.SetActive(IsLocked);

            UpdateStateIndicator();
            DeactivateHighlight();
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

        public void Select(){
            SetSelectionState(true);
            
            Selected?.Invoke(this);
        }

        public void Unselect(){
            SetSelectionState(false);
        }

        private void SetSelectionState(bool state){
            IsSelected = state;
            UpdateStateIndicator();
        }

        private void UpdateStateIndicator(){
            if(IsLocked)
                itemStateIndicator.sprite = lockSrite;
            else if(IsSelected)
                itemStateIndicator.sprite = checmarkSrite;
            
            itemStateIndicator.gameObject.SetActive(IsLocked || IsSelected);
        }
    }
}
