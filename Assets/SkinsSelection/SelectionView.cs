using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tabs;

public class SelectionView : MonoBehaviour, IInitializable<SelectionViewModel>
{
    [SerializeField] private TextMeshProUGUI headlineText;
    [SerializeField] private Button selectButton;

    private SelectionViewModel _viewModel;

    public void Initialize(SelectionViewModel viewModel){
        _viewModel = viewModel;

        _viewModel.ItemClicked += OnItemClicked;

        selectButton.onClick.AddListener(SelectItem);
    }

    private void OnItemClicked(ISelectebleTabItem<Skin> item){
        selectButton.gameObject.SetActive(item.IsLocked == false && item.IsSelected == false);

        headlineText.text = item.Value.Name;
    }

    private void SelectItem(){
        _viewModel.SelectSkin();
        selectButton.gameObject.SetActive(false);
    }
}
