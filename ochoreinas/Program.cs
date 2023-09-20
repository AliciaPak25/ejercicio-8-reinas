// tablero con todos los casilleros libres
int[][] tablero = new int[8][];

for (int i = 0; i < 8; i++)
{
    tablero[i] = new int[8];
    for (int j = 0; j < 8; j++)
    {
        tablero[i][j] = (int)casillero.libre;
    }
}

// boolean para verificar si se encuentra la solución
bool solucionEncontrada = Resolver8Reinas(tablero, 0);

if (!solucionEncontrada)
{
    Console.WriteLine("No se encontró una solución.");
}
    
void ImprimirTablero(int[][] tablero)
{
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            Console.Write(tablero[i][j] + " ");
        }
        Console.WriteLine();
    }
        Console.WriteLine();
}

// Función para verificar si un casillero del tablero es seguro para colocar una reina.
bool EsCasilleroSeguro(int[][] tablero, int fila, int columna)
{
   // horizontal hacia la izquierda
   for (int i = 0; i < columna; i++)
   {
       if (tablero[fila][i] == (int)casillero.ocupado)
       {
            return false;
       }
   }

   // diagonal hacia arriba izquierda
   for (int i = fila, j = columna; i >= 0 && j >= 0; i--, j--)
   {
       if (tablero[i][j] == (int)casillero.ocupado)
       {
            return false;
       }
   }

  // diagonal hacia abajo izquierda
   for (int i = fila, j = columna; i < 8 && j >= 0; i++, j--)
   {
       if (tablero[i][j] == (int)casillero.ocupado)
       {
            return false;
       }
   }

   return true;
 }

// Función principal
 bool Resolver8Reinas(int[][] tablero, int columna)
 {
   if (columna == 8)
   {
           ImprimirTablero(tablero);
           ImprimirPosicionesReinas(tablero);
           return true;
   }

   for (int i = 0; i < 8; i++)
   {
           if (EsCasilleroSeguro(tablero, i, columna))
           {
               tablero[i][columna] = (int)casillero.ocupado;
               if (Resolver8Reinas(tablero, columna + 1))
               {
                   return true;
               }
               tablero[i][columna] = (int)casillero.libre;
           }
   }

   return false;
 }
 void ImprimirPosicionesReinas(int[][] tablero)
 {
   Console.WriteLine("Posiciones de las reinas:");
   for (int i = 0; i < 8; i++)
   {
       for (int j = 0; j < 8; j++)
       {
           if (tablero[i][j] == (int)casillero.ocupado)
           {
              Console.WriteLine($"Reina en fila {i}, columna {j}");
           }
       }
   }
   Console.WriteLine();
 }

enum casillero
{
    libre = 0,
    ocupado = 1,
}