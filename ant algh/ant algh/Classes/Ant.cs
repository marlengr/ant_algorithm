using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace ant_algh.Classes
{
    public class Ant
    {
        public Thread AntThread;
        public Point Point;
        public List<Cell> AntCells = new List<Cell>();
        public List<Road> RoadsMemoryList;
        public bool Run;

        public Ant(Point point, List<Cell> CellList)
        {
            Point = point;
            AntThread = new Thread(StartAntThread);
            AntCells = new List<Cell>();
            RoadsMemoryList = new List<Road>();
            Run = false;

            for (int i = 0; i < CellList.Count; i++)
            {
                Cell cell = new Cell(CellList[i].Point, 0, CellList[i].cellPheromoneBack);
                AntCells.Add(cell);
            }
        }

        public void StartAntThread()
        {
            while (Run && World.Run)
            {
                MoveAnt();
                Thread.Sleep(100);
            }
        }

        private void MoveBack()
        {
            for (int i = RoadsMemoryList.Count - 1; i >= 0; i--)
            {
                Point = RoadsMemoryList[i].P1;
                Thread.Sleep(100);
            }
            for (int i = 0; i < RoadsMemoryList.Count; i++)
            {
                for (int ii = 0; ii < AntCells.Count; ii++)
                {
                    if (RoadsMemoryList[i].P2.Equals(AntCells[ii].Point))
                    {
                        World.CellPheromonBack(RoadsMemoryList[i].P2);
                    }
                    AntCells[ii].cellPheromoneUp = 0;
                }
            }
            World.CellPheromonBack(World.Cells[0].Point);
            AntCells[0].cellPheromoneUp++;
            RoadsMemoryList.Clear();
        }

        private void MoveAnt()
        {
            List<Road> tempRoad = new List<Road>();
            List<Cell> tempCell = new List<Cell>();

            tempRoad.Clear();
            tempCell.Clear();

            foreach (Road road in World.Roads) //dodawanie drog dostepnych dla mrowki z obecnej komorki
            {
                if (Point.Equals(road.P1))
                {
                    tempRoad.Add(new Road(Point, road.P2));
                }
            }
            //jesli jestes w punkcie "food" wróć 
            if (Point.Equals(AntCells[AntCells.Count - 1].Point))
            {
                MoveBack();
            }
            else
            {
                //pobieranie dostepnej komorki z dostepych drog
                for (int ii = tempRoad.Count; ii > 0; ii--)
                {
                    //porownuje wszystkie komorki z dostepnymi (komórkami) drogami, dla konkretnej mrowki 
                    for (int jj = AntCells.Count; jj > 0; jj--)
                    {
                        if (tempRoad[ii - 1].P2.Equals(AntCells[jj - 1].Point))
                        {
                            tempCell.Add(new Cell(AntCells[jj - 1].Point, AntCells[jj - 1].cellPheromoneUp, World.Cells[jj - 1].cellPheromoneBack));
                            //feromon up jest specyficzny dla kazdej mrowki, back jest z listy globalnej
                        }
                    }
                }
                //wyciagam z listy tempCell komorke z najmniejsza wartoscia cellPheromoneUp 
                //i najwieksza wartoscia cellPheromoneBack
                //jesli oba warunki spelniane sa przez wiecej niz 1 obiekt, droga zwracana randomowo

                int minUp = tempCell.Min(s => s.cellPheromoneUp);
                var minCellPheromonList1 = from Cell c in tempCell
                                           where (c.cellPheromoneUp == minUp)
                                           select c;
                int maxBack = minCellPheromonList1.Max(s => s.cellPheromoneBack);
                var minCellPheromonList2 = from Cell c in minCellPheromonList1
                                           where (c.cellPheromoneBack == maxBack)
                                           select c;
                //up najmn, back najw
                var minCellPheromon1 = minCellPheromonList2.ElementAt(World.RandomNumber(0, minCellPheromonList2.Count()));

                //poruszanie sie
                for (int ww = tempRoad.Count; ww > 0; ww--)
                {
                    if (Point.Equals(tempRoad[ww - 1].P1) && minCellPheromon1.Point.Equals(tempRoad[ww - 1].P2))
                    {
                        RoadsMemoryList.Add(tempRoad[ww - 1]);
                        Point = minCellPheromon1.Point;

                        for (int zz = AntCells.Count; zz > 0; zz--)
                        {
                            if (AntCells[zz - 1].Point.Equals(minCellPheromon1.Point))
                            {
                                AntCells[zz - 1].cellPheromoneUp++;
                            }
                        }
                    }
                }
            }
        }
    }
}
