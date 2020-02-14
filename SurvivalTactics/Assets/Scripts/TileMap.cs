using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    // have a clickhandler on each unit, make it assign that unit as the selectedUnit
    public GameObject selectedUnit;

    public TileType[] tileTypes;

    int[,] tiles;

    int mapSizeX = 10;
    int mapSizeY = 10;

    private void Start()
    {
        // allocate map tiles
        tiles = new int[mapSizeX, mapSizeY];

        // initialize map tiles
        for(int x = 0; x<mapSizeX; ++x)
        {
            for(int y=0; y<mapSizeY; ++y)
            {
                tiles[x, y] = 0;
            }
        }

        // make a mountain
        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 4] = 2;

        // spawn the visual prefabs
        GenerateMapVisuals();
    }

    void GenerateMapVisuals()
    {
        for (int x = 0; x < mapSizeX; ++x)
        {
            for (int y = 0; y < mapSizeY; ++y)
            {
                TileType tt = tileTypes[tiles[x, y]];
                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, 0, y), Quaternion.identity);

                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, 0, y);
    }

    public void MoveUnitTo(int x, int y)
    {
        selectedUnit.GetComponent<Unit>().tileX = x;
        selectedUnit.GetComponent<Unit>().tileY = y;
        selectedUnit.transform.position = TileCoordToWorldCoord(x, y);
    }


}
