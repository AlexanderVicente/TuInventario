using UnityEngine;
using UnityEngine.UI;

public class MenuInfo : MonoBehaviour
{
    private MediatorMenu _mediator;
    [SerializeField] Button buttonBack;
    [SerializeField] Image imageComic;

    string nameEditorialSelected = "";

    [Header("SO")]
    [SerializeField] ComicSO dcComics;
    [SerializeField] ComicSO marvelComics;
    [SerializeField] ComicSO assasinsComics;

    private void Start()
    {
        if(buttonBack != null)
            buttonBack.onClick.AddListener(ButtonBack);
    }

    public void Configure(MediatorMenu mediatorMenu)
    {
        _mediator = mediatorMenu;
    }

    public void ShowPanel(string nameComic, string nameEditorial)
    {
        Debug.Log(nameComic + "\n");
        Debug.Log(nameEditorial + "\n");
        nameEditorialSelected = nameEditorial;
        gameObject.SetActive(true);

        ShowImageComic(nameEditorialSelected, nameComic);
    }

    private void ShowImageComic(string nameEditorial, string nameComic)
    {
        switch (nameEditorial)
        {
            case "dc":
                for (int i = 0; i < dcComics.comics.Length; i++)
                {
                    if (dcComics.comics[i].name == nameComic)
                        imageComic.sprite = dcComics.comics[i].image;
                }
                break;

            case "marvel":
                for (int i = 0; i < marvelComics.comics.Length; i++)
                {
                    if (marvelComics.comics[i].name == nameComic)
                        imageComic.sprite = marvelComics.comics[i].image;
                }
                break;

            case "assasinscreed":
                for (int i = 0; i < assasinsComics.comics.Length; i++)
                {
                    if (assasinsComics.comics[i].name == nameComic)
                        imageComic.sprite = assasinsComics.comics[i].image;
                }
                break;

            default:
                break;
        }
    }

    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

    private void ButtonBack()
    {
        _mediator.ShowPanelItems(nameEditorialSelected);
    }

    private void ScrollHaciaItem(int index)
    {
        //if (index < 0 || index >= itemsInstanciados.Count)
        //    return;

        //RectTransform target = itemsInstanciados[index].GetComponent<RectTransform>();

        //// Asegura que el layout se haya calculado
        //Canvas.ForceUpdateCanvases();

        //// Calcula posición normalizada
        //float normalizedPosition = 1f - (target.anchoredPosition.y / (content.rect.height - scrollView.viewport.rect.height));
        //normalizedPosition = Mathf.Clamp01(normalizedPosition);

        //scrollView.verticalNormalizedPosition = normalizedPosition;
    }
}
