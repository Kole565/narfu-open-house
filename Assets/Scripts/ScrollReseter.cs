using UnityEngine;
using UnityEngine.UI;

public class ScrollReseter : MonoBehaviour
{
    public ScrollRect scrollRect;

    public void Reset()
    {
        scrollRect.verticalNormalizedPosition = 1f;
    }
}
