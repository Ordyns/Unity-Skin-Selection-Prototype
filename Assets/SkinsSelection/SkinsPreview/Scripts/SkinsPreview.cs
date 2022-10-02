using UnityEngine;

public class SkinsPreview : MonoBehaviour, IInitializable<SelectionViewModel>
{
    [SerializeField] private PlayerSample playerSample;
    [SerializeField] private StandSample standSample;

    private SelectionViewModel _selectionViewModel;

    public void Initialize(SelectionViewModel viewModel){
        _selectionViewModel = viewModel;

        viewModel.ItemClicked += (item) => PreviewSkin(item.Value);
    }

    private void Start() {
        PreviewSkin(_selectionViewModel.SelectedStand);
        PreviewSkin(_selectionViewModel.SelectedPlayerSkin);
    }

    public void PreviewSkin(Skin skin){
        if(skin is PlayerSkin playerSkin){
            standSample.SetNewStand(_selectionViewModel.SelectedStand as StandSkin);
            playerSample.SetNewSkin(playerSkin);
        }
        else if(skin is StandSkin standSkin){
            playerSample.SetNewSkin(_selectionViewModel.SelectedPlayerSkin as PlayerSkin);
            standSample.SetNewStand(standSkin);
        }
    }
}
