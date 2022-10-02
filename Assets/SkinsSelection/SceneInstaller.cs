using UnityEngine;

public class SceneInstaller : MonoBehaviour
{   
    // Tried to create an installer similar to Zenject installers.
    // 
    // We can't expose interface in Inspector without custom attribute or Editor,
    // therefore I declared array of MonoBehaviour and it's of course not the best solution
    [SerializeField] private MonoBehaviour[] selectionViewModelUsers;
    [Space]
    [SerializeField] private Skin defaultPlayerSkin;
    [SerializeField] private Skin defaultStandSkin;

    private SelectionViewModel _selectionViewModel;

    private void Awake() {
        SaveSystem<PlayerData> _saveSystem = new SaveSystem<PlayerData>();
        _saveSystem.LoadData(out PlayerData playerData);

        _selectionViewModel = new SelectionViewModel(defaultPlayerSkin, defaultStandSkin, _saveSystem, playerData);

        foreach (var user in selectionViewModelUsers){
            if(user is IInitializable<SelectionViewModel> initializable)
                initializable.Initialize(_selectionViewModel);
            else
                Debug.LogError($"{user.name} doesn't implement IInitializable<SelectionViewModel> interface");
        }
    }
}
