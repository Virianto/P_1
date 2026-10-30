using System.Collections.Generic;
using UnityEngine;

public class M_EthanCoinManager : MonoBehaviour
{
    [SerializeField] GameObject normalCoin;
    [SerializeField] GameObject bigCoin;
    [SerializeField] Transform coinLocation;
    [SerializeField] List<B_BigCoin> bc = new();
    [SerializeField] List<B_Coin> nc = new();

    B_Coin coinSmall;
    B_BigCoin coinBig;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Vector3 normlPosition = coinLocation.position;
            coinSmall = Instantiate(normalCoin).GetComponent<B_Coin>();
            nc.Add(coinSmall);
            coinSmall.transform.position = normlPosition;
        }
    }

    public void destroySmallCoin(B_Coin SmallCoin)
    {
        Destroy(coinSmall.gameObject);

    }

}

//if (coinSmall.GetComponent<B_Coin>().isCoincollected)
//{

//}
//if (Input.GetKeyDown(KeyCode.B)) 
//{
//    Vector3 bigPosition = coinLocation.position;
//    coinBig = Instantiate(bigCoin).GetComponent<B_BigCoin>();
//    bc.Add(coinBig);
//    coinBig.transform.position = bigPosition;
//}
//if (bigCoin.GetComponent<B_BigCoin>().isCoincollected)
//{
//    Destroy(coinBig.gameObject);
//}





