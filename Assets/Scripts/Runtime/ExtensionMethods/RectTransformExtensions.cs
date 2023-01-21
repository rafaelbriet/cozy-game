using UnityEngine;

namespace CozyGame
{
    public static class RectTransformExtensions
    {
        public static void DestroyAllChildren(this RectTransform rectTransform)
        {
            foreach (RectTransform child in rectTransform)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}
