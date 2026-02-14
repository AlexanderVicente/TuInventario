using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataBase;

public class PanelAddComic : MonoBehaviour
{
    MediatorMenu _mediator;
    string currentEditorial;

    [SerializeField] MenuItems menuItems;
    [SerializeField] Button buttonAddComic;
    [SerializeField] Button buttonBack;
    [SerializeField] TMP_InputField comicNameInput;

    public void Configure(MediatorMenu mediatorMenu)
    {
        _mediator = mediatorMenu;
    }

    private void Start()
    {
        if (buttonAddComic != null)
            buttonAddComic.onClick.AddListener(AddComicFromInput);

        if (buttonBack != null)
            buttonBack.onClick.AddListener(ButtonBack);
    }

    public void ShowPanel(string nameEditorial)
    {
        currentEditorial = nameEditorial;
        gameObject.SetActive(true);
    }

    public void AddComicFromInput()
    {
        string comicName = comicNameInput.text.Trim();

        if (string.IsNullOrEmpty(comicName))
        {
            Debug.LogWarning("Nombre de cómic vacío");
            return;
        }

        if (string.IsNullOrEmpty(currentEditorial))
        {
            Debug.LogWarning("No hay editorial seleccionada");
            return;
        }

        ComicDatabase db = ComicJsonManager.Instance.GetDatabase();

        EditorialData editorial = db.editorials
            .Find(e => e.editorial == currentEditorial);

        if (editorial == null)
        {
            Debug.LogError("Editorial no encontrada: " + currentEditorial);
            return;
        }

        // Evitar duplicados
        bool exists = editorial.comics.Exists(c =>
            c.name.Equals(comicName, System.StringComparison.OrdinalIgnoreCase));

        if (exists)
        {
            Debug.Log("El cómic ya existe");
            return;
        }

        editorial.comics.Add(new ComicData
        {
            name = comicName,
            imagePath = ""
        });

        ComicJsonManager.Instance.Save();

        comicNameInput.text = "";

        // Refrescar UI
        menuItems.ShowPanel(currentEditorial);
    }

    public void ButtonBack()
    {
        _mediator.ShowPanelEditorials();
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
