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

        public void CreateTestBoard(out Board board)
        // Métodos auxiliares para crear tablero de pruebas
        // a usar por los tests de unidad.
        {
            board = new Board(5, 20);
            board.AddCity(Alejandretta, defensa, 1);
            //    board.AddCity("Alejandretta", 2, 1);
            //    board.AddCity("Troya", 0, 0);
        }

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
            Board board2 = new Board(5, 3); //Board(int maxCities, int numDecks)
            //AddCity(string cityName, int cityDefense, int cityPoints)
            board2.AddCity(Alejandretta, 3, 1);
            board2.AddCity(Troya, 1, 2);

            //Act
            bool attacked = board2.AttackCity(1, 1); //AttackCity(int cityIndex, int attackPoints)

            //Assert
            Assert.IsTrue(attacked,
                         "ERROR: La ciudad no ha sido atacada con éxito");
        }

        [Test]
        public void RemoveCityFromDeckTest()
        {
            //Arrange
            Board board3 = new Board(5, 3); //Board(int maxCities, int numDecks)
            //AddCity(string cityName, int cityDefense, int cityPoints)
            board3.AddCity(Alejandretta, 3, 1);
            board3.AddCity(Troya, 1, 2);
            board3.AddCityToDeck(Alejandretta, 1);
            board3.AddCityToDeck(Troya, 1);
            board3.AddCityToDeck(Sevilla, 1);

            //Act
            bool removetest = board3.RemoveCityFromDeck(1, 1);
            bool removetest2 = board3.RemoveCityFromDeck(2, 1);
            bool removetest3 = board3.RemoveCityFromDeck(1, 1);

            //Assert
            Assert.IsTrue(removetest,
                          "ERROR: No se ha borrado la ciudad del mazo.");
            Assert.IsTrue(removetest2,
                          "ERROR: No se ha borrado la ciudad del mazo.");
            Assert.IsTrue(removetest3,
                          "ERROR: No se ha borrado la ciudad del mazo o ya ha sido borrada.");

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
