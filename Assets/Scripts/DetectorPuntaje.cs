using UnityEngine;

public class DetectorPuntaje : MonoBehaviour
{
    
    [SerializeField] private ControladorTaco controladorJuego;

    private void OnTriggerEnter(Collider otro)
    {
        
        if (otro.CompareTag("BolaBlanca") || otro.name.Contains("Bola"))
        {
            
            if (controladorJuego != null)
            {
                controladorJuego.SumarPuntos(10); 
                Debug.Log("¡Una bola entró al agujero!");
            }

            
        }
    }
}