using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ajedrez.Models
{
    public class Torre: Ficha
    {
         public Torre(SpriteBatch spriteBatch, Colores colorFicha, Vector2 position, ContentManager Content)
        {
            posicion = position;            
            base._spriteBatch = spriteBatch;

            if (colorFicha.Equals(Colores.Black))
            {
                base.Color = Colores.Black;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/TorreB");
            
            }
            else if (colorFicha.Equals(Colores.White))
            {
                base.Color = Colores.White;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/TorreW");

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
            List<Vector2> posicionesValidas1 = new List<Vector2>();
            ;

            #region Posiciones Horizontales
            // Se insertan todas las posiciones horizontales en las que se puede jugar
            for (int x = Convert.ToInt32(posicionInicial.X); x <= 630; x = x + 80)
            {
                // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

                if (estaDentroDelTablero(x, posicionInicial.Y) == 1 && posicionInicial.X != x)
                {
                   
                    Vector2 pos = new Vector2(x, posicionInicial.Y);
                    // Se verifica si en la posicion hay una ficha
                    if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                    {
                        addJugadaMovimiento(pos);
                        posicionesValidas1.Add(pos);
                    }
                    ///Si hay una ficha en la casilla de color diferente, insertalo en las posiciones para capturar fichas
                    else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                    {
                                             
                        addJugadaParaComerFicha(pos);
                        break;

                    }
                    else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false && estatusCasilla(pos, listaFichas).colorDeLaFicha == Color)
                    {
                        break;

                    }
                   
                }

            }

            for (int x = Convert.ToInt32(posicionInicial.X); x >= 70; x = x - 80)
            {
                // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

                if (estaDentroDelTablero(x, posicionInicial.Y) == 1 && posicionInicial.X != x)
                {

                    Vector2 pos = new Vector2(x, posicionInicial.Y);
                    // Se verifica si en la posicion hay una ficha
                    if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                    {
                        addJugadaMovimiento(pos);
                        posicionesValidas1.Add(pos);
                    }
                    ///Si hay una ficha en la casilla de color diferente, insertalo en las posiciones para capturar fichas
                    else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                    {

                        addJugadaParaComerFicha(pos);
                        break;

                    }
                    else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false && estatusCasilla(pos, listaFichas).colorDeLaFicha == Color)
                    {
                        break;

                    }

                }

            }
            #endregion
            // Se insertan todas las posiciones verticales en las que se puede jugar
            #region Posiciones Verticales

            for (int y = Convert.ToInt32(posicionInicial.Y); y >= 20; y = y - 80)
            {
                // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

                if (estaDentroDelTablero(posicionInicial.X, y) == 1 && posicionInicial.Y != y)
                {

                    Vector2 pos = new Vector2(posicionInicial.X, y);
                    // Se verifica si en la posicion hay un ficha de color distinto
                    if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                    {
                        addJugadaMovimiento(pos);
                        posicionesValidas1.Add(pos);
                    }
                    ///Si hay una ficha en la casilla de color diferente, insertalo en las posiciones para capturar fichas
                    else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                    {

                        addJugadaParaComerFicha(pos);
                        break;

                    }
                    else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false && estatusCasilla(pos, listaFichas).colorDeLaFicha == Color)
                    {
                        break;

                    }

                }

            }

            for (int y = Convert.ToInt32(posicionInicial.Y); y <= 580; y = y + 80)
            {
                // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero
                
                if (estaDentroDelTablero(posicionInicial.X, y) == 1 &&  posicionInicial.Y != y)
                {
                   
                    Vector2 pos = new Vector2(posicionInicial.X, y);
                    // Se verifica si en la posicion hay un ficha de color distinto
                    if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                    {
                        addJugadaMovimiento(pos);
                        posicionesValidas1.Add(pos);
                    }
                    ///Si hay una ficha en la casilla de color diferente, insertalo en las posiciones para capturar fichas
                    else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                    {

                        addJugadaParaComerFicha(pos);
                        break;

                    }
                    else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false && estatusCasilla(pos, listaFichas).colorDeLaFicha == Color)
                    {
                        break;

                    }

                }

            }

            #endregion
            // Se verifica si la posicion a evaluar esta dentro de las posiciones validas
            for (int i = 0; i < posicionesValidas1.Count; i++)
            {
                Vector2 posicionAEvaluar = posicionesValidas1.ElementAt(i);
                if (PosicionFinal.X == posicionAEvaluar.X && PosicionFinal.Y == posicionAEvaluar.Y)
                {
                    return 1;
                }

            }
            return 0;


        }

         /* @brief Mueve a la torre de forma que realice el enroque corto
         * 
         * @return       no retorna nada
         * 
         */
         public void hazEnroqueCorto()
         {
             Vector2 nuevaPosicion = new Vector2(posicion.X - 160, posicion.Y);

             base.Position = nuevaPosicion;


         }
         /* @brief Mueve a la torre de forma que realice el enroque largo
         * 
         * @return       no retorna nada
         * 
         */
         public void hazEnroqueLargo()
         {
             Vector2 nuevaPosicion = new Vector2(posicion.X - 160, posicion.Y);

             base.Position = nuevaPosicion;


         }

        
    }
}
