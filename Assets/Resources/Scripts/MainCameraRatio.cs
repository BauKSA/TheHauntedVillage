using UnityEngine;

public class ForceAspectRatio : MonoBehaviour
{
    void Start()
    {
        float targetAspect = 16f / 9f;
        float windowAspect = Camera.main.aspect;
        float scale = windowAspect / targetAspect;
        Camera cam = Camera.main;

        if (scale < 1f)
        {
            Rect r = cam.rect;
            r.width = 1f;
            r.height = scale;
            r.x = 0;
            r.y = (1f - scale) / 2f;
            cam.rect = r;
        }
        else
        {
            float scaleW = 1f / scale;
            Rect r = cam.rect;
            r.width = scaleW;
            r.height = 1f;
            r.x = (1f - scaleW) / 2f;
            r.y = 0f;
            cam.rect = r;
        }
    }
}