using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class PlayerSample : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip defaultAnimaton;

    [HideInInspector, SerializeField] private Animation _animation;

    private PlayerSkin _currentSkin;
    
    private void OnValidate() {
        _animation = GetComponent<Animation>();
    }

    public void SetNewSkin(PlayerSkin skin){
        if(_currentSkin == skin)
            return;

        _currentSkin = skin;

        if(_animation.isPlaying)
            _animation.Stop();

        AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>() { new KeyValuePair<AnimationClip, AnimationClip>(defaultAnimaton, skin.PreviewAnimation) };
        animatorOverrideController.ApplyOverrides(overrides);
        animator.runtimeAnimatorController = animatorOverrideController;

        _animation.Play();
    }
}
