using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    Vector2 mousePosition = new Vector2(0, 0);
    Sprite[] sprites, liquid, solid, air;
    GameObject nearObject;

    public string type;
    public int size = 1;
    public bool isDefault = true;

    string condition;
    float doubleClick = 0;

    private void Awake()
    {
        sprites = GameObject.Find("Sprites").GetComponent<Sprites>().sprites;
        liquid = GameObject.Find("Sprites").GetComponent<Sprites>().liquid;
        solid = GameObject.Find("Sprites").GetComponent<Sprites>().solid;
        air = GameObject.Find("Sprites").GetComponent<Sprites>().air;
    }

    private void OnMouseDrag()
    {
        Block_Layer layer = GameObject.Find("Block_Layer").GetComponent<Block_Layer>();

        if (layer.layer != transform.position.z * -1f)
        {
            layer.layer += 0.01f;
            transform.position = new Vector3(transform.position.x, transform.position.y, layer.layer * -1f);
        }
        transform.position -= new Vector3(mousePosition.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x, mousePosition.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    private void OnMouseUpAsButton()
    {
        if (doubleClick > 0)
        {
            doubleClick = 0;
            if (!isDefault)
            {
                size++;
                if (size > 5)
                    size = 1;

                SpriteRenderer conditionSprite = GetComponent<SpriteRenderer>();

                if (size == 1 && conditionSprite.sprite == liquid[4] || size != 1 && conditionSprite.sprite == liquid[size - 2])
                    conditionSprite.sprite = liquid[size - 1];
                else if (size == 1 && conditionSprite.sprite == solid[4] || size != 1 && conditionSprite.sprite == solid[size - 2])
                    conditionSprite.sprite = solid[size - 1];
                else if (size == 1 && conditionSprite.sprite == air[4] || size != 1 && conditionSprite.sprite == air[size - 2])
                    conditionSprite.sprite = air[size - 1];

                if (size == 1)
                    GetComponent<BoxCollider2D>().size = new Vector2(2, 1.7f);
                else if (size == 2)
                    GetComponent<BoxCollider2D>().size = new Vector2(2, 3);
                else if (size == 3)
                    GetComponent<BoxCollider2D>().size = new Vector2(2, 4.4f);
                else if (size == 4)
                    GetComponent<BoxCollider2D>().size = new Vector2(4, 3);
                else if (size == 5)
                    GetComponent<BoxCollider2D>().size = new Vector2(4.45f, 3);

            }
        }
        else
        {
            doubleClick = 0.3f;

            if (Input.mousePosition.y >= Screen.height / 640f * 530.7f || Input.mousePosition.y <= Screen.height / 640f * 230.9f)
                Destroy(gameObject);
            else if (Input.mousePosition.x <= 0 || Input.mousePosition.x >= Screen.width)
                Destroy(gameObject);
            else if (mousePosition.x != Camera.main.ScreenToWorldPoint(Input.mousePosition).x || mousePosition.y != Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
            {
                GameObject[] obj = GameObject.FindGameObjectsWithTag("Block");

                foreach (GameObject ob in obj)
                {
                    float distance1 = Vector2.Distance
                        (
                            ob.transform.position,
                            transform.position + new Vector3(0, -0.13f +
                            (ob.GetComponent<BoxCollider2D>().size.y + GetComponent<BoxCollider2D>().size.y) / 4f, 0)
                        );
                    float distance2 = Vector2.Distance
                        (
                            ob.transform.position,
                            transform.position - new Vector3(0, -0.13f +
                            (ob.GetComponent<BoxCollider2D>().size.y + GetComponent<BoxCollider2D>().size.y) / 4f, 0)
                        );

                    if ((distance1 <= 0.3f || distance2 <= 0.3f) && ob != gameObject)
                    {
                        if (nearObject == null || Vector2.Distance(transform.position, ob.transform.position) < Vector2.Distance(transform.position, nearObject.transform.position))
                        {
                            nearObject = ob;
                        }
                    }
                }

                if (nearObject != null)
                {
                    string type2 = nearObject.GetComponent<Block>().type;
                    bool change = false;

                    if (Recipe(type, type2, "물", "냉기"))
                    {
                        string Name = "얼음";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[6];
                        condition = "solid";
                        change = true;

                        NewSubstance(Name, condition);
                    }
                    else if (Recipe(type, type2, "물", "나무"))
                    {
                        string Name = "곰팡이";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[0];
                        condition = "solid";
                        change = true;

                        NewSubstance(Name, condition);
                    }
                    else if (Recipe(type, type2, "물", "철"))
                    {
                        string Name = "녹슨 철";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[4];
                        condition = "solid";
                        change = true;

                        NewSubstance(Name, condition);
                    }
                    else if (Recipe(type, type2, "용암", "철"))
                    {
                        string Name = "녹은 철";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[1];
                        condition = "liquid";
                        change = true;

                        NewSubstance(Name, condition);
                    }
                    else if (Recipe(type, type2, "곰팡이", "나무"))
                    {
                        string Name = "버섯";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[3];
                        condition = "solid";
                        change = true;

                        NewSubstance(Name, condition);
                    }
                    else if (Recipe(type, type2, "물", "열기"))
                    {
                        string Name = "수증기";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[5];
                        condition = "air";
                        change = true;

                        NewSubstance(Name, condition);
                    }
                    else if (Recipe(type, type2, "불", "기름"))
                    {
                        string Name = "더 큰 불";
                        nearObject.GetComponent<Block>().type = Name;
                        nearObject.transform.Find("Text").GetComponent<TextMesh>().text = Name;
                        nearObject.transform.Find("Picture").GetComponent<SpriteRenderer>().sprite = sprites[2];
                        condition = "air";
                        change = true;

                        NewSubstance(Name, condition);
                    }

                    if (change)
                    {
                        nearObject.transform.position = (nearObject.transform.position + transform.position) / 2.0f;
                        nearObject.GetComponent<Block>().size += size;
                        nearObject.GetComponent<Block>().isDefault = false;

                        if (nearObject.GetComponent<Block>().size > 5)
                            nearObject.GetComponent<Block>().size = 5;

                        if (condition == "solid")
                            nearObject.GetComponent<SpriteRenderer>().sprite = solid[nearObject.GetComponent<Block>().size - 1];
                        else if (condition == "liquid")
                            nearObject.GetComponent<SpriteRenderer>().sprite = liquid[nearObject.GetComponent<Block>().size - 1];
                        else if (condition == "air")
                            nearObject.GetComponent<SpriteRenderer>().sprite = air[nearObject.GetComponent<Block>().size - 1];

                        if (nearObject.GetComponent<Block>().size == 1)
                            nearObject.GetComponent<BoxCollider2D>().size = new Vector2(2, 1.7f);
                        else if (nearObject.GetComponent<Block>().size == 2)
                            nearObject.GetComponent<BoxCollider2D>().size = new Vector2(2, 3);
                        else if (nearObject.GetComponent<Block>().size == 3)
                            nearObject.GetComponent<BoxCollider2D>().size = new Vector2(2, 4.4f);
                        else if (nearObject.GetComponent<Block>().size == 4)
                            nearObject.GetComponent<BoxCollider2D>().size = new Vector2(4, 3);
                        else if (nearObject.GetComponent<Block>().size == 5)
                            nearObject.GetComponent<BoxCollider2D>().size = new Vector2(4.45f, 3);

                        Destroy(gameObject);
                    }
                    nearObject = null;
                }
            }
        }
    }

    void NewSubstance(string Name, string type)
    {
        if (PlayerPrefs.GetInt("Substance-" + Name) != 1)
        {
            PlayerPrefs.SetInt("Substance-" + Name, 1);
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad(Name, type, 1);
        }
    }

    bool Recipe(string t1, string t2, string t3, string t4)
    {
        return t1 == t3 && t2 == t4 || t2 == t3 && t1 == t4;
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (doubleClick > 0)
        {
            doubleClick -= Time.deltaTime;
            if (doubleClick < 0)
                doubleClick = 0;
        }
    }
}