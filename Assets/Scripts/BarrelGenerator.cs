using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelGenerator : MonoBehaviour {
    [SerializeField]
    private int size;
    [SerializeField]
    private float offsetX;
    [SerializeField]
    private float offsetY;
    [SerializeField]
    private GameObject barrelPrefab;
    [SerializeField]
    private GameObject barrelWinPrefab;
    private List<GameObject> barrels = new List<GameObject>();
    private float minDistance = 15;
    private void Awake()
    {
        CreateBarrelPool();
        AjustPosition();
    }
    private void CreateBarrelPool()
    {
        for(int i = 0; i < size; i++)
        {
            InstantiateObjectInPool(barrelPrefab);
        }
        InstantiateObjectInPool(barrelWinPrefab);
    }
    private void AjustPosition()
    {
       Vector2[] points = GeneratePoints();
        for(int i = 0; i < barrels.Count; i++)
        {
            barrels[i].transform.position = points[i];
            barrels[i].SetActive(true);
        }
    }
    private Vector2[] GeneratePoints()
    {
        Vector2[] vector = new Vector2[size + 1];
        float xPositionStart = 0;
        float yPositionStart = 0;
        for (int i = 0; i < vector.Length; i++)
        {
            float xPositionGenerate = Random.Range(xPositionStart, OffsetCalc(xPositionStart, offsetX));
            float yPositionGenerate = Random.Range(-size, size);

            Vector2 currentPosition = new Vector2(xPositionGenerate, yPositionGenerate);
            vector[i] = currentPosition;

            xPositionStart = OffsetCalc(xPositionStart, offsetX);
            yPositionStart = OffsetCalc(yPositionStart, offsetY);
        }
        return vector;
    }
    private float OffsetCalc(float lastGeneratePosition, float offset)
    {
        return lastGeneratePosition + offset;
    }
    private void InstantiateObjectInPool(GameObject prefab)
    {
        GameObject obj = (GameObject)Instantiate(prefab);
        obj.SetActive(false);
        barrels.Add(obj);
    }
}
