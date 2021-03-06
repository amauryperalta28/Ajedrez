﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ajedrez.Models
{
   public class Alfil: Ficha
    {
       public Alfil(SpriteBatch spriteBatch, Colores colorFicha, Vector2 position, ContentManager Content)
        {
            posicion = position;            
            base._spriteBatch = spriteBatch;

            if (colorFicha.Equals(Colores.Black))
            {
                base.Color = Colores.Black;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/AlfilB");
            
            }
            else if (colorFicha.Equals(Colores.White))
            {
                base.Color = Colores.White;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/AlfilW");

            }
           
            base.Position = position;
                      
            
            
        }
        /** @brief Determina si la ficha se puede mover a una posicion indicada
        *          Se insertan las posiciones validas en la lista de posibles movidas
        * 
        * @param[in]   posicionInicial             Es la posicion actual de la ficha
        * @param[in]   PosicionFinal               Es la posicion a donde se pretende mover la ficha
        * @param[in]   listaFichas                 Esta es la lista de fichas que estan en el tablero
        * 
        * @return      1 si se puede mover, 0 de lo contrario.
        */
        public override int canMove(Vector2 posicionInicial, Vector2 PosicionFinal, List<Ficha> listaFichas)
        {

            removeJugadasMovimiento();
            //Variables en la que se insertan las posiciones validas para moverse
            List<Vector2> posicionesValidas1 = new List<Vector2>();
            
            int x, y;

            x = Convert.ToInt32(posicionInicial.X) + 80;
            y = Convert.ToInt32(posicionInicial.Y) - 80;

            
            // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero
            #region insercion de movimientos validos
            // Se insertan las posiciones diagonales superiores derechas validas
            #region Posiciones diagonales superiores derechas
            while (x <= 630 && y >= 20)
            {
                if (estaDentroDelTablero(x, y) == 1)
                {
                    Vector2 pos = new Vector2(x, y);
                    

                    // Se verifica si en la posicion hay un ficha de color distinto
                    if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                    {
                        addJugadaMovimiento(pos);
                        posicionesValidas1.Add(pos);
                    }
                    else if ( (estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                    {
                        
                        addJugadaParaComerFicha(pos);
                        break;
                    
                    }
                    else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false  )
                    {
                        break;

                    }

                }

                x += 80;
                y -= 80;

            }
            #endregion
            // Se insertan las posiciones diagonales superiores izquierdas validas
            x = Convert.ToInt32(posicionInicial.X) - 80;
            y = Convert.ToInt32(posicionInicial.Y) - 80;

            #region Posiciones diagonales superiores izquierdas
            while (x >= 70 && y >= 20)
            {
                if (estaDentroDelTablero(x, y) == 1)
                {
                    Vector2 pos = new Vector2(x, y);


                    // Se verifica si en la posicion hay un ficha de color distinto
                    if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                    {
                        addJugadaMovimiento(pos);
                        posicionesValidas1.Add(pos);
                    }
                    else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                    {

                        addJugadaParaComerFicha(pos);
                        break;

                    }
                    else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false  )
                    {
                        break;

                    }


                }

                x -= 80;
                y -= 80;

            }

            #endregion
            x = Convert.ToInt32(posicionInicial.X) + 80;
            y = Convert.ToInt32(posicionInicial.Y) + 80;

            #region posiciones diagonales inferiores derechas
            while (x <=630 && y <= 580)
            {
                Vector2 pos = new Vector2(x, y);


                // Se verifica si en la posicion hay un ficha de color distinto
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas1.Add(pos);
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                {

                    addJugadaParaComerFicha(pos);
                    break;

                }
                else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false  )
                {
                    break;

                }


                x += 80;
                y += 80;

            }
            #endregion
            // Se insertan las posiciones diagonales inferiores izquierdas validas
            x = Convert.ToInt32(posicionInicial.X) - 80;
            y = Convert.ToInt32(posicionInicial.Y) + 80;

            #region Posiciones diagonales inferiores izquierdas
            while (x >= 70 && y <= 580)
            {
                Vector2 pos = new Vector2(x, y);


                // Se verifica si en la posicion hay un ficha de color distinto
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas1.Add(pos);
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                {

                    addJugadaParaComerFicha(pos);
                    break;

                }
                else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false  )
                {
                    break;

                }


                x -= 80;
                y += 80;

            }
            #endregion

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

        

    }
}
