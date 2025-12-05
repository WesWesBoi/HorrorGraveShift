using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RaycastFade : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float rayDistance = 5f; // Max distance for interaction
    public LayerMask interactableLayer; // Layer for interactable objects

    [Header("Fade Settings")]
    [Range(0f, 1f)] public float targetAlpha = 0.3f; // Transparency when faded
    public float fadeSpeed = 2f; // Speed of fading

    private Camera cam;
    private Renderer currentRenderer;
    private Material currentMaterial;
    private Color originalColor;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        HandleRaycast();
    }

    void HandleRaycast()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Center of screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();

            if (hitRenderer != null)
            {
                // If new object, restore old one
                if (hitRenderer != currentRenderer)
                {
                    RestoreObject();
                    AssignNewObject(hitRenderer);
                }

                // Fade current object
                FadeObject(currentMaterial, targetAlpha);
            }
        }
        else
        {
            RestoreObject();
        }
    }

    void AssignNewObject(Renderer rend)
    {
        currentRenderer = rend;
        currentMaterial = rend.material; // Instance material
        originalColor = currentMaterial.color;
    }

    void RestoreObject()
    {
        if (currentMaterial != null)
        {
            FadeObject(currentMaterial, originalColor.a);
            currentRenderer = null;
            currentMaterial = null;
        }
    }

    void FadeObject(Material mat, float alpha)
    {
        Color c = mat.color;
        c.a = Mathf.Lerp(c.a, alpha, Time.deltaTime * fadeSpeed);
        mat.color = c;

        // Ensure material supports transparency
        if (alpha < 1f)
            SetMaterialTransparent(mat);
        else
            SetMaterialOpaque(mat);
    }

    void SetMaterialTransparent(Material mat)
    {
        mat.SetFloat("_Mode", 3); // Transparent mode
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
    }

    void SetMaterialOpaque(Material mat)
    {
        mat.SetFloat("_Mode", 0); // Opaque mode
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        mat.SetInt("_ZWrite", 1);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.DisableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = -1;
    }
}