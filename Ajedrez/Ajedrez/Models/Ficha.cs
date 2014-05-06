using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ajedrez.Models;
using DragAndDrop;
using System;

namespace Ajedrez.Models
{
   public abstract class Ficha: Item, IDragAndDropItem
    {

           
      private Colores color;
      private bool seMovio = false;
      protected Vector2 posicion;

      public override Vector2 Position { get { return base.Position; } set { base.Position = value; posicion = value; } }  
      /* Atributo para almacenadar la posiciones finales despues de comer una ficha*/
      protected List<Vector2> posiblesMovidasComer = new List<Vector2>();

      /* Atributo para almacenadar las posibles posiciones donde se puede mover la ficha*/
      protected List<Vector2> posiblesMovidas = new List<Vector2>();


      /*Propiedad del atributo color*/
      public Colores Color { get { return this.color; } set { color = value; } }
      public bool SeMovio { get { return this.seMovio; } set { this.seMovio = value; } }
      

      /** @brief Determina si la ficha puede capturar otra ficha
        *         Se insertan las posiciones validas para capturar 
        *         en la lista de posiblesMovidascomer
        *  @param[in]   FichasTablero       Esta es la lista de ficha del tablero
        *  
        *  @return      true si puede capturar, false de lo contrario
        */
      public bool canEat(List<Ficha> FichasTablero)
      {
          bool comer= false;

          if (posiblesMovidasComer.Count > 1)
              comer = true;

          //Se eliminan las posiciones de las fichas que se pueden comer
         // removeJugadasParaComerFicha();
          
          return comer;
      
      }
      

      /** @brief Determina si una posicion indicada, se encuentra dentro de las posiciones validas para comer una ficha 
       * 
       * @param[in]   jugadaAEvaluar              Es la posicion que se va verificar
       * 
       * @return      true si es una jugada para comer, false de lo contrario.
       */     
      public bool esJugadaParaComerFicha(Vector2 jugadaAEvaluar)
      {
          // Se recorre la lista de posibles movidas para comer
          foreach (var jugada in posiblesMovidasComer)
          {
              //Se verifica si se encuentra la jugada a evaluar dentro 
              //de la lista de posibles jugadas para comer
              if (jugadaAEvaluar.Equals(jugada))
              {
                  return true;
              }
              
          }
         return false;
      
      }
      /** @brief Inserta una posicion indicada en la lista de posibles Movidas para comer ficha
      * 
      * @param[in]   posicion              Es la posicion a insertar
      * 
      * @return      no retorna nada
      */ 
      public void addJugadaParaComerFicha(Vector2 posicion)
      {
          posiblesMovidasComer.Add(posicion);
      }

    /** @brief Elimina una posicion indicada en la lista de posibles Movidas para comer ficha
     * 
     * @return      no retorna nada
     */ 
      public void removeJugadasParaComerFicha()
      {
          posiblesMovidasComer.Clear();
      
      }

      /** @brief Determina si la ficha se puede mover a una posicion indicada
      * 
      * @param[in]   posicionInicial             Es la posicion actual de la ficha
      * @param[in]   PosicionFinal               Es la posicion a donde se pretende mover la ficha
      * 
      * @return      1 si se puede mover, 0 de lo contrario.
      */
      public abstract int canMove(Vector2 posicionInicial, Vector2 PosicionFinal, List<Ficha> listaFichas);

      /** @brief Determina si una posicion indicada, se encuentra dentro de las posiciones validas para moverse 
      * 
      * @param[in]   jugadaAEvaluar              Es la posicion que se va verificar
      * 
      * @return      true si es una jugada para mover, false de lo contrario.
      */
      public bool esJugadaMovimiento(Vector2 jugadaAEvaluar)
      {
          // Se recorre la lista de posibles movidas para comer
          foreach (var jugada in posiblesMovidas)
          {
              //Se verifica si se encuentra la jugada a evaluar dentro 
              //de la lista de posibles jugadas para comer
              if (jugadaAEvaluar.Equals(jugada))
              {
                  return true;
              }

          }
          return false;

      }
      /** @brief Inserta una posicion indicada en la lista de posibles Movidas 
      * 
      * @param[in]   posicion              Es la posicion a insertar
      * 
      * @return      no retorna nada
      */
      public void addJugadaMovimiento(Vector2 posicion)
      {
          posiblesMovidas.Add(posicion);
      }

      /** @brief Elimina una posicion indicada en la lista de posibles Movidas
       * 
       * @return      no retorna nada
       */
      public void removeJugadasMovimiento()
      {
          posiblesMovidas.Clear();

      }

      /** @brief Determina si en una posicion especificada se encuentra una ficha
           * 
           * @param[in]  posicionCasilla        Esta es la posicion que se va a evaluar
           * @param[in]  listaFichas            Esta es la lista de fichas que estan en el tablero
           * 
           * @return     true si no hay una casilla, false de lo contrario 
           * 
           */
      public estatusCasillas estatusCasilla(Vector2 posicionCasilla, List<Ficha> listaFichas)
      {
          estatusCasillas estatusCasillaEvaluada;
          //Verifica Si hay un ficha que tenga la misma posicion a donde me quiero mover

          foreach (var casillaEvaluada in listaFichas)
          {
              // Si hay una ficha en la posicion que estamos evaluando
              if (posicionCasilla.X == casillaEvaluada.Position.X && posicionCasilla.Y == casillaEvaluada.Position.Y)
              {

                  estatusCasillaEvaluada.NohayUnaFicha = false;
                  estatusCasillaEvaluada.colorDeLaFicha = casillaEvaluada.Color;
                  estatusCasillaEvaluada.tipo = casillaEvaluada.GetType().Name;


                  return estatusCasillaEvaluada;
              }

          }
          estatusCasillaEvaluada.NohayUnaFicha = true;
          estatusCasillaEvaluada.colorDeLaFicha = Colores.White;
          estatusCasillaEvaluada.tipo = "";

          return estatusCasillaEvaluada;
      }

    /**
    * @brief Determina si la posicion esta en los limites permitidos
    *
    * @param[in]    posX        	 Es la posicion x a evaluar
    * @param[in]    posY             Es la posicion y a evaluar
    *
    * @return		1 si esta en los limites, 0 si no lo esta.
    */
    public int estaDentroDelTablero(double posX, double posY)
    {

        return (((posX >= 70) && (posX <= 650)) && ((posY >= 20) && (posY <= 580)) ? 1 : 0);
    }
       

    }
}
