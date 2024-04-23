using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class MapGenerator : MonoBehaviour
{
    public Texture2D textura;
    public ObjectInfo[] objectInfo;
    public Vector3 offset = Vector3.zero;

    public Color playerColor;
    public GameObject playerPrefab;

    public Color enemyColor;
    public GameObject enemyPrefab;

    private Vector2 pos;

    public NavMeshSurface surface;

    void Start()
    {
        this.ReadTexture();
    }

    private void ReadTexture()
    {
        for ( int x = 0; x < this.textura.width; x++)
        {
            for (int y = 0; y < this.textura.height; y++)
            {
                this.pos = new Vector2(x, y);
                this.getColor(x, y);
            }
        }
    }

    private void getColor(int x, int y)
    {
        Color c = this.textura.GetPixel(x, y);
        if (c.a < 1)
            return;

        this.CreateObject(c);
        surface.BuildNavMesh();
        this.CreatePlayer(c);
        this.CreateEnemies(c);
    }

    private void CreateObject(Color c)
    {
        foreach(ObjectInfo info in objectInfo)
        {
            if(info.color == c)
            {
                Instantiate(info.prefab, new Vector3(this.pos.x, 0, this.pos.y) + offset, Quaternion.identity, this.transform);
            }
        }
    }

    private void CreatePlayer(Color c)
    {
        foreach(ObjectInfo info in objectInfo)
        {
            if (c == playerColor)
            {
                Instantiate(playerPrefab, new Vector3(pos.x, 0, pos.y) + offset, Quaternion.identity, transform);
            }
            
        }
    }

    private void CreateEnemies(Color c)
    {
        foreach(ObjectInfo info in objectInfo)
        {
            if (c == enemyColor)
            {
                Instantiate(enemyPrefab, new Vector3(pos.x, 0, pos.y) + offset, Quaternion.identity, transform);
            }
        }
    }
}