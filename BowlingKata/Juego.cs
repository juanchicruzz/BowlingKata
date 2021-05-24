using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingKata
{
    public class Jugada
    {
        public int numeroJugada { get; set; }
        public int? primerTiro { get; set; }
        public int? segundoTiro { get; set; }
        public int puntaje { get; set; }
        public bool spare { get; set; }
        public bool strike { get; set; }
        public bool finished { get; set; }

        public Jugada(int numJugada)
        {
            numeroJugada = numJugada;
            puntaje = 0;
        }

    }
    public class Juego
    {
        
        public List<Jugada> jugadas = new List<Jugada>();


        public void Tirar(int cantidad)
        {
            if (!jugadas.Any())
            {
                jugadas.Add(new Jugada(1));
            }

            Jugada ultimaJugada = jugadas.OrderBy(x => x.numeroJugada).Last();

            if (ultimaJugada.primerTiro != null && (ultimaJugada.segundoTiro != null | ultimaJugada.strike))
            {
                if (ultimaJugada.spare)
                {
                    ultimaJugada.puntaje += cantidad;
                }

                if (ultimaJugada.strike)
                {
                    ultimaJugada.puntaje += cantidad;
                    Jugada jugadaAnterior = jugadas.Find(x => x.numeroJugada == (ultimaJugada.numeroJugada - 1));
                    if (jugadaAnterior != null && jugadaAnterior.strike && jugadaAnterior.finished == false)
                    {
                        jugadaAnterior.finished = true;
                        jugadaAnterior.puntaje += cantidad;
                    }
                }

                if(ultimaJugada.numeroJugada == 10) {
                    return;
                }
                jugadas.Add(new Jugada(ultimaJugada.numeroJugada + 1));
                ultimaJugada = jugadas.OrderBy(x => x.numeroJugada).Last();
            }

            if (ultimaJugada.primerTiro == null)
            {
                ultimaJugada.primerTiro = cantidad;
                if(ultimaJugada.primerTiro == 10)
                {
                    ultimaJugada.strike = true;
                }
            }else if(ultimaJugada.segundoTiro == null) 
            {
                ultimaJugada.segundoTiro = cantidad;

                if (ultimaJugada.strike)
                {
                    ultimaJugada.puntaje += cantidad;
                }

                if (ultimaJugada.primerTiro + ultimaJugada.segundoTiro == 10)
                {
                    ultimaJugada.spare = true;
                }
            }
            ultimaJugada.puntaje += cantidad;
        }

        public int Score()
        {
            return jugadas.Sum(x=>x.puntaje);
        }
    }
}
