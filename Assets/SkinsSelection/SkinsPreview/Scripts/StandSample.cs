using UnityEngine;

[RequireComponent(typeof(Animation))]
public class StandSample : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image previewImage;

    [HideInInspector, SerializeField] private Animation _animation;
    private StandSkin _currentSkin;

    private void OnValidate() {
        _animation = GetComponent<Animation>();
    }

    public void SetNewStand(StandSkin skin){
        if(_currentSkin == skin)
            return;

        _currentSkin = skin;

        if(_animation.isPlaying)
            _animation.Stop();

        previewImage.sprite = skin.StandSprite;
        _animation.Play();
    }
}
