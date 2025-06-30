using UnityEngine;

public class Cemara : MonoBehaviour
{
    [SerializeField] private Transform player;        // 拖入玩家对象
    private Vector3 lastPosition;
    // public GameObject oSymbol;
    [SerializeField] private Transform oSymbol;   

    void Start()
    {
        if (player != null)
        {
            lastPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        else {
            if (oSymbol != null)
            {
                lastPosition = new Vector3(oSymbol.position.x, oSymbol.position.y, transform.position.z);
            }
        }
        // else if (player==null && oSymbol!=null)
        // {
        //     lastPosition = new Vector3(oSymbol.position.x, oSymbol.position.y, transform.position.z);
        // }
    }

    void Update()
    {
        if (player != null)
        {
            // 正常跟随玩家
            lastPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        else {
            if (oSymbol != null)
            {
                lastPosition = new Vector3(oSymbol.position.x, oSymbol.position.y, transform.position.z);
            }
        }

        // else if (player==null && oSymbol!=null)
        // {
        //     lastPosition = new Vector3(oSymbol.position.x, oSymbol.position.y, transform.position.z);
        // }

        // 始终更新为最后一次已知的位置（避免 null 出错）
        transform.position = lastPosition;
    }
}
