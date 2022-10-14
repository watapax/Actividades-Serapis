using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public bool ingresoAutomatico;
    public string url;

    public TMP_InputField inputClave, inputUser;
    
    bool emptyInput;

    public GameObject login;
    public GameObject iniciando;
    public GameObject ingresoCorrecto;
    public GameObject ingresoIncorrecto;

    public TextMeshProUGUI mensajeError;

    string errorServer = "Error al tratar de conectarse al servidor";
    string errorUsuario = "El nombre de usuario o la password no coinciden";
    string errorLimite = "Se ha completado el limite de usuarios activos para esta cuenta";

    private void Start()
    {
        inputClave.inputType = TMP_InputField.InputType.Password;
    }

    public void IntentarLogin()
    {
        emptyInput = false;
       // Validar Campos
       if(inputClave.text == "")
        {
            inputClave.GetComponent<Animator>().Play("emptyInput");
            emptyInput = true;
        }

        if (inputUser.text == "")
        {
            inputUser.GetComponent<Animator>().Play("emptyInput");
            emptyInput = true;
        }

        if (!emptyInput)
            StartCoroutine(EnviarRequest());
    }

    IEnumerator EnviarRequest()
    {
        login.SetActive(false);
        iniciando.SetActive(true);


        if(ingresoAutomatico)
        {
            yield return new WaitForSeconds(3);
            iniciando.SetActive(false);
            ingresoCorrecto.SetActive(true);
            yield return null;
            StopAllCoroutines();
        }

        Usuario nuevoUsuario = new Usuario(inputUser.text, inputClave.text);

        WWWForm postData = new WWWForm();

        postData.AddField("usuario", nuevoUsuario.nombre);
        postData.AddField("password", nuevoUsuario.password);

        UnityWebRequest downloadObject = UnityWebRequest.Post(url, postData);

        yield return downloadObject.SendWebRequest();

        iniciando.SetActive(false);

        if (downloadObject.result != UnityWebRequest.Result.Success)
        {
            ingresoIncorrecto.SetActive(true);
            mensajeError.text = errorServer;
        }
        else
        {
            // Validar Datos
            string respuesta = downloadObject.downloadHandler.text;

            if (respuesta == "0")
            {
                ingresoCorrecto.SetActive(true);
            }
            else
            {
                ingresoIncorrecto.SetActive(true);

                if (respuesta == "1")
                    mensajeError.text = errorUsuario;
                else if (respuesta == "2")
                    mensajeError.text = errorLimite;
            }


        }

    }

    public void IntentarDenuevo()
    {
        ingresoIncorrecto.SetActive(false);
        inputClave.text = "";
        inputUser.text = "";
        login.SetActive(true);
    }

    public struct Usuario
    {
        public string nombre;
        public string password;

        public Usuario(string _nombre, string _password)
        {
            nombre = _nombre;
            password = _password;
        }

    }


    public void LoadAplicacion()
    {
        SceneManager.LoadScene("inicio");
    }

}
