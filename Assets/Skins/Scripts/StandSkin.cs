using UnityEngine;

[CreateAssetMenu(menuName = "Stand skin", fileName = "Stand")]
public class StandSkin : Skin
{
    [field:Space]
    [field:SerializeField] public Sprite StandSprite { get; set; }
}
