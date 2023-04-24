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
        string Alejandretta = "Alejandretta", 
               Troya = "Troya",
               Valencia = "Valencia",
               Sevilla = "Sevilla";
        int defensa = 1,
            ataque = 2;
        

        [Test]
        public void FindCityByNameTest()
        /// Busca una ciudad por nombre y devuelve su posición dentro del array de ciudades del tablero.
        /// No se espera que haya ciudades con nombres repetidos
        {
            //Arrange
            Board board = new Board(5, 3); //Board(int maxCities, int numDecks)
            //AddCity(string cityName, int cityDefense, int cityPoints)
            board.AddCity(Alejandretta, 1, 1); 
            board.AddCity(Alejandretta, 1, 2);
            board.AddCity(Troya,1,1);
            board.AddCity(Sevilla,1,2);
            board.AddCity(Valencia,1,3);

            //Act
            int city1 = board.FindCityByName(Troya);
            int city2 = board.FindCityByName(Alejandretta);


            //Assert
            Assert.That(city1,
                        Is.EqualTo(3), //numero esperado
                        "ERROR: No se ha encontrado la ciudad en la lista de ciudades."); //si no, test falla
            Assert.That(city1,
                        Is.EqualTo(1), //numero esperado
                        "ERROR: Se han encontrado ciudades repetidas.");
        }

        [Test]
        public void AttackCityTest()
        {
            //Arrange
            Board board = new Board(0, 0);
            
            //Act
        
            //Assert
            Assert.That(board.AttackCity(0, ataque),
                        Is.EqualTo(ataque> defensa), 
                        "Error");
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
