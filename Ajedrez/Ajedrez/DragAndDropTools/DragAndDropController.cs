using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Ajedrez.Models;
using DragAndDrop;

namespace Ajedrez.DragAndDropTools
{
    /// <summary>
    /// Controllerclass for easy drag and drop in XNA
    /// </summary>
    /// <typeparam name="T">The type of items to interact with using the mouse. Must implement IDragAndDropItem</typeparam>
    public class DragAndDropController<T> : DrawableGameComponent  where T : IDragAndDropItem
    {

        #region Variables and properties

        private KeyboardState _keyboard;
        private MouseState _oldMouse, _currentMouse;
        private SpriteBatch _spriteBatch;
        private Vector2 _mouseDown;
        private  List<Ficha> _selectedItems;
        private  List<Ficha> _items;
        private bool _isDraggingRectangle;
        
        public Ficha ItemUnderTheMouseCursor { get; private set; }
        public bool IsThereAnItemUnderTheMouseCursor { get; private set; }

        public IEnumerable<Ficha> Items { get { foreach (var item in _items) { yield return item; } } }
        public IEnumerable<Ficha> SelectedItems { get { foreach (var item in _selectedItems) { yield return item; } } }

        public int Count { get { return _items.Count; } }
        public int SelectedCount { get { return _selectedItems.Count; } }

        private Texture2D _selectionTexture;
        private Tablero _copiaTablero;
        

        private bool MouseWasJustPressed
        {
            get
            {
                return _currentMouse.LeftButton == ButtonState.Pressed && _oldMouse.LeftButton == ButtonState.Released;
            }
        }

        private bool IsGroupAction
        {
            get
            {
                return _keyboard.IsKeyDown(Keys.LeftControl) || _keyboard.IsKeyDown(Keys.RightControl);
            }
        }

        private Vector2 CurrentMousePosition
        {
            get { return new Vector2(_currentMouse.X, _currentMouse.Y); }
        }

        public Vector2 OldMousePosition
        {
            get { return new Vector2(_oldMouse.X, _oldMouse.Y); }
        }

        public Vector2 MouseMovementSinceLastUpdate
        {
            get { return CurrentMousePosition - OldMousePosition; }
        }

