using UnityEngine;

public class MediatorMenu : MonoBehaviour
{
    [SerializeField] MenuItems _menuItems;
    [SerializeField] MenuEditorials _menuEditorials;
    [SerializeField] MenuInfo _menuInfo;
    [SerializeField] PanelAddComic _panelAddComic;

    bool _panelIsOpen;

    private void Awake()
    {
        _menuEditorials.Configure(this);
        _menuItems.Configure(this);
        _menuInfo.Configure(this);
        _panelAddComic.Configure(this);
    }

    public void ShowPanelItems(string nameEditorial)
    {
        _menuEditorials.HidePanel();
        _menuItems.ShowPanel(nameEditorial);
        _menuInfo.HidePanel();
        _panelAddComic.HidePanel();
    }

    public void ShowPanelEditorials()
    {
        _menuEditorials.ShowPanel();
        _menuItems.HidePanel();
        _menuInfo.HidePanel();
        _panelAddComic.HidePanel();
    }

    public void ShowPanelAddComic(string nameEditorial)
    {
        _menuItems.HidePanel();
        _panelAddComic.ShowPanel(nameEditorial);
    }

    public void ShowPanelInfo(string nameComic, string nameEditorial)
    {
        _menuEditorials.HidePanel();
        _menuItems.HidePanel();
        _menuInfo.ShowPanel(nameComic, nameEditorial);
    }
}
