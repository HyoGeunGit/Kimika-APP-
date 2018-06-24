using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour {

	public void Button_Lab()
    {
        SceneManager.LoadScene("Lab");
    }

    public void Button_conference()
    {
        //SceneManager.LoadScene("Conference");
    }

    public void Button_experiment_note()
    {
        //SceneManager.LoadScene("Experiment_note");
    }

}
