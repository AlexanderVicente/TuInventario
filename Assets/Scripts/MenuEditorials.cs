using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class MenuEditorials : MonoBehaviour
{
    private MediatorMenu _mediator;

    [SerializeField] GameObject editorialButton;
    [SerializeField] ComicSO[] comicSO;
    [SerializeField] Transform parentTransform;

    private void Start()
    {
        for (int i = 0; i < comicSO.Length; i++)
        {
            int index = i;

            GameObject instancia = Instantiate(editorialButton, parentTransform);

            instancia.GetComponent<EditorialButtonReferences>()
                .Init(comicSO[index].editorial, comicSO[index].iconEditorial);

            instancia.transform.GetChild(0).GetComponent<Button>()
                .onClick.AddListener(() => ShowPanelItems(index));
        }
    }

    public void Configure(MediatorMenu mediatorMenu)
    {
        _mediator = mediatorMenu;
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void ShowPanelItems(int i)
    {
        string nameEditorial = comicSO[i].editorial;

        string nameNotSpaceEditorial = Regex.Replace(nameEditorial, @"\s", "");

        string nameNormalEditorial = nameNotSpaceEditorial.Normalize(NormalizationForm.FormD);

        string nameNotAccentsEditorial = Regex.Replace(nameNormalEditorial, @"\p{IsCombiningDiacriticalMarks}+", "");

        _mediator.ShowPanelItems(nameNotAccentsEditorial.ToLower());
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
