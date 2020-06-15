using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class RegristerScript : MonoBehaviour
{
    public InputField _nameInput;
    public InputField _emailInput;
    public InputField _passInput;

    public Text nameError;
    public Text emailError;
    public Text passError;

    private bool canRegister = true;

    public void Register()
    {
        if (_nameInput.text.Length > 3)
        {
            SaveData.nome = _nameInput.text;
            nameError.enabled = false;
        }           
        else
        {
            nameError.enabled = true;
            canRegister = false;
        }
            

        if (isEmailValid(_emailInput.text))
        {
            SaveData.email = _emailInput.text;
            emailError.enabled = false;
        }
        else
        {
            emailError.enabled = true;
            canRegister = false;
        }

        if (_passInput.text.Length > 7)
        {
            SaveData.senha = _passInput.text;
            passError.enabled = false;
        }
        else
        {
            passError.enabled = true;
            canRegister = false;
        }


        if (canRegister)
        {
            SaveData.SaveUserData();
            SceneController.LoadStaticScene("TelaInicial");
        }           
    }

    private bool isEmailValid(string email)
    {
        try
        { 
            MailAddress mail = new MailAddress(email);
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }
}
