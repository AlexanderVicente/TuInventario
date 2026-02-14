using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HidePanelOnClickOutside : MonoBehaviour
{
    [SerializeField] GameObject panel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clic o toque en pantalla
            if (!IsPointerOverUIObject()) // Si el clic no fue en UI
                panel.SetActive(false); // Ocultar panel
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0; // Devuelve true si tocó UI
    }
}
