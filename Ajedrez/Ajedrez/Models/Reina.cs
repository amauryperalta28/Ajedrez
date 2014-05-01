﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ajedrez.Models
{
   public class Reina: Ficha
    {
       public Reina(SpriteBatch spriteBatch, Colores colorFicha, Vector2 position, ContentManager Content)
        {
            posicion = position;            
            base._spriteBatch = spriteBatch;

            if (colorFicha.Equals(Colores.Black))
            {
                base.Color = Colores.Black;
                base.Texture = Content.Load<Texture2D>(@"Images/ficha1");// TorreB
            
            }
            else if (colorFicha.Equals(Colores.White))
            {
                base.Color = Colores.White;
                base.Texture = Content.Load<Texture2D>(@"Images/fondo");//TorreW

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
        public override int canMove(Vector2 posicionInicial, Vector2 PosicionFinal)
        {
            //Variables en la que se insertan las posiciones validas para moverse
            List<Vector2> posicionesValidas1 = new List<Vector2>();
            int x, y;

            x = Convert.ToInt32(posicionInicial.X) + 80;
            y = Convert.ToInt32(posicionInicial.Y) - 80;

            // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero
            #region insercion de movimientos diagonales
            // Se insertan las posiciones diagonales superiores derechas validas
            while (x <= 630 && y >= 20)
            {
                if (estaDentroDelTablero(x, y) == 1)
                {
                    Vector2 pos = new Vector2(x, y);
                    posicionesValidas1.Add(pos);

                }

                x += 80;
                y -= 80;

            }

            // Se insertan las posiciones diagonales superiores izquierdas validas
            x = Convert.ToInt32(posicionInicial.X) - 80;
            y = Convert.ToInt32(posicionInicial.Y) - 80;

            while (x >= 70 && y >= 20)
            {
                if (estaDentroDelTablero(x, y) == 1)
                {
                    Vector2 pos = new Vector2(x, y);
                    posicionesValidas1.Add(pos);

                }

                x -= 80;
                y -= 80;

            }


            x = Convert.ToInt32(posicionInicial.X) + 80;
            y = Convert.ToInt32(posicionInicial.Y) + 80;

            while (x <= 630 && y <= 580)
            {
                if (estaDentroDelTablero(x, y) == 1)
                {
                    Vector2 pos = new Vector2(x, y);
                    posicionesValidas1.Add(pos);

                }

                x += 80;
                y += 80;

            }

            // Se insertan las posiciones diagonales inferiores izquierdas validas
            x = Convert.ToInt32(posicionInicial.X) - 80;
            y = Convert.ToInt32(posicionInicial.Y) + 80;

            while (x >= 70 && y <= 580)
            {
                if (estaDentroDelTablero(x, y) == 1)
                {
                    Vector2 pos = new Vector2(x, y);
                    posicionesValidas1.Add(pos);

                }

                x -= 80;
                y += 80;

            }

            #endregion

            #region insercion de movimientos horizontales y verticales
            // Se insertan todas las posiciones horizontales en las que se puede jugar
            for (int i = 70; i <= 630; i = i + 80)
            {
                // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

                if (estaDentroDelTablero(i, posicionInicial.Y) == 1 && posicionInicial.X != i)
                {
                    //posicionesValidas[IndexValidmove].X = x;
                    //posicionesValidas[IndexValidmove].Y = posicionInicial.Y;

                    Vector2 pos = new Vector2(i, posicionInicial.Y);
                    posicionesValidas1.Add(pos);


                }

            }
            // Se insertan todas las posiciones verticales en las que se puede jugar

            for (int j = 20; j <= 580; j = j + 80)
            {
                // Se inserta en un arreglo las posiciones correctas que esten dentro del tablero

                if (estaDentroDelTablero(posicionInicial.X, j) == 1 && posicionInicial.Y != j)
                {
                    // posicionesValidas[IndexValidmove].X = posicionInicial.X;
                    //posicionesValidas[IndexValidmove].Y = y;

                    Vector2 pos = new Vector2(posicionInicial.X, j);
                    posicionesValidas1.Add(pos);



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

    }
}
