using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Ajedrez.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using DragAndDrop;
using Ajedrez.DragAndDropTools;

namespace Ajedrez
{
    public class Tablero
    {

       private Casilla[,] casillas = new Casilla[8,8];
       private Vector2 posicion;

       // Atributo que ayuda a dibujar la segunda capa del tablero
       private Texture2D _whiteSquare;

      

       /**Arreglo de casillas  */
       public Casilla[,] Casillas { get { return casillas; }

       }

       /** Constructores*/
       public Tablero(ContentManager content)
       {
           //Se inicializa la posicion del tablero
           posicion = new Vector2(70, 20);

           //Se le asignan las posiciones a cada casilla
           for (int i = 0; i < casillas.GetLength(0); i++)
           {
               for (int j = 0; j < casillas.GetLength(1); j++)
               {
                   int posicionXPantalla = 70 + (i) * 80;
                   int posicionYPantalla = 20 + (j) * 80;
                   casillas[i, j] = new Casilla() { Posicion = new Vector2(posicionXPantalla, posicionYPantalla) };

               }

           }
           //Se le asignan los colores a las casillas
           setColorCasillas(content);
       
       }
       public Tablero(ContentManager content, SpriteBatch spriteBatch, Game game1)
           : this(content)
       {
           _whiteSquare = content.Load<Texture2D>("Images/white");

           
          //Se colocan las fichas en el tablero
        setFichasTablero(content, spriteBatch);
            
       
       
       }

       /** @brief Indica a cada casilla del tablero cual es su color
        * 
        * @param[in]   content            Es el objeto que interactua con los contenidos como fotos, audios, etc
        *  
        * @return      no retorna nada
        */ 
       protected void setColorCasillas(ContentManager content)
       {
           //Primero se colorean las filas pares
           Colores colorEnUso = Colores.Black;

           for(int j=0; j < casillas.GetLength(0); j++)
           {
               for(int i=0; i < casillas.GetLength(1); i++)
               {
                   if(colorEnUso == Colores.White)
                   {
                        casillas[i, j].Color = colorEnUso;
                        casillas[i, j].Img = content.Load<Texture2D>("Images/white");
                        colorEnUso = Colores.Black;
                   }
                   else
                   {
                       casillas[i, j].Color = colorEnUso;
                        casillas[i, j].Img = content.Load<Texture2D>("Images/black");
                        colorEnUso = Colores.White;
                   }
               }
               //Si se va a cambiar de fila, cambiame el color anterior
               if (colorEnUso == Colores.White)
                   colorEnUso = Colores.Black;
               else
                   colorEnUso = Colores.White;
           }
   

       }

       /** @brief   Coloca todas las fichas en sus respectivos lugares
        * 
        * @param[in]   content            Es el objeto que interactua con los contenidos como fotos, audios, etc
        * @param[in]   spriteBatch        Es el objeto que nos ayuda a dibujar imagenes en la pantalla
        * 
        * @return      no retorna nada
        */
       protected void setFichasTablero(ContentManager content, SpriteBatch spriteBatch)
       {
           Texture2D ImgfichaNegra = content.Load<Texture2D>("Images/ficha1");
           //Texture2D ImgfichaRoja = content.Load<Texture2D>("Images/ficha2");
           // Se colocan las fichas negras en el tablero
           for (int j = 0; j < 3; j++)
           {
               for (int i = 0; i < casillas.GetLength(1); i++)
               {
                   if (casillas[j, i].Color == 0)
                   {
                       var fichaNegra = new Reina(spriteBatch, Colores.Black, casillas[j, i].Posicion,content);

                       casillas[i, j].FichaContenida = fichaNegra;
                   }
               }
           }
                      
       
       }


       /** @brief Permite  Dibujar el tablero 
        *  
        * Se dibujan tres capas del tablero, en la primera capa se dibuja el tablero con las fichas
        * en la segunda capa se dibuja otro tablero mas transparente encima, en el que se dibuja en que casilla
        * esta el mouse parado. La tercera capa colorea de verde la posicion de las casillas que tienen que comer
        * una ficha si hay alguna.
        * 
        * @param[in]  spritebatch             Es el objeto que nos ayuda a dibujar imagenes en la pantalla
        * @param[in]  _currentMousePosition   Es la posicion en la que se encuentra el mouse.
        * @param[in]  _dragAndDropController  Es el objeto que contiene la lista de fichas y controla el dragAndDrop
        * 
        * @return     no retorna nada
        *
        */
       public void draw(SpriteBatch spritebatch, Vector2 _currentMousePosition, GameTime gameTime)
       {
           float opacity;
           Color colorToUse = Color.White;

           // Dimensiones de las casillas 80px x 80px
           const int _tileSize = 80;

           //the square to draw (local variable to avoid creating a new variable per square)
           Rectangle squareToDrawPosition = new Rectangle();  
                     
           
           // Se recorre el arreglo de casillas
           for (int y = 0; y < casillas.GetLength(0); y++)
           {
               for (int x = 0; x < casillas.GetLength(1); x++)
               {
                   //figure out where to draw the square
                   squareToDrawPosition = new Rectangle((int)(x * _tileSize + posicion.X), (int)(y * _tileSize + posicion.Y), _tileSize, _tileSize);

                   Vector2 squarePosition = new Vector2(x * _tileSize + posicion.X, y * _tileSize + posicion.Y);
                   //if we add the x and y value of the tile
                   //and it is even, we make it one third opaque
                   if ((x + y) % 2 == 0)
                   {
                       opacity = .33f;
                   }
                   else
                   {
                       //otherwise it is one tenth opaque
                       opacity = .1f;
                   }
                   //make the square the mouse is over red
                   if (IsMouseOnTile(x, y,_currentMousePosition))
                   {
                       colorToUse = Color.Red;
                       opacity = .5f;
                   }
                   else
                   {
                       colorToUse = Color.White;
                   }

                   
                   Casilla c1 = casillas[x, y];
                   spritebatch.Draw(c1.Img, c1.Posicion,null, Color.WhiteSmoke);
                   //draw the white square at the given position, offset by the x- and y-offset, in the opacity desired
                   spritebatch.Draw(_whiteSquare, squareToDrawPosition, colorToUse * opacity);

               
               }
           }

           
       
       }

        /** @brief     Determina si una coordenada proporcionada se encuentra dentro del tablero
         * 
         * @param[in] x                      Posicion x a evaluar
         * @param[in] y                      Posicion y a evaluar
         * @param[in] _currentMousePosition  Posicion actual del mouse
         * 
         * @return    no retorna nada
         */ 
       protected bool IsMouseOnTile(int x, int y, Vector2 _currentMousePosition)
       {
           const int _tileSize = 80;
           //do an integerdivision (whole-number) of the coordinates relative to the board offset with the tilesize in mind
           return (int)(_currentMousePosition.X - posicion.X) / _tileSize == x && (int)(_currentMousePosition.Y - posicion.Y) / _tileSize == y;
       }

             

    }
}
