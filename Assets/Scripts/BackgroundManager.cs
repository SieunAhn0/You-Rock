using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [Header("Background Textures")]
    public Texture2D[] backgroundTextures;
    private Renderer quadRenderer;

    void Start()
    {
        quadRenderer = GetComponent<Renderer>();

        int currentStage = GameManager.Instance.stage;
        int index = currentStage - 1;

        quadRenderer.material.mainTexture = backgroundTextures[index];
    }
}