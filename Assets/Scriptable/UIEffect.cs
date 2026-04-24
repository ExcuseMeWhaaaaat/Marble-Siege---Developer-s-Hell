using UnityEngine;

[CreateAssetMenu(fileName = "UIEffect", menuName = "Scriptable Objects/UIEffect")]
public class UIEffect : ScriptableObject
{
    public Vector2 slideDirection;
    public RectTransform destination;
}
