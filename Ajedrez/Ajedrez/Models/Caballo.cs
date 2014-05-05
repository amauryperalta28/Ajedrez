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
                Vector2 pos = new Vector2(posicionInicial.X + (80 * 2), posicionInicial.Y - 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                    
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                

            }

            if (estaDentroDelTablero(posicionInicial.X - (80 * 2), posicionInicial.Y - 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X - (80 * 2), posicionInicial.Y - 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                    //addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                

            }

            //Se insertan las posiciones inferiores horizontales validas
            if (estaDentroDelTablero(posicionInicial.X + (80 * 2), posicionInicial.Y + 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X + (80 * 2), posicionInicial.Y + 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                    //addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                

            }
            if (estaDentroDelTablero(posicionInicial.X - (80 * 2), posicionInicial.Y + 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X - (80 * 2), posicionInicial.Y + 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                    //addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                

            }

            //Se insertan las posiciones superiores verticales validas 
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y - (80 * 2)) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X + 80, posicionInicial.Y - (80 * 2));
                posicionesValidas[IndexValidmove] = pos;
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                   // addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                

            }

            if (estaDentroDelTablero(posicionInicial.X - 80, posicionInicial.Y - (80 * 2)) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X - 80, posicionInicial.Y - (80 * 2));
                posicionesValidas[IndexValidmove] = pos;
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                   // addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                
                                

            }

            //Se insertan las posiciones inferiores verticales validas 
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y + (80 * 2)) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X + 80, posicionInicial.Y + (80 * 2));
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {

                    //addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;


                }
                

            }

            if (estaDentroDelTablero(posicionInicial.X - 80, posicionInicial.Y + (80 * 2)) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X - 80, posicionInicial.Y + (80 * 2));
                // Se verifica si en la posicion hay un ficha de color distinto
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true))
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color)== false)
                {

                   // addJugadaMovimiento(pos);
                    addJugadaParaComerFicha(pos);
                    posicionesValidas[IndexValidmove] = pos;
                    IndexValidmove++;
                    

                }
                
                
               

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

        
    }
}
