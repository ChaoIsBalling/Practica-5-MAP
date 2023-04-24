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
        #region Tests Board
        // Métodos auxiliares para crear tablero de pruebas
        // a usar por los tests de unidad.
        
        #endregion
        [Test]
        public void FindCityByNameTest()
        /// Busca una ciudad por nombre y devuelve su posición dentro del array de ciudades del tablero.
        /// No se espera que haya ciudades con nombres repetidos
        {
            //Arrange
            Board board = new Board();
            board.AddCity("Alejandretta", 0, 1);
            board.AddCity("Alejandretta", 2, 1);
            board.AddCity("Troya", 0, 0);

            //Act
            board.FindCityByName("Alejandretta");
            board.FindCityByName("Troya");
            board.FindCityByName("Madrid");

            //Assert
            Assert.That( , //ejemplo
                         ,
                        "ERROR: Ciudad con nombre repetido");
            Assert.That( , //ejemplo
                         ,
                        "ERROR: Ciudad no encontrada");
        }

        [Test]
        public void AttackCityTest()
        {
            //Arrange

            //Act

            //Assert

        }

        [Test]
        public void RemoveCityFromDeckTest()
        {
            //Arrange

            //Act

            //Assert

        }

        [Test]
        public void MoveTest()
        //Probar con distintas direcciones y comprobar que el movimiento cíclico es correcto
        {
            //Arrange

            //Act

            //Assert

        }
    }

}
