using System;
using Xunit;
using BowlingKata;

namespace BowlingXUnit
{
    public class UnitTest1
    {
        Juego juego = new Juego();
        
        [Fact]
        public void PerdedorTest()
        {
            int cantidad = 0;
            for (int i = 1; i <= 20; i++)
            {
                juego.Tirar(cantidad);
            }
            Assert.Equal(0,juego.Score());
                
        }
        [Fact]
        public void Suma1Test()
        {
            int cantidad = 1;
            for (int i = 1; i <= 20; i++)
            {
                juego.Tirar(cantidad);
            }
            Assert.Equal(20, juego.Score());

        }
        
        [Fact]
        public void OneSpareTest()
        {
            juego.Tirar(5);
            juego.Tirar(5);
            int cantidad = 1;
            for (int i = 1; i <= 18; i++)
            {
                juego.Tirar(cantidad);
            }
            Assert.Equal(29, juego.Score());

        }

        [Fact]
        public void OneStrikeTest()
        {
            juego.Tirar(10);
            int cantidad = 1;
            for (int i = 1; i <= 18; i++)
            {
                juego.Tirar(cantidad);
            }
            Assert.Equal(30, juego.Score());

        }

        [Fact]
        public void JugadaPerfectaTest()
        {
            int cantidad = 10;
            for (int i = 1; i <= 12; i++)
            {
                juego.Tirar(cantidad);
            }
            Assert.Equal(300, juego.Score());

        }
    }
}
