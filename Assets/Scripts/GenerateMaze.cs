
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;
    public GameObject npc_guard;

    private int[,] worldMap = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1},
        {1,2,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,1,1,0,0,0,1},
        {1,0,0,3,0,0,0,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,0,0,0,0,0,3,0,0,1},
        {1,0,0,0,0,0,0,0,0,1},
        {1,1,1,1,1,1,1,1,1,1}
    };

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject t;

                if (worldMap[i, j] == 1)
                {
                    t = Instantiate(wall,
                        new Vector3(50 - i * 10, 1.5f, 50 - j * 10),
                        Quaternion.identity);

                    t.SetActive(true);
                }

                if (worldMap[i, j] == 2)
                {
                    t = Instantiate(player,
                        new Vector3(50 - i * 10, 1.5f, 50 - j * 10),
                        Quaternion.identity);

                    t.name = "FPSController";
                }

                if (worldMap[i, j] == 3)
                {
                    t = Instantiate(npc_guard,
                        new Vector3(50 - i * 10, 0.5f, 50 - j * 10),
                        Quaternion.identity);
                }
            }
        }
    }
}
