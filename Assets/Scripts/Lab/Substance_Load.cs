using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Substance_Load : MonoBehaviour {

    public GameObject Substance; // 물질 선택 UI 프리팹

    public int CountAll = 0; // 전체 카테고리에 있는 물질 수
    public int CountSolid = 0; // 고체 카테고리에 있는 물질 수
    public int CountLiquid = 0; // 액체 카테고리에 있는 물질 수
    public int CountAir = 0; // 기체 카테고리에 있는 물질 수

    public Sprite[] Sprites = new Sprite[20]; // 물질 스프라이트

    bool isStart = true;

    private void Start()
    {
        SubStanceLoad("나무", "solid", 0); // 기본적으로 제공되는 물질들을 로드
        SubStanceLoad("돌", "solid", 0);
        SubStanceLoad("철", "solid", 0);

        SubStanceLoad("기름", "liquid", 0);
        SubStanceLoad("물", "liquid", 0);
        SubStanceLoad("수산화 나트륨", "liquid", 0);
        SubStanceLoad("염산", "liquid", 0);
        SubStanceLoad("용암", "liquid", 0);

        SubStanceLoad("가스", "air", 0);
        SubStanceLoad("냉기", "air", 0);
        SubStanceLoad("불", "air", 0);
        SubStanceLoad("산소", "air", 0);
        SubStanceLoad("열기", "air", 0);
        SubStanceLoad("이산화탄소", "air", 0);

        // 만든 적이 있는 물질들을 로드

        if (PlayerPrefs.GetInt("Substance-" + "얼음") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("얼음", "solid", 1);
        }
        if (PlayerPrefs.GetInt("Substance-" + "곰팡이") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("곰팡이", "solid", 1);
        }
        if (PlayerPrefs.GetInt("Substance-" + "녹슨 철") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("녹슨 철", "solid", 1);
        }
        if (PlayerPrefs.GetInt("Substance-" + "녹은 철") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("녹은 철", "liquid", 1);
        }
        if (PlayerPrefs.GetInt("Substance-" + "더 큰 불") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("더 큰 불", "air", 1);
        }
        if (PlayerPrefs.GetInt("Substance-" + "버섯") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("버섯", "solid", 1);
        }
        if (PlayerPrefs.GetInt("Substance-" + "수증기") == 1)
        {
            GameObject.Find("Substance_Load").GetComponent<Substance_Load>().SubStanceLoad("수증기", "air", 1);
        }

        isStart = false;
    }

    public void SubStanceLoad (string name, string type, int isDefault) // 받은 물질을 리스트에 추가하고, 카운트를 늘리는 함수
    {
        GameObject newObject = Instantiate(Substance);
        newObject.name = name;

        Text SubstanceText = newObject.transform.Find("Name").GetComponent<Text>();
        SubstanceText.text = name;

        ChangeSprite(newObject);
        
        if (isDefault == 0)
        {
            if (type == "solid")
            {
                GameObject Parent = GameObject.Find("Category_mask").transform.Find("Solid").gameObject;
                newObject.transform.SetParent(Parent.transform);

                float x = Screen.width / 2f + (CountSolid % 4 - 1.5f) * 83.7f;
                float y = 140.05f + (CountSolid / 4) * -83.7f;
                newObject.transform.position = new Vector2(x, y);
                newObject.GetComponent<Substance>().isDefault = true;
                newObject.GetComponent<Substance>().condition = type;

                CountSolid++;
            }
            else if (type == "liquid")
            {
                GameObject Parent = GameObject.Find("Category_mask").transform.Find("Liquid").gameObject;
                newObject.transform.SetParent(Parent.transform);

                float x = Screen.width / 2f + (CountLiquid % 4 - 1.5f) * 83.7f;
                float y = 140.05f + (CountLiquid / 4) * -83.7f;
                newObject.transform.position = new Vector2(x, y);
                newObject.GetComponent<Substance>().isDefault = true;
                newObject.GetComponent<Substance>().condition = type;

                CountLiquid++;
            }
            else if (type == "air")
            {
                GameObject Parent = GameObject.Find("Category_mask").transform.Find("Air").gameObject;
                newObject.transform.SetParent(Parent.transform);

                float x = Screen.width / 2f + (CountAir % 4 - 1.5f) * 83.7f;
                float y = 140.05f + (CountAir / 4) * -83.7f;
                newObject.transform.position = new Vector2(x, y);
                newObject.GetComponent<Substance>().isDefault = true;
                newObject.GetComponent<Substance>().condition = type;

                CountAir++;
            }
        }
        else
        {
            float size;
            if (isStart)
            {
                size = 1;
            }
            else
            {
                size = Screen.width / 360f;
            }

            GameObject Parent = GameObject.Find("Category_mask").transform.Find("All").gameObject;
            Debug.Log(Screen.width + ", " + Screen.height + ", " + name + ", " + type);
            if (type == "solid")
            {
                newObject.transform.SetParent(Parent.transform);

                float x = Screen.width / 2f + (CountAll % 4 - 1.5f) * 83.7f * size;
                float y = 140.05f + (CountAll / 4) * -83.7f;

                newObject.transform.position = new Vector2(x, y * size);
                newObject.transform.localScale *= size;
                newObject.GetComponent<Substance>().isDefault = false;
                newObject.GetComponent<Substance>().condition = type;

                CountAll++;
            }
            else if (type == "liquid")
            {
                newObject.transform.SetParent(Parent.transform);

                float x = Screen.width / 2f + (CountAll % 4 - 1.5f) * 83.7f * size;
                float y = 140.05f + (CountAll / 4) * -83.7f;

                newObject.transform.position = new Vector2(x, y * size);
                newObject.transform.localScale *= size;
                newObject.GetComponent<Substance>().isDefault = false;
                newObject.GetComponent<Substance>().condition = type;

                CountAll++;
            }
            else if (type == "air")
            {
                newObject.transform.SetParent(Parent.transform);

                float x = Screen.width / 2f + (CountAll % 4 - 1.5f) * 83.7f * size;
                float y = 140.05f + (CountAll / 4) * -83.7f;

                newObject.transform.position = new Vector2(x, y * size);
                newObject.transform.localScale *= size;
                newObject.GetComponent<Substance>().isDefault = false;
                newObject.GetComponent<Substance>().condition = type;

                CountAll++;
            }
        }
    }

    private void ChangeSprite (GameObject Object) // 인수로 받은 오브젝트의 이름에 따라 스프라이트를 변경하는 함수
    {
        Image image = Object.GetComponent<Image>();

        if (Object.name == "나무")
        {
            image.sprite = Sprites[0];
        }
        else if (Object.name == "돌")
        {
            image.sprite = Sprites[1];
        }
        else if (Object.name == "철")
        {
            image.sprite = Sprites[2];
        }
        else if (Object.name == "녹슨 철")
        {
            image.sprite = Sprites[3];
        }
        else if (Object.name == "가스")
        {
            image.sprite = Sprites[4];
        }
        else if (Object.name == "냉기")
        {
            image.sprite = Sprites[5];
        }
        else if (Object.name == "불")
        {
            image.sprite = Sprites[6];
        }
        else if (Object.name == "산소")
        {
            image.sprite = Sprites[7];
        }
        else if (Object.name == "열기")
        {
            image.sprite = Sprites[8];
        }
        else if (Object.name == "이산화탄소")
        {
            image.sprite = Sprites[9];
        }
        else if (Object.name == "기름")
        {
            image.sprite = Sprites[10];
        }
        else if (Object.name == "물")
        {
            image.sprite = Sprites[11];
        }
        else if (Object.name == "수산화 나트륨")
        {
            image.sprite = Sprites[12];
        }
        else if (Object.name == "염산")
        {
            image.sprite = Sprites[13];
        }
        else if (Object.name == "용암")
        {
            image.sprite = Sprites[14];
        }
        else if (Object.name == "곰팡이")
        {
            image.sprite = Sprites[15];
        }
        else if (Object.name == "녹슨 철")
        {
            image.sprite = Sprites[16];
        }
        else if (Object.name == "녹은 철")
        {
            image.sprite = Sprites[17];
        }
        else if (Object.name == "더 큰 불")
        {
            image.sprite = Sprites[18];
        }
        else if (Object.name == "버섯")
        {
            image.sprite = Sprites[19];
        }
        else if (Object.name == "수증기")
        {
            image.sprite = Sprites[20];
        }
        else if (Object.name == "얼음")
        {
            image.sprite = Sprites[21];
        }
    }
}
