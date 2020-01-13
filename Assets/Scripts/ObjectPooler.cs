using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstace;

    private List<GameObject> Obstacles = new List<GameObject>();
    public GameObject obstacle1 , obstacle2;


    [SerializeField] private int size = 20;

    private void Awake()
    {
        sharedInstace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        FillList();
    }


    public void FillList()
    {
        for(int i = 0; i < size/2; i++)
        {
            GameObject Gobj = Instantiate(obstacle1);
            Gobj.SetActive(false);
            Obstacles.Add(Gobj);
        }
        for (int i = size/2; i < size; i++)
        {
            GameObject Gobj = Instantiate(obstacle2);
            Gobj.SetActive(false);
            Obstacles.Add(Gobj);
        }
    }

    public void UseList()
    {
        int pos = Random.Range(0, 10);
        var Gobj = Obstacles[pos];
        Gobj.transform.position = Random.insideUnitSphere * 20f;
        Gobj.SetActive(true);
        Obstacles.RemoveAt(pos);
    }

    public void BacktoList(GameObject obj)
    {
        obj.SetActive(false);
        Obstacles.Add(obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

