using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.SceneManagement;

public class TokenScript : MonoBehaviour
{
    public PointCollect pointCollect;
    public GameObject HasNotClaimedState;
    public GameObject ClaimingState;
    public GameObject ClaimedState;
    private int pointsToClaim;

    [SerializeField] public TMPro.TextMeshProUGUI earnedText;
    [SerializeField] private TMPro.TextMeshProUGUI tokenBalanceText;
    private const string DROP_ERC20_CONTRACT = "0x050Ca30FAB203f2056C9d176DF3c81CdcFc307e8";

    void Start()
    {
        HasNotClaimedState.SetActive(true);
        ClaimingState.SetActive(false);
        ClaimedState.SetActive(false);
    }

    void Update()
    {
        earnedText.text = "Points Earned: " + pointCollect.points.ToString();
        pointsToClaim = pointCollect.points;
    }

    public async void GetTokenBalance()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(DROP_ERC20_CONTRACT);
            var data = await contract.ERC20.BalanceOf(address);
            tokenBalanceText.text = "$HAR: " + data.displayValue;
        }
        catch (System.Exception)
        {
            Debug.Log("Error getting token balance");
        }
    }

    public void ResetBalance()
    {
        tokenBalanceText.text = "$HAR: 0";
    }

    public async void MintERC20()
    {
        try
        {
            Debug.Log("Minting ERC20");
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(DROP_ERC20_CONTRACT);
            HasNotClaimedState.SetActive(false);
            ClaimingState.SetActive(true);
            var results = await contract.ERC20.Claim(pointsToClaim.ToString());
            Debug.Log("ERC20 minted");
            GetTokenBalance();
            ClaimingState.SetActive(false);
            ClaimedState.SetActive(true);
        }
        catch (System.Exception)
        {
            Debug.Log("Error minting ERC20");
        }
    }

    public void RestartGame()
    {
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
