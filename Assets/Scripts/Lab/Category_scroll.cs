using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Category_scroll : MonoBehaviour {

    Vector2 mousePosition = new Vector2(0, 0);
    Substance_Load substance_load;

    private void Awake()
    {
        substance_load = GameObject.Find("Substance_Load").GetComponent<Substance_Load>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            mousePosition = Input.mousePosition;
        if (Input.GetMouseButton(0) && mousePosition.y <= Screen.height / 640f * 176.3f)
        {
            if (GameObject.Find("All") != null && substance_load.CountAll / 4 > 2)
            {
                RectTransform rectTransform = GameObject.Find("All").GetComponent<RectTransform>();
                rectTransform.position += new Vector3(0, (Input.mousePosition.y - mousePosition.y));
                if (rectTransform.position.y <= 88.15f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, 88.15f * Screen.height / 640f);
                }
                else if (rectTransform.position.y >= (substance_load.CountAll / 4) * 83.7f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, (substance_load.CountAll / 4) * 83.7f * Screen.height / 640f);
                }
            }
            else if (GameObject.Find("Solid") != null && substance_load.CountSolid / 4 > 2)
            {
                RectTransform rectTransform = GameObject.Find("Solid").GetComponent<RectTransform>();
                rectTransform.position += new Vector3(0, (Input.mousePosition.y - mousePosition.y));
                if (rectTransform.position.y <= 88.15f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, 88.15f * Screen.height / 640f);
                }
            }
            else if (GameObject.Find("Liquid") != null && substance_load.CountLiquid / 4 > 2)
            {
                RectTransform rectTransform = GameObject.Find("Liquid").GetComponent<RectTransform>();
                rectTransform.position += new Vector3(0, (Input.mousePosition.y - mousePosition.y));
                if (rectTransform.position.y <= 88.15f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, 88.15f * Screen.height / 640f);
                }
            }
            else if (GameObject.Find("Air") != null && substance_load.CountAir / 4 > 2)
            {
                RectTransform rectTransform = GameObject.Find("Air").GetComponent<RectTransform>();
                rectTransform.position += new Vector3(0, (Input.mousePosition.y - mousePosition.y));
                if (rectTransform.position.y <= 88.15f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, 88.15f * Screen.height / 640f);
                }
                if (rectTransform.position.y <= 88.15f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, 88.15f * Screen.height / 640f);
                }
                else if (rectTransform.position.y >= (substance_load.CountAir / 4) * 83.7f * Screen.height / 640f)
                {
                    rectTransform.position = new Vector3(Screen.width / 2f, (substance_load.CountAir / 4) * 83.7f * Screen.height / 640f);
                }
            }
        }
        mousePosition = Input.mousePosition;
    }
}
