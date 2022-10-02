using UnityEngine.UI;

public static class LayoutExtensions
{
    public static void ForceUpdate(this GridLayoutGroup gridLayoutGroup){
        gridLayoutGroup.CalculateLayoutInputHorizontal();
        gridLayoutGroup.CalculateLayoutInputVertical();
        gridLayoutGroup.SetLayoutHorizontal();
        gridLayoutGroup.SetLayoutVertical();
    }

    public static void ForceUpdate(this ContentSizeFitter contentSizeFilter){
        contentSizeFilter.SetLayoutHorizontal();
        contentSizeFilter.SetLayoutVertical();
    }
}
