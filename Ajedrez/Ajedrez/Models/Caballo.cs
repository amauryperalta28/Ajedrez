using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Ajedrez.Models
{
   public  class Caballo: Ficha
    {
       public Caballo(SpriteBatch spriteBatch, Colores colorFicha, Vector2 position, ContentManager Content)
        {
            posicion = position;            
            base._spriteBatch = spriteBatch;

            if (colorFicha.Equals(Colores.Black))
            {
                base.Color = Colores.Black;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/CaballoB");
            
            }
            else if (colorFicha.Equals(Colores.White))
            {
                base.Color = Colores.White;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/CaballoW");

            }
           
            base.Position = position;
                      
            
            
        }
        /** @brief Determina si la ficha se puede mover a una posicion indicada
        * 
        * @param[in]   posicionInicial             Es la posicion actual de la ficha
        * @param[in]   PosicionFinal               Es la posicion a donde se pretende mover la ficha
        * 
        * @return      1 si se puede mover, 0 de lo contrario.
        */
       public override int canMove(Vector2 posicionInicial, Vector2 PosicionFinal, List<Ficha> listaFichas)
        {
            //Variables en la que se insertan las posiciones validas para moverse
            Vector2[] posicionesValidas = new Vector2[9];
            int IndexValidmove = 0;

            // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero
            // Se insertan las posiciones superiores horizontales validas
            if (estaDentroDelTablero(posicionInicial.X + (80*2), posicionInicial.Y - 80) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X + (80*2);
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y - 80;
                IndexValidmove++;

            }

            if (estaDentroDelTablero(posicionInicial.X - (80 * 2), posicionInicial.Y - 80) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X - (80 * 2);
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y - 80;
                IndexValidmove++;

            }

            //Se insertan las posiciones inferiores horizontales validas
            if (estaDentroDelTablero(posicionInicial.X + (80 * 2), posicionInicial.Y + 80) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X + (80 * 2);
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y + 80;
                IndexValidmove++;

            }
            if (estaDentroDelTablero(posicionInicial.X - (80 * 2), posicionInicial.Y + 80) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X - (80 * 2);
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y + 80;
                IndexValidmove++;

            }

            //Se insertan las posiciones superiores verticales validas 
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y - (80 * 2)) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X + 80;
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y - (80 * 2);
                IndexValidmove++;

            }

            if (estaDentroDelTablero(posicionInicial.X - 80, posicionInicial.Y - (80 * 2)) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X - 80;
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y - (80 * 2);
                IndexValidmove++;

            }

            //Se insertan las posiciones inferiores verticales validas 
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y + (80 * 2)) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X + 80;
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y + (80 * 2);
                IndexValidmove++;

            }

            if (estaDentroDelTablero(posicionInicial.X - 80, posicionInicial.Y + (80 * 2)) == 1)
            {
                posicionesValidas[IndexValidmove].X = posicionInicial.X - 80;
                posicionesValidas[IndexValidmove].Y = posicionInicial.Y + (80 * 2);
                IndexValidmove++;

            }


            // Se verifica si la posicion a evaluar esta dentro de las posiciones validas
            for (int i = 0; i < posicionesValidas.Length; i++)
            {
                if (PosicionFinal.X == posicionesValidas[i].X && PosicionFinal.Y == posicionesValidas[i].Y)
                {
                    return 1;
                }

            }
            return 0;


        }

        /** @brief Determina si la ficha puede capturar otra ficha
         *         Se insertan las posiciones validas para capturar 
         *         en la lista de posiblesMovidascomer
         *  @param[in]   FichasTablero       Esta es la lista de ficha del tablero
         *  
         *  @return      1 si puede capturar, 0 de lo contrario
         */
        public override bool canEat(List<Ficha> FichasTablero)
        {
            return true;
        }
    }
}
