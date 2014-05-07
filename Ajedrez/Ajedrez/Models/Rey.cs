using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ajedrez.Models
{
   public class Rey:Ficha
    {
       public Rey(SpriteBatch spriteBatch, Colores colorFicha, Vector2 position, ContentManager Content)
        {
            posicion = position;            
            base._spriteBatch = spriteBatch;

            if (colorFicha.Equals(Colores.Black))
            {
                base.Color = Colores.Black;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/ReyB");
            
            }
            else if (colorFicha.Equals(Colores.White))
            {
                base.Color = Colores.White;
                base.Texture = Content.Load<Texture2D>(@"Images/Fichas/ReyW");

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
            Vector2[] posicionesValidas = new Vector2[10];
            int IndexValidmove = 0;

            # region insercion de movimientos validos
            // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero
            // Se insertan las posiciones verticales validas
            #region posicionesVerticales
            if (estaDentroDelTablero(posicionInicial.X, posicionInicial.Y - 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X, posicionInicial.Y - 80);
                
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos,listaFichas)== false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false)  && inJaque(pos,listaFichas)== false &&
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                }

            }
            if (estaDentroDelTablero(posicionInicial.X, posicionInicial.Y + 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X, posicionInicial.Y + 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true ) && inJaque(pos,listaFichas)== false )
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                }

            }
            #endregion
            // Se insertan las posiciones horizontales validas
            #region Posiciones Horizontales
            if (estaDentroDelTablero(posicionInicial.X-80, posicionInicial.Y) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X-80, posicionInicial.Y);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos, listaFichas) == false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                }

            }
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X+80, posicionInicial.Y);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos, listaFichas) == false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                }

            }
            #endregion
            // Se insertan las posiciones diagonales superiores validas
            # region Posiciones diagonales superiores
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y - 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X+80, posicionInicial.Y - 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos, listaFichas) == false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                    
                }

            }
            if (estaDentroDelTablero(posicionInicial.X - 80, posicionInicial.Y - 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X-80, posicionInicial.Y - 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos, listaFichas) == false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);

                }

            }
            #endregion
            // Se insertan las posiciones diagonales inferiores validas
            #region Posiciones diagonales inferiores
            if (estaDentroDelTablero(posicionInicial.X + 80, posicionInicial.Y + 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X+80, posicionInicial.Y + 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos, listaFichas) == false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                   
                }

            }
            if (estaDentroDelTablero(posicionInicial.X - 80, posicionInicial.Y + 80) == 1)
            {
                Vector2 pos = new Vector2(posicionInicial.X-80, posicionInicial.Y + 80);
                if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == true) && inJaque(pos, listaFichas) == false)
                {
                    addJugadaMovimiento(pos);
                    posicionesValidas[IndexValidmove] = pos;

                    IndexValidmove++;
                }
                else if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && inJaque(pos, listaFichas) == false && 
                    estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                {
                    addJugadaParaComerFicha(pos);
                }

            }
            #endregion
            #endregion


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

       /* @brief Determina si el Rey puede hacer enroque Corto
        * 
        * @param[in]   listaFichas                 Estas son las fichas que estan en el tablero
        * 
        * @return       true si puede hacer enroque corto, false de lo contrario
        */
       public bool PuedeHaceEnroqueCorto(List<Ficha> listaFichas)
       {
           // Se verifica el color de la ficha para saber que accion ejecutar

           if (Color.Equals(Colores.White))
           {
               Vector2 posOrigen = new Vector2(390,580);
               Vector2 posPrueba1 = new Vector2(470,580);
               Vector2 posPrueba2 = new Vector2(550,580);
               /* Se verifica si el rey esta en su posicion de origen y si las casillas
                que estan entre el rey y la torre estan vacias*/
               if (posicion.Equals(posOrigen) && SeMovio==false && estatusCasilla(posPrueba1, listaFichas).NohayUnaFicha &&
                   estatusCasilla(posPrueba2, listaFichas).NohayUnaFicha)
               {
                   return true;
               }
               else
               {
                   return false;
               }

           }
               // Si verifica si el rey es de color negro
           else 
           {
               Vector2 posOrigen = new Vector2(390, 20);
               Vector2 posPrueba1 = new Vector2(470, 20);
               Vector2 posPrueba2 = new Vector2(550, 20);
               /* Se verifica si el rey esta en su posicion de origen y si las casillas
                que estan entre el rey y la torre estan vacias*/
               if (posicion.Equals(posOrigen) && SeMovio == false && estatusCasilla(posPrueba1, listaFichas).NohayUnaFicha &&
                   estatusCasilla(posPrueba1, listaFichas).NohayUnaFicha)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           
           }

          
        
       }

       /* @brief Mueve al Rey de forma que realice el enroque corto
        * 
        * @return       no retorna nada
        * 
        */
       public void hazEnroqueCorto()
       {
           Vector2 nuevaPosicion = new Vector2(posicion.X+ 160, posicion.Y);

          base.Position = nuevaPosicion;
         
       
       }

       /* @brief Determina si el Rey puede hacer enroque Largo
       * 
       * @param[in]   listaFichas                 Estas son las fichas que estan en el tablero
       * 
       * @return       true si puede hacer enroque Largo, false de lo contrario
       */
       public bool PuedeHaceEnroqueLargo(List<Ficha> listaFichas)
       {
           // Se verifica el color de la ficha para saber que accion ejecutar

           if (Color.Equals(Colores.White))
           {
               Vector2 posOrigen = new Vector2(390, 580);
               Vector2 posPrueba1 = new Vector2(310, 580);
               Vector2 posPrueba2 = new Vector2(230, 580);
               Vector2 posPrueba3 = new Vector2(150, 580);
               /* Se verifica si el rey esta en su posicion de origen y si las casillas
                que estan entre el rey y la torre estan vacias*/
               if (posicion.Equals(posOrigen) && SeMovio == false && estatusCasilla(posPrueba1, listaFichas).NohayUnaFicha &&
                   estatusCasilla(posPrueba2, listaFichas).NohayUnaFicha && estatusCasilla(posPrueba3, listaFichas).NohayUnaFicha)  
               {
                   return true;
               }
               else
               {
                   return false;
               }

           }
           // Si verifica si el rey es de color negro
           else 
           {
               Vector2 posOrigen = new Vector2(390, 20);
               Vector2 posPrueba1 = new Vector2(470, 20);
               Vector2 posPrueba2 = new Vector2(550, 20);
               Vector2 posPrueba3 = new Vector2(150, 20);
               /* Se verifica si el rey esta en su posicion de origen y si las casillas
                que estan entre el rey y la torre estan vacias*/
               if (posicion.Equals(posOrigen) && SeMovio == false && estatusCasilla(posPrueba1, listaFichas).NohayUnaFicha &&
                   estatusCasilla(posPrueba2, listaFichas).NohayUnaFicha && estatusCasilla(posPrueba3, listaFichas).NohayUnaFicha)
               {
                   return true;
               }
               else
               {
                   return false;
               }

           }

       }

       /* @brief Mueve al Rey de forma que realice el enroque largo
        * 
        * @return       no retorna nada
        * 
        */
       public void hazEnroqueLargo()
       {
           Vector2 nuevaPosicion = new Vector2(posicion.X -160, posicion.Y);

           base.Position = nuevaPosicion;


       }

       /* @brief Determina si el Rey esta en jaque
        * 
        * @param[in]  posicionAEvaluar          Es la que posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si esta en jaque, false de lo contrario
        * 
        */
       public bool inJaque(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       {
           if(peligroPorPeon(posicionAEvaluar,listaFichas) || peligroPorCaballo(posicionAEvaluar,listaFichas) ||
              peligroConDiagonales(posicionAEvaluar,listaFichas) ||
              peligroConVerticalesYHorizontales(posicionAEvaluar, listaFichas) ||
              peligroPorRey(posicionAEvaluar, listaFichas))
           {
               bool p1 = peligroPorPeon(posicionAEvaluar, listaFichas);
               bool p2 = peligroPorCaballo(posicionAEvaluar, listaFichas);
               bool p3 = peligroConDiagonales(posicionAEvaluar, listaFichas);
               bool p4 = peligroConVerticalesYHorizontales(posicionAEvaluar, listaFichas);
               bool p5 = peligroPorRey(posicionAEvaluar, listaFichas);
               
               return true;

           }

           return false;
       
       }

       /* @brief Determina si el Rey puede ser capturado por un caballo
        * 
        * @param[in]  posicionAEvaluar          Es la posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si puede ser capturado, false de lo contrario
        */
       public bool peligroPorCaballo(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       {
           if (estaDentroDelTablero(posicionAEvaluar.X + (80 * 2), posicionAEvaluar.Y - 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + (80 * 2), posicionAEvaluar.Y - 80);
               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;

               }

           }

           if (estaDentroDelTablero(posicionAEvaluar.X - (80 * 2), posicionAEvaluar.Y - 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - (80 * 2), posicionAEvaluar.Y - 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;
               }

           }

           if (estaDentroDelTablero(posicionAEvaluar.X + (80 * 2), posicionAEvaluar.Y + 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + (80 * 2), posicionAEvaluar.Y + 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {

                   return true;


               }


           }

           if (estaDentroDelTablero(posicionAEvaluar.X - (80 * 2), posicionAEvaluar.Y + 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - (80 * 2), posicionAEvaluar.Y + 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {

                   return true;


               }


           }

           if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y - (80 * 2)) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y - (80 * 2));

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;
               }


           }

           if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y - (80 * 2)) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y - (80 * 2));

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {

                   return true;
               }

           }

           //Se insertan las posiciones inferiores verticales validas 
           if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y + (80 * 2)) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y + (80 * 2));

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {

                   return true;
               }

           }

           if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y + (80 * 2)) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y + (80 * 2));
               // Se verifica si en la posicion hay un ficha de color distinto

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Caballo") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {

                   return true;
               }

           }

           return false;

       }

       /* @brief Determina si el Rey puede ser capturado por un peon
        * 
        * @param[in]  posicionAEvaluar          Es la posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si puede ser capturado, false de lo contrario
        */
       public bool peligroPorPeon(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       {
           if (Color.Equals(Colores.White))
           {
               if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y - 80) == 1)
               {
                   Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y - 80);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Peon") &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                   {
                       return true;

                   }

               }
               if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y - 80) == 1)
               {
                   Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y - 80);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Peon") &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                   {
                       return true;

                   }

               }
           }

           else
           {
               if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y + 80) == 1)
               {
                   Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y + 80);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Peon") &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                   {

                       return true;

                   }

               }
               if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y + 80) == 1)
               {
                   Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y + 80);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Peon") &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
                   {

                       return true;

                   }

               }

           }

           return false;
       }

       /* @brief Determina si el Rey puede ser capturado por el otro Rey
        * 
        * @param[in]  posicionAEvaluar          Es la posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si puede ser capturado, false de lo contrario
        */
       public bool peligroPorRey(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       {
           #region Verificacion posiciones Verticales
           if (estaDentroDelTablero(posicionAEvaluar.X, posicionAEvaluar.Y - 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X, posicionAEvaluar.Y - 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color)== false)
               {
                   return true;

               }

           }
           if (estaDentroDelTablero(posicionAEvaluar.X, posicionAEvaluar.Y + 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X, posicionAEvaluar.Y + 80);
               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;
               }

           }
           #endregion

           #region Verificacion posiciones horizontales
           if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;

               }

           }
           if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false
                   )
               {

                   return true;

               }

           }
           #endregion

           # region Verificacion Posiciones diagonales superiores
           if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y - 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y - 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {

                   return true;
               }

           }
           if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y - 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y - 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;
               }

           }
           #endregion

           #region Verificacion Posiciones diagonales inferiores
           if (estaDentroDelTablero(posicionAEvaluar.X + 80, posicionAEvaluar.Y + 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X + 80, posicionAEvaluar.Y + 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;

               }

           }
           if (estaDentroDelTablero(posicionAEvaluar.X - 80, posicionAEvaluar.Y + 80) == 1)
           {
               Vector2 pos = new Vector2(posicionAEvaluar.X - 80, posicionAEvaluar.Y + 80);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && estatusCasilla(pos, listaFichas).tipo.Equals("Rey") &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha.Equals(Color) == false)
               {
                   return true;

               }

           }
           #endregion



           return false;

       }

       /* @brief Determina si el Rey puede ser capturado por una torre
        * 
        * @param[in]  posicionAEvaluar          Es la posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si puede ser capturado, false de lo contrario
        */
       public bool peligroConVerticalesYHorizontales(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       {
           #region Posiciones Horizontales
           // Se insertan todas las posiciones horizontales en las que se puede jugar
           for (int x = Convert.ToInt32(posicionAEvaluar.X); x <= 630; x = x + 80)
           {
               // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

               if (estaDentroDelTablero(x, posicionAEvaluar.Y) == 1 && posicionAEvaluar.X != x)
               {

                   Vector2 pos = new Vector2(x, posicionAEvaluar.Y);
                   // Se verifica si en la posicion hay una ficha
                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                       (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") || 
                       estatusCasilla(pos, listaFichas).tipo.Equals("Torre") )&&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                   {

                       return true;


                   }
                   else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false)
                   {
                       //return false;
                       break;

                   }

               }

               
           }

           for (int x = Convert.ToInt32(posicionAEvaluar.X); x >= 70; x = x - 80)
           {
               // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

               if (estaDentroDelTablero(x, posicionAEvaluar.Y) == 1 && posicionAEvaluar.X != x)
               {

                   Vector2 pos = new Vector2(x, posicionAEvaluar.Y);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                       (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") || 
                       estatusCasilla(pos, listaFichas).tipo.Equals("Torre")) &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                   {

                       return true;

                   }
                   else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false)
                   {
                       break;


                   }

               }
               
           }
           #endregion

           #region Posiciones Verticales

           for (int y = Convert.ToInt32(posicionAEvaluar.Y); y >= 20; y = y - 80)
           {
               // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

               if (estaDentroDelTablero(posicionAEvaluar.X, y) == 1 && posicionAEvaluar.Y != y)
               {

                   Vector2 pos = new Vector2(posicionAEvaluar.X, y);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                       (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") ||
                       estatusCasilla(pos, listaFichas).tipo.Equals("Torre")) &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                   {

                       return true;

                   }
                   else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false)
                   {

                       break;
                   }

               }

           }

           for (int y = Convert.ToInt32(posicionAEvaluar.Y); y <= 580; y = y + 80)
           {
               // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

               if (estaDentroDelTablero(posicionAEvaluar.X, y) == 1 && posicionAEvaluar.Y != y)
               {

                   Vector2 pos = new Vector2(posicionAEvaluar.X, y);
                   // Se verifica si en la posicion hay un ficha de color distinto

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                       (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") ||
                       estatusCasilla(pos, listaFichas).tipo.Equals("Torre") )&&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                   {

                       return true;

                   }
                   else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false)
                   {
                       break;

                   }

               }

           }

           #endregion

           return false;
       }

       /** @brief Determina si el Rey puede ser capturado por un alfil
        * 
        * @param[in]  posicionAEvaluar          Es la posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si puede ser capturado, false de lo contrario
        */
       public bool peligroConDiagonales(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       {
           int x, y;

           x = Convert.ToInt32(posicionAEvaluar.X) + 80;
           y = Convert.ToInt32(posicionAEvaluar.Y) - 80;
           #region Posiciones diagonales superiores derechas

           
           while (x <= 630 && y >= 20)
           {
               if (estaDentroDelTablero(x, y) == 1)
               {
                   Vector2 pos = new Vector2(x, y);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                       (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") ||
                       estatusCasilla(pos, listaFichas).tipo.Equals("Alfil")) &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                   {
                       return true;

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
           x = Convert.ToInt32(posicionAEvaluar.X) - 80;
           y = Convert.ToInt32(posicionAEvaluar.Y) - 80;

           #region Posiciones diagonales superiores izquierdas
           while (x >= 70 && y >= 20)
           {
               if (estaDentroDelTablero(x, y) == 1)
               {
                   Vector2 pos = new Vector2(x, y);

                   if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                       (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") ||
                       estatusCasilla(pos, listaFichas).tipo.Equals("Alfil")) &&
                       estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
                   {

                       return true;

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

           x = Convert.ToInt32(posicionAEvaluar.X) + 80;
           y = Convert.ToInt32(posicionAEvaluar.Y) + 80;

           #region posiciones diagonales inferiores derechas
           while (x <= 630 && y <= 580)
           {
               Vector2 pos = new Vector2(x, y);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                   (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") ||
                   estatusCasilla(pos, listaFichas).tipo.Equals("Alfil")) &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
               {

                   return true;

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
           x = Convert.ToInt32(posicionAEvaluar.X) - 80;
           y = Convert.ToInt32(posicionAEvaluar.Y) + 80;

           #region Posiciones diagonales inferiores izquierdas
           while (x >= 70 && y <= 580)
           {
               Vector2 pos = new Vector2(x, y);

               if ((estatusCasilla(pos, listaFichas).NohayUnaFicha == false) && 
                   (estatusCasilla(pos, listaFichas).tipo.Equals("Reina") ||
                   estatusCasilla(pos, listaFichas).tipo.Equals("Alfil")) &&
                   estatusCasilla(pos, listaFichas).colorDeLaFicha != Color)
               {

                   return true;

               }
               else if (estatusCasilla(pos, listaFichas).NohayUnaFicha == false  )
               {
                   break;

               }


               x -= 80;
               y += 80;

           }
           #endregion


           return false;

       }

       /** @brief Determina si el Rey puede ser capturado por una reina
        * 
        * @param[in]  posicionAEvaluar          Es la posicion que se evaluara
        * @param[in]  listaFichas               Estas son las fichas del tablero
        * 
        * @return       true si puede ser capturado, false de lo contrario
        */
       public bool peligroPorReina(Vector2 posicionAEvaluar, List<Ficha> listaFichas)
       { 
           if( peligroConDiagonales(posicionAEvaluar,listaFichas) == true )
           {
               return true;
           }

           if(peligroConVerticalesYHorizontales(posicionAEvaluar,listaFichas) == true)
           {
               return true;
           
           }

           return false;
       }

    }
}
