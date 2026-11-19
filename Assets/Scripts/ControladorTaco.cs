using UnityEngine;

public class ControladorTaco : MonoBehaviour
{
    [Header("Ajustes del Taco")]
    [Range(1f, 50f)]
    [SerializeField] private float fuerzaGolpe = 15f;
    [SerializeField] float radioVisual = 2f;
    private int puntaje = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit impacto;

            if (Physics.Raycast(rayo, out impacto))
            {
                if (impacto.collider.CompareTag("BolaBlanca"))
                {
                    Rigidbody rbEsferaBlanca = impacto.collider.GetComponent<Rigidbody>();

                    if (rbEsferaBlanca != null)
                    {
                        Vector3 direccionGolpe = (impacto.point - Camera.main.transform.position).normalized;
                        direccionGolpe.y = 0f;

                        rbEsferaBlanca.AddForceAtPosition(direccionGolpe * fuerzaGolpe, impacto.point, ForceMode.Impulse);

                        Debug.Log("¡Golpe aplicado a la esfera blanca!");
                    }
                }
            }
        }
    }

    [ContextMenu("Sumar 10 puntos")]
    public void SumarPuntos(int puntosExtra)
    {
        puntaje += puntosExtra;
        Debug.Log("Puntaje actual: " + puntaje);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioVisual);
    }
}