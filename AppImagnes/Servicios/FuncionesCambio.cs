using AppImagnes.Models;

namespace AppImagnes.Servicios
{
    public interface IFuncionesCambio
    {
        void Anterior(List<cImagen> list, int iman);
        void Siguiente(List<cImagen> list, int iman);
    }
    public class FuncionesCambio : IFuncionesCambio
    {
        public void Siguiente(List<cImagen> list, int iman)
        {
            if (iman == 9)
            {
                foreach (cImagen item in list)
                {
                    if (item.posicion == 1)
                    {
                        item.actual = true;
                    }
                    else
                    { item.actual = false; }

                }
            }
            else
            {
                int aux = iman + 1;

                foreach (cImagen item in list)
                {
                    if (item.posicion == aux)
                    {
                        item.actual = true;
                    }
                    else
                    {
                        item.actual = false;
                    }
                }


            }
        }

        public void Anterior(List<cImagen> list, int iman)
        {
            if (iman == 1)
            {
                foreach (cImagen item in list)
                {
                    if (item.posicion == 9)
                    {
                        item.actual = true;
                    }
                    else
                    {
                        item.actual = false;
                    }

                }
            }
            else
            {
                int aux = iman - 1;

                foreach (cImagen item in list)
                {
                    if (item.posicion == aux)
                    {
                        item.actual = true;
                    }
                    else
                    {
                        item.actual = false;
                    }
                }


            }

        }
    }
}
