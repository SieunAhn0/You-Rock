using UnityEngine;

public class RGB : MonoBehaviour
{
    Color32 objColor;
    Renderer objRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        objColor = objRenderer.material.color;
        byte r = (byte) (objColor.r + 10);
        byte g = (byte) (objColor.g + 2);
        byte b = (byte) (objColor.b - 10);
        objRenderer.material.color = new Color32(r, g, b, 255);
    }
}
