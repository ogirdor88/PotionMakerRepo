using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject IngredientPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject newIn = Instantiate(IngredientPrefab);
        newIn.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - .5f);
    }
}
