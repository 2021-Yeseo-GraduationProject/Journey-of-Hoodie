using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    public Material icecolorChoco;
    public Material icecolorMint;
    public string icekind;
    public string othericekind;
    public GameObject[] Player;
    public GameObject MyPlayer;
    public GameObject OtherPlayer;
    public bool state;
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
       // if(null != GameObject.Find("DataObject")){
        //    icekind = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind;
        //}
        
        if(null != GameObject.Find("DataObject")){
            icekind = GameObject.Find("DataObject").GetComponent<TransData>().icekind;
        }
        else if(null != GameObject.Find("icenicknameObject")){
            icekind = GameObject.Find("icenicknameObject").GetComponent<nicknameObject>().icekind;
           // GameObject.Find("MultiPlayer(Clone)").GetComponent<IcePlayer>().PV.RPC("getColor", RpcTarget.All, icekind);
        }
        else{
            return;
        }

        Camera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");

        if(state == true && null != GameObject.Find("MultiPlayer(Clone)")){
            GameObject.Find("MultiPlayer(Clone)").GetComponent<IcePlayer>().PV.RPC("getColor", RpcTarget.Others, icekind);
            state = false;
        }

        if(SceneManager.GetActiveScene().name == "B"){
            if(null != GameObject.Find("MultiPlayer(Clone)") && Camera.activeSelf == true)
            {
                if(Player[0].GetComponent<IcePlayer>().PV.IsMine)
                {
                    MyPlayer = Player[0];
                }
                else if(Player[1].GetComponent<IcePlayer>().PV.IsMine)
                {
                    MyPlayer = Player[1];
                }       

                if(icekind == "Mint"){
                    MyPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                }
                else if(icekind == "Choco"){
                    MyPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                }
            }
            else if(null != GameObject.Find("MultiPlayer(Clone)") && Camera.activeSelf == false)
            {
                if(Player[0].GetComponent<IcePlayer>().PV.IsMine)
                {
                    OtherPlayer = Player[1];
                }
                else if(Player[1].GetComponent<IcePlayer>().PV.IsMine)
                {
                    OtherPlayer = Player[0];
                }       

                if(othericekind == "Mint"){
                    OtherPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                }
                else if(othericekind == "Choco"){
                    OtherPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                }
            }
            else
            {
                if(null != GameObject.Find("Player"))
                {
                    if(icekind == "Mint"){
                        Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                    }
                    else if(icekind == "Choco"){
                        Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                    }
                }
            }
        }
        else{
            if(null != GameObject.Find("TownMultiPlayer(Clone)"))
            {
                if(Player[0].GetComponent<MapIcePlayer>().PV.IsMine)
                {
                    MyPlayer = Player[0];
                    OtherPlayer = Player[1];
                }
                else if(Player[1].GetComponent<MapIcePlayer>().PV.IsMine)
                {
                    MyPlayer = Player[1];
                    OtherPlayer = Player[0];
                }   

                if(icekind == "Mint"){
                    MyPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                }
                else if(icekind == "Choco"){
                    MyPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                }
                else if(othericekind == "Mint"){
                    OtherPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                }
                else if(othericekind == "Choco"){
                    OtherPlayer.transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                }
            }
            else
            {
                if(null != GameObject.Find("Player"))
                {
                    if(icekind == "Mint"){
                        Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorMint;
                    }
                    else if(icekind == "Choco"){
                        Player[0].transform.Find("OilTank001").gameObject.GetComponent<SkinnedMeshRenderer>().material = icecolorChoco;
                    }
                }
            }
        }
    }
}