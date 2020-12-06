using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CollectionGameLibrary
{
    public class GameboardClass
    {

        public List<Tile> Grid = new List<Tile>();
        public int Score;

        public GameboardClass()
        {
            /*Grid.Add(new Tile(3,3,4));
            Grid.Add(new Tile(3, 1, 2));
            Grid.Add(new Tile(1,1,2));*/

        }

        public Tile GetTileAtPos(int x, int y)
        {
            foreach (Tile tile in Grid)
            {
                if (tile.x == x & tile.y == y)
                {
                    return tile;
                }

            }

            return new Tile(x, y, 0);
        }

        public void MoveUp()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GetTileAtPos(j, i).value != 0)
                    {
                        int newY = i;

                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (GetTileAtPos(j, k).value == 0)
                            {
                                newY = k;
                            }

                            else if (GetTileAtPos(j, k).value == GetTileAtPos(j, i).value)
                            {
                                newY = k;
                                GetTileAtPos(j, i).value *= 2;
                                Grid.Remove(GetTileAtPos(j, k));
                            }
                        }

                        GetTileAtPos(j, i).y = newY;
                    }
                }
            }
        }

        public void MoveDown()
        {
            for (int i = 2; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GetTileAtPos(j, i).value != 0)
                    {
                        int newY = i;

                        for (int k = i + 1; k < 4; k++)
                        {
                            if (GetTileAtPos(j, k).value == 0)
                            {
                                newY = k;
                            }

                            else if (GetTileAtPos(j, k).value == GetTileAtPos(j, i).value)
                            {
                                newY = k;
                                GetTileAtPos(j, i).value *= 2;
                                Grid.Remove(GetTileAtPos(j, k));
                            }
                        }

                        GetTileAtPos(j, i).y = newY;
                    }
                }
            }
        }

        public void MoveLeft()
        {
            for (int j = 1; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (GetTileAtPos(j, i).value != 0)
                    {
                        int newX = j;

                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (GetTileAtPos(k, i).value == 0)
                            {
                                newX = k;
                            }

                            else if (GetTileAtPos(k, i).value == GetTileAtPos(j, i).value)
                            {
                                newX = k;
                                GetTileAtPos(j, i).value *= 2;
                                Grid.Remove(GetTileAtPos(k, i));
                            }
                        }

                        GetTileAtPos(j, i).x = newX;
                    }
                }
            }
        }

        public void MoveRight()
        {
            for (int j = 2; j >= 0; j--)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (GetTileAtPos(j, i).value != 0)
                    {
                        int newX = j;

                        for (int k = j + 1; k < 4; k++)
                        {
                            if (GetTileAtPos(k, i).value == 0)
                            {
                                newX = k;
                            }

                            else if (GetTileAtPos(k, i).value == GetTileAtPos(j, i).value)
                            {
                                newX = k;
                                GetTileAtPos(j, i).value *= 2;
                                Grid.Remove(GetTileAtPos(k, i));
                            }
                        }

                        GetTileAtPos(j, i).x = newX;
                    }
                }
            }
        }

        public void DisplayGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(GetTileAtPos(j, i).value);
                }

                Console.WriteLine();
            }
        }

        public void AddRandomToBoard()
        {
            bool placed = false;

            if (Grid.Count != 16)
            {
                while (!placed)
                {

                    Random rand = new Random();
                    int x = rand.Next(4);
                    int y = rand.Next(4);
                    int value = rand.Next(1, 3) * 2;

                    if (GetTileAtPos(x, y).value == 0)
                    {
                        Grid.Add(new Tile(x, y, value));
                        placed = true;
                    }

                }
            }

        }

        public bool CheckGameOver()
        {
            if (Grid.Count != 16)
            {
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GetTileAtPos(j+1, i).value == GetTileAtPos(j,i).value)
                    {
                        return false;
                    }
                    if (GetTileAtPos(j, i+1).value == GetTileAtPos(j, i).value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
