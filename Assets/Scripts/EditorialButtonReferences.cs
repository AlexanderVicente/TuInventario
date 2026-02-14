using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditorialButtonReferences : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textButton;
    [SerializeField] Image iconImage;

    public void Init(string nameEditorial, Sprite icon)
    {
        textButton.text = nameEditorial;
        iconImage.sprite = icon;
    }
}
