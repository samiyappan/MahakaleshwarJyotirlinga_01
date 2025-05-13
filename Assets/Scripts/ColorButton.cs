using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour {
    [SerializeField] private Color colorToPick;
    [SerializeField] private XRHandDraw handDrawScript;

    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
        button.onClick.AddListener(PickColor);
    }

    public void PickColor() {
       handDrawScript.UpdateLineColor(colorToPick);
    }
}
