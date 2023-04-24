using System;

namespace PracticaBase
{
    class MainClass
    {
        /// <summary>
        /// Punto de entrada a la aplicación
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Construcción del tablero y del jugador
            Board theBoard = InitBoard(3, 5);
            Player thePlayer = new Player(4, 4, 0);

            bool finishGame = false;
            while (!finishGame)
            {
                // Información de estado del juego
                Console.WriteLine("----- NEW ROUND --------");
                Console.WriteLine(theBoard.ShowDeck(thePlayer.GetPosition()));
                Console.WriteLine(thePlayer.GetPlayerStatus());

                // Fase de movimiento
                // El juego termina si el jugador se queda sin movimientos
                finishGame = MovementPhase(theBoard, thePlayer);

                // Fase de ataque
                // El juego termina si el jugador no conquista la ciudad que ataque
                if (theBoard.CitiesInDeck(thePlayer.GetPosition()) == 0)
                {
                    Console.WriteLine("No cities to attack");
                }
                else
                {
                    bool playerWins = AttackPhase(theBoard, thePlayer);
                    finishGame = finishGame || !playerWins;
                }
            }

            // Fin de juego: se muestran los puntos del jugador
            Console.WriteLine("GAME OVER!");
            Console.Write("Points: " + thePlayer.ComputePlayerPoints(theBoard));
        }

        /// <summary>
        /// Método para construir un tablero de juego y las ciudades
        /// </summary>
        /// <param name="maxCities">Número máximo de ciudades</param>
        /// <param name="nDecks">Número de mazos</param>
        /// <returns>Un tablero preparado para comenzar a jugar</returns>
        private static Board InitBoard(int maxCities, int nDecks)
        {
            // Ejemplo de inicialización
            Board aBoard = new Board(maxCities, nDecks);
            aBoard.AddCity("Alejandretta", 4, 5);
            aBoard.AddCity("Babilonia", 6,10);
            aBoard.AddCity("Troya", 2, 2);

            aBoard.AddCityToDeck("Alejandretta", 0);
            aBoard.AddCityToDeck("Troya", 0);
            aBoard.AddCityToDeck("Troya", 1);
            aBoard.AddCityToDeck("Alejandretta", 3);
            aBoard.AddCityToDeck("Babilonia", 3);
            return aBoard;
        }

        /// <summary>
        /// Ejecución de la fase de movimiento
        /// </summary>
        /// <param name="aBoard">Tablero de juego</param>
        /// <param name="aPlayer">Jugador</param>
        /// <returns>true si el juego ha de finalizar porque el jugador
        /// se ha quedado sin movimientos; false, en otro caso</returns>
        private static bool MovementPhase(Board aBoard, Player aPlayer)
        {
            bool correctMovement = false;
            bool stopGame = false;
            do
            {
                Console.WriteLine("MOVEMENT");
                bool correct = false;
                Direction dir;
                int numSteps = 0;
                do
                {
                    Console.Write("Direction (left/right): ");
                    string dirString = Console.ReadLine();
                    dir = ReadDirection(dirString);
                    if (dir != Direction.None)
                    {
                        correct = true;
                    }

                } while (!correct);

                correct = false;
                do
                {
                    Console.Write("Steps (0..):");
                    string numStepString = Console.ReadLine();
                    try
                    {
                        numSteps = Int32.Parse(numStepString);
                        correct = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wrong number format");
                    }
                } while (!correct);
                try
                {
                    stopGame = aPlayer.Move(aBoard, numSteps, dir);
                    correctMovement = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!correctMovement);
            return stopGame;
        }

        /// <summary>
        /// Ejecución de la fase de ataque
        /// </summary>
        /// <param name="aBoard">Tablero de juego</param>
        /// <param name="aPlayer">Jugador</param>
        /// <returns>true si el jugador ha conquistado una ciudad;
        /// false, en otro caso (el juego terminará)</returns>
        /// <returns></returns>
        private static bool AttackPhase(Board aBoard, Player aPlayer)
        {
            bool playerWins = false;
            Console.WriteLine("ATTACK");
            bool correct = false;
            Console.WriteLine(aBoard.ShowDeck(aPlayer.GetPosition()));
            do
            {
                Console.Write("Which city will you atack: ");
                string cityName = Console.ReadLine();
                try
                {
                    playerWins = aPlayer.AttackCity(aBoard, cityName);
                    correct = true;
                    if (playerWins)
                    {
                        Console.WriteLine("You conquered " + cityName);                        
                    }
                    else
                    {
                        Console.WriteLine(cityName + " withstands your attack! YOU LOSE");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (!correct);
            return playerWins;

        }

        /// <summary>
        /// Conversión de una cadena de texto a una dirección
        /// </summary>
        /// <param name="line">Cadena de texto a convertir</param>
        /// <returns>Enumerado con la dirección
        /// (Direction.None, si la cadena no representa ninguna dirección)</returns>
        private static Direction ReadDirection(string line)
        {
            if (line.ToLower() == "left")
            {
                return Direction.Left;
            }
            else if (line.ToLower() == "right")
            {
                return Direction.Right;
            }
            else
            {
                return Direction.None;
            }
        }
    }
}
