using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AntaresClient.Get("1f1ba09b851ad05a:d9ef755e4f27280c",
                "https://platform.antares.id:8443/~/antares-cse/antares-id/TestPostman/Tutorial/la")
            .Then(data =>
            {
                Debug.Log(data.con); //data ada di variabel con;
            })
            .Catch(exception => Debug.Log(exception.Message));
    }
}
