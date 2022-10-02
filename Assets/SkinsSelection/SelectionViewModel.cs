using System;
using Tabs;

public class SelectionViewModel
{
    public event Action<ISelectebleTabItem<Skin>> ItemSelected;
    public event Action<ISelectebleTabItem<Skin>> ItemClicked;

    public Skin SelectedPlayerSkin => _data.SelectedPlayerSkin;
    public Skin SelectedStand => _data.SelectedStand;
    
    private ISelectebleTabItem<Skin> _currentItem;
    private ISelectebleTabItem<Skin> _selectedItem;

    private PlayerData _data;
    private SaveSystem<PlayerData> _saveSystem;

    public SelectionViewModel(Skin defaultPlayerSkin, Skin standSkin, SaveSystem<PlayerData> saveSystem, PlayerData playerData){
        _saveSystem = saveSystem;
        _data = playerData;

        _data.SelectedPlayerSkin = _data.SelectedPlayerSkin ?? defaultPlayerSkin;
        _data.SelectedStand = _data.SelectedStand ?? standSkin;
    }

    public void SelectSkin(){
        _selectedItem = _currentItem;
        SaveSelection();

        ItemSelected?.Invoke(_selectedItem);
    }

    private void SaveSelection(){
        if(_selectedItem.Value is PlayerSkin playerSkin)
            _data.SelectedPlayerSkin = playerSkin;
        else if(_selectedItem.Value is StandSkin standSkin)
            _data.SelectedStand = standSkin;
        else
            throw new System.NotSupportedException($"Unknown skin type. ID: {_selectedItem.Value.ID}");

        _saveSystem.SaveData(_data);
    }

    public void InvokeItemClicked(ISelectebleTabItem<Skin> item){
        if(_currentItem == item)
            return;

        _currentItem = item;
        ItemClicked?.Invoke(item);
    }
}
