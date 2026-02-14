using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScrollViewSearcher : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] TMP_InputField searchInput;
    [SerializeField] TextMeshProUGUI searchText;
    [SerializeField] ScrollRect scrollRect;       // El ScrollView
    [SerializeField] Transform contentPanel;      // Panel que contiene los botones
    [SerializeField] ComicSO[] comicEditorialSO;
    private Button lastSelectedButton;

    void Start()
    {
        searchInput.onValueChanged.AddListener(delegate { SearchEditorialAndSelect(searchInput.text); });
    }

    void SearchEditorialAndSelect(string searchText)
    {
        searchText = searchText.Trim().ToLower();

        if (string.IsNullOrEmpty(searchText))
            return;

        for (int i = 0; i < comicEditorialSO.Length; i++)
        {
            string nameEditorial = comicEditorialSO[i].editorial.ToLower().Replace(" ", ""); ;

            if (nameEditorial.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("cocincide --> " + nameEditorial + " "+ i);
                Button targetButton = contentPanel.GetChild(i).GetChild(0).GetComponent<Button>();
                
                ScrollToButton(targetButton);
                break;
            }
        }
    }

    void ScrollToButton(Button targetButton)
    {
        Canvas.ForceUpdateCanvases();

        RectTransform contentRect = contentPanel.GetComponent<RectTransform>();
        RectTransform targetRect = targetButton.GetComponent<RectTransform>();  
        RectTransform viewportRect = scrollRect.viewport;

        float contentHeight = contentRect.rect.height;
        float viewportHeight = viewportRect.rect.height;
        float targetPosY = Mathf.Abs(targetRect.localPosition.y);

        float normalizedPosition =
            1 - Mathf.Clamp01((targetPosY - viewportHeight * 0.5f) / (contentHeight - viewportHeight));

        scrollRect.verticalNormalizedPosition = normalizedPosition;
    }
}