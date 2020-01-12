using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstace;

    private List<GameObject> Obstacles = new List<GameObject>();
    public GameObject obstacle;

    [SerializeField] private int size = 10;

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
        for(int i = 0; i < size; i++)
        {
            GameObject Gobj = Instantiate(obstacle);
            Gobj.SetActive(false);
            Obstacles.Add(Gobj);
        }
    }

    public void UseList()
    {
        var Gobj = Obstacles[0];
        Gobj.transform.position = Random.insideUnitSphere * 20f;
        Gobj.SetActive(true);
        Obstacles.RemoveAt(0);
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
