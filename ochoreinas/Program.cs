/* int l = (int)casillero.ocupado;
Console.WriteLine("conteo de ConstarHasta():" + ContarHasta(9));
// array
int[] arrayInt = new int[6];
// jagged array
int[][] jaggedInt = new int[8][];

jaggedInt[0] = new int[5];
jaggedInt[1] = new int[8];

// hacerlo con un for

 foreach(var arr in jaggedInt) {
arr = new int[5];
}

// funcion recursiva
int ContarHasta(int a, int contador = 0)
{
    Console.WriteLine("contador: " + contador + " a: " + a);
    if (a == 0) return contador;
    a--;
    contador++;
    return ContarHasta(a, contador);
}


enum casillero
{
    libre = 0,
    ocupado = 1,
    marcado = 2
}
*/

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
        for (int i = 0; i < columna; i++)
        {
            if (tablero[fila][i] == (int)casillero.ocupado)
            {
                return false;
            }
        }

        for (int i = fila, j = columna; i >= 0 && j >= 0; i--, j--)
        {
            if (tablero[i][j] == (int)casillero.ocupado)
            {
                return false;
            }
        }

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
    marcado = 2
}