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

        if (index >= 0 && index < backgroundTextures.Length && backgroundTextures[index] != null)
        {
            // Accessing .material creates a local material instance for this object
            quadRenderer.material.mainTexture = backgroundTextures[index];
        }
        else
        {
            Debug.LogError($"Invalid stage index {currentStage} for texture array size {backgroundTextures.Length}.");
        }
    }
}