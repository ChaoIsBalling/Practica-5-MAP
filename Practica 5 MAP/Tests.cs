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
            board = new Board(5, 6);
            board.AddCity(Alejandretta, 1, 2);
            board.AddCity(Troya, 1, 1);
            board.AddCity(Sevilla, 1, 4);
            board.AddCity(Valencia, 1, 3);
            board.AddCityToDeck(Alejandretta, 1);
            board.AddCityToDeck(Troya, 2);
            board.AddCityToDeck(Sevilla, 3);

        }

        public void CreateTestPlayer(out Player player, ref Board board, ref bool attack,ref bool attack2, ref bool attack3)
        {
            player = new Player(20, 6, 1);
            attack = player.AttackCity(board, Alejandretta);
            player.Move(board, 1, Direction.Right);
            attack2 = player.AttackCity(board, Troya);
            player.Move(board, 1, Direction.Right);
            attack3 = player.AttackCity(board, Sevilla);
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
            board.AddCity(Troya,1,1);
            board.AddCity(Sevilla,1,2);
            board.AddCity(Valencia,1,3);

            //Act
            int city1 = board.FindCityByName(Troya);
            int city2 = board.FindCityByName(Alejandretta);


            //Assert
            Assert.That(city1,
                        Is.EqualTo(1), //numero esperado
                        "ERROR: No se ha encontrado la ciudad en la lista de ciudades."); //si no, test falla
        
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
            bool attacked = board2.AttackCity(1, 2); //AttackCity(int cityIndex, int attackPoints)

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
            bool removetest = board3.RemoveCityFromDeck(1, 0);
            bool removetest2 = board3.RemoveCityFromDeck(1, 1);
            bool removetest3 = board3.RemoveCityFromDeck(1, 0);

            //Assert
            Assert.IsTrue(removetest,
                          "ERROR: No se ha borrado la ciudad del mazo.");
            Assert.IsTrue(removetest2,
                          "ERROR: No se ha borrado la ciudad del mazo.");
            //Este assert da error, es a proposito.
           /* Assert.IsTrue(removetest3,
                          "ERROR: No se ha borrado la ciudad del mazo o ya ha sido borrada.");*/

        }

        [Test]
        public void MoveTest()
        //Probar con distintas direcciones y comprobar que el movimiento cíclico es correcto
        {
            //Arrange
            Board board = new Board(0, 0);
            CreateTestBoard(out board);

            
            //Act
            int Move1 = board.Move(0, 1, Direction.Left);
            int Move2 = board.Move(0, 1, Direction.Right);
            int Move3 = board.Move(5, 1, Direction.Right);
            int Move4 = board.Move(0, 6, Direction.Right);
            int Move5 = board.Move(0, 6, Direction.Left);

            //Assert

            Assert.IsTrue(Move1 == 5, "Error: El movimiento no es cíclico/no funciona bien");
            Assert.IsTrue(Move2 == 1, "Error: El movimiento no es cíclico/no funciona bien");
            Assert.IsTrue(Move3 == 0, "Error: El movimiento no es cíclico/no funciona bien");
            Assert.IsTrue(Move4 == 0, "Error: El movimiento no es cíclico/no funciona bien");
            Assert.IsTrue(Move5 == 0, "Error: El movimiento no es cíclico/no funciona bien");
        }

        [Test]
        public void PlayerMoveTest()
        {
            //Arrange
            Board board = new Board(1,5);
            Player player = new Player(1, 1, 1); //1 movimiento
            Player player2 = new Player(2, 1, 1); //2 movimientos

            //Act
            bool move = player.Move(board, 1, Direction.Right); //1step
            bool move2 = player2.Move(board, 1, Direction.Right);

            //Assert
            Assert.IsTrue(move, //Devuelve true si el jugador ha agotado sus movimientos.
                         "ERROR: El jugador no ha agotado sus movimientos.");
            Assert.IsFalse(move2, //Devuelve false porque el jugador aun tiene movimientos.
                          "ERROR: El jugador no ha agotado sus movimientos.");
            Assert.That(() => { player.Move(board, -1, Direction.Left); },
                         Throws.Exception, //Devuelve Exception
                         "ERROR: No lanza excepción por número de pasos negativos.");
            Assert.That(() => { player.Move(board, 3, Direction.Right); },
                         Throws.Exception, //Devuelve Exception
                         "ERROR: No lanza excepción porque no hay suficientes movimientos.");
        }

        [Test]
        public void ComputePlayerPointsTest()
        {
            //Arrange
            Board board = new Board(0, 0);
            CreateTestBoard(out board);
            Player player = new Player(20,6,1);

            //Act
            bool attack = true;
            bool attack2 = true;
            bool attack3 = true;
            CreateTestPlayer(out player, ref board, ref attack, ref attack2, ref attack3);
            //Assert
            Assert.That(player.ComputePlayerPoints(board), Is.EqualTo(7), "Error: no se han obtenido puntos.");

        }
        [Test]
        public void AttackCityPlayerTest()
        {
            //Arrange
            Board board = new Board(0, 0);
            CreateTestBoard(out board);
            Player player = new Player(20, 6, 1);
            //Act

            bool attack = true;
            bool attack2 = true;
            bool attack3 = true;

            CreateTestPlayer(out player,ref board,ref attack,ref attack2,ref attack3);
            //Assert
            Assert.IsTrue(attack, "Error:El ataque no funciona");
            Assert.IsTrue(attack2, "Error:El ataque no funciona");
            Assert.IsTrue(attack3, "Error:El ataque no funciona");
            Assert.That(() => { player.AttackCity(board, "Paris"); }, Throws.Exception, "ERROR: AttackCity no Lanza excepción cuando la ciudad no existe");
            Assert.That(() => { player.AttackCity(board, Troya); }, Throws.Exception, "ERROR: AttackCity no Lanza excepción cuando la ciudad no está en el mazo");

        }
    }

}
