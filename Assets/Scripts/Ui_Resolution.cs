using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Resolution : MonoBehaviour
{

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {

        // 메인화면 UI

        if (name == "Kimika")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(197.8f, "center"));
        }
        else if (name == "Button_Lab")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(130.85f, "left"), Height(-379.7f, "up"));
        }
        else if (name == "Button_conference")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(271f, "left"), Height(-499.95f, "up"));
        }
        else if (name == "Button_experiment_note")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(271f, "left"), Height(-258.35f, "up"));
        }

        // 실험실 UI

        else if (name == "Background")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(-54.65f, "up"));
        }
        else if (name == "Category_smaller")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(204.35f, "down"));
        }
        else if (name == "Category_bigger")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(88.15f, "down"));
        }
        else if (name == "Category_mask")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(88.15f, "down"));
        }
        else if (name == "Button_All")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(-125, "center"), Height(-117.45f, "center"));
        }
        else if (name == "Button_Solid")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(-41.3f, "center"), Height(-117.45f, "center"));
        }
        else if (name == "Button_Liquid")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(42.3f, "center"), Height(-117.45f, "center"));
        }
        else if (name == "Button_Air")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(126f, "center"), Height(-117.45f, "center"));
        }
        else if (name == "Button_Save")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(126f, "center"), Height(-67.45f, "center"));
        }
        else if (name == "Button_Home")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(-67.45f, "center"));
        }
        else if (name == "Lab_Spoid")
        {
            rectTransform.localScale = SetSize();
            rectTransform.localPosition = new Vector2(Width(0f, "center"), Height(-60f, "up"));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    Vector2 SetSize ()
    {
        return new Vector2 (Screen.width / 360f, Screen.width / 360f);
    }

    float Width (float width, string pos)
    {
        if (pos == "left")
        {
            return width * Screen.width / 360f - Screen.width / 2f; // 왼쪽을 기준으로 (360:width를 현재 해상도에 맞게 변환)
        }
        else if (pos == "center")
        {
            return width * Screen.width / 360f; // 중앙을 기준으로 (360:width를 현재 해상도에 맞게 변환)
        }
        else if (pos == "right")
        {
            return width * Screen.width / 360f + Screen.width / 2f; // 오른쪽을 기준으로 (360:width를 현재 해상도에 맞게 변환)
        }
        else
        {
            return 0;
        }
    }

    float Height(float height, string pos)
    {
        if (pos == "down")
        {
            return height * Screen.height / 640f - Screen.height / 2f; // 아래쪽을 기준으로 (640:height를 현재 해상도에 맞게 변환)
        }
        else if (pos == "center")
        {
            return height * Screen.height / 640f; // 중앙을 기준으로 (640:height를 현재 해상도에 맞게 변환)
        }
        else if (pos == "up")
        {
            return height * Screen.height / 640f + Screen.height / 2f; // 위쪽을 기준으로 (640:height를 현재 해상도에 맞게 변환)
        }
        else
        {
            return 0;
        }
    }
}
