using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectBenner
{
    public class Rede
    {
        private List<(int, int)> ConnectionsForRemoving {  get; set; }

        private int quantityElements;
        private List<(int, int)> Connections = new List<(int, int)>();
        int ElementConnection = -1;

        public Rede(int numberElements)
        {
            try
            {
                if (numberElements < 0)
                {
                    throw new Exception("'elementsNumbers' não válido por não ser inteiro");
                }

                numberElements = quantityElements;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Connect(int numberOne, int numberTwo)
        {
            try
            {
                Connections.Add((numberTwo, numberOne));
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception when connecting (Excep: {ex.ToString()})");
            }
        }


        /// <summary>
        /// Método usado para consultar se dois números estão conectados.
        /// </summary>
        /// <param name="connectionOne"></param>
        /// <param name="connectionTwo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Query(int connectionOne, int connectionTwo)
        {
            try
            {
                if(Connections.Contains((connectionOne, connectionTwo))) //Caso ja estejam conectados.
                {
                    return true;
                }

                foreach (var connOne in Connections)
                {
                    if ((connOne.Item1 == connectionOne || connOne.Item2 == connectionOne)
                        || (connOne.Item1 == connectionTwo || connOne.Item2 == connectionTwo))
                    {
                        int key1 = connOne.Item1;
                        int key2 = connOne.Item2;

                        if(key1 == connectionOne || key2 == connectionOne)
                        {
                            ElementConnection = connectionTwo;
                        }
                        else
                        {
                            ElementConnection = connectionOne;
                        }

                        ConnectionsForRemoving = Connections.ToList();
                        ConnectionsForRemoving.Remove(connOne);

                        foreach (var connTwo in ConnectionsForRemoving)
                        {
                            if (key1 == connTwo.Item1 || key1 == connTwo.Item2)
                            {
                                if (Search(key1))
                                {
                                    return true;
                                }
                            }

                            if (key2 == connTwo.Item1 || key2 == connTwo.Item2)
                            {
                                if (Search(key2))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception when querying (Excep: {ex.ToString()})");
            }

            return false;
        }

        /// <summary>
        /// Metódo usado para 'procurar' o elemento em todos as Conexões.
        /// </summary>
        /// <param name="number"></param>
        private bool Search(int number)
        {
            foreach (var connOne in ConnectionsForRemoving)
            {
                if (number == connOne.Item1 || number == connOne.Item2)
                {
                    if (ElementConnection == connOne.Item1 || ElementConnection == connOne.Item2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
