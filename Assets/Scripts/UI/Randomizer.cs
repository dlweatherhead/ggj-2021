using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject[] objects;

    void Start()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        var x = Random.Range(0, objects.Length);
        objects[x].SetActive(true);
    }
}
