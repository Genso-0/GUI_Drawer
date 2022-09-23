
using UnityEngine;

public class GUI_Drawer : MonoBehaviour
{
    [SerializeField] bool showGUI;
    [SerializeField] Vector3 GUI_Position;
    [SerializeField] Color backgroundColor = new Color(0.2F, 0.2F, 0.2F, 0.4F);
    [SerializeField] GUIStyle GUI_Style;
    [SerializeField] string GUI_Text = "Default <color=yellow>Text</color> Message\n" +
        "With some <color=blue>formating</color>";
    float previousHeight;
    float previousWidth;
    Color previousBackgroundColor; 
   
    private void OnGUI()
    {
        if (!showGUI) return;

        float width = Screen.width / 1200.0f;
        float height = Screen.height / 800.0f;
        if (width != previousWidth || height != previousHeight || GUI_Style.normal.background == null || previousBackgroundColor != backgroundColor)
        {
            previousBackgroundColor = backgroundColor;
            previousWidth = width;
            previousHeight = height;
            GUI_Style.normal.background =
                MakeTex(Mathf.CeilToInt(width), Mathf.CeilToInt(height), backgroundColor);
        }
        GUI.matrix = Matrix4x4.TRS(GUI_Position, Quaternion.identity, new Vector3(width, height, 1.0f));

        GUILayout.Label(GUI_Text, GUI_Style);
    }
    Texture2D MakeTex(int width, int height, Color col)
    {
        var pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++)
        {
            pix[i] = col;
        }

        var result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
