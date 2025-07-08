using UnityEngine;

public class UISafeArea : MonoBehaviour
{
    private Rect lastSafeArea = new Rect(0, 0, 0, 0);
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = transform as RectTransform;

        SetSafeAreaRect();
    }

    void Update()
    {
        SetSafeAreaRect();
    }

    void SetSafeAreaRect()
    {
        Rect safeArea = Screen.safeArea;

        if (safeArea != lastSafeArea)
        {
            lastSafeArea = safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}
