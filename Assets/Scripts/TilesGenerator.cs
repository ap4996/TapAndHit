using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    public GameObject tile;
    public int numberOfTiles;
    public Vector3 startPosition;
    public float heightDifference, minimumXValue, maximumXValue;

    private void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        Vector3 tilePosition = startPosition;
        Transform instantiatedTile;
        for(int i = 0; i < numberOfTiles; ++i)
        {
            tilePosition = new Vector3(startPosition.x + Random.Range(minimumXValue, maximumXValue), startPosition.y + (heightDifference * i), startPosition.z);
            instantiatedTile = Instantiate(tile, transform, false).transform;
            instantiatedTile.localPosition = tilePosition;
        }
    }
}
