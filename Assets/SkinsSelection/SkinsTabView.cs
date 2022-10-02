using Tabs;

public class SkinsTabView : SelectebleTabView<Skin>, IInitializable<SelectionViewModel>
{
    private SelectionViewModel _viewModel;

    public void Initialize(SelectionViewModel viewModel){
        _viewModel = viewModel;

        ItemClicked += (item) => _viewModel.InvokeItemClicked(item);
    }

    private void Start() {
        _viewModel.ItemSelected += OnItemSelected;

        SelectItem(_viewModel.SelectedStand);
        SelectItem(_viewModel.SelectedPlayerSkin);
    }

    private void OnItemSelected(ISelectebleTabItem<Skin> item){
        SelectItem(item.Value);
    }
}
