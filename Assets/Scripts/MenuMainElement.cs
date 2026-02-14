using UnityEngine;
using UnityEngine.UI;

public class MenuMainElement : MonoBehaviour
{
    MediatorMenu _mediator;
    [SerializeField] Button _buttonElement;

    private void Start()
    {
        _buttonElement.onClick.AddListener(PushInElement);
    }

    public void Configure(MediatorMenu mediatorMenu)
    {
        _mediator = mediatorMenu;
    }

    public void PushInElement()
    {
        _mediator.ShowPanelEditorials();
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }

    public void HidePanel() 
    { 
        this.gameObject.SetActive(false);
    }
}
