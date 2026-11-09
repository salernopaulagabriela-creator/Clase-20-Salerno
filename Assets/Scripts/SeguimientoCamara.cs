using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    [SerializeField] private Transform esferaBlanca; 
    [SerializeField] private float velocidadMovimiento = 10f;
    
    private void Update()
    {
        
        float movimientoX = 0f;
        float movimientoZ = 0f;

        if (Input.GetKey(KeyCode.W)) movimientoZ += 1f;
        if (Input.GetKey(KeyCode.S)) movimientoZ -= 1f;
        if (Input.GetKey(KeyCode.A)) movimientoX -= 1f;
        if (Input.GetKey(KeyCode.D)) movimientoX += 1f;

        Vector3 direccionMovimiento = new Vector3(movimientoX, 0f, movimientoZ).normalized;
        transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime, Space.World);

        
        if (esferaBlanca != null)
        {
            transform.LookAt(esferaBlanca);
        }
    }
}