using PrimeTween;
using TMPro;
using UnityEngine;

public class AnimationText : MonoBehaviour
{
    MediatorMenu _mediator;

    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI textComponent;

    [Header("Configuración")]
    [SerializeField] float tiempoEntreLletras = 0.1f;

    void Start()
    {
        AnimationTitle();
    }

    public void Configure(MediatorMenu mediatorMenu)
    {
        _mediator = mediatorMenu;
    }

    void AnimationTitle()
    {
        textComponent.maxVisibleCharacters = 0;

        Sequence sequence = Sequence.Create();

        for (int i = 0; i < textComponent.text.Length; i++)
        {
            int index = i; 

            sequence.Chain(Tween.Delay(tiempoEntreLletras, () =>
            {
                textComponent.maxVisibleCharacters = index + 1;
            }));
        }

        sequence.ChainCallback(OnAnimacionCompletada);
    }

    void OnAnimacionCompletada()
    {
        gameObject.SetActive(false);
        _mediator.ShowPanelEditorials();
    }
}
