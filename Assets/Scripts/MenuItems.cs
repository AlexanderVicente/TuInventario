using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DataBase;

public class MenuItems : MonoBehaviour
{
    MediatorMenu _mediator;
    [SerializeField] Button buttonBack;
    [SerializeField] Button buttonAddComic;

    [SerializeField] GameObject _prefabItem;
    GameObject _itemClone;
    [SerializeField] GameObject _parent;

    [Header("SO")]
    [SerializeField] ComicSO dc;
    [SerializeField] ComicSO marvelComics;
    [SerializeField] ComicSO assasinsComics;
    [SerializeField] ComicSO asterixComics;

    string currentEditorial;

    private void Start()
    {
        buttonBack.onClick.AddListener(ButtonBack);
        buttonAddComic.onClick.AddListener(ButtonAddComic);
    }

    public void Configure(MediatorMenu mediatorMenu)
    {
        _mediator = mediatorMenu;
    }

    public void ShowPanel(string editorial)
    {
        ClearAllChildren(_parent);

        currentEditorial = editorial;

        LoadComicsUI(GetComicsByEditorial(currentEditorial), currentEditorial);
   
        this.gameObject.SetActive(true);
    }

    public List<ComicData> GetComicsByEditorial(string editorialName)
    {
        ComicDatabase db = ComicJsonManager.Instance.GetDatabase();

        EditorialData editorial = db.editorials
            .Find(e => e.editorial.Equals(editorialName, StringComparison.OrdinalIgnoreCase));

        if (editorial == null)
        {
            Debug.LogWarning("No existe la editorial: " + editorialName);
            return new List<ComicData>();
        }

        return editorial.comics;
    }

    void LoadComicsUI(List<ComicData> comics, string editorialName)
    {
        foreach (Transform child in _parent.transform)
            Destroy(child.gameObject);

        foreach (ComicData comic in comics)
        {
            _itemClone = Instantiate(_prefabItem, _prefabItem.transform.position, Quaternion.identity);

            _itemClone.transform.SetParent(_parent.transform, false);
            _itemClone.GetComponent<ReferenceButtonText>().textButton.text = comic.name;

            string nameComic = comic.name;

            _itemClone.GetComponent<ReferenceButtonText>().button.onClick.AddListener(() 
                                   => ShowPanelInfo(nameComic, editorialName));
        }
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    private void ShowPanelInfo(string nameComic, string nameEditorial)
    {
        _mediator.ShowPanelInfo(nameComic, nameEditorial);
    }

    public void ButtonBack()
    {
        _mediator.ShowPanelEditorials();
        currentEditorial = "";
    }

    private void ClearAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
            Destroy(child.gameObject);
    }

    public void ButtonAddComic()
    {
        _mediator.ShowPanelAddComic(currentEditorial);
    }
}