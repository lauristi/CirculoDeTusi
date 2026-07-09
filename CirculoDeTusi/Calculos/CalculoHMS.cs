using Microsoft.VisualBasic.Logging;
using System.Runtime.InteropServices;

namespace CirculoDeTusi.Calculos
{
    public class CalculoHMS
    {
        // Movimento Harmônico Simples (MHS).
        // Propriedades para armazenar as dimensões da janela, o raio do círculo maior, o número total de círculos menores e o tempo de animação

        public int LarguraJanela { get; set; }
        public int AlturaJanela { get; set; }
        public int RaioCirculoMaior { get; set; }
        public int TotalCirculosMenores { get; set; }
        public float TempoAnimacao { get; set; }

        #region Geral

        public int GetCentroJanela_X()
        {
            return (LarguraJanela / 2);
        }

        public int GetCentroJanela_Y()
        {
            return (AlturaJanela / 2);
        }

        public int GetRaioCirculoMenor()
        {
            if (TotalCirculosMenores > 3)
            {
                return (RaioCirculoMaior / TotalCirculosMenores);
            }
            else
            {
                return (RaioCirculoMaior / 4);
            }
        }

        public float GetAnguloAtual(int linhaAtual)
        {
            return (float)(linhaAtual * Math.PI / TotalCirculosMenores);
        }

        #endregion Geral

        #region Calculo do circulo Maior

        public float GetCirculoMaior_X()
        {
            return (GetCentroJanela_X() - RaioCirculoMaior);
        }

        public float GetCirculoMaior_Y()
        {
            return (GetCentroJanela_Y() - RaioCirculoMaior);
        }

        public float GetCirculoMaior_Altura()
        {
            return (RaioCirculoMaior * 2);
        }

        public float GetCirculoMaior_Largura()
        {
            return (RaioCirculoMaior * 2);
        }

        #endregion Calculo do circulo Maior

        #region Calculo dos circulos menores

        public float GetDistanciaEntreCirculos(float angulo)
        {
            // O limite agora é a borda interna do círculo grande
            // Usamos esse novo limite na oscilação
            float raioMaximoPermitido = (RaioCirculoMaior - GetRaioCirculoMenor());

            return (raioMaximoPermitido * (float)Math.Cos(TempoAnimacao + angulo));
        }

        public float GetCirculoMenor_X(float angulo, float distanciaAtual)
        {
            return (GetCentroJanela_X() + distanciaAtual * (float)Math.Cos(angulo) - GetRaioCirculoMenor());
        }

        public float GetCirculoMenor_Y(float angulo, float distanciaAtual)
        {
            return (GetCentroJanela_Y() + distanciaAtual * (float)Math.Sin(angulo) - GetRaioCirculoMenor());
        }

        public float GetCirculoMenor_Altura()
        {
            return (GetRaioCirculoMenor() * 2);
        }

        public float GetCirculoMenor_Largura()
        {
            return (GetRaioCirculoMenor() * 2);
        }

        #endregion Calculo dos circulos menores

        #region Calculo da linha de extremidade do círculo maior

        public float GetExtremidadeLinha_X1(float angulo)
        {
            return (GetCentroJanela_X() + RaioCirculoMaior * (float)Math.Cos(angulo));
        }

        public float GetExtremidadeLinha_Y1(float angulo)
        {
            return (GetCentroJanela_Y() + RaioCirculoMaior * (float)Math.Sin(angulo));
        }

        public float GetExtremidadeLinha_X2(float angulo)
        {
            return (GetCentroJanela_X() - RaioCirculoMaior * (float)Math.Cos(angulo));
        }

        public float GetExtremidadeLinha_Y2(float angulo)
        {
            return (GetCentroJanela_Y() - RaioCirculoMaior * (float)Math.Sin(angulo));
        }

        #endregion 
    }
}