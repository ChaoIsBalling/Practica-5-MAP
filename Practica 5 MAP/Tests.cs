using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PracticaBase;

namespace PracticaBase
{

    [TestFixture]
    public class Tests
    {
        string Alejandretta = "Alejandretta";
        int defensa = 1;
        int ataque = 2;
        string Troya = "Troya";
        string Valencia = "Valencia";
        string Sevilla = "Sevilla";


        [Test]
        public void FindCityByNameTest()
        /// Busca una ciudad por nombre y devuelve su posición dentro del array de ciudades del tablero.
        /// No se espera que haya ciudades con nombres repetidos
        {
            //Arrange
            Board board = new Board();
            board.CreateTestBoard(board);


            //Act
            int city = board.FindCityByName(Alejandretta);


            //Assert
            Assert.That(board.GetCityName(city), Is.EqualTo(Alejandretta), "ERROR: Ciudad con nombre repetido");
            
        }

        [Test]
        public void AttackCityTest()
        {
            //Arrange
            Board board = new Board(0, 0);
            CreateTestBoard(out board);
            //Act
        
            //Assert
            Assert.That(board.AttackCity(0, ataque), Is.EqualTo(ataque> defensa), "Error");
        }

        //  [Test]
        public void RemoveCityFromDeckTest()
        {
            //Arrange

            //Act

            //Assert

        }

        //[Test]
        public void MoveTest()
        //Probar con distintas direcciones y comprobar que el movimiento cíclico es correcto
        {
            //Arrange

            //Act

            //Assert

        }
    }

}
