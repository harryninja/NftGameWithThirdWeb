using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectWalletScript : MonoBehaviour
{
    public GameObject connectPrompt;
    public GameObject claimPrompt;
    public CharacterMovementScript playerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        claimPrompt.SetActive(false);
        connectPrompt.SetActive(true);
        playerMovementScript.runSpeed = 0f;
    }

    public void ConnectWallet()
    {
        connectPrompt.SetActive(false);
        playerMovementScript.runSpeed = 50f;
    }

    public void ShowConnectPrompt()
    {
        connectPrompt.SetActive(true);
        playerMovementScript.runSpeed = 0f;
    }
}
