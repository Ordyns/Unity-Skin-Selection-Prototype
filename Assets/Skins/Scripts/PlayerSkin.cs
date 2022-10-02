using UnityEngine;

[CreateAssetMenu(menuName = "Player skin", fileName = "Skin")]
public class PlayerSkin : Skin
{
    [field:Space]
    [field:SerializeField] public AnimationClip PreviewAnimation { get; set; }
}
