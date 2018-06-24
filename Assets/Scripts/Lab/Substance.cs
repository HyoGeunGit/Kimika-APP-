using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Substance : MonoBehaviour {

    public string condition;
    public bool isDefault = true;

    public GameObject block;

    public Sprite solid;
    public Sprite liquid;
    public Sprite air;

    public void MouseClick()
    {
        Block_Layer layer = GameObject.Find("Block_Layer").GetComponent<Block_Layer>();
        GameObject newObject = Instantiate(block);

        newObject.transform.SetParent(GameObject.Find("Blocks").transform);
        newObject.name = "block";
        if (condition == "solid")
            newObject.GetComponent<SpriteRenderer>().sprite = solid;
        else if (condition == "liquid")
            newObject.GetComponent<SpriteRenderer>().sprite = liquid;
        else
            newObject.GetComponent<SpriteRenderer>().sprite = air;
        newObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = GetComponent<Image>().sprite;

        newObject.transform.Find("Text").GetComponent<TextMesh>().text = name;
        newObject.GetComponent<Block>().type = name;
        newObject.GetComponent<Block>().isDefault = isDefault;
        layer.layer += 0.01f;
        newObject.transform.localPosition = new Vector3(0, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 640f * 380.85f)).y, layer.layer * -1f);
    }

}