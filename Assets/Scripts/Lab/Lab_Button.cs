using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab_Button : MonoBehaviour {

    GameObject All, Solid, Liquid, Air;
    GameObject Sel1, Sel2, Sel3, Sel4;

    public void Awake()
    {
        All = GameObject.Find("Category_mask").transform.Find("All").gameObject;
        Solid = GameObject.Find("Category_mask").transform.Find("Solid").gameObject;
        Liquid = GameObject.Find("Category_mask").transform.Find("Liquid").gameObject;
        Air = GameObject.Find("Category_mask").transform.Find("Air").gameObject;

        Sel1 = GameObject.Find("Button_All").transform.Find("Select").gameObject;
        Sel2 = GameObject.Find("Button_Solid").transform.Find("Select").gameObject;
        Sel3 = GameObject.Find("Button_Liquid").transform.Find("Select").gameObject;
        Sel4 = GameObject.Find("Button_Air").transform.Find("Select").gameObject;
    }

    public void Button_Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Button_All ()
    {
        Sel1.SetActive(true);
        All.SetActive(true);

        Sel2.SetActive(false);
        Solid.SetActive(false);

        Sel3.SetActive(false);
        Liquid.SetActive(false);

        Sel4.SetActive(false);
        Air.SetActive(false);
    }

    public void Button_Solid()
    {
        Sel1.SetActive(false);
        All.SetActive(false);

        Sel2.SetActive(true);
        Solid.SetActive(true);

        Sel3.SetActive(false);
        Liquid.SetActive(false);

        Sel4.SetActive(false);
        Air.SetActive(false);
    }

    public void Button_Liquid()
    {
        Sel1.SetActive(false);
        All.SetActive(false);

        Sel2.SetActive(false);
        Solid.SetActive(false);

        Sel3.SetActive(true);
        Liquid.SetActive(true);

        Sel4.SetActive(false);
        Air.SetActive(false);
    }

    public void Button_Air()
    {
        Sel1.SetActive(false);
        All.SetActive(false);

        Sel2.SetActive(false);
        Solid.SetActive(false);

        Sel3.SetActive(false);
        Liquid.SetActive(false);

        Sel4.SetActive(true);
        Air.SetActive(true);
    }
}