        public Ficha ItemUnderMouseCursor()
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                if (_items[i].Contains(CurrentMousePosition))
                {
                    return _items[i];
                }
            }
            return default(Ficha);
        }

        #endregion

        #region Constructor, Draw() and Update()

        public DragAndDropController(Game game, SpriteBatch spriteBatch) : base(game)
        {
            _selectedItems = new List<Ficha>();
            _items = new List<Ficha>();
            _spriteBatch = spriteBatch;
            _selectionTexture = Game.Content.Load<Texture2D>(@"Images/white");
            _copiaTablero = new Tablero(Game.Content);
            
            
            
        }

        public override void Update(GameTime gameTime)
        {
            GetCurrentMouseState();
            GetCurrentKeyboardState();
            HandleMouseInput();
            HandleKeyboardInput();
            SaveCurrentMouseState();
        }

        public override void Draw(GameTime gameTime)
        {
            if (_isDraggingRectangle)
            {
                Rectangle selectionRectangle = GetSelectionRectangle();
                _spriteBatch.Begin();
                _spriteBatch.Draw(_selectionTexture, selectionRectangle, Color.White * .4f);
                _spriteBatch.End();
            }
        }

        #endregion

        #region implementacion propia de metodos

        /** @brief Determina si en una posicion especificada se encuentra una ficha
         * 
         * @param[in]  posicion         Esta es la posicion que se va a evaluar
         * 
         * @return     true si no hay una casilla, false de lo contrario 
         * 
         */
        public estatusCasillas estatusCasilla(Vector2 posicion)
        {
            estatusCasillas estatusCasillaEvaluada;
            //Verifica Si hay un ficha que tenga la misma posicion a donde me quiero mover
            
            foreach (var casillaEvaluada in _items) 
            {
                // Si hay una ficha en la posicion que estamos evaluando
                if (posicion.X == casillaEvaluada.Position.X && posicion.Y == casillaEvaluada.Position.Y)
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

        /** @brief Convierte en Reina la ficha que llega a la primera fila del oponente
         * 
         * @return      no retorna nada
         */
        public void coronarAReina()
        {
                           

        }

        /** @brief   Determina la cantidad de fichas rojas que hay en el tablero
         * 
         * @return      El numero de fichas rojas
         */
       public int cantFichasRojas()
        {
            int contadorFichas=0;
            foreach(var item in _items)
            {
                if(item.Color == Colores.Red)
                    contadorFichas++;           
            }

            return contadorFichas;
        
        }

       /** @brief   Determina la cantidad de fichas negras que hay en el tablero
        * 
        * @return      El numero de fichas negras
        */
       public int cantFichasNegras()
       {
           int contadorFichas = 0;
           foreach (var item in _items)
           {
               if (item.Color == Colores.Black)
                   contadorFichas++;
           }

           return contadorFichas;

       }

       
        /** @brief  Determina si un jugador debe comer otra ficha
         * 
         * @param[in]  colorJugador        color del jugador
         * 
         * @return                  true si debe que comer, false de lo contrario
         * 
         */
    /*    public bool jugadorDebeComer(Colores colorJugador)
        {
            //Recorro las fichas que se encuentran en el tablero
            foreach(Ficha fichaAEvaluar in _items)
            {
                //Verifico si es del color del jugador indicado
                if (fichaAEvaluar.Color.Equals(colorJugador) && fichaPuedeComer(fichaAEvaluar) == true)
                {
                    return true;
                
                }

            }
            return false;
        
        }*/

        /** @brief Se elimina una ficha en una posicion indicada
         * 
         * @param[in] posFichaACapturar            Esta es la posicion de la ficha a capturar
         * 
         * @return    no retorna nada
         * 
         */
        public void capturarFicha (Vector2 posFichaACapturar)
        {
            

            //Se recorre la lista de fichas del tablero 
          
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                for (int x = 70; x <= 630; x = x + 80)
                {
                    Ficha item = _items.ElementAt(i);
                   
                    if (item.Position.Equals(posFichaACapturar) )
                    {
                        Remove(item);
                        return;
                                             
                    }

                }

            }
        }

        #endregion
     
               

        #region public interaction methods

        public void Add(Ficha item) { _items.Add(item); }
        public void Remove(Ficha item) { _items.Remove(item); _selectedItems.Remove(item); }

        public void DeselectAll()
        {
            for (int i = _selectedItems.Count - 1; i >= 0; i--)
            {
                DeselectItem(_selectedItems[i]);
            }
        }

        public void SelectAll()
        {
            _items.ForEach(SelectItem);
        }

        public void Clear()
        {
            _selectedItems.Clear();
            _items.Clear();
        }

        public void RemoveSelected()
        {
            for (int i = _selectedItems.Count - 1; i >= 0; i--)
            {
                _items.Remove(_selectedItems[i]);
                _selectedItems.Remove(_selectedItems[i]);
            }
        }

        #endregion

        #region Private helpermethods

        private Rectangle GetSelectionRectangle()
        {
            int left = (int)MathHelper.Min(_mouseDown.X, CurrentMousePosition.X);
            int right = (int)MathHelper.Max(_mouseDown.X, CurrentMousePosition.X);
            int top = (int)MathHelper.Min(_mouseDown.Y, CurrentMousePosition.Y);
            int bottom = (int)MathHelper.Max(_mouseDown.Y, CurrentMousePosition.Y);

            return new Rectangle(left, top, right - left, bottom - top);
        }

        private void HandleKeyboardInput()
        {
            if (_keyboard.IsKeyDown(Keys.A) && (_keyboard.IsKeyDown(Keys.LeftControl) || _keyboard.IsKeyDown(Keys.RightControl)))
            {
                SelectAll();
            }
            if (_keyboard.IsKeyDown(Keys.Delete) && _selectedItems.Count > 0)
            {
                RemoveSelected();
            }
        }

        private void GetCurrentMouseState() { _currentMouse = Mouse.GetState(); }
        private void GetCurrentKeyboardState() { _keyboard = Keyboard.GetState(); }

        private void HandleMouseInput()
        {
            SetAllItemsToIsMouseOverFalse();
            ItemUnderTheMouseCursor = ItemUnderMouseCursor();
            if (!Equals(ItemUnderTheMouseCursor, default(T)))
            {
                UpdateItemUnderMouse();
            }
            else
            {
                if (MouseWasJustPressed) 
                {
                    DeselectAll();
                    _mouseDown = CurrentMousePosition;
                    // Se quito la opcion de que se dibuje un rectangulo de seleccion
                   // _isDraggingRectangle = true; 
                }
            }

            if (_currentMouse.LeftButton == ButtonState.Released)
            {
                _isDraggingRectangle = false;
            }
            else
            {
                if (_isDraggingRectangle)
                {
                    Rectangle selectionRectangle = GetSelectionRectangle();
                    DeselectAll();
                    _items.Where(item => selectionRectangle.Contains(item.Border)).ToList().ForEach(SelectItem);
                }
                else
                {   //Se quito la opcion de poder arrastrar las fichas
                    //MoveSelectedItemsIfMouseButtonIsPressed();
                }
            }
        }

        private void SetAllItemsToIsMouseOverFalse()
        {
            _items.ForEach(item => item.IsMouseOver = false);
        }

        private void MoveSelectedItemsIfMouseButtonIsPressed()
        {
            if (_currentMouse.LeftButton == ButtonState.Pressed)
            {
                _selectedItems.ForEach(item => item.Position += MouseMovementSinceLastUpdate);
            }
        }

        private void UpdateItemUnderMouse()
        {
            ItemUnderTheMouseCursor.IsMouseOver = true;

            if (MouseWasJustPressed)
            {
                IfItemUnderMouseIsNotInSelectedGroupThenDeselectAll();
                SelectItem(ItemUnderTheMouseCursor);
            }
        }

        private void IfItemUnderMouseIsNotInSelectedGroupThenDeselectAll()
        {
            if (!IsGroupAction && !_selectedItems.Contains(ItemUnderTheMouseCursor))
            {
                DeselectAll();
            }
        }

        private void SaveCurrentMouseState() { _oldMouse = _currentMouse; }

        private void SelectItem(Ficha itemToSelect)
        {
            
           
                //Se verifica si es el turno del jugador rojo para jugar
                    
                    itemToSelect.IsSelected = true;

                    Vector2 posDestino = CurrentMousePosition;

                    // Se crea un tablero para saber la posicion de la casilla en la que se dio click
                    Tablero t1 = new Tablero(Game.Content, _spriteBatch, Game);
                    Vector2 posFichaSeleccionada = itemToSelect.Position;

                    for (int y = 0; y < t1.Casillas.GetLength(0); y++)
                    {
                        for (int x = 0; x < t1.Casillas.GetLength(1); x++)
                        {
                            Casilla casillaEvaluada = t1.Casillas[x, y];

                            /*  Si el puntero esta dentro de una casilla, ponle la posicion de esa casilla
                             *  al objeto seleccionado.  */
                            if ((posDestino.X > casillaEvaluada.Posicion.X && posDestino.X <= casillaEvaluada.Posicion.X + 80) && (posDestino.Y > casillaEvaluada.Posicion.Y && posDestino.Y <= casillaEvaluada.Posicion.Y + 80))
                            {
                                // Se insertan las posibles posiciones para mover y capturar fichas.
                                itemToSelect.canMove(posFichaSeleccionada, casillaEvaluada.Posicion, _items);
                                

                            }
                        }

                    }
                    _selectedItems.Add(itemToSelect);


                    
                          
                
          

            
        }

        private void DeselectItem(Ficha itemToDeselect)
        {
            itemToDeselect.IsSelected = false;
            bool canNotMove = true;                      

            Ficha fichaSeleccionada = ((Ficha)itemToDeselect);

            Vector2 posFichaSeleccionada = itemToDeselect.Position;
            
            Vector2 posDestino = CurrentMousePosition;
           
            // Se crea un tablero para saber la posicion de la casilla en la que se dio click
            Tablero t1 = new Tablero(Game.Content, _spriteBatch, Game);

            for (int y = 0; y < t1.Casillas.GetLength(0); y++)
            {
                for (int x = 0; x < t1.Casillas.GetLength(1); x++)
                {
                    Casilla casillaEvaluada = t1.Casillas[x, y];

                    /*  Si el puntero esta dentro de una casilla, ponle la posicion de esa casilla
                     *  al objeto seleccionado.  */
                    if ((posDestino.X > casillaEvaluada.Posicion.X && posDestino.X <= casillaEvaluada.Posicion.X + 80) && (posDestino.Y > casillaEvaluada.Posicion.Y && posDestino.Y <= casillaEvaluada.Posicion.Y + 80))
                    {
                        if (fichaSeleccionada.canMove(posFichaSeleccionada, casillaEvaluada.Posicion, _items) ==1 && estatusCasilla(casillaEvaluada.Posicion).NohayUnaFicha)
                        {
                            itemToDeselect.Position = casillaEvaluada.Posicion;
                            if (itemToDeselect.SeMovio == false) { itemToDeselect.SeMovio = true; }

                            canNotMove = false;
                        }
                        else if (fichaSeleccionada.canEat(_items) && fichaSeleccionada.esJugadaParaComerFicha(casillaEvaluada.Posicion))
                        {
                            capturarFicha(casillaEvaluada.Posicion);
                            itemToDeselect.Position = casillaEvaluada.Posicion;

                            if (itemToDeselect.SeMovio == false) { itemToDeselect.SeMovio = true; }
                            canNotMove = false;
                            fichaSeleccionada.removeJugadasParaComerFicha();
 
                        
                        }

                                                         
                    }
                }
            
            }
               if(canNotMove)
                 itemToDeselect.Position = posFichaSeleccionada;
            
            _selectedItems.Remove(itemToDeselect);

            if (itemToDeselect is Rey)
            {
                if (((Rey)itemToDeselect).inJaque(itemToDeselect.Position, _items))
                {
                    
                    this.Game.Exit();

                }

            }
            
        } 
        #endregion

    }
}