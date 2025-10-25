using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance { get; private set; }

    [Header("UI Elements")]
    public Slider progressBar;
    public TextMeshProUGUI loadingText;
    

    void Awake()
    {
        Instance = this;
    }
    

    public void UpdateProgress(float progress)
    {
        if (progressBar != null)
        {
            progressBar.value = progress;
        }

        if (loadingText != null)
        {
            loadingText.text = $"Cargando... {Mathf.RoundToInt(progress * 100)}%";
        }
    }
}