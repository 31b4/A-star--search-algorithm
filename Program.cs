using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyors_utazás
{
    class Program
    {
        public struct Pont
        {
            public int x, y;
            public int  osX;
            public int  osY;
        }//end
        public static List<Pont> nyitott = new List<Pont>();//ebbe rakjuk a VIZSGÁLANDÓ elemeket
        public static List<Pont> zart = new List<Pont>();//ebbe rakjuk a MEGVIZSGÁLT elemeket
        public static Pont aktualis;
        public static Pont vizsgal;

        static bool Check()
        {
           
            for (int i = 0; i < nyitott.Count; i++)
            {
                if (nyitott[i].x == vizsgal.x && nyitott[i].y == vizsgal.y)
                {
                    return true;
                }
                
            }
            for (int i = 0; i < zart.Count; i++)
            {
                if (zart[i].x == vizsgal.x && zart[i].y == vizsgal.y)
                {
                    return true;
                }
            }

            return false;
        }
        static void Main(string[] args)
        {
            //Mátrix létrehozása: 
            int[,] tabla = new int[10,10];
            //0 szabad utat, 1 akadályt
            Random r = new Random();
            for (int sor = 0; sor < 10; sor++){//külső ciklus
                for (int oszlop = 0; oszlop < 10; oszlop++){//belső ciklus
                    
                    if (r.Next(1,101)<=70){
                        tabla[sor, oszlop] = 0;
                    }//endif
                    else{
                        tabla[sor, oszlop] = 1;
                    }//endelse
                }
            }
            tabla[0,0] = 0;//start
            tabla[9, 9] = 0;//end
            
            for (int i = 0; i < 10; i++){//külső ciklus
                for (int j = 0; j < 10; j++){//belső ciklus
                    if ((i==0 && j==0)||(i==9 && j==9))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(tabla[i,j] + " ");//start,end
                        Console.ResetColor();
                    }
                    else if (tabla[i,j]==1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(tabla[i, j] + " ");//akadály
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(tabla[i,j]+" ");
                    }
                }
                Console.WriteLine();
            }
            
            
            aktualis.x=0;
            aktualis.y=0;
            aktualis.osX = -1;
            aktualis.osY = -1;
            nyitott.Add(aktualis);

            //vége: 9,9

            /*
                ciklus amíg(NEM (elérte a célt:9,9) és nem (üres a nyitottak tömb))
                    aktuális= a nyitottak első eleme (-van a célhoz)
                    
                    Végignézzük mind a 8 esetet és csak akkor rakjuk bele a nyitottak tömbe, ha
                        - nem akadály (nem 1)
                        - nincs benne a zártba (eldöntés tétele)
                        - nics benne a nyitottban (eldöntés tétele)

                    a zárt tömbe belerakjuk az aktuális elemet
                    a nyitottak tömből töröljuk az aktuális elemet
                    //nyitott.ToList().RemoveAt(index);
            */
            while (!(aktualis.x==9&&aktualis.y==9)&&nyitott.Count!=0)
            {
                
                aktualis = nyitott[0];
                vizsgal.osX = aktualis.x;
                vizsgal.osY = aktualis.y;
                if (aktualis.x+1>=0&&aktualis.x+1<=9&& aktualis.y >= 0 && aktualis.y <= 9 && tabla[aktualis.x+1, aktualis.y] == 0)
                {
                    
                    vizsgal.x = aktualis.x+1;
                    vizsgal.y = aktualis.y;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                        
                        
                    }
                }
                if (aktualis.x >= 0 && aktualis.x <= 9 && aktualis.y+1 >= 0 && aktualis.y+1 <= 9 && tabla[aktualis.x, aktualis.y + 1] == 0)
                {
                    vizsgal.y = aktualis.y+1;
                    vizsgal.x = aktualis.x;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                         
                    }
                }
                if (aktualis.x-1 >= 0 && aktualis.x-1 <= 9 && aktualis.y >= 0 && aktualis.y <= 9 && tabla[aktualis.x-1, aktualis.y ] == 0)
                {
                    vizsgal.x = aktualis.x-1;
                    vizsgal.y = aktualis.y;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                    
                    }
                }
                if (aktualis.x >= 0 && aktualis.x <= 9 && aktualis.y-1 >= 0 && aktualis.y-1 <= 9 && tabla[aktualis.x, aktualis.y - 1] == 0)
                {
                    vizsgal.y = aktualis.y-1;
                    vizsgal.x = aktualis.x;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                    
                    }
                }
                if (aktualis.x+1 >= 0 && aktualis.x+1 <= 9 && aktualis.y+1 >= 0 && aktualis.y+1 <= 9 && tabla[aktualis.x+1,aktualis.y+1] ==0)
                {
                    vizsgal.x = aktualis.x+1;
                    vizsgal.y = aktualis.y+1;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                     
                    }
                }
                if (aktualis.x-1 >= 0 && aktualis.x-1 <= 9 && aktualis.y-1 >= 0 && aktualis.y-1 <= 9 && tabla[aktualis.x-1,aktualis.y-1] ==0)
                {
                    vizsgal.x = aktualis.x-1;
                    vizsgal.y = aktualis.y-1;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                   
                    }
                }
                if (aktualis.x-1 >= 0 && aktualis.x-1 <= 9 && aktualis.y+1 >= 0 && aktualis.y+1 <= 9 && tabla[aktualis.x-1,aktualis.y+1] ==0)
                {
                    vizsgal.x = aktualis.x-1;
                    vizsgal.y = aktualis.y+1;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                   
                    }
                }
                if (aktualis.x+1 >= 0 && aktualis.x+1 <= 9 && aktualis.y-1 >= 0 && aktualis.y-1 <= 9 && tabla[aktualis.x+1,aktualis.y-1] ==0)
                {
                    vizsgal.x = aktualis.x+1;
                    vizsgal.y = aktualis.y-1;
                    if (Check()==false)
                    {
                        nyitott.Add(vizsgal);
                    }
                }
                zart.Add(aktualis);
                //Console.WriteLine("ok");
                nyitott.RemoveAt(0);
            }//zart lista feltöltése
            List<Pont> ut = new List<Pont>();
            Pont aktualisOs=aktualis;
            aktualisOs.x = zart[zart.Count-1].x;
            aktualisOs.y = zart[zart.Count - 1].y;
            
            while (!(aktualisOs.x == -1 && aktualisOs.y == -1))
            {
                
                for (int i = 0; i < zart.Count; i++)
                {
                    if (zart[i].x==aktualisOs.x && zart[i].y==aktualisOs.y)
                    {
                        ut.Add(aktualisOs);
                        
                        aktualisOs.x = zart[i].osX;
                        aktualisOs.y = zart[i].osY;
                        break;
                    }
                }
            }
           
            Console.WriteLine("megoldas?!\n");
            Console.WriteLine(ut.Count);
            /*for (int i = 0; i < ut.Count; i++)
            {
                Console.WriteLine(ut[i].x+" "+ut[i].y);
            }*/

            bool szerepel = false;
            for (int i = 0; i < 10; i++)
            {//külső ciklus
                for (int j = 0; j < 10; j++)
                {//belső ciklus
                    szerepel = false;
                    for (int k = 0; k < ut.Count; k++)
                    {
                        if (ut[k].x==i&&ut[k].y==j)
                        {
                            szerepel = true;
                        }
                    }
                    if ((i == 0 && j == 0) || (i == 9 && j == 9))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(tabla[i, j] + " ");//start,end
                        Console.ResetColor();
                    }
                    else if (tabla[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(tabla[i, j] + " ");//akadály
                        Console.ResetColor();
                    }
                    else if (szerepel)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(tabla[i, j] + " ");//start,end
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(tabla[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }//endMain
    }
}
